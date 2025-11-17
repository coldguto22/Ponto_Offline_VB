# Script para Corrigir Erro de Configuração do App.config

Write-Host "========================================" -ForegroundColor Cyan
Write-Host " Correção de Erro - App.config" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

Write-Host "Erro identificado:" -ForegroundColor Yellow
Write-Host "  App.config não está sendo copiado para bin\Debug" -ForegroundColor White
Write-Host ""

# Solução 1: Limpar e Recompilar
Write-Host "Solução 1: Limpando projeto..." -ForegroundColor Cyan
$projectPath = "C:\Users\Guto\source\repos\coldguto22\Ponto_Offline_VB\DesktopAppVB"

Set-Location $projectPath

# Limpar bin e obj
Write-Host "  Removendo bin\Debug..." -ForegroundColor Gray
if (Test-Path "bin\Debug") {
    Remove-Item -Path "bin\Debug" -Recurse -Force -ErrorAction SilentlyContinue
}

Write-Host "  Removendo obj\Debug..." -ForegroundColor Gray
if (Test-Path "obj\Debug") {
    Remove-Item -Path "obj\Debug" -Recurse -Force -ErrorAction SilentlyContinue
}

Write-Host "? Limpeza concluída" -ForegroundColor Green
Write-Host ""

# Solução 2: Copiar App.config manualmente
Write-Host "Solução 2: Copiando App.config..." -ForegroundColor Cyan

# Criar diretório bin\Debug se não existir
if (-Not (Test-Path "bin\Debug")) {
    New-Item -Path "bin\Debug" -ItemType Directory -Force | Out-Null
}

# Copiar App.config para bin\Debug com nome correto
$appConfigSource = "App.config"
$appConfigDest = "bin\Debug\Ponto_Offline_VB.exe.config"

if (Test-Path $appConfigSource) {
    Copy-Item -Path $appConfigSource -Destination $appConfigDest -Force
    Write-Host "? App.config copiado para: $appConfigDest" -ForegroundColor Green
} else {
    Write-Host "? App.config não encontrado!" -ForegroundColor Red
    exit 1
}

Write-Host ""

# Solução 3: Verificar conteúdo
Write-Host "Solução 3: Verificando configuração..." -ForegroundColor Cyan

$configContent = Get-Content $appConfigDest -Raw
if ($configContent -match "TESTE_PONTO") {
    Write-Host "? Credenciais Oracle Cloud encontradas" -ForegroundColor Green
} else {
    Write-Host "? Credenciais Oracle Cloud não encontradas" -ForegroundColor Yellow
}

if ($configContent -match "Wallet_PontoOfflineDB") {
    Write-Host "? Configuração Wallet encontrada" -ForegroundColor Green
} else {
    Write-Host "? Configuração Wallet não encontrada" -ForegroundColor Yellow
}

Write-Host ""

# Solução 4: Recompilar
Write-Host "Solução 4: Recompilando projeto..." -ForegroundColor Cyan
Write-Host "  Execute no Visual Studio:" -ForegroundColor White
Write-Host "  Build ? Rebuild Solution (Ctrl+Shift+B)" -ForegroundColor Yellow
Write-Host ""

Write-Host "========================================" -ForegroundColor Green
Write-Host " ? CORREÇÕES APLICADAS!" -ForegroundColor Green
Write-Host "========================================" -ForegroundColor Green
Write-Host ""

Write-Host "Próximos passos:" -ForegroundColor Cyan
Write-Host "1. Feche o Visual Studio" -ForegroundColor White
Write-Host "2. Reabra o Visual Studio" -ForegroundColor White
Write-Host "3. Build ? Rebuild Solution (Ctrl+Shift+B)" -ForegroundColor White
Write-Host "4. Debug ? Start Debugging (F5)" -ForegroundColor White
Write-Host ""

Write-Host "Se o erro persistir, execute:" -ForegroundColor Yellow
Write-Host "  .\SOLUCAO_ALTERNATIVA.ps1" -ForegroundColor White
Write-Host ""

Read-Host "Pressione Enter para sair"
