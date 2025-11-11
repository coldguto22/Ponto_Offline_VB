# 📌 CARTÃO DE REFERÊNCIA RÁPIDA - H2

## ⚡ TL;DR - 3 PASSOS

```powershell
# Terminal 1
cd ApiSpringboot
.\mvnw.cmd clean package -DskipTests -q
java -jar target/ApiSpringboot-0.0.1-SNAPSHOT.jar

# Terminal 2
.\TESTE_RAPIDO.ps1

# Navegador
http://localhost:8080/marcacao.html
```

---

## 📍 URLS IMPORTANTES

```
API Base:           http://localhost:8080
Empresas:           http://localhost:8080/api/empresas
Funcionários:       http://localhost:8080/api/funcionarios
Registros:          http://localhost:8080/api/registros
Web Interface:      http://localhost:8080/marcacao.html
H2 Console:         http://localhost:8080/h2-console
```

---

## 🔍 FILTROS DE BUSCA

```
Funcionário por CPF:
GET /api/funcionarios?cpf=12345678901

Registros por Funcionário:
GET /api/registros?funcionarioId=1

Registros por Data:
GET /api/registros?data=2025-11-11
```

---

## 📊 DADOS DE TESTE PADRÃO

**Empresa:**
- ID: 1
- Nome: Empresa Teste H2
- CNPJ: 12345678000100

**Funcionário:**
- ID: 1
- Nome: João Silva
- CPF: 12345678901
- Empresa: 1

**Registro:**
- ID: 1
- Funcionário: 1
- Tipo: ENTRADA
- Data: Hoje
- Hora: Hora atual

---

## H2 CONSOLE

```
URL:      http://localhost:8080/h2-console
JDBC URL: jdbc:h2:mem:ponto
User:     sa
Password: (deixe em branco)
```

---

## COMANDOS RÁPIDOS

### Ver todos os dados
```sql
SELECT * FROM EMPRESA;
SELECT * FROM FUNCIONARIO;
SELECT * FROM REGISTRO_PONTO;
```

### Contar registros
```sql
SELECT COUNT(*) FROM EMPRESA;
SELECT COUNT(*) FROM FUNCIONARIO;
SELECT COUNT(*) FROM REGISTRO_PONTO;
```

### Buscar registros de um funcionário
```sql
SELECT * FROM REGISTRO_PONTO 
WHERE FUNCIONARIO_ID = 1 
ORDER BY DATA DESC;
```

---

## TROUBLESHOOTING

| Problema | Solução |
|----------|---------|
| Port 8080 in use | `taskkill /IM java.exe /F` |
| Script erro | `Set-ExecutionPolicy -ExecutionPolicy RemoteSigned` |
| API não responde | Aguarde 5s após iniciar |
| Sem dados | Execute `TESTE_RAPIDO.ps1` |
| H2 Console erro | `spring.h2.console.enabled=true` |

---

## 📚 DOCUMENTAÇÃO

```
COMECE_AQUI.md              ← Comece aqui!
CHECKLIST_H2.md             ← Verificação
TESTES_COM_H2.md            ← Testes detalhados
ERRO_CONEXAO_BANCO.md       ← Troubleshooting
FLUXO_VISUAL.md             ← Diagramas
TESTE_RAPIDO.ps1            ← Testes automáticos
```

---

## ⌨️ ATALHOS

### Compilar
```powershell
cd ApiSpringboot
.\mvnw.cmd clean package -DskipTests
```

### Rodar
```powershell
java -jar target/ApiSpringboot-0.0.1-SNAPSHOT.jar
```

### Testar
```powershell
.\TESTE_RAPIDO.ps1
```

### Matar java
```powershell
taskkill /IM java.exe /F
```

---

## 🧪 TESTE COM CURL

```powershell
# Listar empresas
curl http://localhost:8080/api/empresas

# Listar funcionários
curl http://localhost:8080/api/funcionarios

# Buscar por CPF
curl "http://localhost:8080/api/funcionarios?cpf=12345678901"

# Listar registros
curl http://localhost:8080/api/registros

# Registros de hoje
curl "http://localhost:8080/api/registros?data=2025-11-11"
```

---

## ✅ VERIFICAÇÃO

```powershell
# 1. API respondendo?
curl http://localhost:8080/api/empresas

# 2. Dados criados?
curl http://localhost:8080/api/registros

# 3. H2 Console?
Abrir http://localhost:8080/h2-console

# 4. Web interface?
Abrir http://localhost:8080/marcacao.html
```

---

## 🎯 PRÓXIMOS PASSOS

1. ✅ Testes com H2 passando
2. ⏳ Integrar SincronizadorPonto.vb no VB.NET
3. ⏳ Criar tela de gestão (frm_registros)
4. ⏳ Implementar JWT
5. ⏳ Migrar para SQL Server

---

## 📞 SUPORTE

- **Rápido:** COMECE_AQUI.md
- **Completo:** TESTES_COM_H2.md
- **Problemas:** ERRO_CONEXAO_BANCO.md
- **Visual:** FLUXO_VISUAL.md

---

**Última atualização:** 11 de Novembro de 2025
**Status:** ✅ Operacional
**Banco:** H2 In-Memory
