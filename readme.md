# Ponto Offline VB + API REST  
**Projeto Integrado:** Desktop VB.NET + API Spring Boot  

## 🎯 Visão geral  
Este projeto consiste em duas partes que se complementam:

- **DesktopAppVB**: Aplicação desktop em VB.NET onde os funcionários ou estações podem marcar ponto localmente, independente de conexão internet (“offline”).  
- **ApiSpringBoot**: API REST desenvolvida em Java com Spring Boot que conecta o módulo desktop + uma interface web “na nuvem” (ou local) onde o próprio funcionário pode marcar ponto via navegador. A API processa essas marcações e armazena no banco de dados relacional central.

A ideia é que ambas ideias sejam **uma coisa só**: o desktop registra localmente, e a API permite marcações remotas e sincronização.  

## 📁 Estrutura do repositório  
Ponto_Offline_VB/
├── DesktopAppVB/ ← Projeto VB.NET (offline)
├── ApiSpringBoot/ ← Projeto Spring Boot (API REST)
├── README.md ← Esta documentação principal
└── .gitignore

## 💡 Como funciona a integração  
1. O usuário/funcionário pode usar o app desktop (em VB.NET) para marcar ponto localmente.  
2. Quando houver conexão ou em momento definido, o desktop envia os dados para a API REST (`ApiSpringBoot`).  
3. A API persiste os dados no banco central (H2 por padrão ou outro SGBD configurado).  
4. Paralelamente, a interface web da API permite que o próprio funcionário acesse via navegador e registre ponto — também via API.  
5. O módulo desktop e a API compartilham o mesmo modelo de dados (entidades: Funcionário, Empresa, RegistroPonto) para garantir consistência.

## 🧩 Entidades mínimas implementadas  
- **Empresa**: representa a unidade ou local de trabalho.  
- **Funcionario**: representa o colaborador que vai registrar ponto.  
- **RegistroPonto**: representa a marcação de entrada ou saída do funcionário, com data/hora, tipo, vínculo com funcionário.  

## ✨ Status da Implementação (Nov 2025)

| Feature | Status | Detalhe |
|---------|--------|---------|
| **Interface web de marcação** | ✅ Completo | `/marcacao` com CPF, tipo, geolocalização |
| **CORS configurado** | ✅ Completo | Desktop e web podem chamar API |
| **Sincronização offline** | ✅ Completo | Fila local + worker automático |
| **Tela desktop de gestão** | ⏳ Planejado | Próxima prioridade |
| **Autenticação JWT** | ⏳ Planejado | Proteção de endpoints |
| **Relatórios** | ⏳ Planejado | Export PDF/CSV |

## 🛠 Como rodar cada módulo  

### ApiSpringBoot (API REST)
```bash
cd ApiSpringboot

# Opção 1: Maven wrapper (recomendado)
mvnw.cmd spring-boot:run

# Opção 2: Compilar e executar JAR
mvnw.cmd clean package
java -jar target/ApiSpringboot-0.0.1-SNAPSHOT.jar
```

A API estará disponível em:
- `http://localhost:8080/api/` — endpoints REST
- `http://localhost:8080/marcacao` — interface web de marcação
- `http://localhost:8080/h2-console` — console H2 (se usar H2)

### DesktopAppVB (Aplicação Windows Forms)
1. Abra a solução `DesktopAppVB/PontoOfflineVB.sln` no Visual Studio
2. Execute o script `Scripts/criar_tb_registros_ponto_pending.sql` no SQL Server para criar tabela de sincronização offline
3. No formulário principal, integre o módulo `SincronizadorPonto.vb`:
   ```vb
   ' Ver exemplo em: DesktopAppVB/frm_menu_integracao_exemplo.vb
   Private sincronizador As New SincronizadorPonto()
   ```
4. Compile e execute a aplicação

## 🚀 Endpoints da API

### Funcionários
```bash
GET /api/funcionarios                  # Listar todos
GET /api/funcionarios?cpf=123...       # Buscar por CPF
GET /api/funcionarios?empresaId=1      # Buscar por Empresa
POST /api/funcionarios                 # Criar novo
PUT /api/funcionarios/{id}             # Atualizar
DELETE /api/funcionarios/{id}          # Deletar
```

### Registros de Ponto
```bash
GET /api/registros                           # Listar todos
GET /api/registros?funcionarioId=1          # Por funcionário
GET /api/registros?data=2025-11-11          # Por data
POST /api/registros                         # Registrar ponto
PUT /api/registros/{id}                     # Atualizar
DELETE /api/registros/{id}                  # Deletar
```

### Tela Web
```bash
GET /marcacao  # Interface responsiva para marcar ponto
```

## 📚 Documentação Adicional

- **[GUIA_INTEGRACAO.md](./GUIA_INTEGRACAO.md)** — Guia completo de integração desktop ↔ API
- **[RESUMO_IMPLEMENTACAO.md](./RESUMO_IMPLEMENTACAO.md)** — O que foi entregue e como testar
- **[CHECKLIST_TESTES.md](./CHECKLIST_TESTES.md)** — 23 testes para validar tudo
- **[nextSteps.md](./nextSteps.md)** — Roadmap priorizado

## 💻 Exemplos de Uso

### Marcar ponto via Web
```bash
# 1. Criar funcionário
curl -X POST http://localhost:8080/api/funcionarios \
  -H "Content-Type: application/json" \
  -d '{
    "nome":"João Silva",
    "CPF":"12345678900",
    "cargo":"Desenvolvedor"
  }'

# 2. Acessar interface
# http://localhost:8080/marcacao
# Digitar CPF e clicar "Marcar Ponto"
```

### Marcar ponto no Desktop (offline)
```vb
Dim sync = New SincronizadorPonto()

' Registrar ponto localmente (sem conexão)
sync.RegistrarPontoLocal(
  funcionarioId:=1,
  tipo:="ENTRADA",
  latitude:=-23.55052,
  longitude:=-46.63331
)

' Sincroniza automaticamente quando houver conexão (timer a cada 30s)
' Ou manualmente:
Await sync.SincronizarAsync()
```

etc.

✅ Tecnologias usadas
VB.NET / Windows Forms (ou WPF) – módulo desktop

Java 11+ com Spring Boot – módulo API REST

Banco de dados relacional (H2 por padrão; opção para MySQL, SQL Server etc)

JSON para comunicação REST entre desktop ↔ API

🚀 Próximos passos / roadmap
Autenticação/Autorização (ex: JWT) para acesso seguro à API.

Interface web responsiva para marcação de ponto via navegador/mobile.

Sincronização automática offline → online entre desktop e API.

Logs, auditoria de marcações e relatórios de presença.

Deploy da API para nuvem ou VPS + suporte para múltiplas estações desktop.

🤝 Contribuindo
Sinta-se à vontade para sugerir melhorias! Verifique os arquivos de roadmap e issues aberta no repositório.
Para patches: faça fork → branch → pull request.

📄 Licença
Este projeto está disponível sob a licença MIT.

## Java runtime (ApiSpringBoot)

Nota rápida: o módulo `ApiSpringBoot` agora tem como alvo o Java 21 (LTS).

- O `pom.xml` do módulo define `<java.version>21` e o projeto usa o
   `maven-compiler-plugin` configurado com `<release>21` para garantir
   compatibilidade de bytecode.
- Na sua máquina de desenvolvimento ou CI, tenha o JDK 21 disponível. Se
   houver uma versão mais nova instalada (por exemplo JDK 23), o compilador
   ainda pode gerar bytecode alvo para 21 usando a opção `--release`.

Como compilar o módulo (usando o wrapper Maven incluído):

```powershell
cd 'c:\Users\Guto\source\repos\coldguto22\Ponto_Offline_VB\ApiSpringboot'
.\mvnw.cmd -v
.\mvnw.cmd package
```

Para CI (GitHub Actions), use `actions/setup-java` com `java-version: '21'`.