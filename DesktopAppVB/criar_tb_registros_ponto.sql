-- Script para criação da tabela de registros de ponto
CREATE TABLE tb_registros_ponto (
    id BIGINT PRIMARY KEY IDENTITY(1,1),
    funcionario_id BIGINT NOT NULL,
    data DATE NOT NULL,
    hora TIME NOT NULL,
    tipo NVARCHAR(16) NOT NULL, -- ENTRADA ou SAIDA
    latitude FLOAT NULL,
    longitude FLOAT NULL,
    CONSTRAINT fk_funcionario_registro FOREIGN KEY (funcionario_id)
        REFERENCES tb_funcionarios(id)
);
