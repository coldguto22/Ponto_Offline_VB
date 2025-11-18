-- ============================================================================
-- Script para adicionar coluna IS_ADMIN na tabela FUNCIONARIO
-- Database: Oracle Cloud Autonomous Database
-- ============================================================================

-- Adicionar coluna IS_ADMIN (0 = funcionário normal, 1 = administrador)
ALTER TABLE FUNCIONARIO ADD IS_ADMIN NUMBER(1) DEFAULT 0;

-- Adicionar constraint para garantir valores válidos (0 ou 1)
ALTER TABLE FUNCIONARIO ADD CONSTRAINT chk_is_admin CHECK (IS_ADMIN IN (0, 1));

-- Atualizar funcionários existentes para não-admin (se necessário)
UPDATE FUNCIONARIO SET IS_ADMIN = 0 WHERE IS_ADMIN IS NULL;

-- Commit das alterações
COMMIT;

-- Verificar estrutura atualizada
SELECT column_name, data_type, data_length, nullable, data_default
FROM user_tab_columns
WHERE table_name = 'FUNCIONARIO'
AND column_name = 'IS_ADMIN';

-- Verificar dados
SELECT ID, CPF, NOME, IS_ADMIN FROM FUNCIONARIO;
