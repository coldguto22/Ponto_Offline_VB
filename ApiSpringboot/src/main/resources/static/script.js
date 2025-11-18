(() => {
  const $ = (sel) => document.querySelector(sel);
  const $$ = (sel) => Array.from(document.querySelectorAll(sel));
  const api = {
    empresas: '/api/empresas',
    funcionarios: '/api/funcionarios',
    registros: '/api/registros'
  };

  let currentUser = null; // { id, nome, isAdmin }
  let adminCharts = {
    chartAvg: null,
    chartDelays: null,
    chartCompliance: null
  };

  function fmtDate(d){
    const y = d.getFullYear();
    const m = String(d.getMonth()+1).padStart(2,'0');
    const day = String(d.getDate()).padStart(2,'0');
    return `${y}-${m}-${day}`;
  }
  function fmtTime(d){
    const hh = String(d.getHours()).padStart(2,'0');
    const mm = String(d.getMinutes()).padStart(2,'0');
    const ss = String(d.getSeconds()).padStart(2,'0');
    return `${hh}:${mm}:${ss}`;
  }
  function setMessage(el, msg, isError=false){
    el.textContent = msg;
    el.classList.toggle('error', !!isError);
  }
  function showTab(name){
    $$('.tab').forEach(btn => btn.classList.toggle('active', btn.dataset.tab === name));
    $$('.tab-content').forEach(sec => sec.classList.toggle('hidden', sec.id !== name));
    if(name === 'espelho') refreshEspelho();
    if(name === 'admin' && currentUser?.isAdmin) refreshAdmin();
  }

  function tickClock(){
    const now = new Date();
    const hh = String(now.getHours()).padStart(2,'0');
    const mm = String(now.getMinutes()).padStart(2,'0');
    const ss = String(now.getSeconds()).padStart(2,'0');
    $('#clock').textContent = `${hh}:${mm}:${ss}`;
  }

  async function jsonFetch(url, options={}){
    const res = await fetch(url, { headers: { 'Content-Type': 'application/json' }, ...options });
    if(!res.ok){
      const text = await res.text().catch(()=> '');
      throw new Error(`HTTP ${res.status} ${res.statusText} - ${text}`);
    }
    const ct = res.headers.get('content-type') || '';
    if(ct.includes('application/json')) return res.json();
    return res.text();
  }

  async function handleLogin(evt){
    evt.preventDefault();
    const cpfInput = $('#cpf').value.trim();
    const cpf = cpfInput.replace(/\D/g, ''); // Remove formatação
    const loginMsg = $('#loginMsg');

    try{
      const response = await fetch(`${api.funcionarios}/login`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ cpf: cpf })
      });

      if(response.ok){
        const funcionario = await response.json();
        currentUser = { 
          id: funcionario.id, 
          cpf: funcionario.cpf,
          nome: funcionario.nome, 
          isAdmin: funcionario.admin === 1 
        };
        afterLogin();
        setMessage(loginMsg, '');
      }else{
        setMessage(loginMsg, 'CPF não encontrado', true);
      }
    }catch(err){
      console.error(err);
      setMessage(loginMsg, `Erro ao conectar: ${err.message}`, true);
    }
  }

  function afterLogin(){
    $('#loginView').classList.add('hidden');
    $('#appView').classList.remove('hidden');
    $('#welcomeTitle').textContent = `Olá, ${currentUser.nome}`;
    $('#tabAdmin').classList.toggle('hidden', !currentUser.isAdmin);
    $('.avatar').textContent = currentUser.isAdmin ? 'A' : (currentUser.nome?.[0]||'U').toUpperCase();
    showTab('registro');
  }

  async function handleRegistrar(evt){
    evt.preventDefault();
    const tipo = $('#tipo').value;
    const msgEl = $('#mensagem');
    if(!tipo){ setMessage(msgEl, 'Selecione um tipo.', true); return; }
    if(!currentUser){ setMessage(msgEl, 'Faça login primeiro.', true); return; }

    const now = new Date();
    const payload = {
      data: fmtDate(now),
      hora: fmtTime(now),
      tipo,
      latitude: null,
      longitude: null,
      funcionarioId: currentUser.id
    };

    // Tenta pegar geolocalização (opcional)
    const getGeo = () => new Promise(resolve => {
      if(!navigator.geolocation) return resolve();
      navigator.geolocation.getCurrentPosition(
        (pos) => { payload.latitude = pos.coords.latitude; payload.longitude = pos.coords.longitude; resolve(); },
        () => resolve(),
        { enableHighAccuracy: false, timeout: 3000, maximumAge: 60000 }
      );
    });

    try{
      await getGeo();
      const saved = await jsonFetch(api.registros, { method: 'POST', body: JSON.stringify(payload) });
      setMessage(msgEl, `Ponto registrado com sucesso! #${saved.id}`);
      $('#pontoForm').reset();
      refreshEspelho();
    }catch(err){
      console.error(err);
      setMessage(msgEl, `Erro ao registrar ponto: ${err.message}`, true);
    }
  }

  function registrosToTable(items){
    if(!items.length) return '<div class="mensagem">Nenhum registro encontrado.</div>';
    const rows = items.map(r => `<tr><td>${r.id}</td><td>${r.data||''}</td><td>${r.hora||''}</td><td>${r.tipo||''}</td><td>${r.latitude??''}</td><td>${r.longitude??''}</td></tr>`).join('');
    return `<table><thead><tr><th>ID</th><th>Data</th><th>Hora</th><th>Tipo</th><th>Lat</th><th>Long</th></tr></thead><tbody>${rows}</tbody></table>`;
  }

  function downloadCSV(filename, rows){
    const header = ['id','data','hora','tipo','latitude','longitude'];
    const lines = [header.join(',')].concat(rows.map(r => [r.id,r.data,r.hora,r.tipo,r.latitude,r.longitude].join(',')));
    const blob = new Blob([lines.join('\n')], { type: 'text/csv;charset=utf-8;' });
    const url = URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url; a.download = filename; a.click();
    URL.revokeObjectURL(url);
  }

  async function refreshEspelho(){
    const listEl = $('#listaRegistros');
    try{
      const all = await jsonFetch(api.registros);
      const items = currentUser?.isAdmin ? all : all.filter(x => x.funcionarioId === currentUser?.id);
      listEl.innerHTML = registrosToTable(items);
      $('#btnExportar').onclick = () => downloadCSV('espelho.csv', items);
    }catch(err){
      console.error(err);
      listEl.innerHTML = `<div class="mensagem error">Erro ao carregar espelho: ${err.message}</div>`;
    }
  }

  async function refreshAdmin(){
    const box = $('#adminSummary');
    try{
      const registros = await jsonFetch(api.registros);
      const funcionarios = await jsonFetch(api.funcionarios);
      const total = registros.length;
      const byFunc = new Map();
      registros.forEach(r => byFunc.set(r.funcionarioId, (byFunc.get(r.funcionarioId)||0)+1));
      const avgPorFunc = total && byFunc.size ? (total/byFunc.size) : 0;
      const entradas = registros.filter(r => (r.tipo||'').toUpperCase().includes('ENTRADA'));
      const atrasos = entradas.filter(r => (r.hora||'') > '09:05:00').length;
      const compliance = entradas.length ? Math.round(100*(1 - (atrasos/entradas.length))) : 100;

      box.innerHTML = `
        <div class="card">Total registros: <b>${total}</b></div>
        <div class="card">Funcionários: <b>${funcionarios.length}</b></div>
        <div class="card">Média por funcionário: <b>${avgPorFunc.toFixed(1)}</b></div>
        <div class="card">Compliance entr.: <b>${compliance}%</b></div>
      `;

      // Gráficos simples
      const ctx1 = document.getElementById('chartAvg');
      const ctx2 = document.getElementById('chartDelays');
      const ctx3 = document.getElementById('chartCompliance');

      const porDia = registros.reduce((acc,r)=>{ if(r.data){ acc[r.data]=(acc[r.data]||0)+1 } return acc; },{});
      const labels1 = Object.keys(porDia).sort();
      const data1 = labels1.map(k => porDia[k]);

      const porFunc = Array.from(byFunc.entries());
      const labels2 = porFunc.map(([id]) => `F${id}`);
      const data2 = porFunc.map(([,q]) => q);

      const compVal = compliance;

      const palette = ['#2a6df0','#7c3aed','#10b981','#f59e0b','#ef4444'];
      
      // Destroy existing charts before creating new ones
      if (adminCharts.chartAvg) adminCharts.chartAvg.destroy();
      if (adminCharts.chartDelays) adminCharts.chartDelays.destroy();
      if (adminCharts.chartCompliance) adminCharts.chartCompliance.destroy();
      
      // Create and store new chart instances
      adminCharts.chartAvg = new Chart(ctx1,{type:'line',data:{labels:labels1,datasets:[{label:'Registros/Dia',data:data1,borderColor:palette[0]}]},options:{plugins:{legend:{display:false}}}});
      adminCharts.chartDelays = new Chart(ctx2,{type:'bar',data:{labels:labels2,datasets:[{label:'Registros/Func',data:data2,backgroundColor:palette[1]}]},options:{plugins:{legend:{display:false}}}});
      adminCharts.chartCompliance = new Chart(ctx3,{type:'doughnut',data:{labels:['OK','Atrasos'],datasets:[{data:[compVal,100-compVal],backgroundColor:[palette[2],palette[4]]}]},options:{plugins:{legend:{display:false}}}});

    }catch(err){
      console.error(err);
      box.innerHTML = `<div class="mensagem error">Erro ao carregar dashboard: ${err.message}</div>`;
    }
  }

  function init(){
    setInterval(tickClock, 1000); tickClock();
    $('#loginForm').addEventListener('submit', handleLogin);
    $('#pontoForm').addEventListener('submit', handleRegistrar);
    $('#btnAtualizar').addEventListener('click', refreshEspelho);

    $$('.tab').forEach(btn => btn.addEventListener('click', () => showTab(btn.dataset.tab)));
    $('#logoutBtn').addEventListener('click', () => location.reload());
    
    // Máscara de CPF
    const cpfInput = $('#cpf');
    if(cpfInput){
      cpfInput.addEventListener('input', function(e){
        let value = e.target.value.replace(/\D/g, '');
        if(value.length > 11) value = value.slice(0, 11);
        
        if(value.length > 9){
          value = value.replace(/(\d{3})(\d{3})(\d{3})(\d{1,2})/, '$1.$2.$3-$4');
        }else if(value.length > 6){
          value = value.replace(/(\d{3})(\d{3})(\d{1,3})/, '$1.$2.$3');
        }else if(value.length > 3){
          value = value.replace(/(\d{3})(\d{1,3})/, '$1.$2');
        }
        
        e.target.value = value;
      });
    }
  }

  document.addEventListener('DOMContentLoaded', init);
})();
