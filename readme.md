# Logistics Platform

## Introducci�n
Esta soluci�n es una API Rest con arquitectura DDD y patr�n CQRS. La implementaci�n de este patr�n se ha realizado en su forma m�s simple, es decir, se ha desarrollado la estructura para poder tener la separaci�n de los comandos y las consultas con un �nico repositor�o de datos.

La soluci�n parte de que existe un sistema de pedidos donde hay que implementar la consulta, creaci�n o actualizaci�n de la localizaci�n del veh�culo que lleva los pedidos y la posibilidad de a�adir o eliminar pedidos de un veh�culo. Para llevar a cabo la implementaci�n se ha divido en varios proyectos cada uno con la responsabilidad que le toca.
- Proyecto LogisticsPlatform. Es el proyecto que se encarga del dominio.
- LogisticsPlatform.Application. Proyecto donde se realiza la implementaci�n de los comandos y las consultas.
- LogisticsPlatform.Infrastructure. Proyecto donde se realiza la implementaci�n a los repositorios.
- LogisticsPlatform.API. Proyecto que expone los m�todos para interactuar con la aplicaci�n.
- LogisticsPlatform.Test. Proyecto donde se implementa los test unitarios.
- LogisticsPlatform.Notification.Client.Console. Proyecto cliente que implementa la escucha de los cambios de localizaci�n.

## Detalles t�cnicos de la soluci�n.

La soluci�n est� desarrollada en .net 7, por lo que para poder ejecutarla se debe tener Visual Studio 2022 o Visual Studio Code

### Paquetes utilizados
- Automapper
- Mediatr
- Microsoft Entity Framework Core (con el paquete para ejecutar una base de datos en memoria)
- Newtonsoft.Json
- Swagger
- SignalR

### Arquitectura y patrones utilizados.
- Arquitectura DDD
- Patr�n CQRS
- Patr�n repositorio
- Patr�n mediador
- Inyecci�n de dependencias.

### Como probar la soluci�n.

Una vez clonada la soluci�n, abrir visual studio, establecer el proyecto API como inicial y ejecutar la soluci�n. Se abrir� el explorador donde a trav�s de Swagger se podr� probar cada uno de los m�todos. Al estar en memoria cada uno de los registros nuevos o modificaciones que se introduzca se quedar� reflejado hasta que se finalice la ejecuci�n.

De forma predeteminada se incluye lo siguiente:
- N�mero de pedidos: 
  - 151f1b3a-75c3-4830-8979-7c6559c0e713
  - c6e7a711-d019-4a41-87dc-e69f5c17622a
  - d03e31f4-cecd-47b6-8fef-feef9f53e293
  - 575226c5-063a-4d06-a29c-7bbb9345f24a
  - 9dcf6195-b3d8-48d8-9294-c23e080deaf8

- Identificador de Vehiculos
  - 562053af-2761-4e9f-b8f6-18ea878c3f09
  - e43948b2-2f3d-414c-ad6b-3e045ce5942b
  - a629143c-38de-4ffb-88a7-a54cf3d3722d

Los tres primeros n�meros de pedidos est�n asignados al primer veh�culo y el cuarto pedido al segundo veh�culo, dejando el �ltimo n�mero de pedido libre as� como el �ltimo veh�culo de la lista.

### Anotaciones
Para probar la subscripci�n a la actualizaci�n de la localizaci�n de un veh�culo/pedido, una vez compilado la soluci�n, y est� el API levantado, vaya a ..\LogisticsPlatform.Notification.Client.Console\bin\Debug\net7.0 y busque el archivo y ejecute el archivo LogisticsPlatform.Notification.Client.Console.exe