# ?? Guia de Configuração Segura - Oracle

## ? Solução Implementada

Suas credenciais Oracle agora estão **seguras** e **fora do código-fonte**!

---

## ?? Como Funciona

### ? ANTES (Inseguro - Hardcoded)
```vb
' Module1.vb
Public DefaultUser As String = "meu_usuario"      ' ? Exposto no código!
Public DefaultPassword As String = "minha_senha"' ? Perigo de vazar!
```

### ? AGORA (Seguro - App.config)
```vb
' Module1.vb
Private ReadOnly Property OracleUser As String
    Get
        Return ConfigurationManager.AppSettings("OracleUser")  ' ? Lido do config
    End Get
End Property
```

```xml
<!-- App.config -->
<appSettings>
    <add key="OracleUser" value="seu_usuario"/>      <!-- ? Fora do código -->
    <add key="OraclePassword" value="sua_senha"/>    <!-- ? Fácil de mudar -->
</appSettings>
```

---

## ?? Configurar Credenciais

### Passo 1: Abrir App.config

No seu projeto, abra o arquivo `App.config`

### Passo 2: Editar Credenciais

Localize a seção `<appSettings>` e edite:

```xml
<appSettings>
  <!-- ?? EDITE ESTAS LINHAS: -->
    <add key="OracleDataSource" value="PONTO_OFFLINE"/>        <!-- Nome do TNS -->
    <add key="OracleUser" value="seu_usuario_real"/>    <!-- Seu usuário -->
    <add key="OraclePassword" value="sua_senha_real"/>         <!-- Sua senha -->
    <add key="OraclePort" value="1521"/>        <!-- Porta Oracle -->
    
    <!-- Tipo de conexão: TNS ou DIRECT -->
    <add key="OracleConnectionType" value="TNS"/>
    
    <!-- Se usar DIRECT, preencha: -->
    <add key="OracleHost" value="localhost"/>
    <add key="OracleServiceName" value="xe"/>
</appSettings>
```

### Passo 3: Escolher Tipo de Conexão

#### Opção 1: Conexão via TNS (Recomendado)
```xml
<add key="OracleConnectionType" value="TNS"/>
<add key="OracleDataSource" value="PONTO_OFFLINE"/>  <!-- Nome do TNS -->
```

**Vantagens:**
- ? Configuração centralizada (tnsnames.ora)
- ? Fácil gerenciar múltiplos ambientes
- ? Padrão Oracle

#### Opção 2: Conexão Direta (Sem TNS)
```xml
<add key="OracleConnectionType" value="DIRECT"/>
<add key="OracleHost" value="192.168.1.100"/>     <!-- IP do servidor -->
<add key="OraclePort" value="1521"/>
<add key="OracleServiceName" value="xe"/>         <!-- Service name -->
```

**Vantagens:**
- ? Não precisa configurar tnsnames.ora
- ? Funciona em qualquer máquina
- ? Bom para testes rápidos

---

## ?? Adicionar Referência System.Configuration

### Passo 1: Adicionar Referência (Visual Studio)

1. **Solution Explorer** ? Clique com botão direito em **References**
2. **Add Reference...**
3. **Assemblies** ? Procure: `System.Configuration`
4. Marque a checkbox e clique **OK**

### Passo 2: Verificar se foi adicionado

No `.vbproj`, deve aparecer:
```xml
<Reference Include="System.Configuration" />
```

---

## ?? Segurança Adicional

### Nível 1: App.config Simples (Atual)
```xml
<add key="OraclePassword" value="minha_senha"/>
```
- ? Fora do código-fonte
- ?? Texto plano no arquivo
- ?? Bom para desenvolvimento

### Nível 2: Criptografar App.config (Recomendado para Produção)

Use o comando `aspnet_regiis.exe` para criptografar:

```powershell
# Criptografar seção appSettings
aspnet_regiis.exe -pef "appSettings" "C:\caminho\para\seu\app"

# Descriptografar (se necessário)
aspnet_regiis.exe -pdf "appSettings" "C:\caminho\para\seu\app"
```

**Após criptografia, o App.config fica assim:**
```xml
<appSettings configProtectionProvider="RsaProtectedConfigurationProvider">
    <EncryptedData Type="http://www.w3.org/2001/04/xmlenc#Element"
        xmlns="http://www.w3.org/2001/04/xmlenc#">
        <EncryptionMethod Algorithm="http://www.w3.org/2001/04/xmlenc#tripledes-cbc" />
 <KeyInfo xmlns="http://www.w3.org/2000/09/xmldsig#">
       <EncryptedKey xmlns="http://www.w3.org/2001/04/xmlenc#">
            <!-- Dados criptografados -->
  </EncryptedKey>
        </KeyInfo>
        <CipherData>
     <CipherValue>...</CipherValue>
   </CipherData>
    </EncryptedData>
</appSettings>
```

**Vantagens:**
- ? Senha criptografada
- ? Seguro para produção
- ? Transparente para o código

### Nível 3: Usar Variáveis de Ambiente

Modifique `Module1.vb`:
```vb
Private ReadOnly Property OraclePassword As String
    Get
        ' Prioridade: 1. Variável de ambiente, 2. App.config
    Dim envPassword = Environment.GetEnvironmentVariable("ORACLE_PASSWORD")
        If Not String.IsNullOrEmpty(envPassword) Then
            Return envPassword
        End If
        Return ConfigurationManager.AppSettings("OraclePassword")
    End Get
End Property
```

**Definir variável de ambiente:**
```powershell
# PowerShell (sessão atual)
$env:ORACLE_PASSWORD = "minha_senha_secreta"

# PowerShell (permanente - usuário)
[System.Environment]::SetEnvironmentVariable("ORACLE_PASSWORD", "minha_senha_secreta", "User")

# PowerShell (permanente - sistema)
[System.Environment]::SetEnvironmentVariable("ORACLE_PASSWORD", "minha_senha_secreta", "Machine")
```

---

## ?? Exemplo Completo de App.config

### Desenvolvimento (Local)
```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
    <appSettings>
        <add key="OracleDataSource" value="localhost"/>
        <add key="OracleUser" value="dev_user"/>
        <add key="OraclePassword" value="dev_password"/>
    <add key="OraclePort" value="1521"/>
     <add key="OracleConnectionType" value="DIRECT"/>
        <add key="OracleHost" value="localhost"/>
        <add key="OracleServiceName" value="xe"/>
    </appSettings>
</configuration>
```

### Produção (Servidor)
```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
    <appSettings>
        <add key="OracleDataSource" value="PROD_DB"/>
    <add key="OracleUser" value="prod_user"/>
   <add key="OraclePassword" value="Pr0d$ecureP@ssw0rd"/>
        <add key="OraclePort" value="1521"/>
        <add key="OracleConnectionType" value="TNS"/>
    </appSettings>
</configuration>
```

---

## ?? Migrar Configurações Existentes

Se você já tem um banco configurado, atualize assim:

**De:**
```vb
' Module1.vb (antigo)
Public DefaultDataSource As String = "PONTO_OFFLINE"
Public DefaultUser As String = "admin"
Public DefaultPassword As String = "senha123"
```

**Para:**
```xml
<!-- App.config (novo) -->
<appSettings>
    <add key="OracleDataSource" value="PONTO_OFFLINE"/>
  <add key="OracleUser" value="admin"/>
    <add key="OraclePassword" value="senha123"/>
</appSettings>
```

---

## ?? Troubleshooting

### Erro: "Configuration system failed to initialize"
**Solução:** Adicione referência `System.Configuration` ao projeto

### Erro: "Object reference not set to an instance"
**Solução:** Verifique se `<appSettings>` existe no App.config

### Senha não funciona
**Solução:** Verifique se há caracteres especiais. Se sim, use CDATA:
```xml
<add key="OraclePassword" value="<![CDATA[P@ssw0rd&Special]]>"/>
```

### App.config não está sendo lido
**Solução:** Certifique-se que o arquivo está na raiz do projeto e é copiado para `bin/Debug`

---

## ? Benefícios da Solução

| Aspecto | Hardcoded | App.config |
|---------|-----------|------------|
| **Segurança** | ? Exposto no código | ? Fora do código |
| **Versionamento** | ? Senha no Git | ? Pode adicionar ao .gitignore |
| **Flexibilidade** | ? Recompilar para mudar | ? Editar e rodar |
| **Ambientes** | ? Um código = uma senha | ? App.config diferente por ambiente |
| **Segurança extra** | ? Não possível | ? Pode criptografar |

---

## ?? Checklist Final

- [ ] ? App.config criado/atualizado
- [ ] ? Referência `System.Configuration` adicionada
- [ ] ? Module1.vb modificado para ler do config
- [ ] ? Credenciais preenchidas no App.config
- [ ] ? Tipo de conexão escolhido (TNS ou DIRECT)
- [ ] ? Projeto compilado sem erros
- [ ] ? Conexão testada e funcionando
- [ ] ? (Opcional) App.config criptografado para produção
- [ ] ? (Opcional) App.config adicionado ao .gitignore

---

## ?? Adicionar App.config ao .gitignore

Para **não** versionar senhas no Git:

Crie/edite `.gitignore`:
```gitignore
# Configurações locais (senhas)
App.config
*.config

# OU mantenha um modelo:
# App.config
!App.config.example
```

Crie `App.config.example` (sem senhas):
```xml
<appSettings>
<add key="OracleDataSource" value="SEU_TNS_AQUI"/>
 <add key="OracleUser" value="SEU_USUARIO_AQUI"/>
    <add key="OraclePassword" value="SUA_SENHA_AQUI"/>
</appSettings>
```

---

**Desenvolvido para:** Ponto_Offline_VB  
**Segurança:** ? Credenciais fora do código  
**Status:** ? Pronto para uso seguro  
**Nível:** Recomendado para Produção
