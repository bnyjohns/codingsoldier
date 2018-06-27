#aspnet core build image
FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out



#aspnet core runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app

#nginx install
RUN apt-get update
RUN apt-get install -y nginx

#copy startup.sh with correct permissions
COPY ./startup.sh .
RUN chmod 755 /app/startup.sh

#copy nginx.conf
RUN rm /etc/nginx/nginx.conf
COPY nginx.conf /etc/nginx

#expose 2350 - aspnet core site will listen on this port
#expose 80 - nginx will listen on this port.
#Both ports are internal to the host. 
#While running the image, port mapping need to be mentioned: $ docker run -p 8080:80 codingsoldier-with-nginx
EXPOSE 2350 80

#copying output of "build-env" from "/app/out" to "."
COPY --from=build-env /app/out .
CMD ["sh", "/app/startup.sh"]


#Docker Commands:
#$ docker build -t codingsoldier-with-nginx .
#$ docker run -p 8080:80 codingsoldier-with-nginx