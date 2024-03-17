using AhorroConsumoEnergia;
using System;
using System.Collections.Generic;

class Program
{
    static List<ListaUsuario> usuarios = new List<ListaUsuario>();
    static void Main()
    {
        int opcionPrincipal = 0;

        while (opcionPrincipal != 3)
        {
            Console.WriteLine("MENÚ PRINCIPAL");
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Ingresar usuario");
            Console.WriteLine("2. Actualizar usuario");
            Console.WriteLine("3. Eliminar usuario");
            Console.WriteLine("4. Cálcular datos de consumo");
            Console.WriteLine("5. Salir");
            opcionPrincipal = Convert.ToInt32(Console.ReadLine());

            switch (opcionPrincipal)
            {
                case 1:
                    MenuOpcion1();
                    break;
                case 2:
                    //MenuOpcion2();
                    break;
                case 3:
                    //MenuOpcion3();
                    break;
                case 4:
                    MenuOpcion4();
                    break;
                case 5:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }
        }

        static void MenuOpcion1()
        {

            Console.WriteLine("Ingrese los datos de los servicios de su hogar");

            while (true)
            {
                Console.Write("Ingresar cedula para continuar o ingrese fin si desea finalizar:");
                string input = Console.ReadLine();
                if (input.ToLower() == "fin")
                    break;

                int cedula;
                while (!int.TryParse(input, out cedula))
                {
                    Console.WriteLine("Ingresar número de cedula válido.");
                    Console.Write("Cédula: ");
                    input = Console.ReadLine();
                }

                Console.Write("Ingresar número de Estrato: ");
                int estrato;
                while (!int.TryParse(Console.ReadLine(), out estrato))
                {
                    Console.WriteLine("Ingrese un número de Estrato válido.");
                    Console.Write("Estrato: ");
                }

                Console.Write("Ingresar la cantidad esperada de ahorro de energia: ");
                int meta_ahorro_energia;
                while (!int.TryParse(Console.ReadLine(), out meta_ahorro_energia))
                {
                    Console.WriteLine("Ingrese una cantidad válida para el ahorro de energia.");
                    Console.Write("Ahorro de energia: ");
                }

                Console.Write("Ingresar el consumo actual de energia: ");
                int consumo_actual_energia;
                while (!int.TryParse(Console.ReadLine(), out consumo_actual_energia))
                {
                    Console.WriteLine("Ingrese una cantidad válida para el consumo de energia.");
                    Console.Write("Consumo de energia: ");
                }

                Console.Write("Ingresar el promedio del consumo del agua: ");
                int promedio_consumo_agua;
                while (!int.TryParse(Console.ReadLine(), out promedio_consumo_agua))
                {
                    Console.WriteLine("Ingrese una cantidad válida para el promedio de consumo de agua.");
                    Console.Write("Promedio de consumo de agua: ");
                }

                Console.Write("Ingresar el consumo actual del agua: ");
                int consumo_actual_agua;
                while (!int.TryParse(Console.ReadLine(), out consumo_actual_agua))
                {
                    Console.WriteLine("Ingrese una cantidad válida para el consumo actual del agua.");
                    Console.Write("Consumo actual del agua: ");
                }

                // Agregar la nueva cedula a la lista
                usuarios.Add(new ListaUsuario(cedula, estrato, meta_ahorro_energia, consumo_actual_energia, promedio_consumo_agua, consumo_actual_agua));
            }

            // Mostrar las cedulas ingresadas
            Console.WriteLine("\nCedulas ingresadas:");
            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"Cedula: {usuario.Cedula}, Estrato: {usuario.estrato}, Meta Ahorro Energia: {usuario.meta_ahorro_energia}, Consumo Actual Energia: {usuario.consumo_actual_energia}, Promedio Consumo Agua: {usuario.promedio_consumo_agua}");
            }
        }

        static void MenuOpcion4()
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
                            FuncionesCalculo.CalcularValorPagarEnergia(usuarios);
                            break;
                        case 2:
                            FuncionesCalculo.CalcularValorPagarAgua(usuarios);
                            break;
                        case 3:
                            FuncionesCalculo.CalcularValorPagarFactura(usuarios);
                            break;
                        case 4:
                            FuncionesCalculo.CalcularPromedioConsumoEnergiaClientes(usuarios);
                            break;
                        case 5:
                            int totalDescuentos = FuncionesCalculo.CalcularDescuentosEnergia(usuarios);
                            Console.WriteLine($"Total de descuentos de los clientes: ${totalDescuentos}");
                            break;
                        case 6:
                            int totalExcesoAgua = FuncionesCalculo.CalcularExcesoAgua(usuarios);
                            Console.WriteLine($"Total de exceso de agua: {totalExcesoAgua} mt3");
                            break;
                        case 7:
                            FuncionesCalculo.CalcularPorcentajeExcesoAguaPorEstrato(usuarios);
                            break;
                        case 8:
                            int consumoMayorPromedio = FuncionesCalculo.CalcularConsumoMayorPromedio(usuarios);
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

}
