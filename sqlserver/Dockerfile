FROM mcr.microsoft.com/mssql/server:2022-latest

USER root

COPY init.sql /usr/src/app/init.sql
COPY init.sh /usr/src/app/init.sh

RUN chmod +x /usr/src/app/init.sh

USER mssql

ENTRYPOINT ["/usr/src/app/init.sh"]