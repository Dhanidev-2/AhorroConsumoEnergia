using AhorroConsumoEnergia;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Obtiene la información de los clientes desde la clase DatosClientes
        Dictionary<int, Dictionary<string, int>> clientes = DatosClientes.ObtenerClientes();

        MostrarMenu(clientes);

    }

    static void MostrarMenu(Dictionary<int, Dictionary<string, int>> clientes)
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("Bienvenido al sistema Incentivo al ahorro en el consumo de energía");
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Calcular valor a pagar por energía");
            Console.WriteLine("2. Calcular valor a pagar por agua");
            Console.WriteLine("3. Calcular factura de los servicios");
            Console.WriteLine("4. Calcular promedio del consumo actual de energía");
            Console.WriteLine("5. Calcular valor total del descuento de los clientes");
            Console.WriteLine("6. Calcular exceso del agua por encima del promedio");
            Console.WriteLine("7. Calcular exceso de agua por estrato");
            Console.WriteLine("8. Calcular consumo de agua mayor al promedio");
            Console.WriteLine("9. Salir");

            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                switch (opcion)
                {
                    case 1:
                        FuncionesCalculo.CalcularValorPagarEnergia(clientes);
                        break;
                    case 2:
                        FuncionesCalculo.CalcularValorPagarAgua(clientes);
                        break;
                    case 3:
                        FuncionesCalculo.CalcularValorPagarFactura(clientes);
                        break;
                    case 4:
                        FuncionesCalculo.CalcularPromedioConsumoEnergiaCliente(clientes);
                        break;
                    case 5:
                        int totalDescuentos = FuncionesCalculo.CalcularDescuentosEnergia(clientes);
                        Console.WriteLine($"Total de descuentos de los clientes: ${totalDescuentos}"); 
                        break;
                    case 6:
                        int totalExcesoAgua = FuncionesCalculo.CalcularExcesoAgua(clientes);
                        Console.WriteLine($"Total de exceso de agua: {totalExcesoAgua} mt3");
                        break;
                    case 7:
                        FuncionesCalculo.CalcularPorcentajeExcesoAguaPorEstrato(clientes);
                        break;
                    case 8:
                        int consumoMayorPromedio = FuncionesCalculo.CalcularConsumoMayorPromedio(clientes);
                        Console.WriteLine($"Cantidad de clientes con consumo de agua mayor al promedio: {consumoMayorPromedio}");
                        break;
                    case 9:
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opción no válida. Intente de nuevo.");
            }
        }
    }
}
