FROM microsoft/dotnet:latest
WORKDIR /app

# Ctrl+C (or Ctrl+\) to exit interactive environment

# copy csproj and restore as distinct layers
#COPY *.csproj ./
#RUN dotnet restore

# copy and build everything else
COPY ./published ./
#RUN dotnet publish -c Release -o out
ENTRYPOINT ["dotnet", "WebMiningPool.dll"]

# for mysql
# 1. sudo docker pull mysql/mysql-server:8.0
# 2. sudo docker run --name=mysql-dev -p 3306:3306 -d mysql/mysql-server:8.0
# 3. sudo docker logs mysql1 2>&1 | grep GENERATED
#       GENERATED ROOT PASSWORD: Axegh3kAJyDLaRuBemecis&EShOs
# 4. sudo docker exec -it mysql1 mysql -uroot -p
# 5. ALTER USER 'root'@'localhost' IDENTIFIED BY 'password';
#   5.1 CREATE USER 'admin'@'localhost' IDENTIFIED BY 'admin1@3';
#   5.2 CREATE USER 'admin'@'%' IDENTIFIED BY 'admin1@3';
#   5.3 GRANT ALL PRIVILEGES ON *.* TO 'admin'@'localhost';
#   5.4 GRANT ALL PRIVILEGES ON *.* TO 'admin'@'%';
#   5.5 FLUSH PRIVILEGES;
# 6. docker exec -it mysql1 bash, shell> ls
# 7. docker restart mysql1
# 8. docker stop mysql1
# 9. docker rm mysql1