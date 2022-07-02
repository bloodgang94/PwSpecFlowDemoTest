# Playwright Demo

Example playwright test + specflow

## Installation

To run locally, you need to install browsers

```bash
pwsh bin\Debug\netX\playwright.ps1 install
```

## Run docker

```bash
cd PwSpecFlowDemoTest
docker build --tag pwtest .
docker run --rm -it pwtest
```