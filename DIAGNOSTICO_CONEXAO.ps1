# Script de Diagnóstico - Verificar Conexão com API#!/usr/bin/env powershell

# Script de Diagnóstico - Verificar Conexão com API

Write-Host "================================" -ForegroundColor Cyan

Write-Host "DIAGNOSTICO DE CONEXAO - API" -ForegroundColor CyanWrite-Host "================================" -ForegroundColor Cyan

Write-Host "================================" -ForegroundColor CyanWrite-Host "DIAGNÓSTICO DE CONEXÃO - API" -ForegroundColor Cyan

Write-Host ""Write-Host "================================" -ForegroundColor Cyan

Write-Host ""

# 1. Verificar se porta 8080 está aberta

Write-Host "[1] Verificando porta 8080..." -ForegroundColor Yellow# 1. Verificar se porta 8080 está aberta

$port = netstat -aon | Select-String ':8080' | Select-Object -First 1Write-Host "[1] Verificando porta 8080..." -ForegroundColor Yellow

if ($port) {$port = netstat -aon | Select-String ':8080' | Select-Object -First 1

    Write-Host "OK: Porta 8080 está escutando:" -ForegroundColor Greenif ($port) {

    Write-Host $port    Write-Host "✅ Porta 8080 está escutando:" -ForegroundColor Green

        Write-Host $port

    # Extrair PID    

    $portStr = $port -as [string]    # Extrair PID

    if ($portStr -match '(\d+)$') {    $pidMatch = $port -match '(\d+)$'

        $processId = $matches[1]    if ($pidMatch) {

        Write-Host "   PID: $processId" -ForegroundColor Green        $processId = $matches[1]

        $process = Get-Process -Id $processId -ErrorAction SilentlyContinue        Write-Host "   PID: $processId" -ForegroundColor Green

        if ($process) {        $process = Get-Process -Id $processId -ErrorAction SilentlyContinue

            Write-Host "   Processo: $($process.ProcessName)" -ForegroundColor Green        if ($process) {

        }            Write-Host "   Processo: $($process.ProcessName)" -ForegroundColor Green

    }            Write-Host "   Caminho: $($process.Path)" -ForegroundColor Green

} else {        }

    Write-Host "ERRO: Nenhum processo escutando na porta 8080" -ForegroundColor Red    }

    Write-Host "Acao: Inicie a API com:" -ForegroundColor Yellow} else {

    Write-Host "   cd ApiSpringboot" -ForegroundColor Yellow    Write-Host "❌ Nenhum processo escutando na porta 8080" -ForegroundColor Red

    Write-Host "   java -jar target/ApiSpringboot-0.0.1-SNAPSHOT.jar" -ForegroundColor Yellow    Write-Host "   Ação: Inicie a API com:" -ForegroundColor Yellow

    Write-Host ""    Write-Host "   cd ApiSpringboot" -ForegroundColor Yellow

    exit 1    Write-Host "   java -jar target/ApiSpringboot-0.0.1-SNAPSHOT.jar" -ForegroundColor Yellow

}    Write-Host ""

    exit 1

Write-Host ""}



# 2. Testar conexão TCP simplesWrite-Host ""

Write-Host "[2] Testando conexão TCP em localhost:8080..." -ForegroundColor Yellow

$tcpClient = New-Object System.Net.Sockets.TcpClient# 2. Testar conexão TCP simples

try {Write-Host "[2] Testando conexão TCP em localhost:8080..." -ForegroundColor Yellow

    $tcpClient.Connect("127.0.0.1", 8080)$tcpClient = New-Object System.Net.Sockets.TcpClient

    if ($tcpClient.Connected) {try {

        Write-Host "OK: Conexão TCP estabelecida" -ForegroundColor Green    $tcpClient.Connect("127.0.0.1", 8080)

    }    if ($tcpClient.Connected) {

    $tcpClient.Close()        Write-Host "✅ Conexão TCP estabelecida" -ForegroundColor Green

} catch {    }

    Write-Host "ERRO: Falha na conexão TCP: $($_.Exception.Message)" -ForegroundColor Red    $tcpClient.Close()

    exit 1} catch {

}    Write-Host "❌ Falha na conexão TCP: $($_.Exception.Message)" -ForegroundColor Red

    exit 1

Write-Host ""}



# 3. Testar HTTP GET para raizWrite-Host ""

Write-Host "[3] Testando HTTP GET em http://localhost:8080/" -ForegroundColor Yellow

try {# 3. Testar HTTP GET para raiz

    $response = Invoke-WebRequest -Uri "http://localhost:8080/" -UseBasicParsing -TimeoutSec 3 -ErrorAction StopWrite-Host "[3] Testando HTTP GET em http://localhost:8080/" -ForegroundColor Yellow

    Write-Host "OK: HTTP Status $($response.StatusCode)" -ForegroundColor Greentry {

} catch {    $response = Invoke-WebRequest -Uri "http://localhost:8080/" -UseBasicParsing -TimeoutSec 3 -ErrorAction Stop

    $errMsg = $_.Exception.Message    Write-Host "✅ HTTP Status: $($response.StatusCode)" -ForegroundColor Green

    Write-Host "ERRO: HTTP GET falhou - $errMsg" -ForegroundColor Red    Write-Host "   Tamanho: $($response.RawContentLength) bytes" -ForegroundColor Green

}} catch {

    $errMsg = $_.Exception.Message

Write-Host ""    Write-Host "❌ HTTP GET falhou:" -ForegroundColor Red

    Write-Host "   Erro: $errMsg" -ForegroundColor Red

# 4. Testar HTTP GET para /api/empresas    Write-Host "   Tipo: $($_.Exception.GetType().Name)" -ForegroundColor Red

Write-Host "[4] Testando HTTP GET em http://localhost:8080/api/empresas" -ForegroundColor Yellow}

try {

    $response = Invoke-WebRequest -Uri "http://localhost:8080/api/empresas" -UseBasicParsing -TimeoutSec 3 -ErrorAction StopWrite-Host ""

    Write-Host "OK: HTTP Status $($response.StatusCode)" -ForegroundColor Green

} catch {# 4. Testar HTTP GET para /api/empresas

    $errMsg = $_.Exception.MessageWrite-Host "[4] Testando HTTP GET em http://localhost:8080/api/empresas" -ForegroundColor Yellow

    if ($errMsg -like "*404*") {try {

        Write-Host "AVISO: HTTP 404 - controlador nao encontrado" -ForegroundColor Yellow    $response = Invoke-WebRequest -Uri "http://localhost:8080/api/empresas" -UseBasicParsing -TimeoutSec 3 -ErrorAction Stop

        Write-Host "   Possivel causa: Tomcat vazio ou controllers nao deployados" -ForegroundColor Yellow    Write-Host "✅ HTTP Status: $($response.StatusCode)" -ForegroundColor Green

    } else {    Write-Host "   Resposta: $($response.Content.Substring(0, [Math]::Min(100, $response.Content.Length)))" -ForegroundColor Green

        Write-Host "ERRO: HTTP GET falhou - $errMsg" -ForegroundColor Red} catch {

    }    $errMsg = $_.Exception.Message

}    if ($errMsg -like "*404*") {

        Write-Host "⚠️  HTTP 404 (controlador não encontrado)" -ForegroundColor Yellow

Write-Host ""        Write-Host "   Possível causa: Tomcat vazio ou controllers não deployados" -ForegroundColor Yellow

    } else {

# 5. Resumo        Write-Host "❌ HTTP GET falhou:" -ForegroundColor Red

Write-Host "[RESUMO]" -ForegroundColor Cyan        Write-Host "   Erro: $errMsg" -ForegroundColor Red

Write-Host "========================================" -ForegroundColor Cyan    }

Write-Host "Se todos testes passaram:" -ForegroundColor Green}

Write-Host "   Execute: .\TESTE_RAPIDO.ps1" -ForegroundColor Green

Write-Host ""Write-Host ""

Write-Host "Se falhou na porta 8080:" -ForegroundColor Red

Write-Host "   Inicie: java -jar target/ApiSpringboot-0.0.1-SNAPSHOT.jar" -ForegroundColor Red# 5. Resumo e recomendações

Write-Host ""Write-Host "[RESUMO]" -ForegroundColor Cyan

Write-Host "Se falhou no HTTP:" -ForegroundColor YellowWrite-Host "========================================" -ForegroundColor Cyan

Write-Host "   Verifique qual Tomcat esta rodando (veja DIAGNOSTICO_404.md)" -ForegroundColor YellowWrite-Host "Se todos os testes passaram (✅):" -ForegroundColor Green

Write-Host ""Write-Host "  → API está pronta para testes" -ForegroundColor Green

Write-Host "  → Execute: .\TESTE_RAPIDO.ps1" -ForegroundColor Green
Write-Host ""
Write-Host "Se falhou na porta 8080 (❌):" -ForegroundColor Red
Write-Host "  → Inicie a API primeiro" -ForegroundColor Red
Write-Host "  → cd ApiSpringboot" -ForegroundColor Red
Write-Host "  → java -jar target/ApiSpringboot-0.0.1-SNAPSHOT.jar" -ForegroundColor Red
Write-Host ""
Write-Host "Se falhou no HTTP GET (❌ ou avisoPF):" -ForegroundColor Yellow
Write-Host "  → Verifique qual Tomcat está rodando" -ForegroundColor Yellow
Write-Host "  → Deve ser Spring Boot JAR, não Tomcat standalone" -ForegroundColor Yellow
Write-Host "  → Veja DIAGNOSTICO_404.md para detalhes" -ForegroundColor Yellow
Write-Host ""
