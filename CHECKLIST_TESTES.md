# ✅ Checklist de Testes - Marcação de Ponto Offline/Online

Use este checklist para validar se tudo está funcionando corretamente.

---

## 🧪 Testes Básicos

### **Teste 1: API em execução**
- [ ] Execute: `mvnw.cmd spring-boot:run` na pasta `ApiSpringboot`
- [ ] Acesse: `http://localhost:8080/api/funcionarios`
- [ ] Esperado: JSON vazio ou lista de funcionários
- [ ] Status: HTTP 200

### **Teste 2: Tela web de marcação**
- [ ] Abra: `http://localhost:8080/marcacao`
- [ ] Esperado: Formulário com campo CPF, seletor Tipo e botão "Marcar Ponto"
- [ ] CSS carregado (tela bem formatada): ✅ Sim / ❌ Não

### **Teste 3: Registrar funcionário via API**
```bash
curl -X POST http://localhost:8080/api/funcionarios \
  -H "Content-Type: application/json" \
  -d '{"nome":"João Silva","CPF":"12345678900","cargo":"Desenvolvedor"}'
```
- [ ] Resposta: HTTP 201 Created
- [ ] JSON retornado com ID do funcionário

---

## 🌐 Testes de Integração Web

### **Teste 4: Marcar ponto via Web**
1. [ ] Na tela `/marcacao`, digite: `12345678900` (CPF registrado)
2. [ ] Selecione tipo: `ENTRADA`
3. [ ] Clique em "Marcar Ponto"
4. [ ] Esperado: Mensagem de sucesso "Ponto registrado com sucesso!"
5. [ ] Verifique no banco: `SELECT * FROM registros_ponto WHERE funcionario_id = 1`

### **Teste 5: CPF não encontrado**
1. [ ] Na tela `/marcacao`, digite: `99999999999` (CPF inexistente)
2. [ ] Selecione tipo: `SAIDA`
3. [ ] Clique em "Marcar Ponto"
4. [ ] Esperado: Mensagem "Funcionário não encontrado."

### **Teste 6: Geolocalização (opcional)**
1. [ ] Na tela `/marcacao`, permitir acesso à localização (navegador pedirá)
2. [ ] Marcar ponto normalmente
3. [ ] Verificar no banco: latitude e longitude devem estar preenchidas
```sql
SELECT id, tipo, latitude, longitude FROM registros_ponto ORDER BY id DESC LIMIT 1;
```

---

## 🖥️ Testes de Sincronização (Desktop)

### **Teste 7: Criar tabela pending**
```sql
-- Executar em SQL Server (database PontoOfflineVB)
-- Arquivo: DesktopAppVB/Scripts/criar_tb_registros_ponto_pending.sql
```
- [ ] Tabela `tb_registros_ponto_pending` criada com sucesso
- [ ] Campos presentes: `id`, `funcionario_id`, `data`, `hora`, `tipo`, `latitude`, `longitude`, `sincronizado`, `erro_sincronizacao`

### **Teste 8: Registrar ponto offline (VB.NET)**
```vb
' No formulário do Desktop (após integração)
Dim sync = New SincronizadorPonto()
sync.RegistrarPontoLocal(funcionarioId:=1, tipo:="ENTRADA", latitude:=Nothing, longitude:=Nothing)
```
- [ ] Sucesso: Retorna `True`
- [ ] Banco local: Novo registro em `tb_registros_ponto_pending` com `sincronizado = 0`

### **Teste 9: Sincronização automática**
```vb
' Simular conexão e sincronização
Await sync.SincronizarAsync()
```
- [ ] Verificar banco local: Registro agora tem `sincronizado = 1`
- [ ] Verificar API: `SELECT * FROM registros_ponto` deve mostrar o novo registro
- [ ] Sem erro: `erro_sincronizacao` deve ser NULL

### **Teste 10: Sincronização com erro (sem conexão)**
1. [ ] Desconecte da internet ou parar a API
2. [ ] Registrar ponto: `sync.RegistrarPontoLocal(...)`
3. [ ] Tentar sincronizar: `await sync.SincronizarAsync()`
4. [ ] Esperado: `sincronizado` continua 0 (sem sucesso)
5. [ ] Reconectar / reiniciar API
6. [ ] Sincronização automática (timer) deve enviar o registro

### **Teste 11: Retry automático (timer)**
1. [ ] Desconecte da internet
2. [ ] Registrar 3 pontos offline
3. [ ] Verificar banco: 3 registros com `sincronizado = 0`
4. [ ] Reconectar à internet
5. [ ] Aguardar 30 segundos (intervalo do timer)
6. [ ] Verificar banco: Todos com `sincronizado = 1`
7. [ ] Verificar API: 3 novos registros

---

## 🔍 Testes de CORS

### **Teste 12: CORS from Desktop**
```powershell
# PowerShell — simular chamada do desktop
$uri = "http://localhost:8080/api/funcionarios"
$response = Invoke-WebRequest -Uri $uri -Method Get -Headers @{"Origin" = "http://localhost:3000"}
```
- [ ] Status: 200 (sucesso)
- [ ] Sem erro CORS

### **Teste 13: CORS from Web (navegador)**
- [ ] Abra DevTools (F12) em `/marcacao`
- [ ] Console deve estar vazio (sem erros de CORS)
- [ ] Marcar ponto deve funcionar

---

## 📊 Testes de Dados

### **Teste 14: Busca por CPF**
```bash
curl "http://localhost:8080/api/funcionarios?cpf=12345678900"
```
- [ ] Resposta: JSON com 1 funcionário
- [ ] Status: 200

### **Teste 15: Busca por Empresa**
```bash
curl "http://localhost:8080/api/funcionarios?empresaId=1"
```
- [ ] Resposta: JSON com funcionários dessa empresa
- [ ] Status: 200

### **Teste 16: Filtro de registros por data**
```bash
curl "http://localhost:8080/api/registros?data=2025-11-11"
```
- [ ] Resposta: JSON com registros da data
- [ ] Status: 200

### **Teste 17: Editar registro (PUT)**
```bash
curl -X PUT http://localhost:8080/api/registros/1 \
  -H "Content-Type: application/json" \
  -d '{"tipo":"SAIDA","hora":"17:30:00",...}'
```
- [ ] Status: 200
- [ ] Registro atualizado no banco

### **Teste 18: Deletar registro (DELETE)**
```bash
curl -X DELETE http://localhost:8080/api/registros/1
```
- [ ] Status: 204 (No Content)
- [ ] Registro removido do banco

---

## ⚠️ Testes de Erro

### **Teste 19: Servidor offline**
- [ ] Parar API Spring Boot
- [ ] Tentar acessar `/marcacao`
- [ ] Esperado: Erro de conexão no navegador
- [ ] Reconnect automático: ❌ Não esperado nesta versão

### **Teste 20: Banco vazio**
- [ ] Deletar todos os funcionários
- [ ] Tentar marcar ponto
- [ ] Esperado: Mensagem "Funcionário não encontrado"

### **Teste 21: Campo CPF vazio**
- [ ] Na tela `/marcacao`, deixar CPF em branco
- [ ] Clicar "Marcar Ponto"
- [ ] Esperado: Mensagem de erro (validação client-side)

---

## 🎯 Testes de Performance (opcional)

### **Teste 22: Registros em massa**
- [ ] Registrar 100 pontos rapidamente
- [ ] Verificar: Não deve haver crash ou timeout
- [ ] Tempo de resposta: < 500ms por registro

### **Teste 23: Sincronização em massa**
- [ ] 50 registros offline pendentes
- [ ] Sincronizar todos de uma vez
- [ ] API não deve timeout
- [ ] Todos devem ser sincronizados com sucesso

---

## 📝 Checklist Final

- [ ] Teste 1-6: Testes básicos e web (OBRIGATÓRIO)
- [ ] Teste 7-11: Testes de sincronização (OBRIGATÓRIO)
- [ ] Teste 12-13: CORS (OBRIGATÓRIO)
- [ ] Teste 14-18: CRUD de dados (RECOMENDADO)
- [ ] Teste 19-21: Tratamento de erros (RECOMENDADO)
- [ ] Teste 22-23: Performance (OPCIONAL)

---

## 🆘 Troubleshooting

| Problema | Causa provável | Solução |
|----------|-----------------|---------|
| CORS bloqueado | CorsConfig não aplicada | Verificar `CorsConfig.java` |
| Ponto não sincroniza | API offline | Verificar se `spring-boot:run` está rodando |
| CPF não encontra | CPF com formatação errada | Usar apenas números (ex: 12345678900) |
| Timer não dispara | Timer não iniciado | Chamar `inicializarSincronizacao()` no Load |
| Banco local vazio | Tabela não criada | Executar scripts SQL de criação |

---

Boa sorte nos testes! 🚀
