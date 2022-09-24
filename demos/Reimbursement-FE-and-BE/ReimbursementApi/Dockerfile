# every Dockerfile must start with a base image. This is the .NET6.0 SDK and everything needed to run a .NET program
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

# create a folder inside the Container
WORKDIR /app

# make available port 5222 of application for mapping to the containers port
EXPOSE 5222
# override whatever port the application exposes already.
ENV ASPNETCORE_URLS=http://+:5222

# get the .NET6.0 SDK image for this stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#create a new folder inside the container and (cd into it) to hold the folers and files below
WORKDIR /src

# using EXEC syntax
# cope a file from a location relative to the dockerfile to a location relative to the working directory
COPY ["ApiLayer.sln", "."]
#copy this file into the container => src/ApiLayer/ApiLayer.csproj
COPY ["ApiLayer/ApiLayer.csproj", "ApiLayer/"]
COPY ["BusinessLayer/BusinessLayer.csproj","BusinessLayer/"]
COPY ["ModelsLayer/ModelsLayer.csproj","ModelsLayer/"]
COPY ["RepositoryAccessLayer/RepositoryAccessLayer.csproj","RepositoryAccessLayer/"]

# restore is the first command to running a .NET program. It restores the dependencies and references of the application
# This command restores the app INSIDE tre container.
RUN dotnet restore "ApiLayer\ApiLayer.csproj"

# using shell syntax
# copy the rest of the files and folder into their respective folders. 
# we don't use 'COPY . .'  because each line is a layer in the image, 
# so it's faster on rebuilding images to split the COPY into separate lines
COPY ApiLayer/ ./ApiLayer/
COPY BusinessLayer/ ./BusinessLayer/
COPY ModelsLayer/ ./ModelsLayer/
COPY RepositoryAccessLayer/ ./RepositoryAccessLayer/

# cd into the ApiLayer folder.
WORKDIR "/src/ApiLayer"

# build the .csproj file that is in thefolder that we are currently in.
RUN dotnet build "ApiLayer.csproj" -c Release -o /app/build

# declare a new stage adn name it publish
FROM build AS publish
# publish the app in production env.
RUN dotnet publish "ApiLayer.csproj" -c Release -o /app/publish /p:UseAppHost=false

# another new stage AS final
FROM base AS final

# change over to the app folder
WORKDIR /app

# copy the publish files into the app folder from app/publish
COPY --from=publish /app/publish .

# run the apop.
ENTRYPOINT ["dotnet", "ApiLayer.dll"]
