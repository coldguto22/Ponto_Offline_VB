# ?? Guia Rápido de Testes - Aplicação Adaptada para Oracle

## ? Pré-requisitos

Antes de testar, certifique-se que:
- ? Tabelas `EMPRESA` e `FUNCIONARIO` existem no Oracle Cloud
- ? Conexão Oracle está configurada no `App.config`
- ? Wallet está no caminho correto: `C:\Users\Guto\Downloads\Wallet_PontoOfflineDB`
- ? Aplicação VB.NET compilada com sucesso

---

## ?? Teste 1: Cadastrar Empresa

### Passos:
1. **Abrir aplicação VB.NET**
2. **Menu principal** ? Clicar em "Empresas"
3. **Tela Empresas** ? Clicar em "Novo"
4. **Preencher dados:**
   - CNPJ: `12.345.678/0001-90`
   - Razão Social: `Teste Oracle LTDA`
   - Nome Fantasia: `Teste Oracle`
   - Inscrição Estadual: `123456789`
   - Endereço: `Rua Oracle, 100`
   - Telefone: `(11) 98765-4321`
   - Email: `contato@teste-oracle.com`
5. **Clicar em "Concluir"**

### Resultado Esperado:
- ? Mensagem: "Empresa cadastrada com sucesso!"
- ? Tela limpa automaticamente
- ? Empresa aparece na lista (frm_empresa)

### Verificar no Oracle:
```sql
SELECT * FROM EMPRESA WHERE CNPJ = '12345678000190';
```

---

## ?? Teste 2: Editar Empresa

### Passos:
1. **Tela Empresas** ? Selecionar empresa cadastrada
2. **Clicar em "Editar"**
3. **Modificar dados:**
   - Telefone: `(11) 91111-2222`
   - Email: `novo@teste-oracle.com`
4. **Clicar em "Concluir"**

### Resultado Esperado:
- ? Mensagem: "Empresa atualizada com sucesso!"
- ? Dados atualizados na lista

### Verificar no Oracle:
```sql
SELECT TELEFONE, EMAIL 
FROM EMPRESA 
WHERE CNPJ = '12345678000190';
```

---

## ?? Teste 3: Cadastrar Funcionário

### Passos:
1. **Menu principal** ? Clicar em "Funcionários"
2. **Tela Funcionários** ? Clicar em "Novo"
3. **Preencher dados:**
   - CPF: `123.456.789-00`
   - Nome: `João da Silva Oracle`
   - Data Admissão: `01/01/2025`
   - Data Nascimento: `15/05/1990`
   - PIS: `12345678901`
 - **Empresa:** Selecionar "Teste Oracle LTDA" (dropdown)
 - Folha: `5`
   - Cargo: `Desenvolvedor`
   - Horário: `09:00-18:00`
   - Foto (opcional): Selecionar uma imagem
4. **Clicar em "Concluir"**

### Resultado Esperado:
- ? Mensagem: "Funcionário cadastrado com sucesso!"
- ? Tela limpa automaticamente
- ? Funcionário aparece na lista (frm_funcionario)

### Verificar no Oracle:
```sql
SELECT 
    F.CPF,
    F.NOME,
    F.CARGO,
    E.RAZAO_SOCIAL AS EMPRESA
FROM FUNCIONARIO F
LEFT JOIN EMPRESA E ON F.EMPRESA_ID = E.ID
WHERE F.CPF = '12345678900';
```

**Importante:** Verifique se `EMPRESA_ID` não está NULL e se `RAZAO_SOCIAL` aparece corretamente!

---

## ?? Teste 4: Buscar Funcionário por CPF

### Passos:
1. **Tela Cadastro Funcionário** (cad_funcionario)
2. **Digitar CPF:** `123.456.789-00`
3. **Clicar fora do campo CPF** (LostFocus)

### Resultado Esperado:
- ? Todos os campos preenchidos automaticamente
- ? Empresa selecionada: "Teste Oracle LTDA"
- ? Foto carregada (se foi cadastrada)

---

## ?? Teste 5: Editar Funcionário

### Passos:
1. **Tela Funcionários** ? Selecionar funcionário
2. **Clicar em "Atualizar"**
3. **Modificar dados:**
   - Cargo: `Desenvolvedor Sênior`
   - Horário: `10:00-19:00`
4. **Clicar em "Concluir"**

### Resultado Esperado:
- ? Mensagem: "Funcionário atualizado com sucesso!"
- ? Dados atualizados na lista

### Verificar no Oracle:
```sql
SELECT CARGO, HORARIO 
FROM FUNCIONARIO 
WHERE CPF = '12345678900';
```

---

## ?? Teste 6: Excluir Funcionário

### Passos:
1. **Tela Funcionários** ? Selecionar funcionário
2. **Clicar em "Excluir"**
3. **Confirmar exclusão** ? Clicar "Sim"

### Resultado Esperado:
- ? Mensagem: "Funcionário excluído com sucesso!"
- ? Funcionário removido da lista

### Verificar no Oracle:
```sql
SELECT COUNT(*) FROM FUNCIONARIO WHERE CPF = '12345678900';
-- Deve retornar 0
```

---

## ?? Teste 7: Excluir Empresa

### Passos:
1. **Tela Empresas** ? Selecionar empresa
2. **Clicar em "Excluir"**
3. **Confirmar exclusão** ? Clicar "Sim"

### Resultado Esperado:
- ? Se não tiver funcionários vinculados: "Empresa excluída com sucesso!"
- ? Se tiver funcionários: Erro de FK (esperado, é proteção de integridade)

### Verificar no Oracle:
```sql
SELECT COUNT(*) FROM EMPRESA WHERE CNPJ = '12345678000190';
-- Deve retornar 0 (se não tiver FK)
```

---

## ?? Troubleshooting

### Erro: "ORA-00942: a tabela ou view não existe"
**Causa:** Tabelas EMPRESA ou FUNCIONARIO não foram criadas  
**Solução:** Execute os comandos CREATE TABLE no Oracle (veja estrutura na imagem)

### Erro: "ORA-02291: restrição de integridade violada - chave superior não encontrada"
**Causa:** EMPRESA_ID não existe na tabela EMPRESA  
**Solução:** Certifique-se de cadastrar a empresa **antes** do funcionário

### Erro: "ORA-01722: número inválido"
**Causa:** Tentativa de inserir texto em EMPRESA_ID (que é NUMBER)  
**Solução:** Verifique se a query está usando `ExecutarEscalar` para buscar o ID

### Combo Empresa vazio
**Causa:** Query SELECT RAZAO_SOCIAL FROM EMPRESA não retorna dados  
**Solução:** 
1. Verifique se há empresas cadastradas
2. Execute: `SELECT * FROM EMPRESA;` no Oracle

### Funcionário não mostra empresa
**Causa:** EMPRESA_ID está NULL ou empresa foi deletada  
**Solução:**
1. Verifique: `SELECT EMPRESA_ID FROM FUNCIONARIO WHERE CPF='...'`
2. Se NULL, edite e selecione uma empresa

---

## ? Checklist de Validação Final

Após todos os testes:

- [ ] ? Empresas são listadas corretamente em frm_empresa
- [ ] ? Nova empresa é inserida em EMPRESA (verificado no Oracle)
- [ ] ? Empresa pode ser editada e atualizada
- [ ] ? Combo de empresas no cadastro de funcionário mostra RAZAO_SOCIAL
- [ ] ? Funcionários são listados em frm_funcionario com NOME e CARGO
- [ ] ? Novo funcionário é inserido em FUNCIONARIO com EMPRESA_ID correto
- [ ] ? Busca por CPF preenche dados + nome da empresa
- [ ] ? Funcionário pode ser editado e atualizado
- [ ] ? Foto do funcionário é salva e carregada corretamente
- [ ] ? Exclusões funcionam (com proteção de FK para empresas)
- [ ] ? Dados no Oracle estão corretos (use Scripts/verificar_dados_oracle.sql)

---

## ?? Queries de Validação Rápida

Execute no Oracle Cloud para validar tudo:

```sql
-- Ver empresas e funcionários vinculados
SELECT 
    E.RAZAO_SOCIAL AS EMPRESA,
    COUNT(F.ID) AS TOTAL_FUNCIONARIOS,
 STRING_AGG(F.NOME, ', ') AS NOMES
FROM EMPRESA E
LEFT JOIN FUNCIONARIO F ON E.ID = F.EMPRESA_ID
GROUP BY E.RAZAO_SOCIAL
ORDER BY E.RAZAO_SOCIAL;

-- Ver todos os funcionários com detalhes
SELECT 
    F.CPF,
    F.NOME,
    F.CARGO,
    E.RAZAO_SOCIAL AS EMPRESA,
    F.DATA_ADMISSAO,
    F.HORARIO,
    CASE WHEN F.FOTO IS NOT NULL THEN 'Sim' ELSE 'Não' END AS TEM_FOTO
FROM FUNCIONARIO F
LEFT JOIN EMPRESA E ON F.EMPRESA_ID = E.ID
ORDER BY F.NOME;
```

---

**Data:** 2025-11-11  
**Status:** ? Aplicação adaptada e pronta para testes  
**Próximo:** Execute os testes acima e valide cada funcionalidade!
