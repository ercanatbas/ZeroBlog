FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/", "."]
RUN dotnet restore "app/ZBlog.Api/ZBlog.Api.csproj"
WORKDIR /src/app/ZBlog.Api/
RUN dotnet build "ZBlog.Api.csproj" -c Release -o /app

WORKDIR .
RUN dotnet test

WORKDIR /src/app/ZBlog.Api/
FROM build AS publish
RUN dotnet publish "ZBlog.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ZBlog.Api.dll"]