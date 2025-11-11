-- Script para criação da tabela de registros de ponto pendentes (sincronização offline)
-- Esta tabela armazena registros feitos offline no desktop
-- Quando houver conexão, o sistema envia esses registros à API e limpa a tabela

CREATE TABLE tb_registros_ponto_pending (
    id BIGINT PRIMARY KEY IDENTITY(1,1),
    funcionario_id BIGINT NOT NULL,
    data DATE NOT NULL,
    hora TIME NOT NULL,
    tipo NVARCHAR(16) NOT NULL, -- ENTRADA ou SAIDA
    latitude FLOAT NULL,
    longitude FLOAT NULL,
    criado_em DATETIME DEFAULT GETDATE(),
    sincronizado BIT DEFAULT 0, -- 0 = não sincronizado, 1 = sincronizado
    erro_sincronizacao NVARCHAR(MAX) NULL, -- armazena erro se houver
    CONSTRAINT fk_funcionario_pending FOREIGN KEY (funcionario_id)
        REFERENCES tb_funcionarios(id)
);

-- Criar índice para melhorar performance de busca por sincronizados
CREATE INDEX idx_sincronizado ON tb_registros_ponto_pending(sincronizado);
