#!/bin/bash

#==========================================================================
# Builds and pushes an image for the microservice to the local registery
# that is deployed into the cluster by applying the Kubernetes deployment. 
#==========================================================================

docker build -t examples-microservicetwo:latest -f ../Dockerfile ../
docker tag examples-microservicetwo:latest localhost:5050/examples-microservicetwo:latest
docker push localhost:5050/examples-microservicetwo:latest

kubectl create configmap examples-microservicetwo.settings -n examples \
--from-file=../src/Examples.MicroserviceTwo.WebApi/appsettings.json

kubectl create secret generic examples-microservicetwo.secrets -n examples

kubectl apply -f ../deploy/deployment.yaml
