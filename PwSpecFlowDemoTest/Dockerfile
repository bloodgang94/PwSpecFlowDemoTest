
ARG PLAYWRIGHT_VERSION=1.23.0

FROM mcr.microsoft.com/playwright/dotnet:v${PLAYWRIGHT_VERSION}-focal

WORKDIR /src
COPY ["PwSpecFlowDemoTest/PwSpecFlowDemoTest.csproj", "PwSpecFlowDemoTest/"]
RUN dotnet restore "PwSpecFlowDemoTest/PwSpecFlowDemoTest.csproj"
COPY . .

WORKDIR /src/PwSpecFlowDemoTest
RUN dotnet build "PwSpecFlowDemoTest.csproj" -c Release -o /app/build
RUN dotnet tool update --global PowerShell
RUN pwsh /app/build/playwright.ps1 install chrome
CMD dotnet test PwSpecFlowDemoTest.csproj
