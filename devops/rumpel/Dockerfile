FROM hellgrenj/rumpel:v0.3.1
WORKDIR /app
COPY ./api-location.rumpel.contract.json ./contracts/
ENTRYPOINT ["dotnet", "./Rumpel.dll", "--mock-provider", "--contract-path=./contracts/api-location.rumpel.contract.json"]
