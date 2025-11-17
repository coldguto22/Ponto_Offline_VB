# Solução Alternativa - Configurar App.config Permanentemente

Write-Host "========================================" -ForegroundColor Cyan
Write-Host " Solução Alternativa - App.config" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

$projectPath = "C:\Users\Guto\source\repos\coldguto22\Ponto_Offline_VB\DesktopAppVB"
$vbprojFile = "$projectPath\Ponto_Offline_VB.vbproj"

Write-Host "Modificando arquivo de projeto..." -ForegroundColor Cyan
Write-Host "Arquivo: $vbprojFile" -ForegroundColor Gray
Write-Host ""

# Ler conteúdo do .vbproj
$content = Get-Content $vbprojFile -Raw

# Verificar se App.config está como None
if ($content -match '<None Include="App\.config"') {
    Write-Host "? App.config encontrado como 'None'" -ForegroundColor Yellow
    
    # Substituir None por Content e adicionar CopyToOutputDirectory
    $newConfig = @"
    <None Include="App.config">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
    </None>
"@
    
  $content = $content -replace '<None Include="App\.config"\s*/>', $newConfig
    
    # Salvar arquivo modificado
    Set-Content -Path $vbprojFile -Value $content -Encoding UTF8
    
    Write-Host "? Arquivo .vbproj modificado!" -ForegroundColor Green
    Write-Host "  App.config agora será copiado automaticamente" -ForegroundColor Gray
    
} else {
    Write-Host "? App.config já está configurado corretamente" -ForegroundColor Yellow
}

Write-Host ""
Write-Host "========================================" -ForegroundColor Green
Write-Host " ? CONFIGURAÇÃO PERMANENTE APLICADA!" -ForegroundColor Green
Write-Host "========================================" -ForegroundColor Green
Write-Host ""

Write-Host "Próximos passos:" -ForegroundColor Cyan
Write-Host "1. Feche o Visual Studio completamente" -ForegroundColor White
Write-Host "2. Reabra o projeto" -ForegroundColor White
Write-Host "3. Clique com botão direito em 'App.config'" -ForegroundColor White
Write-Host "4. Properties ? Copy to Output Directory ? 'Copy always'" -ForegroundColor White
Write-Host "5. Build ? Rebuild Solution" -ForegroundColor White
Write-Host "6. F5 para executar" -ForegroundColor White
Write-Host ""

Read-Host "Pressione Enter para sair"
