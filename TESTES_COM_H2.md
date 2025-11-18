# 🚀 Guia de Testes com H2

## 1. ✅ Status Atual

A API está **já compilada e rodando com H2** na porta **8080**.

- ✅ Driver SQL Server adicionado (`mssql-jdbc`)
- ✅ H2 configurado como banco de testes
- ✅ CORS habilitado
- ✅ Todos os 3 controladores prontos (Empresa, Funcionario, RegistroPonto)
- ✅ `marcacao.html` criado para testes web
  
> Observação: o módulo DesktopAppVB é destinado à gestão de cadastros (Funcionários e Empresas) e não realiza marcações de ponto.

## 2. 🏃 Rodar a API com H2

**Terminal 1 - Compilar e rodar:**

```powershell
cd c:\Users\Guto\source\repos\coldguto22\Ponto_Offline_VB\ApiSpringboot

# Compilar
.\mvnw.cmd clean package -DskipTests

# Rodar
java -jar target/ApiSpringboot-0.0.1-SNAPSHOT.jar
```

**Resultado esperado:**
```
Tomcat started on port 8080 (http) with context path '/'
Started ApiSpringbootApplication in X.XXX seconds
```

A API estará disponível em: `http://localhost:8080`

## 3. 🧪 Testar os Endpoints

Abra **outro terminal** (Terminal 2) e execute os comandos abaixo.

### **3.1 Testar GET /api/empresas (vazio)**

```powershell
curl -X GET http://localhost:8080/api/empresas \
  -H "Content-Type: application/json"
```

**Resposta esperada:** `[]` (lista vazia)

---

### **3.2 Criar uma Empresa (POST)**

```powershell
$body = @{
    nome = "Empresa Teste"
    cnpj = "12345678000100"
    endereco = "Rua Teste, 123"
    razaoSocial = "Empresa Teste LTDA"
    nomeFantasia = "Empresa Teste"
    inscEstadual = "123456789.123.456"
    telefone = "(11) 99999-9999"
    email = "contato@empresa.com"
} | ConvertTo-Json

curl -X POST http://localhost:8080/api/empresas `
  -H "Content-Type: application/json" `
  -d $body
```

**Resposta esperada:**
```json
{
  "id": 1,
  "nome": "Empresa Teste",
  "cnpj": "12345678000100",
  ...
}
```

---

### **3.3 Listar Empresas (GET)**

```powershell
curl -X GET http://localhost:8080/api/empresas
```

**Resposta esperada:**
```json
[
  {
    "id": 1,
    "nome": "Empresa Teste",
    ...
  }
]
```

---

### **3.4 Criar um Funcionário**

```powershell
$body = @{
    nome = "João Silva"
    cpf = "12345678901"
    empresa = @{ id = 1 }
    dataAdmissao = "2025-01-01"
    pis = "12345678901"
    folha = 5
    horario = "08:00-17:00"
    dataNascimento = "1990-05-15"
} | ConvertTo-Json

curl -X POST http://localhost:8080/api/funcionarios `
  -H "Content-Type: application/json" `
  -d $body
```

---

### **3.5 Buscar Funcionário por CPF**

```powershell
curl -X GET "http://localhost:8080/api/funcionarios?cpf=12345678901"
```

**Resposta esperada:**
```json
[
  {
    "id": 1,
    "nome": "João Silva",
    "cpf": "12345678901",
    ...
  }
]
```

---

### **3.6 Criar um Registro de Ponto**

```powershell
$body = @{
    funcionario = @{ id = 1 }
    data = "2025-11-11"
    hora = "09:00"
    tipo = "ENTRADA"
    latitude = -23.5505
    longitude = -46.6333
} | ConvertTo-Json

curl -X POST http://localhost:8080/api/registros `
  -H "Content-Type: application/json" `
  -d $body
```

---

### **3.7 Listar Registros de Ponto**

```powershell
curl -X GET http://localhost:8080/api/registros
```

---

### **3.8 Filtrar Registros por Funcionário**

```powershell
curl -X GET "http://localhost:8080/api/registros?funcionarioId=1"
```

---

### **3.9 Filtrar Registros por Data**

```powershell
curl -X GET "http://localhost:8080/api/registros?data=2025-11-11"
```

---

## 4. 🌐 Testar Web Interface (marcacao.html)

1. **Acesse no navegador (já incluído na API):**
```
http://localhost:8080/marcacao.html
```

2. **Na interface:**
   - Digite CPF: `12345678901` (do funcionário criado)
   - Selecione tipo: `ENTRADA` ou `SAIDA`
   - Clique "Registrar Ponto"
   - Permita geolocalização (opcional)

3. **Verifique se o registro foi criado:**
```powershell
curl -X GET http://localhost:8080/api/registros
```

---

## 5. ℹ️ Observação sobre o DesktopAppVB

O módulo DesktopAppVB, nesta versão, é focado em gestão de cadastros de Funcionários e Empresas. As **marcações de ponto** devem ser realizadas **exclusivamente pela interface web** ou via **integração com a API**. Trechos anteriores sobre sincronização offline e `SincronizadorPonto.vb` ficam como material legado e não fazem parte do escopo atual.

---

## 6. 📊 H2 Web Console (Opcional)

Você pode visualizar o banco H2 em tempo real:

1. **Acesse:**
```
http://localhost:8080/h2-console
```

2. **Na página de login:**
   - **JDBC URL:** `jdbc:h2:mem:ponto`
   - **User:** `sa`
   - **Password:** (deixe em branco)

3. **Clique "Connect"**

4. **Você verá as tabelas:**
   - `empresa`
   - `funcionario`
   - `registro_ponto`

---

## 7. 🐛 Troubleshooting

### Erro: "Port 8080 already in use"
```powershell
# Encontre o processo usando a porta:
netstat -ano | findstr :8080

# Mate o processo (substitua PID):
taskkill /PID <PID> /F

# Ou use outra porta:
java -Dserver.port=8081 -jar target/ApiSpringboot-0.0.1-SNAPSHOT.jar
```

### Erro: "Connection refused"
- Certifique-se de que o terminal anterior não foi fechado
- Espere 5 segundos após iniciar a API
- Verifique se `http://localhost:8080/` responde

### Erro: "Table already exists"
- Isso é normal em H2. O `ddl-auto=create-drop` recria as tabelas a cada inicialização
- Se quiser persistir dados, mude para `ddl-auto=update` no `application.properties`

---

## 8. 📝 Checklist de Testes

- [ ] API iniciada com sucesso (porta 8080)
- [ ] GET /api/empresas retorna `[]`
- [ ] POST /api/empresas cria empresa
- [ ] GET /api/empresas retorna lista com 1 empresa
- [ ] POST /api/funcionarios cria funcionário
- [ ] GET /api/funcionarios?cpf=X retorna funcionário
- [ ] POST /api/registros cria registro
- [ ] GET /api/registros retorna lista com registros
- [ ] GET /api/registros?funcionarioId=1 filtra por funcionário
- [ ] GET /api/registros?data=2025-11-11 filtra por data
- [ ] marcacao.html carrega no navegador
- [ ] marcacao.html consegue buscar funcionário por CPF
- [ ] marcacao.html consegue criar novo registro
- [ ] H2 Console acessível em /h2-console
- [ ] Tabelas visíveis no H2 Console

---

## 9. 🎯 Próximos Passos

Após passar em todos os testes acima:

1. **Integrar no VB.NET:**
   - Copie `SincronizadorPonto.vb` para o projeto VB.NET
   - Use `frm_menu_integracao_exemplo.vb` como referência
   - Implemente a sincronização offline

2. **Implementar Gestão de Registros:**
   - Criar tela `frm_registros` para listar/editar registros
   - Integrar com `/api/registros` endpoints

3. **Produção:**
   - Trocar H2 por SQL Server
   - Habilitar TCP/IP no SQL Server
   - Configurar segurança (JWT, HTTPS)

---

**Última atualização:** 2025-11-11 às 09:42
