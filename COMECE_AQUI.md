# 🎯 GUIA RÁPIDO: Testes com H2 em 5 Minutos

## ⚡ TL;DR (Versão Ultra Rápida)

Abra 2 terminais PowerShell:

### Terminal 1 - Rodar API
```powershell
cd c:\Users\Guto\source\repos\coldguto22\Ponto_Offline_VB\ApiSpringboot
.\mvnw.cmd clean package -DskipTests -q
java -jar target/ApiSpringboot-0.0.1-SNAPSHOT.jar
```

**Resultado:** "Tomcat started on port 8080" ✅

### Terminal 2 - Rodar Testes
```powershell
cd c:\Users\Guto\source\repos\coldguto22\Ponto_Offline_VB
.\TESTE_RAPIDO.ps1
```

**Resultado:** Tela verde com "✅ TODOS OS TESTES PASSARAM!" ✅

---

## 📋 O que cada teste faz:

```
[1/10] Conecta à API
[2/10] Cria uma empresa de teste
[3/10] Lista todas as empresas
[4/10] Cria um funcionário
[5/10] Busca o funcionário por CPF
[6/10] Cria um registro de ponto (ENTRADA)
[7/10] Lista todos os registros
[8/10] Filtra registros por funcionário
[9/10] Filtra registros por data
[10/10] Mostra como acessar o H2 Console
```

---

## 🌐 Testar no Navegador

Depois dos testes passarem:

1. Abra http://localhost:8080/marcacao.html
2. Digite CPF: `12345678901` (criado pelo teste)
3. Clique "Marcar Ponto"
4. Sucesso! 🎉

---

## 🗄️ Ver Banco de Dados (H2 Console)

http://localhost:8080/h2-console

```
JDBC URL: jdbc:h2:mem:ponto
User: sa
Password: (deixe em branco)
```

---

## 🐛 Se Algo Não Funcionar

| Problema | Solução |
|----------|---------|
| "Connection refused" | Certifique-se que o Terminal 1 está rodando (API) |
| "Port 8080 already in use" | Mate o processo anterior: `taskkill /IM java.exe /F` |
| Script não funciona | Execute no PowerShell (admin): `Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser` |

---

## 📁 Arquivos Importantes

| Arquivo | Propósito |
|---------|-----------|
| `ApiSpringboot/src/main/resources/application.properties` | Config do banco (H2 ativado) |
| `ApiSpringboot/src/main/resources/templates/marcacao.html` | Interface web |
| `TESTE_RAPIDO.ps1` | Script de testes automáticos |
| `TESTES_COM_H2.md` | Guia completo com testes manuais |
| `ERRO_CONEXAO_BANCO.md` | Solução de problemas |

---

## ✅ Checklist para Começar

- [ ] Ter 2 terminais PowerShell abertos
- [ ] Terminal 1: Executar API
- [ ] Aguardar "Tomcat started on port 8080"
- [ ] Terminal 2: Executar TESTE_RAPIDO.ps1
- [ ] Ver "✅ TODOS OS TESTES PASSARAM!"
- [ ] Abrir http://localhost:8080/marcacao.html no navegador
- [ ] Testar marcação de ponto com CPF: 12345678901

---

## 🎉 Parabéns!

Se você chegou até aqui, significa que:
- ✅ API está rodando
- ✅ Banco H2 está funcionando
- ✅ Todos os 3 endpoints estão operacionais
- ✅ Interface web está respondendo
- ✅ Pronto para integração no VB.NET!

**Próximo passo:** Integrar `SincronizadorPonto.vb` no seu `frm_menu.vb`

---

**Data:** 2025-11-11
