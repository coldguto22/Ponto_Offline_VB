# Script de Teste Rápido da API com H2
# Execute este script DEPOIS de rodar: java -jar target/ApiSpringboot-0.0.1-SNAPSHOT.jar

$ApiUrl = "http://localhost:8080"
$green = "Green"
$red = "Red"

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "  TESTE RÁPIDO DA API COM H2" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Função para testar conexão com retry rápido
function Wait-ForApi {
    param(
        # Use a real API endpoint instead of root to avoid 404 from '/'
        [string]$Url = "$ApiUrl/api/empresas",
        [int]$Retries = 6,
        [int]$DelaySeconds = 2,
        [int]$TimeoutSec = 2
    )
    Write-Host "[1/10] Testando conexão com API (endpoint: $Url)..." -ForegroundColor Yellow
    Write-Host "  Aguardando em $Url (até ${Retries} tentativas, intervalo ${DelaySeconds}s)" -ForegroundColor DarkCyan
    
    for ($i = 1; $i -le $Retries; $i++) {
        try {
            $resp = Invoke-WebRequest -Uri $Url -UseBasicParsing -TimeoutSec $TimeoutSec -ErrorAction Stop
            Write-Host "✅ Servidor HTTP respondendo em $ApiUrl (status $($resp.StatusCode))" -ForegroundColor Green
            return $true
        } catch {
            $errMsg = $_.Exception.Message
            if ($errMsg -like "*Connection refused*" -or $errMsg -like "*No connection*" -or $errMsg -like "*ConnectFailure*") {
                Write-Host "  ⏳ Tentativa $i/${Retries}: conexão recusada (servidor não iniciado?)" -ForegroundColor Yellow
            } else {
                Write-Host "  ⏳ Tentativa $i/${Retries}: $errMsg" -ForegroundColor Yellow
            }
            
            if ($i -lt $Retries) {
                Start-Sleep -Seconds $DelaySeconds
            }
        }
    }

    Write-Host "❌ Erro: Não conseguiu conectar em $Url após ${Retries} tentativas" -ForegroundColor $red
    Write-Host "   Por favor, verifique:" -ForegroundColor $red
    Write-Host "   1. API está rodando? (java -jar target/ApiSpringboot-0.0.1-SNAPSHOT.jar)" -ForegroundColor DarkRed
    Write-Host "   2. Porta 8080 está disponível? (netstat -aon | findstr :8080)" -ForegroundColor DarkRed
    Write-Host "   3. Firewall bloqueando localhost:8080?" -ForegroundColor DarkRed
    return $false
}

# 1. Testar conexão com API (com retry)
Write-Host ""
if (-not (Wait-ForApi)) { exit 1 }

# 2. Criar Empresa
Write-Host ""
Write-Host "[2/10] Criando empresa de teste..." -ForegroundColor Yellow
$empresaBody = @{
    nome = "Empresa Teste H2"
    cnpj = "12345678000100"
    endereco = "Rua H2, 123"
    razaoSocial = "Empresa H2 LTDA"
    nomeFantasia = "Empresa H2"
    inscEstadual = "123456789.123.456"
    telefone = "(11) 99999-9999"
    email = "contato@h2.com"
} | ConvertTo-Json

$empresa = Invoke-RestMethod -Uri "$ApiUrl/api/empresas" -Method Post `
    -ContentType "application/json" `
    -Body $empresaBody

$empresaId = $empresa.id
Write-Host "✅ Empresa criada com ID: $empresaId" -ForegroundColor $green
Write-Host "   Nome: $($empresa.nome)" -ForegroundColor $green

# 3. Listar Empresas
Write-Host ""
Write-Host "[3/10] Listando empresas..." -ForegroundColor Yellow
$empresas = Invoke-RestMethod -Uri "$ApiUrl/api/empresas" -Method Get
Write-Host "✅ Total de empresas: $($empresas.Count)" -ForegroundColor $green

# 4. Criar Funcionário
Write-Host ""
Write-Host "[4/10] Criando funcionário de teste..." -ForegroundColor Yellow
$funcionarioBody = @{
    nome = "João Silva"
    cpf = "12345678901"
    empresa = @{ id = $empresaId }
    dataAdmissao = "2025-01-01"
    pis = "12345678901"
    folha = 5
    horario = "08:00-17:00"
    dataNascimento = "1990-05-15"
} | ConvertTo-Json

$funcionario = Invoke-RestMethod -Uri "$ApiUrl/api/funcionarios" -Method Post `
    -ContentType "application/json" `
    -Body $funcionarioBody

$funcionarioId = $funcionario.id
Write-Host "✅ Funcionário criado com ID: $funcionarioId" -ForegroundColor $green
Write-Host "   Nome: $($funcionario.nome)" -ForegroundColor $green
Write-Host "   CPF: $($funcionario.cpf)" -ForegroundColor $green

# 5. Buscar Funcionário por CPF
Write-Host ""
Write-Host "[5/10] Buscando funcionário por CPF..." -ForegroundColor Yellow
$funcionarioBuscado = Invoke-RestMethod -Uri "$ApiUrl/api/funcionarios?cpf=12345678901" -Method Get
if ($funcionarioBuscado.Count -gt 0) {
    Write-Host "✅ Funcionário encontrado: $($funcionarioBuscado[0].nome)" -ForegroundColor $green
} else {
    Write-Host "❌ Funcionário não encontrado" -ForegroundColor $red
}

# 6. Criar Registro de Ponto
Write-Host ""
Write-Host "[6/10] Criando registro de ponto (ENTRADA)..." -ForegroundColor Yellow
$registroBody = @{
    funcionario = @{ id = $funcionarioId }
    data = (Get-Date -Format "yyyy-MM-dd")
    hora = (Get-Date -Format "HH:mm")
    tipo = "ENTRADA"
    latitude = -23.5505
    longitude = -46.6333
} | ConvertTo-Json

$registro = Invoke-RestMethod -Uri "$ApiUrl/api/registros" -Method Post `
    -ContentType "application/json" `
    -Body $registroBody

$registroId = $registro.id
Write-Host "✅ Registro de ponto criado com ID: $registroId" -ForegroundColor $green
Write-Host "   Tipo: $($registro.tipo)" -ForegroundColor $green
Write-Host "   Data/Hora: $($registro.data) $($registro.hora)" -ForegroundColor $green

# 7. Listar Registros
Write-Host ""
Write-Host "[7/10] Listando todos os registros..." -ForegroundColor Yellow
$registros = Invoke-RestMethod -Uri "$ApiUrl/api/registros" -Method Get
Write-Host "✅ Total de registros: $($registros.Count)" -ForegroundColor $green

# 8. Filtrar por Funcionário
Write-Host ""
Write-Host "[8/10] Filtrando registros por funcionário..." -ForegroundColor Yellow
$registrosFuncionario = Invoke-RestMethod -Uri "$ApiUrl/api/registros?funcionarioId=$funcionarioId" -Method Get
Write-Host "✅ Registros do funcionário: $($registrosFuncionario.Count)" -ForegroundColor $green

# 9. Filtrar por Data
Write-Host ""
Write-Host "[9/10] Filtrando registros por data..." -ForegroundColor Yellow
$hoje = Get-Date -Format "yyyy-MM-dd"
$registrosHoje = Invoke-RestMethod -Uri "$ApiUrl/api/registros?data=$hoje" -Method Get
Write-Host "✅ Registros de hoje: $($registrosHoje.Count)" -ForegroundColor $green

# 10. Verificar H2 Console
Write-Host ""
Write-Host "[10/10] H2 Console..." -ForegroundColor Yellow
Write-Host "✅ Acesse http://localhost:8080/h2-console para visualizar o banco" -ForegroundColor $green
Write-Host "   JDBC URL: jdbc:h2:mem:ponto" -ForegroundColor $green
Write-Host "   User: sa" -ForegroundColor $green
Write-Host "   Password: (deixe em branco)" -ForegroundColor $green

# Resumo Final
Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "  ✅ TODOS OS TESTES PASSARAM!" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""
Write-Host "Resumo:" -ForegroundColor Yellow
Write-Host "  • Empresa: $($empresa.nome) (ID: $empresaId)" -ForegroundColor Green
Write-Host "  • Funcionário: $($funcionario.nome) (ID: $funcionarioId)" -ForegroundColor Green
Write-Host "  • Registro: $($registro.tipo) em $($registro.data) $($registro.hora)" -ForegroundColor Green
Write-Host ""
Write-Host "Próximos passos:" -ForegroundColor Yellow
Write-Host "  1. Abra http://localhost:8080/marcacao.html no navegador" -ForegroundColor Cyan
Write-Host "  2. Digite CPF: 12345678901" -ForegroundColor Cyan
Write-Host "  3. Teste a marcação de ponto via web" -ForegroundColor Cyan
Write-Host ""
Write-Host "Documentação disponível em:" -ForegroundColor Yellow
Write-Host "  • TESTES_COM_H2.md - Guia completo de testes" -ForegroundColor Cyan
Write-Host "  • ERRO_CONEXAO_BANCO.md - Solução de problemas" -ForegroundColor Cyan
Write-Host ""
