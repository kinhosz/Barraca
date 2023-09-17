## run server
dotnet watch run --launcher-profile https

## run sql-server
sudo systemctl start mssql-server
sudo systemctl status mssql-server

## migrations
dotnet ef migrations add NomeDaMigracao

dotnet ef database update