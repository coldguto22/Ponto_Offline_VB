# 🔌 Guia de Integração: Desktop VB.NET + API Spring Boot + Sincronização

> Aviso de escopo: nesta versão, o **DesktopAppVB** é focado em **gestão de cadastros (Funcionários e Empresas)** e **não realiza marcações de ponto**. As seções sobre marcação no desktop e sincronização offline são mantidas aqui apenas como referência histórica/legada.

## 📋 Resumo do que foi implementado

1. **CORS configurado** na API Spring Boot — desktop e web podem chamar a API
2. **Tabela de sincronização** (`tb_registros_ponto_pending`) no banco desktop — armazena registros offline
3. **Módulo SincronizadorPonto.vb** — sincroniza automaticamente quando houver conexão

---

## 🚀 Como usar o sistema

### **Cenário 1: Funcionário marca ponto via Web**

1. Abra `http://localhost:8080/marcacao` no navegador
2. Digite CPF ou ID do funcionário
3. Escolha tipo (ENTRADA ou SAÍDA)
4. Clique em "Marcar Ponto"
5. Sistema busca funcionário na API, registra ponto com geolocalização (se permitido)
6. Registro é armazenado em `/registros` na API

---

### **Cenário 2: Funcionário marca ponto no Desktop (OFFLINE)**

1. Abra o app VB.NET
2. Navegue para tela de marcação (a ser implementada)
3. Digite CPF e tipo
4. Clique em "Marcar Ponto"
5. Se **com conexão**: registra na API imediatamente
6. Se **sem conexão**: armazena em `tb_registros_ponto_pending` (fila local)

---

### **Cenário 3: Sincronização automática (background)**

1. Desktop roda um **Timer** que chama `SincronizadorPonto.SincronizarAsync()` a cada 30 segundos
2. Se **há conexão com API**:
   - Busca registros pendentes (`sincronizado = 0`)
   - Envia cada um para `/api/registros`
   - Marca como sincronizado (`sincronizado = 1`)
3. Se **sem conexão**: aguarda próxima tentativa

---

## 🔧 Setup passo a passo

### **Backend (Spring Boot)**

#### 1. Criar/executar script de banco
```sql
-- Criar tabela de registros (já existe em RegistroPonto.java)
-- Executar criação automática com Hibernate DDL:
-- spring.jpa.hibernate.ddl-auto=update (já configurado em application.properties)
```

#### 2. Rodar API
```bash
cd ApiSpringboot
mvnw.cmd spring-boot:run
# Ou
java -jar target\ApiSpringboot-0.0.1-SNAPSHOT.jar
```

API disponível em:
- `/api/funcionarios` — CRUD de funcionários
- `/api/registros` — CRUD de registros de ponto
- `/marcacao` — Tela web de marcação

---

### **Desktop (VB.NET)**

#### 1. Criar tabela de sincronização
Execute no SQL Server (database `PontoOfflineVB`):
```sql
-- Arquivo: DesktopAppVB/Scripts/criar_tb_registros_ponto_pending.sql
```

#### 2. Integrar SincronizadorPonto no App

No formulário principal (`frm_menu.vb` ou `Form1.vb`):

```vb
' No topo da classe
Private sincronizador As New SincronizadorPonto()
Private timerSincronizacao As New System.Timers.Timer(30000) ' 30 segundos

' No Load do formulário
Private Sub Form_Load(sender As Object, e As EventArgs)
    ' ... código existente ...
    
    ' Configurar timer de sincronização
    AddHandler timerSincronizacao.Elapsed, AddressOf TimerSincronizacao_Tick
    timerSincronizacao.Start()
End Sub

Private Async Sub TimerSincronizacao_Tick(sender As Object, e As EventArgs)
    Await sincronizador.SincronizarAsync()
    ' Opcional: atualizar tela com status "Sincronizado em: HH:mm:ss"
End Sub

' Para registrar um ponto localmente:
Private Sub BtnMarcarPonto_Click(sender As Object, e As EventArgs)
    Dim funcionarioId = 1 ' buscar do formulário
    Dim tipo = "ENTRADA" ' buscar do formulário
    Dim latitude As Double? = Nothing
    Dim longitude As Double? = Nothing
    
    ' Se quiser geolocalização (GPS):
    ' latitude = ObterLatitude()
    ' longitude = ObterLongitude()
    
    Dim sucesso = sincronizador.RegistrarPontoLocal(funcionarioId, tipo, latitude, longitude)
    If sucesso Then
        MsgBox("Ponto registrado (será sincronizado quando houver conexão)")
    Else
        MsgBox("Erro ao registrar ponto")
    End If
End Sub
```

---

## 📡 Endpoints da API

### **GET /api/funcionarios**
```bash
# Listar todos
GET http://localhost:8080/api/funcionarios

# Buscar por CPF
GET http://localhost:8080/api/funcionarios?cpf=12345678900

# Buscar por Empresa
GET http://localhost:8080/api/funcionarios?empresaId=1
```

### **POST /api/registros**
```bash
curl -X POST http://localhost:8080/api/registros \
  -H "Content-Type: application/json" \
  -d '{
    "funcionario": {"id": 1},
    "data": "2025-11-11",
    "hora": "08:30:00",
    "tipo": "ENTRADA",
    "latitude": -23.55052,
    "longitude": -46.63331
  }'
```

### **GET /api/registros?funcionarioId=1&data=2025-11-11**
Filtrar registros por funcionário e data

---

## 🔍 Monitoramento / Troubleshooting

### **Verificar sincronização no Desktop**

Query na tabela:
```sql
SELECT * FROM tb_registros_ponto_pending
WHERE sincronizado = 0; -- registros pendentes

SELECT * FROM tb_registros_ponto_pending
WHERE erro_sincronizacao IS NOT NULL; -- registros com erro
```

### **Verificar registros na API**
```bash
curl http://localhost:8080/api/registros
```

### **Erro: "Funcionário não encontrado"**
- Certifique-se de que o funcionário está registrado (`/api/funcionarios`)
- Verifique se o CPF está correto (sem formatação ou espaços)

### **Erro: CORS bloqueado**
- API está respondendo com erro de CORS?
- Verifique `CorsConfig.java` — está permitindo a origem do desktop?
- Para produção, altere `allowedOrigins()` para seu domínio real

---

## 🎯 Próximos passos

1. **Tela de visualização no Desktop** — listar/filtrar/editar registros
2. **Autenticação JWT** — proteger endpoints
3. **Relatórios** — export PDF/CSV de presença
4. **Migração MySQL** — preparar para produção em nuvem

---

## 📝 Notas Importantes

- **Geolocalização é opcional** — funciona apenas em navegadores modernos (HTTPS em produção)
- **Intervalo de sincronização (30s)** — ajustável via `INTERVALO_SINCRONIZACAO` em `SincronizadorPonto.vb`
- **Banco Local** — use H2 para testes rápidos, SQL Server/MySQL para produção
- **Rate Limiting** — se muitos clientes sincronizarem simultaneamente, considere implementar fila batch

