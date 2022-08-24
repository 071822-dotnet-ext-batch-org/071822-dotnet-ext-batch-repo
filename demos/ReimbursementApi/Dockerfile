FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

EXPOSE 5222
ENV ASPNETCORE_URLS=http://+:5222

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ApiLayer.sln", "."]
COPY ["ApiLayer\ApiLayer.csproj", "ApiLayer/"]
COPY ["BusinessLayer/BusinessLayer.csproj","BusinessLayer/"]
COPY ["ModelsLayer/ModelsLayer.csproj","ModelsLayer/"]
COPY ["RepositoryAccessLayer/RepositoryAccessLayer.csproj","RepositoryAccessLayer/"]

RUN dotnet restore "ApiLayer\ApiLayer.csproj"

#does this create new folders beside the folders created above?
#COPY . .

COPY ApiLayer/ ./ApiLayer/
COPY BusinessLayer/ ./BusinessLayer/
COPY ModelsLayer/ ./ModelsLayer/
COPY RepositoryAccessLayer/ ./RepositoryAccessLayer/

#I'm already inside src... does this create a second src?
WORKDIR "/src/ApiLayer"

#is 'app/build' a path relative to the Dockerfile? (is that how all paths are created?)
RUN dotnet build "ApiLayer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiLayer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiLayer.dll"]
