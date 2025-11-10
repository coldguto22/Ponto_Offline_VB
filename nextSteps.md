## 🚀 Próximos passos (priorizados)

Resumo rápido: com base no seu comentário, priorizei duas frentes principais — 1) tela web para marcação de ponto e 2) tela de gerenciamento de pontos no desktop — e organizei as demais dependências e melhorias em ordem de importância para entregar essas funcionalidades com segurança e confiabilidade.

1) Implementar interface web responsiva para marcação de ponto (PRIORIDADE ALTA)
	- Objetivo: permitir que funcionários registrem ponto via navegador (desktop/mobile).
	- Critérios de aceite: rota pública de marcação que aceita autenticação/session; feedback imediato (sucesso/erro); persistência no banco e visualização mínima em lista.
	- Dependências: controllers REST prontos (já adicionados), datasource configurado, CORS/configuração de segurança mínima.
	- Próximo passo imediato: criar um frontend simples (React/Vue/Thymeleaf) com um formulário de marcação e integração com `/api/registros`.

2) Implementar tela de visualização e gestão de registros de ponto no app desktop (PRIORIDADE ALTA)
	- Objetivo: permitir que usuários administrativos no aplicativo VB.NET vejam, filtrem e gerenciem marcações (editar/excluir/validar).
	- Critérios de aceite: listagem paginada/filtrável por funcionário/data, ação para editar/excluir registro, sincronização manual/imediata com a API.
	- Dependências: endpoints CRUD da API (já adicionados), sincronização offline-online (próxima prioridade), mecanismo para upload/download de fotos/logos se necessário.
	- Próximo passo imediato: mapear telas existentes (`frm_funcionario`, `frm_menu`) e adicionar formulário/grade de registros com chamadas HTTP à API.

3) Implementar sincronização automática offline → online entre desktop e API (PRIORIDADE MÉDIA)
	- Objetivo: garantir que marcações feitas no desktop enquanto offline sejam enviadas ao servidor quando houver conexão.
	- Critérios de aceite: fila local de alterações, retries com backoff, detecção de conflitos simples (timestamp) e logs de sincronização.
	- Próximo passo imediato: definir formato de payload e criar endpoint de batch (ex: POST /api/registros/batch) ou usar os endpoints existentes com um worker local.

4) Implementar autenticação segura na API (ex: JWT) e autorização básica (PRIORIDADE MÉDIA)
	- Objetivo: proteger endpoints de gestão e permitir que apenas usuários autenticados registrem/vejam dados sensíveis.
	- Critérios de aceite: endpoints de login/refresh, geração de token JWT, proteção de rotas, e exemplos de uso no frontend/desktop.
	- Observação: para protótipo rápido podemos começar com autenticação simples (usuario estático) e evoluir para integração com AD/LDAP.

5) Logs, auditoria e relatórios de presença (PRIORIDADE BAIXA → MÉDIA)
	- Objetivo: armazenar histórico de ações e disponibilizar relatórios por período/funcionário.
	- Critérios de aceite: auditoria de CRUD em registros, endpoint para exportação CSV/PDF, visualização básica no desktop/web.

6) Migração para banco de dados servidor (MySQL) e preparação para banco em nuvem (PRIORIDADE MÉDIA)
	- Objetivo: migrar do H2/SQL Server local para um servidor MySQL gerenciado para produção, e preparar para futura migração a um banco em nuvem (RDS/Aurora, Cloud SQL etc).
	- Justificativa: MySQL em servidor facilita deploys em infraestrutura tradicional e é compatível com provedores de nuvem; planejamento prévio reduz risco de downtime na migração.
	- Critérios de aceite: script de migração (DDL/DML) ou mapeamento de dados, profile `application-mysql.properties` funcional, testes de integração apontando para MySQL, documentação de como provisionar o DB em produção.
	- Próximo passo imediato: adicionar profile `application-mysql.properties`, incluir dependência `mysql-connector-java` no `pom.xml` e validar com um banco MySQL local/contêiner.

7) Suporte a múltiplos bancos (MySQL, SQL Server, H2) e deploy (PRIORIDADE BAIXA)
	- Objetivo: facilitar deploys locais e em diferentes infraestruturas.
	- Critérios de aceite: profiles `application-{profile}.properties`, instruções de configuração e dependências de driver opcionais.

Ações imediatas recomendadas (próximas tasks — 1–2 dias):
 - Criar prototype web (single page ou server-side template) que consome `/api/registros` para marcação rápida.
 - Acrescentar uma tela/aba no app desktop que consome `/api/registros` para listagem e edição básica.
 - Habilitar a configuração do datasource (já coloquei exemplos em `application.properties`) e validar conexão local (usar H2 para testes rápidos).

Notas finais:
 - Já adicionei controllers no backend para suportar CRUD — isso acelera as tarefas 1 e 2.
 - Posso gerar um prototype em React + chamadas fetch para `/api/registros` e um exemplo de integração no VB.NET (ex.: método para chamar a API e preencher DataGridView).
 - Me diga qual tecnologia prefere para a interface web (React, Vue, Angular, Thymeleaf) e se quer que eu gere o código do prototype agora.

Priorizado por: facilidade de entrega → dependências → impacto no fluxo de negócio

```

