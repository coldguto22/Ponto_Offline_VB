// Configuração
const API_BASE = 'http://localhost:8080/api';

// Estado da aplicação
let currentUser = null;
let registros = [];
let allRegistros = [];
let charts = {};

// Elementos DOM
const elements = {
    loginView: document.getElementById('loginView'),
    appView: document.getElementById('appView'),
    loginForm: document.getElementById('loginForm'),
    pontoForm: document.getElementById('pontoForm'),
    logoutBtn: document.getElementById('logoutBtn'),
    tabs: document.querySelectorAll('.tab'),
    tabContents: document.querySelectorAll('.tab-content'),
    clock: document.getElementById('clock'),
    welcomeTitle: document.getElementById('welcomeTitle'),
    loginMsg: document.getElementById('loginMsg'),
    mensagem: document.getElementById('mensagem'),
    listaRegistros: document.getElementById('listaRegistros'),
    tabAdmin: document.getElementById('tabAdmin'),
    btnAtualizar: document.getElementById('btnAtualizar'),
    btnExportar: document.getElementById('btnExportar'),
    btnLimpar: document.getElementById('btnLimpar'),
    btnExportAll: document.getElementById('btnExportAll'),
    btnClearAll: document.getElementById('btnClearAll'),
    adminSummary: document.getElementById('adminSummary'),
    adminTable: document.getElementById('adminTable')
};

// Inicialização
document.addEventListener('DOMContentLoaded', function() {
    initClock();
    setupEventListeners();
    checkAuth();
    initSampleData();
});

// Dados de exemplo mais realistas
function initSampleData() {
    registros = [
        {
            id: 1,
            matricula: 'USER001',
            tipoRegistro: 'ENTRADA',
            dataHora: new Date('2024-01-15T08:00:00').toISOString(),
            usuario: 'user'
        },
        {
            id: 2,
            matricula: 'USER001', 
            tipoRegistro: 'SAIDA',
            dataHora: new Date('2024-01-15T12:00:00').toISOString(),
            usuario: 'user'
        },
        {
            id: 3,
            matricula: 'USER001',
            tipoRegistro: 'ENTRADA',
            dataHora: new Date('2024-01-15T13:00:00').toISOString(),
            usuario: 'user'
        },
        {
            id: 4,
            matricula: 'USER001',
            tipoRegistro: 'SAIDA',
            dataHora: new Date('2024-01-15T17:30:00').toISOString(),
            usuario: 'user'
        }
    ];

    allRegistros = [
        ...registros,
        {
            id: 5,
            matricula: 'ADMIN',
            tipoRegistro: 'ENTRADA',
            dataHora: new Date('2024-01-15T07:30:00').toISOString(),
            usuario: 'admin'
        },
        {
            id: 6,
            matricula: 'USER002',
            tipoRegistro: 'ENTRADA',
            dataHora: new Date('2024-01-15T08:15:00').toISOString(),
            usuario: 'joao'
        },
        {
            id: 7,
            matricula: 'USER002',
            tipoRegistro: 'SAIDA',
            dataHora: new Date('2024-01-15T12:00:00').toISOString(),
            usuario: 'joao'
        },
        {
            id: 8,
            matricula: 'USER003',
            tipoRegistro: 'ENTRADA',
            dataHora: new Date('2024-01-15T09:00:00').toISOString(),
            usuario: 'maria'
        }
    ];
}

// Relógio em tempo real
function initClock() {
    function updateClock() {
        const now = new Date();
        elements.clock.textContent = now.toLocaleTimeString('pt-BR');
    }
    updateClock();
    setInterval(updateClock, 1000);
}

// Event Listeners
function setupEventListeners() {
    // Login
    elements.loginForm.addEventListener('submit', handleLogin);
    
    // Logout
    elements.logoutBtn.addEventListener('click', handleLogout);
    
    // Registrar ponto
    elements.pontoForm.addEventListener('submit', handleRegistroPonto);
    
    // Tabs
    elements.tabs.forEach(tab => {
        tab.addEventListener('click', () => switchTab(tab.dataset.tab));
    });
    
    // Espelho actions
    elements.btnAtualizar.addEventListener('click', carregarRegistros);
    elements.btnExportar.addEventListener('click', exportarCSV);
    elements.btnLimpar.addEventListener('click', limparRegistros);
    
    // Admin actions
    elements.btnExportAll.addEventListener('click', exportarTodosCSV);
    elements.btnClearAll.addEventListener('click', limparTodosRegistros);
}

// Autenticação
async function handleLogin(e) {
    e.preventDefault();
    
    const cpfInput = document.getElementById('cpf').value;
    const cpf = cpfInput.replace(/[.\-]/g, ''); // Remove formatação
    
    try {
        const response = await fetch(`${API_BASE}/funcionarios/login`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ cpf: cpf })
        });
        
        if (response.ok) {
            const funcionario = await response.json();
            
            currentUser = {
                id: funcionario.id,
                cpf: funcionario.cpf,
                nome: funcionario.nome,
                isAdmin: funcionario.admin === 1
            };
            
            showApp();
            elements.loginMsg.textContent = '';
            elements.loginMsg.className = 'mensagem';
            
            // Carregar registros do usuário
            carregarRegistros();
        } else {
            elements.loginMsg.textContent = 'CPF não encontrado';
            elements.loginMsg.className = 'mensagem erro';
        }
    } catch (error) {
        console.error('Erro ao fazer login:', error);
        elements.loginMsg.textContent = 'Erro ao conectar com o servidor';
        elements.loginMsg.className = 'mensagem erro';
    }
}

function handleLogout() {
    currentUser = null;
    showLogin();
    elements.loginForm.reset();
}

function checkAuth() {
    if (!currentUser) {
        showLogin();
    } else {
        showApp();
    }
}

function showLogin() {
    elements.loginView.classList.remove('hidden');
    elements.appView.classList.add('hidden');
}

function showApp() {
    elements.loginView.classList.add('hidden');
    elements.appView.classList.remove('hidden');
    
    elements.welcomeTitle.textContent = `Olá, ${currentUser.nome}`;
    
    if (currentUser.isAdmin) {
        elements.tabAdmin.classList.remove('hidden');
        elements.btnLimpar.classList.remove('hidden');
    } else {
        elements.tabAdmin.classList.add('hidden');
        elements.btnLimpar.classList.add('hidden');
    }
}
    
    carregarRegistros();
}

// Navegação por tabs
function switchTab(tabName) {
    elements.tabs.forEach(tab => {
        tab.classList.toggle('active', tab.dataset.tab === tabName);
    });
    
    elements.tabContents.forEach(content => {
        content.classList.toggle('hidden', content.id !== tabName);
    });
    
    if (tabName === 'espelho') {
        carregarRegistros();
    } else if (tabName === 'admin' && currentUser.isAdmin) {
        carregarDashboardAdmin();
    }
}

// Registrar ponto
async function handleRegistroPonto(e) {
    e.preventDefault();
    
    const tipo = document.getElementById('tipo').value;
    
    if (!tipo) {
        showMessage('Selecione um tipo de registro', 'erro');
        return;
    }
    
    const novoRegistro = {
        id: Date.now(),
        matricula: currentUser.username === 'admin' ? 'ADMIN' : 'USER001',
        tipoRegistro: tipo,
        dataHora: new Date().toISOString(),
        usuario: currentUser.username
    };
    
    registros.unshift(novoRegistro);
    allRegistros.unshift(novoRegistro);
    
    showMessage('✅ Ponto registrado com sucesso!', 'sucesso');
    elements.pontoForm.reset();
    
    if (!document.getElementById('espelho').classList.contains('hidden')) {
        carregarRegistros();
    }
}

// Carregar registros do usuário
function carregarRegistros() {
    const userRegistros = currentUser.isAdmin ? 
        allRegistros : 
        registros.filter(r => r.usuario === currentUser.username);
    
    if (userRegistros.length === 0) {
        elements.listaRegistros.innerHTML = `
            <div class="registro-item">
                <div class="registro-info">
                    <div class="registro-tipo">Nenhum registro encontrado</div>
                </div>
            </div>
        `;
        return;
    }
    
    elements.listaRegistros.innerHTML = userRegistros.map(registro => `
        <div class="registro-item">
            <div class="registro-info">
                <div class="registro-tipo">${formatarTipo(registro.tipoRegistro)}</div>
                <div class="registro-data">${formatarData(registro.dataHora)}</div>
            </div>
            ${currentUser.isAdmin ? `<div class="registro-matricula">${registro.matricula}</div>` : ''}
        </div>
    `).join('');
}

// Dashboard Admin
function carregarDashboardAdmin() {
    carregarKPIs();
    carregarTabelaAdmin();
    initCharts();
}

function carregarKPIs() {
    const totalRegistros = allRegistros.length;
    const usuariosUnicos = [...new Set(allRegistros.map(r => r.usuario))].length;
    const registrosHoje = allRegistros.filter(r => 
        new Date(r.dataHora).toDateString() === new Date().toDateString()
    ).length;
    
    const entradas = allRegistros.filter(r => r.tipoRegistro === 'ENTRADA').length;
    
    elements.adminSummary.innerHTML = `
        <div class="kpi-card">
            <div class="kpi-value">${totalRegistros}</div>
            <div class="kpi-label">Total de Registros</div>
        </div>
        <div class="kpi-card">
            <div class="kpi-value">${usuariosUnicos}</div>
            <div class="kpi-label">Usuários Ativos</div>
        </div>
        <div class="kpi-card">
            <div class="kpi-value">${registrosHoje}</div>
            <div class="kpi-label">Registros Hoje</div>
        </div>
        <div class="kpi-card">
            <div class="kpi-value">${entradas}</div>
            <div class="kpi-label">Entradas</div>
        </div>
    `;
}

function carregarTabelaAdmin() {
    const usuarios = [...new Set(allRegistros.map(r => r.usuario))];
    
    const tableHTML = `
        <table>
            <thead>
                <tr>
                    <th>Usuário</th>
                    <th>Matrícula</th>
                    <th>Total Registros</th>
                    <th>Último Registro</th>
                    <th>Status</th>
                </tr>
            </thead>
            <tbody>
                ${usuarios.map(usuario => {
                    const userRegs = allRegistros.filter(r => r.usuario === usuario);
                    const ultimoRegistro = userRegs[0];
                    const status = userRegs.length > 2 ? '🟢 Ativo' : '🟡 Poucos registros';
                    return `
                        <tr>
                            <td><strong>${usuario}</strong></td>
                            <td>${ultimoRegistro?.matricula || 'N/A'}</td>
                            <td>${userRegs.length}</td>
                            <td>${ultimoRegistro ? formatarData(ultimoRegistro.dataHora) : 'N/A'}</td>
                            <td>${status}</td>
                        </tr>
                    `;
                }).join('')}
            </tbody>
        </table>
    `;
    
    elements.adminTable.innerHTML = tableHTML;
}

// GRÁFICOS - CORRIGIDOS
function initCharts() {
    destroyCharts(); // Limpar gráficos existentes
    
    // Dados para os gráficos
    const tiposRegistro = ['ENTRADA', 'SAIDA', 'INTERVALO_INICIO', 'INTERVALO_FIM'];
    const contagemPorTipo = tiposRegistro.map(tipo => 
        allRegistros.filter(r => r.tipoRegistro === tipo).length
    );

    const usuarios = [...new Set(allRegistros.map(r => r.usuario))];
    const registrosPorUsuario = usuarios.map(usuario =>
        allRegistros.filter(r => r.usuario === usuario).length
    );

    const ultimos7Dias = Array.from({length: 7}, (_, i) => {
        const date = new Date();
        date.setDate(date.getDate() - i);
        return date.toLocaleDateString('pt-BR');
    }).reverse();

    const registrosPorDia = ultimos7Dias.map(dia => {
        return allRegistros.filter(r => 
            new Date(r.dataHora).toLocaleDateString('pt-BR') === dia
        ).length;
    });

    // Gráfico 1: Distribuição por Tipo de Registro
    const ctxAvg = document.getElementById('chartAvg');
    if (ctxAvg) {
        charts.avg = new Chart(ctxAvg, {
            type: 'doughnut',
            data: {
                labels: ['Entradas', 'Saídas', 'Início Intervalo', 'Fim Intervalo'],
                datasets: [{
                    data: contagemPorTipo,
                    backgroundColor: [
                        '#10b981',
                        '#ef4444', 
                        '#f59e0b',
                        '#3b82f6'
                    ],
                    borderWidth: 2,
                    borderColor: '#ffffff'
                }]
            },
            options: {
                responsive: true,
                plugins: {
                    title: {
                        display: true,
                        text: 'Distribuição por Tipo',
                        font: { size: 14, weight: 'bold' }
                    },
                    legend: {
                        position: 'bottom'
                    }
                }
            }
        });
    }

    // Gráfico 2: Registros por Usuário
    const ctxDelays = document.getElementById('chartDelays');
    if (ctxDelays) {
        charts.delays = new Chart(ctxDelays, {
            type: 'bar',
            data: {
                labels: usuarios,
                datasets: [{
                    label: 'Total de Registros',
                    data: registrosPorUsuario,
                    backgroundColor: '#2563eb',
                    borderColor: '#1d4ed8',
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                plugins: {
                    title: {
                        display: true,
                        text: 'Registros por Usuário',
                        font: { size: 14, weight: 'bold' }
                    }
                },
                scales: {
                    y: {
                        beginAtZero: true,
                        ticks: {
                            stepSize: 1
                        }
                    }
                }
            }
        });
    }

    // Gráfico 3: Registros dos Últimos 7 Dias
    const ctxCompliance = document.getElementById('chartCompliance');
    if (ctxCompliance) {
        charts.compliance = new Chart(ctxCompliance, {
            type: 'line',
            data: {
                labels: ultimos7Dias,
                datasets: [{
                    label: 'Registros por Dia',
                    data: registrosPorDia,
                    backgroundColor: 'rgba(37, 99, 235, 0.1)',
                    borderColor: '#2563eb',
                    borderWidth: 2,
                    tension: 0.4,
                    fill: true
                }]
            },
            options: {
                responsive: true,
                plugins: {
                    title: {
                        display: true,
                        text: 'Registros (Últimos 7 Dias)',
                        font: { size: 14, weight: 'bold' }
                    }
                },
                scales: {
                    y: {
                        beginAtZero: true,
                        ticks: {
                            stepSize: 1
                        }
                    }
                }
            }
        });
    }
}

// Destruir gráficos existentes
function destroyCharts() {
    Object.values(charts).forEach(chart => {
        if (chart) {
            chart.destroy();
        }
    });
    charts = {};
}

// Exportação
function exportarCSV() {
    const userRegistros = currentUser.isAdmin ? 
        allRegistros : 
        registros.filter(r => r.usuario === currentUser.username);
    
    if (userRegistros.length === 0) {
        showMessage('Nenhum registro para exportar', 'erro');
        return;
    }
    
    const csv = [
        ['Matricula', 'Tipo', 'Data/Hora', 'Usuário'],
        ...userRegistros.map(r => [r.matricula, r.tipoRegistro, r.dataHora, r.usuario])
    ].map(row => row.join(',')).join('\n');
    
    downloadCSV(csv, `registros-ponto-${currentUser.username}.csv`);
    showMessage('📤 CSV exportado com sucesso!', 'sucesso');
}

function exportarTodosCSV() {
    if (allRegistros.length === 0) {
        showMessage('Nenhum registro para exportar', 'erro');
        return;
    }
    
    const csv = [
        ['Matricula', 'Tipo', 'Data/Hora', 'Usuário'],
        ...allRegistros.map(r => [r.matricula, r.tipoRegistro, r.dataHora, r.usuario])
    ].map(row => row.join(',')).join('\n');
    
    downloadCSV(csv, 'registros-ponto-completo.csv');
    showMessage('📤 CSV completo exportado!', 'sucesso');
}

function downloadCSV(csv, filename) {
    const blob = new Blob([csv], { type: 'text/csv' });
    const url = window.URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url;
    a.download = filename;
    a.click();
    window.URL.revokeObjectURL(url);
}

// Limpar registros
function limparRegistros() {
    if (confirm('Tem certeza que deseja limpar SEUS registros?')) {
        registros = registros.filter(r => r.usuario !== currentUser.username);
        allRegistros = allRegistros.filter(r => r.usuario !== currentUser.username);
        carregarRegistros();
        showMessage('Registros limpos com sucesso', 'sucesso');
    }
}

function limparTodosRegistros() {
    if (confirm('Tem certeza que deseja limpar TODOS os registros?')) {
        registros = [];
        allRegistros = [];
        carregarRegistros();
        if (currentUser.isAdmin) {
            carregarDashboardAdmin();
        }
        showMessage('Todos os registros foram limpos', 'sucesso');
    }
}

// Utilitários
function showMessage(text, type) {
    elements.mensagem.textContent = text;
    elements.mensagem.className = `mensagem ${type}`;
    setTimeout(() => {
        elements.mensagem.textContent = '';
        elements.mensagem.className = 'mensagem';
    }, 5000);
}

function formatarTipo(tipo) {
    const tipos = {
        'ENTRADA': '🟢 Entrada',
        'SAIDA': '🔴 Saída',
        'INTERVALO_INICIO': '🟡 Intervalo - Início',
        'INTERVALO_FIM': '🔵 Intervalo - Fim'
    };
    return tipos[tipo] || tipo;
}

function formatarData(dataString) {
    return new Date(dataString).toLocaleString('pt-BR');
}

// M�scara de CPF
setTimeout(() => {
    const cpfInput = document.getElementById('cpf');
    if (cpfInput) {
        cpfInput.addEventListener('input', function(e) {
            let value = e.target.value.replace(/\D/g, '');
            if (value.length > 11) value = value.slice(0, 11);
            
            if (value.length > 9) {
                value = value.replace(/(\d{3})(\d{3})(\d{3})(\d{1,2})/, '$1.$2.$3-$4');
            } else if (value.length > 6) {
                value = value.replace(/(\d{3})(\d{3})(\d{1,3})/, '$1.$2.$3');
            } else if (value.length > 3) {
                value = value.replace(/(\d{3})(\d{1,3})/, '$1.$2');
            }
            
            e.target.value = value;
        });
    }
}, 100);
