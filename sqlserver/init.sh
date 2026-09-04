#!/bin/bash
set -e

/opt/mssql/bin/sqlservr &

echo "Esperando SQL Server..."

until /opt/mssql-tools18/bin/sqlcmd \
    -S localhost \
    -U sa \
    -P "$MSSQL_SA_PASSWORD" \
    -C \
    -Q "SELECT 1" > /dev/null 2>&1
do
    sleep 2
done

if ! /opt/mssql-tools18/bin/sqlcmd \
    -S localhost \
    -U sa \
    -P "$MSSQL_SA_PASSWORD" \
    -C \
    -h -1 \
    -W \
    -Q "IF DB_ID('Gestion_Eventos') IS NULL SELECT 0 ELSE SELECT 1" \
    | grep -Eq '^[[:space:]]*1[[:space:]]*$'
then
    /opt/mssql-tools18/bin/sqlcmd \
        -S localhost \
        -U sa \
        -P "$MSSQL_SA_PASSWORD" \
        -C \
        -b \
        -i /usr/src/app/init.sql
fi

echo "Base de datos inicializada."

wait