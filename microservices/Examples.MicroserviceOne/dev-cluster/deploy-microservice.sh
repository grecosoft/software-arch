#!/bin/bash

#==========================================================================
# Builds and pushes an image for the microservice to the local registery
# that is deployed into the cluster by applying the Kubernetes deployment. 
#==========================================================================

docker build -t examples-microserviceone:latest -f ../Dockerfile ../
docker tag examples-microserviceone:latest localhost:5050/examples-microserviceone:latest
docker push localhost:5050/examples-microserviceone:latest

kubectl create configmap examples-microserviceone.settings -n examples \
--from-file=../src/Examples.MicroserviceOne.WebApi/appsettings.json

kubectl create secret generic examples-microserviceone.secrets -n examples

kubectl apply -f ../deploy/deployment.yaml
