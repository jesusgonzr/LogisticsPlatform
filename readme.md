# Logistics Platform

## Introducción
Esta solución es una API Rest con arquitectura DDD y patrón CQRS. La implementación de este patrón se ha realizado en su forma más simple, es decir, se ha desarrollado la estructura para poder tener la separación de los comandos y las consultas con un único repositorío de datos.

La solución parte de que existe un sistema de pedidos donde hay que implementar la consulta, creación o actualización de la localización del vehículo que lleva los pedidos y la posibilidad de añadir o eliminar pedidos de un vehículo. Para llevar a cabo la implementación se ha divido en varios proyectos cada uno con la responsabilidad que le toca.
- Proyecto LogisticsPlatform. Es el proyecto que se encarga del dominio.
- LogisticsPlatform.Application. Proyecto donde se realiza la implementación de los comandos y las consultas.
- LogisticsPlatform.Infrastructure. Proyecto donde se realiza la implementación a los repositorios.
- LogisticsPlatform.API. Proyecto que expone los métodos para interactuar con la aplicación.
- LogisticsPlatform.Test. Proyecto donde se implementa los test unitarios.
- LogisticsPlatform.Notification.Client.Console. Proyecto cliente que implementa la escucha de los cambios de localización.

## Detalles técnicos de la solución.

La solución está desarrollada en .net 7, por lo que para poder ejecutarla se debe tener Visual Studio 2022 o Visual Studio Code

### Paquetes utilizados
- Automapper
- Mediatr
- Microsoft Entity Framework Core (con el paquete para ejecutar una base de datos en memoria)
- Newtonsoft.Json
- Swagger
- SignalR

### Arquitectura y patrones utilizados.
- Arquitectura DDD
- Patrón CQRS
- Patrón repositorio
- Patrón mediador
- Inyección de dependencias.

### Como probar la solución.

Una vez clonada la solución, abrir visual studio, establecer el proyecto API como inicial y ejecutar la solución. Se abrirá el explorador donde a través de Swagger se podrá probar cada uno de los métodos. Al estar en memoria cada uno de los registros nuevos o modificaciones que se introduzca se quedará reflejado hasta que se finalice la ejecución.

De forma predeteminada se incluye lo siguiente:
- Número de pedidos: 
  - 151f1b3a-75c3-4830-8979-7c6559c0e713
  - c6e7a711-d019-4a41-87dc-e69f5c17622a
  - d03e31f4-cecd-47b6-8fef-feef9f53e293
  - 575226c5-063a-4d06-a29c-7bbb9345f24a
  - 9dcf6195-b3d8-48d8-9294-c23e080deaf8

- Identificador de Vehiculos
  - 562053af-2761-4e9f-b8f6-18ea878c3f09
  - e43948b2-2f3d-414c-ad6b-3e045ce5942b
  - a629143c-38de-4ffb-88a7-a54cf3d3722d

Los tres primeros números de pedidos están asignados al primer vehículo y el cuarto pedido al segundo vehículo, dejando el último número de pedido libre así como el último vehículo de la lista.

### Anotaciones
Para probar la subscripción a la actualización de la localización de un vehículo/pedido, una vez compilado la solución, y esté el API levantado, vaya a ..\LogisticsPlatform.Notification.Client.Console\bin\Debug\net7.0 y busque el archivo y ejecute el archivo LogisticsPlatform.Notification.Client.Console.exe