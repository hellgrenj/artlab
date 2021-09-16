# Artlab

## Syfte

En enkel miljö för att bekanta sig med:

* [Docker](https://www.docker.com/)
* [Kubernetes](https://kubernetes.io/)
* [Skaffold](https://skaffold.dev/)
* Polly ... TODO....
* Automatisk hantering av databasschemaförändringar mha [Roadhouse](https://github.com/chucknorris/roundhouse)
* Automatiserade kontraktstester och stubbar av lokala beroenden mha [Rumpel](https://github.com/hellgrenj/Rumpel) (Kan ersätta med Postman eller PACT eller liknande om vi vill sen såklart!)

## Förutsättningar

Se till att du har [Docker Desktop](https://www.docker.com/products/docker-desktop) installerat och det inbyggda (singel-nod) kubernetesklustret aktiverat (Settings -> Kubernetes).
Du behöver även [Installera Skaffold](https://skaffold.dev/docs/install/) och [Node](https://nodejs.org/en/). *Node behövs endast för att kunna serva vår webb app lokalt med* ```npx serve```

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

1. Navigera till ./api och starta API:et med: ```skaffold run``` 
2. I en annan terminal (flik/fönster) navigera till ./webb och starta webbklienten med ```npx serve```

## Labb  

Klona detta repo och utveckla demoapplikationen att ... 
- rapportera observationer av något annat än IT-konsulter? 
- kanske lägga till något nytt fält för att beskriva de IT-konsulter vi observerar?
- lägga till input-validering?


