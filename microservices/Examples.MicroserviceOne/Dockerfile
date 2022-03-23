FROM  mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /build/src

# --------------------------------------------------------------------------------------
# RESTORE 
# --------------------------------------------------------------------------------------
# - This section copies only the solution and projects files used to restore the needed 
#   NuGet packages.  The restored packages are placed in:  /root/.nuget/packages.
#
# - Since the source of the microservice will change the most often, these layers will
#   be reused and will not have be recreated when the updated source is built. 
# --------------------------------------------------------------------------------------

# Copy microservice components:
COPY ./src/Components/Examples.MicroserviceOne.App/*.csproj ./Components/Examples.MicroserviceOne.App/
COPY ./src/Components/Examples.MicroserviceOne.Domain/*.csproj ./Components/Examples.MicroserviceOne.Domain/
COPY ./src/Components/Examples.MicroserviceOne.Infra/*.csproj ./Components/Examples.MicroserviceOne.Infra/

# Copy microservice unit tests and web host:
COPY ./src/Examples.MicroserviceOne.Tests/*.csproj ./Examples.MicroserviceOne.Tests/
COPY ./src/Examples.MicroserviceOne.WebApi/*.csproj ./Examples.MicroserviceOne.WebApi/

# Copy the solution file to restore all projects:
COPY ./src/Examples.MicroserviceOne.sln ./
RUN dotnet restore 

# # --------------------------------------------------------------------------------------
# # PUBLISH
# # --------------------------------------------------------------------------------------

# Copy all the source and build the microservice.
COPY ./src ./
RUN dotnet publish ./Examples.MicroserviceOne.WebApi/Examples.MicroserviceOne.WebApi.csproj -c release --output ../out --no-restore  /p:DebugType=None

# --------------------------------------------------------------------------------------
# CREATE IMAGE FOR CONTAINER CREATION
# - This stage takes the published output and copies it to a layer
#   belonging to a new Docker image based on the runtime .net image. 
# --------------------------------------------------------------------------------------
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /microservice

LABEL "net-fusion.project.url"="https://github.com/grecosoft/NetFusion"

COPY --from=build-env /build/out ./
ENTRYPOINT ["dotnet", "Examples.MicroserviceOne.WebApi.dll"]
EXPOSE 80