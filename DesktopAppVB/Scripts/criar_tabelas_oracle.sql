-- ============================================================================
-- Script de criação de tabelas para Oracle Cloud Autonomous Database
-- Database: PontoOfflineVB (Oracle Cloud)
-- ============================================================================

-- Tabela de Empresas
CREATE TABLE tb_empresas (
    id NUMBER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    cnpj VARCHAR2(20) NOT NULL UNIQUE,
razao_social VARCHAR2(255) NOT NULL,
    nome_fantasia VARCHAR2(255),
    insc_estadual VARCHAR2(50),
    endereco VARCHAR2(500),
    telefone VARCHAR2(20),
    email VARCHAR2(100),
    logo VARCHAR2(500),
    criado_em TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Tabela de Funcionários
CREATE TABLE tb_funcionarios (
    id NUMBER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
 cpf VARCHAR2(20) NOT NULL UNIQUE,
    nome VARCHAR2(255) NOT NULL,
 data_admissao DATE,
    data_nasc DATE,
    pis VARCHAR2(20),
    empresa VARCHAR2(255),
    folha VARCHAR2(50),
  cargo VARCHAR2(100),
    horario VARCHAR2(50),
 data_demissao DATE,
    foto VARCHAR2(500),
  ativo NUMBER(1) DEFAULT 1,
    email VARCHAR2(100),
    data_cadastro TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT chk_ativo CHECK (ativo IN (0, 1))
);

-- Tabela de Registros de Ponto
CREATE TABLE tb_registros_ponto (
    id NUMBER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    funcionario_cpf VARCHAR2(20) NOT NULL,
    data DATE NOT NULL,
    hora TIMESTAMP NOT NULL,
    tipo VARCHAR2(16) NOT NULL,
    latitude BINARY_DOUBLE,
    longitude BINARY_DOUBLE,
    criado_em TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT fk_funcionario_registro FOREIGN KEY (funcionario_cpf) 
     REFERENCES tb_funcionarios(cpf),
    CONSTRAINT chk_tipo CHECK (tipo IN ('ENTRADA', 'SAIDA'))
);

-- Índices para performance
CREATE INDEX idx_funcionarios_cpf ON tb_funcionarios(cpf);
CREATE INDEX idx_funcionarios_empresa ON tb_funcionarios(empresa);
CREATE INDEX idx_empresas_cnpj ON tb_empresas(cnpj);
CREATE INDEX idx_registros_data ON tb_registros_ponto(data);
CREATE INDEX idx_registros_funcionario ON tb_registros_ponto(funcionario_cpf);

-- Comentários nas tabelas
COMMENT ON TABLE tb_empresas IS 'Tabela de cadastro de empresas';
COMMENT ON TABLE tb_funcionarios IS 'Tabela de cadastro de funcionários';
COMMENT ON TABLE tb_registros_ponto IS 'Tabela de registros de ponto dos funcionários';

-- Dados de teste (opcional)
-- Empresa de exemplo
INSERT INTO tb_empresas (cnpj, razao_social, nome_fantasia, insc_estadual, endereco, telefone, email)
VALUES ('12345678000100', 'Empresa Teste LTDA', 'Empresa Teste', '123456789', 'Rua Teste, 123', '(11) 99999-9999', 'contato@teste.com');

COMMIT;
