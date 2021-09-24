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
In this simple demo application you can create (POST) and fetch (GET) observations of IT consultants. 

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

run ```skaffold run``` in your terminal and when everything is up and running navigate to http://localhost in your browser


## try adding something

perhaps: 
- make it possible to create other types of observations 
- add a new field to describe the IT consultants



