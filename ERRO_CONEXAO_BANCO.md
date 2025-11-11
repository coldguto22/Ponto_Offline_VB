# 🔴 Erro de Conexão ao Banco de Dados

## Problema Identificado

Ao rodar a API com `mvnw.cmd spring-boot:run`, você recebeu:

```
The server sqlexpress is not configured to listen with TCP/IP
```

## Por que ocorre?

O driver JDBC do SQL Server tenta se conectar via **TCP/IP**, que precisa estar habilitado no SQL Server. Sem isso, não há comunicação entre a aplicação Java e o banco de dados.

## ✅ Solução

Você tem 2 opções:

### **Opção 1: Habilitar TCP/IP no SQL Server (Permanente)**

**Passos:**

1. Abra **SQL Server Configuration Manager**
   - No Windows, procure por `SQL Server Configuration Manager` no menu Iniciar
   
2. Na árvore à esquerda, navegue para:
   ```
   SQL Server Network Configuration 
   → Protocols for SQLEXPRESS
   ```

3. Clique com direito em **TCP/IP** e selecione **Enable**

4. Na aba **IP Addresses**, certifique-se de que:
   - IPAll → TCP Port = **1433** (ou a porta usada)

5. Reinicie o serviço SQL Server:
   - Procure por **Services** no Windows
   - Localize `SQL Server (SQLEXPRESS)`
   - Clique direito → Restart

6. Agora a API deve conectar normalmente:
   ```bash
   cd ApiSpringboot
   .\mvnw.cmd spring-boot:run
   ```

### **Opção 2: Usar H2 Para Testes Rápidos (Temporário)**

Se não quiser configurar TCP/IP agora, use o banco H2 em memória (está já configurado):

```bash
cd ApiSpringboot
.\mvnw.cmd clean package -DskipTests -q
java -jar target/ApiSpringboot-0.0.1-SNAPSHOT.jar
```

**Vantagens do H2:**
- ✅ Sem instalação de banco externo
- ✅ Rápido para testes
- ✅ Dados em memória (reset a cada execução)

**Desvantagens:**
- ❌ Dados perdidos ao fechar a aplicação
- ❌ Apenas para desenvolvimento/testes

### **Opção 3: Usar TCP Pipe (Windows Named Pipes)**

Se TCP/IP não puder ser habilitado, use Named Pipes:

Na `application.properties`, troque:
```properties
spring.datasource.url=jdbc:sqlserver://DESKTOP-BNHPJH3\\SQLEXPRESS;databaseName=PontoOfflineVB
```

Por:
```properties
spring.datasource.url=jdbc:sqlserver://DESKTOP-BNHPJH3;instanceName=SQLEXPRESS;databaseName=PontoOfflineVB;integratedSecurity=true
```

E adicione a dependência no `pom.xml`:
```xml
<dependency>
    <groupId>com.microsoft.sqlserver</groupId>
    <artifactId>mssql-jdbc</artifactId>
    <version>13.2.1.jre11</version>
    <scope>runtime</scope>
</dependency>
```

---

## 📋 Status Atual

- ✅ **Driver SQL Server adicionado** ao `pom.xml`
- ✅ **H2 configurado** como banco de teste
- ✅ **API iniciada com sucesso** na porta **8080**
- ✅ **Endpoints disponíveis** em `http://localhost:8080/api/*`

## 🧪 Testando a API

Com H2 rodando, você pode testar os endpoints:

```bash
# Criar empresa
curl -X POST http://localhost:8080/api/empresas \
  -H "Content-Type: application/json" \
  -d '{"nome":"Empresa Teste","cnpj":"12345678000100"}'

# Listar empresas
curl http://localhost:8080/api/empresas
```

## 📝 Próximos Passos

1. **Se usou H2:** Configure TCP/IP no SQL Server para produção
2. **Se usou TCP/IP:** Integre o app VB.NET com a API
3. Teste os endpoints da API com o `marcacao.html`
4. Implemente sincronização offline com `SincronizadorPonto.vb`

---

**Última atualização:** 2025-11-11 às 09:42
