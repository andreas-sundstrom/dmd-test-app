# DMD Testapp

Detta projekt används för att testa inloggningsflöde med DMD-skärmar. Besök sidan på [denna länk](https://dmd-test-app-ascfb6dae3bkbhfy.swedencentral-01.azurewebsites.net).

## Publicera image

Logga in till registret

```ps
docker login -u dmdtestapp dmdtestapp.azurecr.io
```

Bygg image

```ps
docker build -t dmdtestapp.azurecr.io/dmdtestapp/dmdtestapp:1.0 .
```

Pusha image

```ps
docker push dmdtestapp.azurecr.io/dmdtestapp/dmdtestapp:1.0
```
