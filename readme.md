# Artlab

A simple demo application that you can use to get familiar with:

* [Docker](https://www.docker.com/)
* [Kubernetes](https://kubernetes.io/)
* [Skaffold](https://skaffold.dev/)
* [Polly](https://github.com/App-vNext/Polly) (a .NET resilience and transient-fault-handling library)
* [Roundhouse](https://github.com/chucknorris/roundhouse) (a Database Migration Utility for .NET using sql files and versioning based on source control)
* [Rumpel](https://github.com/hellgrenj/Rumpel) (Simple, opinionated and automated consumer-driven contract testing for your JSON API's)

## prerequisites

You need to have [Docker Desktop](https://www.docker.com/products/docker-desktop) installed with Kubernetes enabled (Settings -> Kubernetes).
You also need to [Install Skaffold](https://skaffold.dev/docs/install/).

## demo application
In this simple demo application you can create and list observations of IT consultants. 

```
               |--------------|
               |    Webb      |
               | (vanilla js) |
               |--------------|
                      |
                      | 
           |----------------------|       |------------------------|        
           |  API - Observations  |       | Location (coordinates)-|
           | (.net 5 web api -    |-------| (.net 5 route-2-code   |
           |   json over http     |       | - json over http)      |    
           |----------------------|       |------------------------|
                      |
                      |
               |------------|
               |    DB      |
               | (postgres) | 
               |------------| 
``` 

## run it

run ```skaffold run``` in your terminal and when everything is up and running navigate to http://localhost in your browser (http://localhost:1337/swagger for the API Swagger UI)

## run different scenarios

run ```skaffold run -f skaffold.mocked.deps.yaml``` (in this scenario we use Rumpel and a 
pre-recorded contract to mock the location service. You can record a new contract by following the instructions in [./devops/howtos/record-new-rumpel.contract.md](https://github.com/hellgrenj/artlab/blob/main/devops/howtos/record-new-rumpel-contract.md))  

run ```skaffold run -f skaffold.only.deps.yaml``` (in this scenario we only spin up the location service and the database and run the database migrations. The location service and the database are available on localhost so you can now work with the api and web locally, outside of kubernetes)

## try adding something

perhaps: 
- make it possible to create other types of observations 
- add a new field to describe the IT consultants



