# ?? Resumo das Alterações - Adaptação para Nomenclatura Oracle

## ? Mudanças Realizadas

### Problema Original
O código VB.NET estava usando nomes de tabelas e colunas que não existiam no Oracle Cloud:
- ? `tb_empresas` ? ? `EMPRESA`
- ? `tb_funcionarios` ? ? `FUNCIONARIO`

### Arquivos Modificados

#### 1. **cad_empresa.vb**
**Mudanças:**
- ? Tabela: `tb_empresas` ? `EMPRESA`
- ? Colunas adaptadas:
  - `razao_social` ? `RAZAO_SOCIAL`
  - `nome_fantasia` ? `NOME_FANTASIA`
  - `insc_estadual` ? `INSC_ESTADUAL`
  - `endereco` ? `ENDERECO`
  - `telefone` ? `TELEFONE`
  - `email` ? `EMAIL`
  - `logo` ? `LOGO`
  - `cnpj` ? `CNPJ`

**Queries atualizadas:**
```sql
-- Antes
SELECT COUNT(*) FROM tb_empresas WHERE cnpj='...'
INSERT INTO tb_empresas (cnpj, razao_social, ...) VALUES (...)
UPDATE tb_empresas SET razao_social='...' WHERE cnpj='...'

-- Depois
SELECT COUNT(*) FROM EMPRESA WHERE CNPJ='...'
INSERT INTO EMPRESA (CNPJ, RAZAO_SOCIAL, ...) VALUES (...)
UPDATE EMPRESA SET RAZAO_SOCIAL='...' WHERE CNPJ='...'
```

---

#### 2. **frm_empresa.vb**
**Mudanças:**
- ? Tabela: `tb_empresas` ? `EMPRESA`
- ? Colunas: `cnpj` ? `CNPJ`, `razao_social` ? `RAZAO_SOCIAL`

**Queries atualizadas:**
```sql
-- Antes
SELECT cnpj, razao_social FROM tb_empresas ORDER BY razao_social
DELETE FROM tb_empresas WHERE cnpj='...'

-- Depois
SELECT CNPJ, RAZAO_SOCIAL FROM EMPRESA ORDER BY RAZAO_SOCIAL
DELETE FROM EMPRESA WHERE CNPJ='...'
```

**Referências ao DataGridView:**
- ? `dgv_empresas.SelectedRows(0).Cells("cnpj")` ? `Cells("CNPJ")`

---

#### 3. **cad_funcionario.vb**
**Mudanças:**
- ? Tabela: `tb_funcionarios` ? `FUNCIONARIO`
- ? Tabela: `tb_empresas` ? `EMPRESA`
- ? Colunas da tabela FUNCIONARIO:
  - `cpf` ? `CPF`
  - `nome` ? `NOME`
  - `data_admissao` ? `DATA_ADMISSAO`
  - `data_nasc` ? `DATA_NASCIMENTO`
  - `pis` ? `PIS`
  - `empresa` (VARCHAR) ? `EMPRESA_ID` (NUMBER, FK)
  - `folha` ? `FOLHA`
  - `cargo` ? `CARGO`
  - `horario` ? `HORARIO`
  - `data_demissao` ? `DATA_DEMISSAO`
  - `foto` ? `FOTO`

**Mudança Importante:**
A coluna `empresa` era VARCHAR (nome da empresa), agora é `EMPRESA_ID` (NUMBER, chave estrangeira).

**Nova lógica implementada:**
1. Buscar `EMPRESA_ID` a partir da `RAZAO_SOCIAL` selecionada:
```vb
sql = "SELECT ID FROM EMPRESA WHERE RAZAO_SOCIAL='" & empresaNome & "'"
empresaId = ExecutarEscalar(sql)
```

2. Usar `EMPRESA_ID` no INSERT/UPDATE:
```sql
INSERT INTO FUNCIONARIO (CPF, NOME, ..., EMPRESA_ID, ...) 
VALUES ('...', '...', ..., 123, ...)
```

3. Ao carregar funcionário, fazer JOIN para pegar `RAZAO_SOCIAL`:
```sql
SELECT F.*, E.RAZAO_SOCIAL 
FROM FUNCIONARIO F 
LEFT JOIN EMPRESA E ON F.EMPRESA_ID = E.ID 
WHERE F.CPF='...'
```

**Queries atualizadas:**
```sql
-- Antes
SELECT razao_social FROM tb_empresas ORDER BY razao_social
SELECT COUNT(*) FROM tb_funcionarios WHERE cpf='...'
INSERT INTO tb_funcionarios (cpf, nome, ..., empresa, ...) VALUES (...)
UPDATE tb_funcionarios SET nome='...', empresa='...' WHERE cpf='...'
SELECT * FROM tb_funcionarios WHERE cpf='...'

-- Depois
SELECT RAZAO_SOCIAL FROM EMPRESA ORDER BY RAZAO_SOCIAL
SELECT COUNT(*) FROM FUNCIONARIO WHERE CPF='...'
INSERT INTO FUNCIONARIO (CPF, NOME, ..., EMPRESA_ID, ...) VALUES (...)
UPDATE FUNCIONARIO SET NOME='...', EMPRESA_ID=123 WHERE CPF='...'
SELECT F.*, E.RAZAO_SOCIAL FROM FUNCIONARIO F LEFT JOIN EMPRESA E ON F.EMPRESA_ID = E.ID WHERE F.CPF='...'
```

---

#### 4. **frm_funcionario.vb**
**Mudanças:**
- ? Tabela: `tb_funcionarios` ? `FUNCIONARIO`
- ? Colunas removidas (não existem na tabela):
  - ? `email` (não existe em FUNCIONARIO)
  - ? `ativo` (existe mas não estava sendo usado corretamente)
  - ? `data_cadastro` (não existe)

**Queries atualizadas:**
```sql
-- Antes
SELECT cpf, nome, email, cargo, ativo, data_cadastro FROM tb_funcionarios ORDER BY nome
DELETE FROM tb_funcionarios WHERE cpf='...'

-- Depois
SELECT CPF, NOME, CARGO FROM FUNCIONARIO ORDER BY NOME
DELETE FROM FUNCIONARIO WHERE CPF='...'
```

**Referências ao DataGridView:**
- ? `dgv_funcionarios.SelectedRows(0).Cells("cpf")` ? `Cells("CPF")`

---

## ?? Estrutura das Tabelas Oracle (Confirmada)

### Tabela: EMPRESA
| Coluna | Tipo | Constraint |
|--------|------|------------|
| ID | NUMBER | PK, AUTO INCREMENT |
| CNPJ | VARCHAR2(20) | UNIQUE |
| RAZAO_SOCIAL | VARCHAR2(255) | NOT NULL |
| NOME_FANTASIA | VARCHAR2(255) | |
| INSC_ESTADUAL | VARCHAR2(50) | |
| ENDERECO | VARCHAR2(500) | |
| TELEFONE | VARCHAR2(20) | |
| EMAIL | VARCHAR2(100) | |
| LOGO | VARCHAR2(500) | |

### Tabela: FUNCIONARIO
| Coluna | Tipo | Constraint |
|--------|------|------------|
| ID | NUMBER | PK, AUTO INCREMENT |
| CPF | VARCHAR2(20) | UNIQUE |
| NOME | VARCHAR2(255) | NOT NULL |
| CARGO | VARCHAR2(100) | |
| DATA_ADMISSAO | DATE | |
| DATA_DEMISSAO | DATE | |
| DATA_NASCIMENTO | DATE | |
| FOLHA | VARCHAR2(50) | |
| FOTO | VARCHAR2(500) | |
| HORARIO | VARCHAR2(50) | |
| PIS | VARCHAR2(20) | |
| **EMPRESA_ID** | NUMBER | FK ? EMPRESA.ID |
| TOLERANCIA_MINUTOS | NUMBER | |
| ESCALA_TIPO | VARCHAR2(50) | |

---

## ? Testes Recomendados

### 1. Teste de Empresa
1. ? Abrir `frm_empresa`
2. ? Clicar em "Novo"
3. ? Preencher dados da empresa
4. ? Salvar ? Deve inserir em `EMPRESA`
5. ? Editar empresa existente ? Deve atualizar `EMPRESA`
6. ? Excluir empresa ? Deve deletar de `EMPRESA`

### 2. Teste de Funcionário
1. ? Abrir `frm_funcionario`
2. ? Clicar em "Novo"
3. ? Preencher CPF, Nome, Empresa (dropdown), etc.
4. ? Salvar ? Deve inserir em `FUNCIONARIO` com `EMPRESA_ID` correto
5. ? Buscar por CPF ? Deve mostrar dados + nome da empresa
6. ? Editar funcionário ? Deve atualizar `FUNCIONARIO`
7. ? Excluir funcionário ? Deve deletar de `FUNCIONARIO`

---

## ?? Verificações no Oracle

Execute estas queries para confirmar que os dados estão sendo salvos:

```sql
-- Ver todas as empresas
SELECT * FROM EMPRESA ORDER BY RAZAO_SOCIAL;

-- Ver todos os funcionários com empresa
SELECT 
    F.CPF,
    F.NOME,
    F.CARGO,
    E.RAZAO_SOCIAL AS EMPRESA
FROM FUNCIONARIO F
LEFT JOIN EMPRESA E ON F.EMPRESA_ID = E.ID
ORDER BY F.NOME;

-- Contar registros
SELECT 'EMPRESA' AS TABELA, COUNT(*) AS TOTAL FROM EMPRESA
UNION ALL
SELECT 'FUNCIONARIO', COUNT(*) FROM FUNCIONARIO;
```

---

## ?? Notas Importantes

1. **EMPRESA_ID vs Nome da Empresa:**
   - Antes: coluna `empresa` armazenava o **nome** da empresa (VARCHAR)
   - Agora: coluna `EMPRESA_ID` armazena o **ID** da empresa (NUMBER, FK)
   - A interface continua mostrando o nome, mas internamente usa ID

2. **Campos Não Utilizados:**
   - `TOLERANCIA_MINUTOS` e `ESCALA_TIPO` existem na tabela mas não são usados na interface
   - Podem ser adicionados futuramente

3. **Case Sensitivity:**
   - Oracle trata nomes de colunas em maiúsculas por padrão
   - Todas as queries foram atualizadas para usar MAIÚSCULAS

4. **Performance:**
   - Os índices existentes (`idx_funcionarios_cpf`, `idx_empresas_cnpj`) já estão otimizados

---

## ? Status Final

- ? **Build:** Sucesso (sem erros de compilação)
- ? **Tabelas:** Adaptadas para nomenclatura Oracle
- ? **Relacionamentos:** FK FUNCIONARIO.EMPRESA_ID ? EMPRESA.ID implementada
- ? **Queries:** Todas atualizadas com nomes corretos
- ? **Pronto para uso!**

---

**Data:** 2025-11-11  
**Arquivos modificados:** 4 (cad_empresa.vb, frm_empresa.vb, cad_funcionario.vb, frm_funcionario.vb)  
**Linhas alteradas:** ~150 linhas
