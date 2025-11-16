@echo off
REM Script para rodar a aplicacao com H2 (sem Oracle)
cd /d "%~dp0"

echo.
echo ========================================
echo    INICIANDO COM H2 (IN-MEMORY)
echo ========================================
echo.

REM Sem definir DB_URL, vai usar H2 como default

java -jar target\ApiSpringboot-0.0.1-SNAPSHOT.jar

pause
