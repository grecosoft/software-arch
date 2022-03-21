#!/bin/bash

#==========================================================================
# Builds and pushes an image for the microservice to the local registery
# that is deployed into the cluster by applying the Kubernetes deployment. 
#==========================================================================

docker build -t examples-probes:latest -f ../Dockerfile ../
docker tag examples-probes:latest localhost:5050/examples-probes:latest
docker push localhost:5050/examples-probes:latest

kubectl create configmap examples-probes.settings -n examples \
--from-file=../src/Examples.Probes.WebApi/appsettings.json

kubectl create secret generic examples-probes.secrets -n examples

kubectl apply -f ../deploy/deployment.yaml
