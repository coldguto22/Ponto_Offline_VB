# ?? SOLUÇÃO DEFINITIVA - Erro App.config

## ? Problema Identificado

```
Error while trying to run project: Unable to start program
This application has failed to start because the application
configuration is incorrect.
```

**Causa:** `App.config` não está sendo copiado para `bin\Debug\Ponto_Offline_VB.exe.config`

---

## ? SOLUÇÃO RÁPIDA (2 Minutos)

### **Opção 1: Solução Manual no Visual Studio (RECOMENDADO)**

1. **No Visual Studio**, localize o arquivo `App.config` no **Solution Explorer**

2. **Clique com botão direito** em `App.config`

3. Selecione **Properties**

4. Na janela de propriedades, encontre:
- **Copy to Output Directory**
   - Mude de `Do not copy` para **`Copy always`**

5. **Salve** (Ctrl+S)

6. **Rebuild Solution** (Ctrl+Shift+B)

7. **Execute** (F5)

---

### **Opção 2: Via Script PowerShell (AUTOMÁTICO)**

Feche o Visual Studio e execute:

```powershell
cd C:\Users\Guto\source\repos\coldguto22\Ponto_Offline_VB
.\CORRIGIR_APPCONFIG.ps1
```

Depois:
1. Reabra o Visual Studio
2. Rebuild Solution (Ctrl+Shift+B)
3. Execute (F5)

---

### **Opção 3: Copiar Manualmente (TEMPORÁRIO)**

```powershell
# Executar no PowerShell

cd C:\Users\Guto\source\repos\coldguto22\Ponto_Offline_VB\DesktopAppVB

# Criar pasta se não existir
New-Item -Path "bin\Debug" -ItemType Directory -Force

# Copiar App.config com nome correto
Copy-Item "App.config" "bin\Debug\Ponto_Offline_VB.exe.config" -Force

Write-Host "? App.config copiado!"
```

Depois execute (F5) no Visual Studio

---

## ?? Verificar se Funcionou

Após aplicar a solução, verifique:

```powershell
# Verificar se arquivo existe
Test-Path "C:\Users\Guto\source\repos\coldguto22\Ponto_Offline_VB\DesktopAppVB\bin\Debug\Ponto_Offline_VB.exe.config"
```

**Deve retornar:** `True`

---

## ?? Se Ainda Houver Erro

### Erro: "TNS_ADMIN não configurado"

Execute como **Administrador**:

```powershell
[System.Environment]::SetEnvironmentVariable("TNS_ADMIN", "C:\Users\Guto\Downloads\Wallet_PontoOfflineDB", "Machine")

# Reinicie o Visual Studio
```

### Erro: "Wallet não encontrado"

Verifique se existe:

```powershell
Test-Path "C:\Users\Guto\Downloads\Wallet_PontoOfflineDB\tnsnames.ora"
Test-Path "C:\Users\Guto\Downloads\Wallet_PontoOfflineDB\sqlnet.ora"
```

Ambos devem retornar `True`

---

## ?? Checklist de Validação

### Antes de Executar
- [ ] App.config existe no projeto
- [ ] App.config tem propriedade "Copy to Output Directory" = "Copy always"
- [ ] Arquivo existe em bin\Debug\Ponto_Offline_VB.exe.config
- [ ] Rebuild Solution executado

### Ao Executar
- [ ] Aplicação inicia sem erro de configuração
- [ ] Mensagem "Conexão OK - Oracle Cloud" aparece
- [ ] Formulário abre normalmente

---

## ?? Solução Definitiva no .vbproj

Se quiser resolver permanentemente, edite `Ponto_Offline_VB.vbproj`:

**Procure por:**
```xml
<None Include="App.config" />
```

**Substitua por:**
```xml
<None Include="App.config">
  <CopyToOutputDirectory>Always</CopyToOutputDirectory>
</None>
```

Depois:
1. Feche o Visual Studio
2. Reabra o projeto
3. Rebuild Solution

---

## ?? Resumo das Soluções

| Solução | Tempo | Permanente? | Dificuldade |
|---------|-------|-------------|-------------|
| **Opção 1: Visual Studio** | 1 min | ? Sim | ? Fácil |
| **Opção 2: Script** | 2 min | ? Sim | ? Fácil |
| **Opção 3: Manual** | 30 seg | ? Não | ? Muito Fácil |
| Editar .vbproj | 3 min | ? Sim | ?? Médio |

**Recomendação:** Use **Opção 1** (Visual Studio Properties)

---

## ?? Próximos Passos

1. **Escolha uma solução** acima
2. **Execute a correção**
3. **Rebuild Solution** (Ctrl+Shift+B)
4. **Execute** (F5)
5. **Verifique** se aparece "Conexão OK - Oracle Cloud"

---

**Status:** ?? Erro de Configuração  
**Solução:** ? Disponível (3 opções)  
**Tempo:** 1-3 minutos  

?? **Escolha a Opção 1 e em 1 minuto estará resolvido!**
