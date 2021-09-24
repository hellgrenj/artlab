# Artlab

## Syfte

En enkel miljö för att bekanta sig med:

* [Docker](https://www.docker.com/)
* [Kubernetes](https://kubernetes.io/)
* [Skaffold](https://skaffold.dev/)
* Felhantering i distribuerade system med [Polly](https://github.com/App-vNext/Polly)
* Automatisk hantering av databasschemaförändringar mha [Roundhouse](https://github.com/chucknorris/roundhouse)
* Automatiserade kontraktstester och stubbar av lokala beroenden mha [Rumpel](https://github.com/hellgrenj/Rumpel)

## Förutsättningar

Se till att du har [Docker Desktop](https://www.docker.com/products/docker-desktop) installerat och det inbyggda (singel-nod) kubernetesklustret aktiverat (Settings -> Kubernetes).
Du behöver även [Installera Skaffold](https://skaffold.dev/docs/install/).

## Demoapplikation
I vår enkla demoapplikation kan du skapa (POST) och hämta (GET) observationer. 
I första versionen kan vi endast rapportera observationer av IT-konsulter, vi kanske kan förbättra och vidareutveckla detta ihop sen? =)

```
               |--------------|
               |    Webb      |
               | (vanilla js) |
               |--------------|
                      |
                      | 
           |----------------------|       |---------------------|        
           |  API - Observationer |       | GPS-koordinater     |
           | (.net 5 web api -    |-------|(.net 5 route-2-code |
           |   json över http     |       | - json över http)   |    
           |----------------------|       |---------------------|
                      |
                      |
               |------------|
               |    DB      |
               | (postgres) | 
               |------------| 
``` 

## Testa

Starta systemet med: ```skaffold run``` och navigera till http://localhost i din webbläsare

## Labb  

Klona detta repo och utveckla demoapplikationen att ... 
- rapportera observationer av något annat än IT-konsulter? 
- kanske lägga till något nytt fält för att beskriva de IT-konsulter vi observerar?



