# escape=`

ARG RELEASE_VER=1.0.0.0
ARG RID=any
ARG NUGET_URL=https://api.nuget.org/v3/index.json
ARG NUGET_KEY

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG RID
# Copy csproj and restore as distinct layers
WORKDIR /code
COPY ["src/BNet.Extensions.Microsoft.DependencyInjection/BNet.Extensions.Microsoft.DependencyInjection.csproj", "src/BNet.Extensions.Microsoft.DependencyInjection/"]
RUN dotnet restore `
    /code/src/BNet.Extensions.Microsoft.DependencyInjection/BNet.Extensions.Microsoft.DependencyInjection.csproj `
    --runtime $RID

COPY ["src/BNet.Extensions.Microsoft.DependencyInjection", "src/BNet.Extensions.Microsoft.DependencyInjection"]
ARG RELEASE_VER
RUN dotnet build `
    /code/src/BNet.Extensions.Microsoft.DependencyInjection/BNet.Extensions.Microsoft.DependencyInjection.csproj `
    -c Release `
    --runtime $RID `
    /p:Version=$RELEASE_VER `
    --no-restore `
    -o /app/build

FROM build AS test
ARG RID
WORKDIR /code
COPY ["tests/BNet.Extensions.Microsoft.DependencyInjection.Tests/BNet.Extensions.Microsoft.DependencyInjection.Tests.csproj", "tests/BNet.Extensions.Microsoft.DependencyInjection.Tests/"]
RUN dotnet restore `
    /code/tests/BNet.Extensions.Microsoft.DependencyInjection.Tests/BNet.Extensions.Microsoft.DependencyInjection.Tests.csproj `
    --runtime $RID

COPY ["tests/BNet.Extensions.Microsoft.DependencyInjection.Tests", "tests/BNet.Extensions.Microsoft.DependencyInjection.Tests"]
ARG RELEASE_VER
RUN dotnet test `
    /code/tests/BNet.Extensions.Microsoft.DependencyInjection.Tests/BNet.Extensions.Microsoft.DependencyInjection.Tests.csproj `
    -c Release `
    --runtime $RID `
    /p:Version=$RELEASE_VER `
    --no-restore `
    --results-directory /code/testresults `
    --logger "trx"

FROM build AS pack
ARG RELEASE_VER
ARG RID
WORKDIR /code
RUN dotnet pack /code/src/BNet.Extensions.Microsoft.DependencyInjection/BNet.Extensions.Microsoft.DependencyInjection.csproj `
    -c Release `
    --runtime $RID `
    /p:Version=$RELEASE_VER `
    --no-restore `
    -o /code/nupkgs

FROM mcr.microsoft.com/dotnet/sdk:6.0 as push-pack
ARG NUGET_URL
ARG NUGET_KEY
COPY --from=pack /code/nupkgs /nupkgs
RUN dotnet nuget push /nupkgs/*.nupkg `
    --source $NUGET_URL `
    --api-key $NUGET_KEY
