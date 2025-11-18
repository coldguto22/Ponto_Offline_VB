-- ============================================================================
-- Script de Verificação das Tabelas Oracle
-- Execute após testar a aplicação VB.NET
-- ============================================================================

-- 1. Verificar estrutura da tabela EMPRESA
SELECT column_name, data_type, data_length, nullable
FROM user_tab_columns
WHERE table_name = 'EMPRESA'
ORDER BY column_id;

-- 2. Verificar estrutura da tabela FUNCIONARIO
SELECT column_name, data_type, data_length, nullable
FROM user_tab_columns
WHERE table_name = 'FUNCIONARIO'
ORDER BY column_id;

-- 3. Listar todas as empresas cadastradas
SELECT 
    ID,
    CNPJ,
    RAZAO_SOCIAL,
    NOME_FANTASIA,
    EMAIL,
    TELEFONE
FROM EMPRESA
ORDER BY RAZAO_SOCIAL;

-- 4. Listar todos os funcionários com suas empresas
SELECT 
    F.ID,
    F.CPF,
    F.NOME,
    F.CARGO,
    E.RAZAO_SOCIAL AS EMPRESA,
  F.DATA_ADMISSAO,
    F.HORARIO
FROM FUNCIONARIO F
LEFT JOIN EMPRESA E ON F.EMPRESA_ID = E.ID
ORDER BY F.NOME;

-- 5. Contar registros por tabela
SELECT 
    'EMPRESA' AS TABELA, 
    COUNT(*) AS TOTAL_REGISTROS
FROM EMPRESA
UNION ALL
SELECT 
    'FUNCIONARIO' AS TABELA,
    COUNT(*) AS TOTAL_REGISTROS
FROM FUNCIONARIO;

-- 6. Verificar funcionários sem empresa (EMPRESA_ID NULL)
SELECT 
    CPF,
    NOME,
    CARGO
FROM FUNCIONARIO
WHERE EMPRESA_ID IS NULL;

-- 7. Verificar integridade referencial (FK)
SELECT 
    constraint_name,
    table_name,
    column_name,
    r_constraint_name
FROM user_cons_columns
WHERE constraint_name IN (
    SELECT constraint_name
    FROM user_constraints
    WHERE table_name IN ('EMPRESA', 'FUNCIONARIO')
 AND constraint_type = 'R'  -- Foreign Key
);

-- 8. Último registro inserido em EMPRESA
SELECT *
FROM EMPRESA
WHERE ID = (SELECT MAX(ID) FROM EMPRESA);

-- 9. Último registro inserido em FUNCIONARIO
SELECT 
    F.*,
    E.RAZAO_SOCIAL AS EMPRESA_NOME
FROM FUNCIONARIO F
LEFT JOIN EMPRESA E ON F.EMPRESA_ID = E.ID
WHERE F.ID = (SELECT MAX(ID) FROM FUNCIONARIO);

-- 10. Funcionários por empresa (resumo)
SELECT 
    E.RAZAO_SOCIAL AS EMPRESA,
    COUNT(F.ID) AS TOTAL_FUNCIONARIOS
FROM EMPRESA E
LEFT JOIN FUNCIONARIO F ON E.ID = F.EMPRESA_ID
GROUP BY E.RAZAO_SOCIAL
ORDER BY COUNT(F.ID) DESC;

-- ============================================================================
-- QUERIES DE TESTE (use conforme necessário)
-- ============================================================================

-- Inserir empresa de teste (se necessário)
-- INSERT INTO EMPRESA (CNPJ, RAZAO_SOCIAL, NOME_FANTASIA, EMAIL, TELEFONE)
-- VALUES ('99999999000199', 'Empresa Teste SQL', 'Teste SQL', 'teste@sql.com', '(11) 99999-9999');
-- COMMIT;

-- Inserir funcionário de teste vinculado à primeira empresa
-- INSERT INTO FUNCIONARIO (CPF, NOME, CARGO, DATA_ADMISSAO, DATA_NASCIMENTO, EMPRESA_ID, FOLHA, HORARIO, PIS)
-- VALUES (
--     '99999999999',
--     'Funcionário Teste',
--     'Testador',
--     TO_DATE('2025-01-01', 'YYYY-MM-DD'),
--     TO_DATE('1990-01-01', 'YYYY-MM-DD'),
--     (SELECT ID FROM EMPRESA WHERE RAZAO_SOCIAL = 'Empresa Teste SQL'),
--     '1',
--     '09:00-18:00',
--     '99999999999'
-- );
-- COMMIT;

-- Limpar tabelas (CUIDADO! Só use em ambiente de teste)
-- DELETE FROM FUNCIONARIO;
-- DELETE FROM EMPRESA;
-- COMMIT;

-- ============================================================================
-- FIM DO SCRIPT
-- ============================================================================
