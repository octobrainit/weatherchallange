#start SQL Server, start the script to create/setup the DB
sleep 10s
echo "running set up script"
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Pl33nkml1. -d master -i data_definition_language.sql -i data_manipulation_language.sql  & /opt/mssql/bin/sqlservr