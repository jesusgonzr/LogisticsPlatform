using Microsoft.AspNetCore.SignalR.Client;

internal class Program
{
    private static void Main(string[] args)
    {
        var hubConnectionBuilder = new HubConnectionBuilder();

        var connection = hubConnectionBuilder
            .WithUrl("https://localhost:44386/locationHub")
            .WithAutomaticReconnect()
            .Build();

        connection.StartAsync();

        connection.InvokeAsync("TestConnection").ContinueWith(_task =>
        {
            if (_task.IsFaulted)
            {
                System.Console.WriteLine("There was an error calling send: {0}", _task.Exception.GetBaseException());
            }
        });

        /*
        // Test signalR
        connection.On<string>("TestBrodcasting", (message) =>
        {
            System.Console.WriteLine("{0}", message);
        });
        */

        System.Console.WriteLine("Introduzca el numero de pedido:");
        string orderId = System.Console.ReadLine();

        if (!string.IsNullOrEmpty(orderId))
        {
            connection.On<string>($"order-{orderId}", (message) =>
            {
                System.Console.WriteLine(message);
            });
            System.Console.WriteLine($"Esperando actualizaciones del estado para el pedido {orderId}...... ");
            System.Console.WriteLine("Presione doble <enter> para cerrar la escucha.");
            System.Console.ReadLine();
        }
        else
        {
            System.Console.WriteLine("El pedido está vacio. Presione <enter> para finalizar.");
        }

        connection.StopAsync();

        System.Console.ReadLine();
    }
}