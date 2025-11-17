# Script para instalar Oracle.ManagedDataAccess no projeto VB.NET

Write-Host "========================================" -ForegroundColor Cyan
Write-Host " Instalador Oracle.ManagedDataAccess" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

$projectPath = "C:\Users\Guto\source\repos\coldguto22\Ponto_Offline_VB\DesktopAppVB"

# Verificar se o diretório existe
if (-Not (Test-Path $projectPath)) {
    Write-Host "? Erro: Diretório do projeto não encontrado!" -ForegroundColor Red
    Write-Host "Caminho: $projectPath" -ForegroundColor Yellow
    exit 1
}

Write-Host "? Diretório do projeto encontrado" -ForegroundColor Green
Write-Host "Caminho: $projectPath" -ForegroundColor Gray
Write-Host ""

# Navegar para o diretório
Set-Location $projectPath

# Verificar se o arquivo .vbproj existe
$vbprojFiles = Get-ChildItem -Filter "*.vbproj"
if ($vbprojFiles.Count -eq 0) {
    Write-Host "? Erro: Nenhum arquivo .vbproj encontrado!" -ForegroundColor Red
    exit 1
}

$projectFile = $vbprojFiles[0].Name
Write-Host "? Arquivo do projeto encontrado: $projectFile" -ForegroundColor Green
Write-Host ""

# Verificar se dotnet CLI está disponível
Write-Host "Verificando dotnet CLI..." -ForegroundColor Cyan
$dotnetVersion = dotnet --version 2>$null
if ($LASTEXITCODE -ne 0) {
    Write-Host "? dotnet CLI não encontrado!" -ForegroundColor Red
    Write-Host ""
    Write-Host "SOLUÇÃO ALTERNATIVA:" -ForegroundColor Yellow
    Write-Host "1. Abra o Visual Studio" -ForegroundColor White
    Write-Host "2. Clique com botão direito no projeto" -ForegroundColor White
    Write-Host "3. Selecione 'Manage NuGet Packages'" -ForegroundColor White
    Write-Host "4. Procure por 'Oracle.ManagedDataAccess'" -ForegroundColor White
    Write-Host "5. Clique em 'Install'" -ForegroundColor White
    Write-Host ""
    Read-Host "Pressione Enter para sair"
    exit 1
}

Write-Host "? dotnet CLI versão: $dotnetVersion" -ForegroundColor Green
Write-Host ""

# Instalar pacote Oracle.ManagedDataAccess
Write-Host "Instalando Oracle.ManagedDataAccess..." -ForegroundColor Cyan
Write-Host ""

try {
    dotnet add package Oracle.ManagedDataAccess
    
    if ($LASTEXITCODE -eq 0) {
        Write-Host ""
        Write-Host "========================================" -ForegroundColor Green
     Write-Host " ? INSTALAÇÃO CONCLUÍDA COM SUCESSO!" -ForegroundColor Green
        Write-Host "========================================" -ForegroundColor Green
        Write-Host ""
        Write-Host "Próximos passos:" -ForegroundColor Cyan
        Write-Host "1. Abra o projeto no Visual Studio" -ForegroundColor White
     Write-Host "2. Compile o projeto (Ctrl+Shift+B)" -ForegroundColor White
        Write-Host "3. Configure as credenciais em Module1.vb:" -ForegroundColor White
        Write-Host "   - DefaultUser" -ForegroundColor Yellow
        Write-Host "   - DefaultPassword" -ForegroundColor Yellow
        Write-Host "   - DefaultDataSource" -ForegroundColor Yellow
        Write-Host ""
      Write-Host "Leia INSTRUCOES_ORACLE.md para mais detalhes" -ForegroundColor Gray
    } else {
        throw "Erro ao instalar pacote"
    }
} catch {
    Write-Host ""
    Write-Host "? Erro durante a instalação!" -ForegroundColor Red
    Write-Host "Erro: $_" -ForegroundColor Yellow
 Write-Host ""
    Write-Host "SOLUÇÃO ALTERNATIVA:" -ForegroundColor Yellow
    Write-Host "Use o Visual Studio NuGet Package Manager" -ForegroundColor White
    Write-Host "Consulte INSTRUCOES_ORACLE.md para instruções detalhadas" -ForegroundColor White
}

Write-Host ""
Read-Host "Pressione Enter para sair"
