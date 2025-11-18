# Ponto Offline VB

Sistema integrado para registro de ponto pensado para empresas que precisam de controle simples, confiável e rápido, com marcações realizadas via web/API.

Este README apresenta o sistema de forma direta e comercial. Informações técnicas e instruções detalhadas de instalação estão separadas por módulo e podem ser consultadas nos links ao final.

## O que é o Ponto Offline VB

- Plataforma completa de marcação de ponto composta por:
  - Aplicativo de mesa (Windows) para cadastros de funcionários e empresas
  - Portal web para marcação e consulta via navegador, com sincronização automática.
  - API segura para integração com outros sistemas e relatórios.

## Para quem é

- Pequenas e médias empresas que precisam registrar jornada com praticidade.
- Times em campo ou em locais com internet instável.
- Organizações que desejam manter os dados centralizados e auditáveis.

## Principais benefícios

- Praticidade: marcações via navegador, sem instalação nas estações.
- Simplicidade: uso intuitivo em desktop e no navegador (PC ou celular).
- Confiabilidade: histórico centralizado, com trilha de auditoria.
- Flexibilidade: integra com banco existente (ex.: Oracle) e com outros sistemas via API.

## O que o sistema faz

- Marcação de ponto (entrada/saída) por CPF, na interface web.
- Cadastro básico de Funcionários e Empresas.
- Consulta de registros e espelho de ponto.
- Armazenamento centralizado em banco relacional.
- Processamento centralizado dos registros em tempo real.

## Como funciona (visão simples)

1. O colaborador registra o ponto pelo navegador (interface web).
2. Se não houver internet, o registro fica salvo localmente e é enviado depois.
3. A API centraliza as informações e permite integração e relatórios.

## Módulos do sistema

- DesktopAppVB (Windows): gestão de cadastros (Funcionários e Empresas). Não realiza marcações de ponto.
- ApiSpringboot (Web): portal de marcação e API para integrações e relatórios.

Quer detalhes técnicos de instalação, perfis de banco e scripts? Consulte:

- Desktop (técnico): `DesktopAppVB/README_COMPLETO.md`
- API (técnico): `ApiSpringboot/HELP.md`

## Avaliação rápida (sem falar “tecnicês”)

1. Abra o arquivo `BOAS_VINDAS.txt` para um tour visual de 2 minutos.
2. Inicie o sistema seguindo o passo a passo do arquivo `COMECE_AQUI.md`.
3. Acesse a interface web de marcação e faça um teste de registro.

## Requisitos (resumo)

- Estações Windows para uso do aplicativo de cadastros.
- Servidor local ou em nuvem para hospedar a API.
- Banco de dados relacional (ex.: Oracle). O sistema se adapta ao seu ambiente.

## Segurança e conformidade

- Perfis de acesso e boas práticas de privacidade.
- Registro de ações e trilha de auditoria.
- Adequação a políticas internas e à LGPD (orientações disponíveis na documentação técnica).

## Roadmap (alto nível)

- Relatórios gerenciais e exportação (PDF/CSV).
- Autenticação avançada (ex.: Single Sign-On/JWT).
- Painéis de presença e notificações.

## Suporte e contato

- Precisa de ajuda para implantação ou migração de banco? Consulte `ERRO_CONEXAO_BANCO.md` e os guias na pasta de documentação.
- Dúvidas comerciais ou parceria: abra uma issue no repositório com o assunto “Comercial”.

---

### Documentação técnica por módulo

- Desktop (instalação, configuração e scripts): `DesktopAppVB/README_COMPLETO.md`
- API (perfis, bancos e execução): `ApiSpringboot/HELP.md`

Para um índice completo de materiais, consulte `INDICE.md`.
