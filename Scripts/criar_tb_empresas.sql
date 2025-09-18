-- Script para criação da tabela de empresas
CREATE TABLE tb_empresas (
    cnpj VARCHAR(18) PRIMARY KEY,
    razao_social VARCHAR(100) NOT NULL,
    nome_fantasia VARCHAR(100),
    insc_estadual VARCHAR(30),
    endereco VARCHAR(150),
    telefone VARCHAR(20),
    email VARCHAR(100)
);