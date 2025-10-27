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

## 🛠 Como rodar cada módulo  

### DesktopAppVB  
1. Abra a solução `PontoOfflineVB.sln` no Visual Studio (versão compatível VB.NET).  
2. Configure o banco local (SQLite ou outro) conforme já existente no módulo.  
3. No menu de configurações do app, defina a URL da API REST (ex: `http://localhost:8080/api`) para sincronização.  
4. Compile e execute.

### ApiSpringBoot  
1. No diretório `ApiSpringBoot`, execute:
   ```bash
   mvn clean install
   mvn spring-boot:run
ou usando Gradle conforme o build.
2. Acesse no navegador: http://localhost:8080/h2-console (caso use H2) e use a URL configurada em application.properties.
3. Use endpoints REST, por exemplo:

GET /funcionarios

POST /registrosponto

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