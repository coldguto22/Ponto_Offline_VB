# ?? INÍCIO RÁPIDO - Migração Oracle

## ? 4 Passos para Começar (Agora com Segurança!)

### 1?? Instalar Pacote Oracle (2 minutos)

Abra **PowerShell** no diretório raiz do projeto:

```powershell
cd C:\Users\Guto\source\repos\coldguto22\Ponto_Offline_VB
.\InstalarOracle.ps1
```

**OU** no Visual Studio:
- Tools ? NuGet Package Manager ? Manage NuGet Packages
- Browse ? Pesquisar "**Oracle.ManagedDataAccess**"
- Install

---

### 2?? Adicionar Referência System.Configuration (1 minuto)

No Visual Studio:
1. **Solution Explorer** ? Clique direito em **References**
2. **Add Reference...**
3. **Assemblies** ? Procure: `System.Configuration`
4. Marque e clique **OK**

---

### 3?? Configurar Credenciais no App.config (2 minutos) ??

Abra `App.config` e edite:

```xml
<appSettings>
    <!-- ?? EDITE AQUI (SEGURO - NÃO FICA NO CÓDIGO!): -->
    <add key="OracleDataSource" value="PONTO_OFFLINE"/>  <!-- Seu TNS -->
    <add key="OracleUser" value="seu_usuario"/>  <!-- Seu usuário -->
    <add key="OraclePassword" value="sua_senha"/>      <!-- Sua senha -->
    
    <!-- Tipo: TNS ou DIRECT -->
    <add key="OracleConnectionType" value="TNS"/>
</appSettings>
```

**? Vantagem:** Credenciais **fora do código-fonte**!

---

### 4?? Criar Tabelas Oracle (5 minutos)

Execute os scripts SQL (disponíveis em `INSTRUCOES_ORACLE.md`):

**Via SQL Developer ou SQL*Plus:**

```sql
-- Copiar e executar os CREATE TABLE de INSTRUCOES_ORACLE.md
CREATE TABLE tb_empresas (...);
CREATE TABLE tb_funcionarios (...);
CREATE TABLE tb_registros_ponto (...);
```

---

## ? Pronto!

Agora compile o projeto:
- Visual Studio ? **Build ? Rebuild Solution** (Ctrl+Shift+B)
- Execute (F5)

Você deve ver: **"Conexão OK - Oracle (PONTO_OFFLINE)"**

---

## ?? Segurança Extra (Opcional)

### Criptografar App.config
```powershell
aspnet_regiis.exe -pef "appSettings" "C:\caminho\para\seu\app"
```

### Adicionar ao .gitignore
```gitignore
App.config
```

**Leia:** `CONFIGURACAO_SEGURA_ORACLE.md` para detalhes

---

## ?? Documentação Completa

| Arquivo | Quando Ler |
|---------|------------|
| **CONFIGURACAO_SEGURA_ORACLE.md** | ?? Como proteger credenciais |
| **STATUS_MIGRACAO_FINAL.md** | Visão geral completa |
| **INSTRUCOES_ORACLE.md** | Guia detalhado de setup |
| **MIGRACAO_ORACLE_RESUMO.md** | Resumo das mudanças |

---

## ?? Ajuda Rápida

**Erro de compilação?**  
? Instale Oracle.ManagedDataAccess (Passo 1) + System.Configuration (Passo 2)

**Erro de conexão?**  
? Verifique credenciais no **App.config** (Passo 3)

**Tabelas não existem?**  
? Execute os scripts SQL (Passo 4)

---

**Tempo total:** ~10 minutos  
**Status:** ? Código 100% pronto  
**Segurança:** ?? Credenciais protegidas
