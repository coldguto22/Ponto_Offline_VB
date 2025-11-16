# Ponto Offline VB - Spring Boot API

API REST para gerenciamento de empresas, funcionários e registros de ponto integrada com a aplicação VB.NET.

## 🚀 Quick Start

### Com H2 (Banco de dados em memória - Desenvolvimento)

```bash
cd ApiSpringboot
java -jar target/ApiSpringboot-0.0.1-SNAPSHOT.jar
```

A API estará disponível em `http://localhost:8080`

### Com Oracle (Produção)

```bash
cd ApiSpringboot
set DB_URL=jdbc:oracle:thin:@pontoofflinedb_tp
set DB_USER=TESTE_PONTO
set DB_PASSWORD=<password>
set DB_DRIVER=oracle.jdbc.OracleDriver
java -Dcom.sun.jndi.ldap.connect.pool=false -Doracle.net.wallet_location=C:/Users/Guto/Downloads/Wallet_PontoOfflineDB -jar target/ApiSpringboot-0.0.1-SNAPSHOT.jar
```

## 📚 API Endpoints

### Empresas (`/api/empresas`)

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/api/empresas` | Lista todas as empresas |
| GET | `/api/empresas/{id}` | Obtém empresa por ID |
| POST | `/api/empresas` | Cria nova empresa |
| PUT | `/api/empresas/{id}` | Atualiza empresa existente |
| DELETE | `/api/empresas/{id}` | Remove empresa |

**Request body (POST/PUT):**
```json
{
  "razaoSocial": "Company Name LTDA",
  "nomeFantasia": "Company Short Name",
  "cnpj": "11.222.333/0001-44",
  "email": "contact@company.com",
  "endereco": "Rua Principal, 100",
  "telefone": "(11) 3000-1000",
  "inscEstadual": "123.456.789.012",
  "logo": "logo.png"
}
```

### Funcionários (`/api/funcionarios`)

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/api/funcionarios` | Lista todos os funcionários |
| GET | `/api/funcionarios/{id}` | Obtém funcionário por ID |
| POST | `/api/funcionarios` | Cria novo funcionário |
| PUT | `/api/funcionarios/{id}` | Atualiza funcionário |
| DELETE | `/api/funcionarios/{id}` | Remove funcionário |

**Request body (POST/PUT):**
```json
{
  "nome": "João Silva",
  "cpf": "123.456.789-00",
  "pis": "120.123.456-70",
  "cargo": "Gerente",
  "dataNascimento": "1990-05-15",
  "dataAdmissao": "2020-01-10",
  "dataDemissao": null,
  "horario": "09:00-18:00",
  "folha": "Mensal",
  "foto": "joao_silva.jpg",
  "empresaId": 1
}
```

### Registros de Ponto (`/api/registroponto`)

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/api/registroponto` | Lista todos os registros |
| GET | `/api/registroponto/{id}` | Obtém registro por ID |
| POST | `/api/registroponto` | Cria novo registro |
| DELETE | `/api/registroponto/{id}` | Remove registro |

**Request body (POST):**
```json
{
  "data": "2024-11-16",
  "hora": "09:30:00",
  "tipo": "ENTRADA",
  "latitude": -23.5505,
  "longitude": -46.6333,
  "funcionarioId": 1
}
```

## 🔧 Build & Deploy

### Compilar

```bash
cd ApiSpringboot
./mvnw clean package
```

JAR será gerado em `target/ApiSpringboot-0.0.1-SNAPSHOT.jar`

### Rodar Testes

```bash
./mvnw test
```

## 🏗️ Arquitetura

```
src/main/java/com/pontoofflineVB/ApiSpringboot/
├── model/
│   ├── Empresa.java
│   ├── Funcionario.java
│   └── RegistroPonto.java
├── repository/
│   ├── EmpresaRepository.java
│   ├── FuncionarioRepository.java
│   └── RegistroPontoRepository.java
├── controller/
│   ├── EmpresaController.java
│   ├── FuncionarioController.java
│   ├── RegistroPontoController.java
│   └── MarcacaoController.java
└── ApiSpringbootApplication.java

src/main/resources/
└── application.properties
```

## 🔐 Configuração Oracle

1. **Wallet Setup**: Coloque os arquivos do Oracle Wallet em `C:\Users\Guto\Downloads\Wallet_PontoOfflineDB/`
2. **Variáveis de Ambiente**:
   - `DB_URL`: JDBC connection string
   - `DB_USER`: Oracle username (ex: TESTE_PONTO)
   - `DB_PASSWORD`: Oracle password
   - `DB_DRIVER`: oracle.jdbc.OracleDriver
3. **JVM Flags**: `-Dcom.sun.jndi.ldap.connect.pool=false -Doracle.net.wallet_location=C:/path/to/wallet`

## 📱 Integração com VB.NET

Use a biblioteca `HttpClient` do .NET para consumir a API:

```vb.net
Public Async Function ObterEmpresas() As Task(Of List(Of Empresa))
    Using client As New HttpClient()
        Dim response = Await client.GetAsync("http://localhost:8080/api/empresas")
        If response.IsSuccessStatusCode Then
            Dim json = Await response.Content.ReadAsStringAsync()
            ' Parse JSON e retornar lista de Empresa
        End If
    End Using
End Function
```

## 📊 Database Schema

### Empresa
- `id`: PK, auto-generated
- `razaoSocial`, `nomeFantasia`, `cnpj`, `email`, `endereco`, `telefone`, `inscEstadual`, `logo`

### Funcionario
- `id`: PK, auto-generated
- `nome`, `cpf`, `pis`, `cargo`, `dataNascimento`, `dataAdmissao`, `dataDemissao`, `horario`, `folha`, `foto`
- FK: `empresaId` → Empresa

### RegistroPonto
- `id`: PK, auto-generated
- `data`, `hora`, `tipo`, `latitude`, `longitude`
- FK: `funcionarioId` → Funcionario

## ✅ Testing

Todos os endpoints CRUD foram validados com sucesso:
- ✓ POST /api/empresas (create)
- ✓ GET /api/empresas (list)
- ✓ GET /api/empresas/{id} (retrieve)
- ✓ PUT /api/empresas/{id} (update)
- ✓ DELETE /api/empresas/{id} (delete)

## 🐛 Troubleshooting

**Port 8080 já está em uso:**
```bash
# Encontrar processo usando porta 8080
netstat -ano | findstr :8080
# Matar processo (substitua PID)
taskkill /PID <PID> /F
```

**H2 Database Console:**
Acesse `http://localhost:8080/h2-console` (apenas desenvolvimento)
- JDBC URL: `jdbc:h2:mem:ponto`
- User: `sa`
- Password: (deixar em branco)

## 📝 Notas

- Por padrão, a API usa H2 (banco em memória) para desenvolvimento rápido
- Para produção, configure Oracle via variáveis de ambiente
- Tabelas são criadas automaticamente via Hibernate (ddl-auto=create)
- API está sem autenticação no modo desenvolvimento

---

**Status**: ✅ Funcional e pronto para integração  
**Versão**: 0.0.1-SNAPSHOT  
**Framework**: Spring Boot 4.0.0-SNAPSHOT
