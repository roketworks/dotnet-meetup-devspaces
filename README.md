
# Building and Debugging Dotnet Core services on Kubernetes using Azure Dev Spaces

Slides & code samples from dotnet meetup Belfast (11/09/2018)

## Running samples


### Prerequisites 
* A azure account and active subscription
* Azure CLI (2.0.43 or above)
* Visual Studio Code
* Azure Dev Spaces Extension for Visual Studio Code

### Provision Services
First you will need to create your AKS (Azure Kubernetes Service) cluster, which can be done by running the following commands:
```
az group create --name DevSpacesDemo --location westeurope
az aks create -g DevSpacesDemo -n AksDevSpacesDemo --location westeurope --kubernetes-version 1.11.2 --enable-addons http_application_routing -c 1 --node-vm-size Standard_A1 --node-osdisk-size 30
az aks use-dev-spaces -g DevSpacesDemo -n AksDevSpacesDemo
```

*N.B. Azure Dev spaces currently does not support the North Europe region and the minimum node size supported for AKS is Standard_A1*

### Prepare Services

Run the following command in the `frontend` directory:

```
azds prep --public
```
*This will also produce configuration that exposes a public endpoint for this service.*


Run the following command in the `webapi` directory:

```
azds prep
```
*As we don't need a public endpoint for this service, we can remove the `--public` flag.*


## References 
* [Azure Dev Spaces Getting Started (Dotnet core)](https://docs.microsoft.com/en-us/azure/dev-spaces/get-started-netcore)
* [Azure Dev Spaces Team Development (Dotnet Core)](https://docs.microsoft.com/en-us/azure/dev-spaces/team-development-netcore)
* [DotnetConf2018](https://github.com/dotnet-presentations/dotnetconf2018/blob/master/Technical/Decks/.NET%20Core%20Microservice%20Development%20Made%20Easy%20with%20Azure%20Dev%20Spaces.pptx)
