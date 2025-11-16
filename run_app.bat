@echo off
setlocal enabledelayedexpansion

cd C:\Users\Guto\source\repos\coldguto22\Ponto_Offline_VB\ApiSpringboot

set TNS_ADMIN=C:\Users\Guto\Downloads\Wallet_PontoOfflineDB
set DB_URL=jdbc:oracle:thin:@pontoofflinedb_tp
set DB_USER=TESTE_PONTO
set DB_PASSWORD=Medeixaempaz2001
set DB_DRIVER=oracle.jdbc.OracleDriver
set JPA_DDL_AUTO=update

java -Djavax.net.ssl.trustStore=C:\Users\Guto\Downloads\Wallet_PontoOfflineDB\truststore.jks ^
     -Djavax.net.ssl.trustStorePassword=changeit ^
     -Doracle.net.tns_admin=C:\Users\Guto\Downloads\Wallet_PontoOfflineDB ^
     -Djavax.net.ssl.trustStoreType=JKS ^
     -jar target\ApiSpringboot-0.0.1-SNAPSHOT.jar

pause

