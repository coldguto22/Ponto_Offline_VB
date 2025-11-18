@echo off
setlocal enabledelayedexpansion

cd /d "%~dp0"

echo ========================================
echo    INICIANDO COM ORACLE CLOUD
echo ========================================
echo.

java ^
  -Djavax.net.ssl.trustStore=C:\Users\Guto\Downloads\Wallet_PontoOfflineDB\truststore.jks ^
  -Djavax.net.ssl.trustStorePassword=Guto081001. ^
  -Djavax.net.ssl.keyStore=C:\Users\Guto\Downloads\Wallet_PontoOfflineDB\keystore.jks ^
  -Djavax.net.ssl.keyStorePassword=Guto081001. ^
  -Doracle.net.tns_admin=C:\Users\Guto\Downloads\Wallet_PontoOfflineDB ^
  -jar target\ApiSpringboot-0.0.1-SNAPSHOT.jar ^
  --spring.profiles.active=oracle

pause
