# ? CHECKLIST DE TESTES - Aplicação Oracle VB.NET

Use este checklist para validar todas as funcionalidades após a adaptação.

---

## ?? PRÉ-REQUISITOS

### Antes de Começar
- [ ] Oracle Cloud está acessível (wallet configurado)
- [ ] TNS_ADMIN configurado: `C:\Users\Guto\Downloads\Wallet_PontoOfflineDB`
- [ ] App.config com credenciais corretas (TESTE_PONTO / senha)
- [ ] Tabelas EMPRESA e FUNCIONARIO existem no Oracle
- [ ] Aplicação VB.NET compilada sem erros

---

## ?? MÓDULO: EMPRESAS

### Teste 1: Listar Empresas
- [ ] Abrir frm_empresa
- [ ] Grid mostra colunas: CNPJ, RAZAO_SOCIAL
- [ ] Total de registros aparece no título da janela
- [ ] Sem erros de conexão

**Query esperada:** `SELECT CNPJ, RAZAO_SOCIAL FROM EMPRESA ORDER BY RAZAO_SOCIAL`

---

### Teste 2: Cadastrar Nova Empresa
- [ ] Clicar em "Novo"
- [ ] Preencher todos os campos:
  - [ ] CNPJ: `11.222.333/0001-44`
  - [ ] Razão Social: `Minha Empresa LTDA`
  - [ ] Nome Fantasia: `Minha Empresa`
  - [ ] Inscrição Estadual: `123456789`
  - [ ] Endereço: `Rua Teste, 100`
  - [ ] Telefone: `(11) 98765-4321`
  - [ ] Email: `contato@minhaempresa.com`
  - [ ] Logo (opcional): Selecionar imagem
- [ ] Clicar em "Concluir"
- [ ] Mensagem: "Empresa cadastrada com sucesso!"
- [ ] Empresa aparece na lista

**Validar no Oracle:**
```sql
SELECT * FROM EMPRESA WHERE CNPJ = '11222333000144';
```
- [ ] Registro existe
- [ ] RAZAO_SOCIAL = 'Minha Empresa LTDA'
- [ ] Todos os campos salvos corretamente

---

### Teste 3: Buscar Empresa por CNPJ (LostFocus)
- [ ] Abrir formulário de cadastro (Novo ou Editar)
- [ ] Digitar CNPJ existente: `11.222.333/0001-44`
- [ ] Clicar fora do campo CNPJ
- [ ] Todos os campos preenchem automaticamente
- [ ] Logo carregado (se foi cadastrado)

---

### Teste 4: Editar Empresa
- [ ] Selecionar empresa na lista
- [ ] Clicar em "Editar"
- [ ] Dados preenchidos automaticamente
- [ ] Alterar:
  - [ ] Telefone: `(11) 91111-2222`
  - [ ] Email: `novo@minhaempresa.com`
- [ ] Clicar em "Concluir"
- [ ] Mensagem: "Empresa atualizada com sucesso!"
- [ ] Dados atualizados na lista

**Validar no Oracle:**
```sql
SELECT TELEFONE, EMAIL FROM EMPRESA WHERE CNPJ = '11222333000144';
```
- [ ] TELEFONE = '(11) 91111-2222'
- [ ] EMAIL = 'novo@minhaempresa.com'

---

### Teste 5: Excluir Empresa (sem funcionários)
- [ ] Cadastrar empresa temporária
- [ ] Selecionar na lista
- [ ] Clicar em "Excluir"
- [ ] Confirmar exclusão
- [ ] Mensagem: "Empresa excluída com sucesso!"
- [ ] Empresa removida da lista

**Validar no Oracle:**
```sql
SELECT COUNT(*) FROM EMPRESA WHERE CNPJ = '[CNPJ_EXCLUIDO]';
```
- [ ] Retorna 0

---

### Teste 6: Tentar Excluir Empresa com Funcionários
- [ ] Cadastrar funcionário vinculado à empresa
- [ ] Tentar excluir a empresa
- [ ] ? Deve dar erro de FK (proteção de integridade)
- [ ] Empresa não é excluída

---

## ?? MÓDULO: FUNCIONÁRIOS

### Teste 7: Listar Funcionários
- [ ] Abrir frm_funcionario
- [ ] Grid mostra colunas: CPF, NOME, CARGO
- [ ] Total de registros no título
- [ ] Sem erros

**Query esperada:** `SELECT CPF, NOME, CARGO FROM FUNCIONARIO ORDER BY NOME`

---

### Teste 8: Combo de Empresas no Cadastro
- [ ] Abrir cad_funcionario (Novo)
- [ ] Combo "Empresa" está preenchido
- [ ] Mostra lista de empresas por RAZAO_SOCIAL
- [ ] Ordenadas alfabeticamente

**Query esperada:** `SELECT RAZAO_SOCIAL FROM EMPRESA ORDER BY RAZAO_SOCIAL`

---

### Teste 9: Cadastrar Novo Funcionário
- [ ] Clicar em "Novo"
- [ ] Preencher dados:
  - [ ] CPF: `123.456.789-00`
  - [ ] Nome: `João da Silva`
  - [ ] Data Admissão: `01/01/2025`
  - [ ] Data Nascimento: `15/05/1990`
  - [ ] PIS: `12345678901`
  - [ ] **Empresa:** Selecionar "Minha Empresa LTDA"
  - [ ] Folha: `5`
  - [ ] Cargo: `Desenvolvedor`
  - [ ] Horário: `09:00-18:00`
  - [ ] Foto (opcional): Selecionar imagem
- [ ] Clicar em "Concluir"
- [ ] Mensagem: "Funcionário cadastrado com sucesso!"
- [ ] Funcionário aparece na lista

**Validar no Oracle:**
```sql
SELECT 
    F.CPF,
 F.NOME,
    F.CARGO,
    F.EMPRESA_ID,
    E.RAZAO_SOCIAL
FROM FUNCIONARIO F
LEFT JOIN EMPRESA E ON F.EMPRESA_ID = E.ID
WHERE F.CPF = '12345678900';
```
- [ ] Registro existe
- [ ] EMPRESA_ID **não é NULL**
- [ ] RAZAO_SOCIAL = 'Minha Empresa LTDA'
- [ ] Todos os campos salvos

---

### Teste 10: Buscar Funcionário por CPF (LostFocus)
- [ ] Abrir formulário de cadastro
- [ ] Digitar CPF: `123.456.789-00`
- [ ] Clicar fora do campo
- [ ] Todos os campos preenchem automaticamente
- [ ] **Empresa selecionada: "Minha Empresa LTDA"**
- [ ] Foto carregada (se foi cadastrada)

---

### Teste 11: Editar Funcionário
- [ ] Selecionar funcionário na lista
- [ ] Clicar em "Atualizar"
- [ ] Dados preenchidos
- [ ] Alterar:
  - [ ] Cargo: `Desenvolvedor Sênior`
  - [ ] Horário: `10:00-19:00`
- [ ] Clicar em "Concluir"
- [ ] Mensagem: "Funcionário atualizado com sucesso!"
- [ ] Dados atualizados na lista

**Validar no Oracle:**
```sql
SELECT CARGO, HORARIO FROM FUNCIONARIO WHERE CPF = '12345678900';
```
- [ ] CARGO = 'Desenvolvedor Sênior'
- [ ] HORARIO = '10:00-19:00'

---

### Teste 12: Trocar Empresa do Funcionário
- [ ] Cadastrar segunda empresa
- [ ] Editar funcionário
- [ ] Selecionar outra empresa no combo
- [ ] Salvar
- [ ] Validar no Oracle que EMPRESA_ID mudou

**Validar no Oracle:**
```sql
SELECT 
    F.NOME,
    E.RAZAO_SOCIAL AS EMPRESA_ATUAL
FROM FUNCIONARIO F
LEFT JOIN EMPRESA E ON F.EMPRESA_ID = E.ID
WHERE F.CPF = '12345678900';
```
- [ ] EMPRESA_ATUAL mudou

---

### Teste 13: Excluir Funcionário
- [ ] Selecionar funcionário
- [ ] Clicar em "Excluir"
- [ ] Confirmar
- [ ] Mensagem: "Funcionário excluído com sucesso!"
- [ ] Removido da lista

**Validar no Oracle:**
```sql
SELECT COUNT(*) FROM FUNCIONARIO WHERE CPF = '12345678900';
```
- [ ] Retorna 0

---

## ?? MÓDULO: IMAGENS

### Teste 14: Upload de Logo (Empresa)
- [ ] Cadastrar empresa
- [ ] Clicar na imagem de logo
- [ ] Selecionar arquivo JPG/PNG
- [ ] Logo aparece no formulário
- [ ] Salvar empresa
- [ ] Reabrir empresa
- [ ] Logo carregado automaticamente

**Validar:** Pasta `bin\Debug\Logos\` contém arquivo

---

### Teste 15: Upload de Foto (Funcionário)
- [ ] Cadastrar funcionário
- [ ] Clicar na imagem de foto
- [ ] Selecionar arquivo
- [ ] Foto aparece no formulário
- [ ] Salvar funcionário
- [ ] Reabrir funcionário
- [ ] Foto carregada automaticamente

**Validar:** Pasta `bin\Debug\Fotos\` contém arquivo

---

## ?? MÓDULO: INTEGRIDADE REFERENCIAL

### Teste 16: FK FUNCIONARIO ? EMPRESA
- [ ] Cadastrar empresa "Empresa A"
- [ ] Cadastrar funcionário vinculado a "Empresa A"
- [ ] Validar no Oracle:

```sql
SELECT 
    constraint_name,
    table_name,
    column_name
FROM user_cons_columns
WHERE constraint_name IN (
    SELECT constraint_name
    FROM user_constraints
    WHERE table_name = 'FUNCIONARIO'
    AND constraint_type = 'R'
);
```
- [ ] FK existe e aponta para EMPRESA.ID

---

### Teste 17: Proteção de Integridade
- [ ] Cadastrar funcionário em "Empresa A"
- [ ] Tentar excluir "Empresa A"
- [ ] ? Deve dar erro: ORA-02292 (constraint violada)
- [ ] Empresa não é excluída
- [ ] Funcionário continua existindo

---

## ?? MÓDULO: CONSULTAS ORACLE

### Teste 18: Validação de Dados
Execute no Oracle Cloud:

```sql
-- Total de empresas
SELECT COUNT(*) AS TOTAL_EMPRESAS FROM EMPRESA;
```
- [ ] Número bate com a lista na aplicação

```sql
-- Total de funcionários
SELECT COUNT(*) AS TOTAL_FUNCIONARIOS FROM FUNCIONARIO;
```
- [ ] Número bate com a lista na aplicação

```sql
-- Funcionários por empresa
SELECT 
    E.RAZAO_SOCIAL AS EMPRESA,
    COUNT(F.ID) AS FUNCIONARIOS
FROM EMPRESA E
LEFT JOIN FUNCIONARIO F ON E.ID = F.EMPRESA_ID
GROUP BY E.RAZAO_SOCIAL
ORDER BY COUNT(F.ID) DESC;
```
- [ ] Números corretos

---

### Teste 19: Funcionários sem Empresa
```sql
SELECT CPF, NOME FROM FUNCIONARIO WHERE EMPRESA_ID IS NULL;
```
- [ ] ?? Se retornar registros, há erro no cadastro!
- [ ] Idealmente deve retornar 0 linhas

---

## ?? TROUBLESHOOTING

### Erros Comuns

#### ? "ORA-00942: a tabela ou view não existe"
- [ ] Verifique: `SELECT table_name FROM user_tables WHERE table_name IN ('EMPRESA', 'FUNCIONARIO');`
- [ ] Se não retornar 2 tabelas, elas não existem

#### ? "ORA-02291: FK violada - chave superior não encontrada"
- [ ] Causa: EMPRESA_ID aponta para empresa que não existe
- [ ] Solução: Cadastre a empresa primeiro

#### ? "ORA-01722: número inválido"
- [ ] Causa: Tentativa de inserir texto em EMPRESA_ID
- [ ] Verificar: código está fazendo `ExecutarEscalar` para buscar ID?

#### ? Combo Empresas vazio
- [ ] Executar: `SELECT COUNT(*) FROM EMPRESA;`
- [ ] Se = 0, cadastre uma empresa primeiro
- [ ] Se > 0, problema na query SELECT RAZAO_SOCIAL

#### ? Funcionário não mostra nome da empresa
- [ ] Verificar: `SELECT F.*, E.RAZAO_SOCIAL FROM FUNCIONARIO F LEFT JOIN EMPRESA E ON F.EMPRESA_ID = E.ID;`
- [ ] Se RAZAO_SOCIAL = NULL, problema no JOIN ou EMPRESA_ID incorreto

---

## ? VALIDAÇÃO FINAL

### Checklist Geral
- [ ] ? Todas as empresas listadas corretamente
- [ ] ? CRUD completo de empresas funciona
- [ ] ? Todos os funcionários listados corretamente
- [ ] ? CRUD completo de funcionários funciona
- [ ] ? Combo de empresas mostra RAZAO_SOCIAL
- [ ] ? EMPRESA_ID é NUMBER (não texto)
- [ ] ? JOIN funciona (mostra nome da empresa)
- [ ] ? FK protege integridade (não permite excluir empresa com funcionários)
- [ ] ? Fotos e logos salvos e carregados
- [ ] ? Sem erros ORA-00942, ORA-02291, ORA-01722
- [ ] ? Dados no Oracle batem com a aplicação

---

## ?? CONCLUSÃO

**Se todos os testes acima passaram:**
? **APLICAÇÃO 100% FUNCIONAL COM ORACLE CLOUD!**

**Próximos passos:**
1. Implementar campos faltantes (TOLERANCIA_MINUTOS, ESCALA_TIPO)
2. Adicionar mais validações
3. Criar relatórios
4. Integrar com registros de ponto

---

**Data:** 2025-11-11  
**Total de testes:** 19  
**Status:** ? Aguardando execução
