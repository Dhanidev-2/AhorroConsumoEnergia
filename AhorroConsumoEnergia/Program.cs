using AhorroConsumoEnergia;
using System;
using System.Collections.Generic;

class Program
{
    static List<ListaUsuario> usuarios = new List<ListaUsuario>();
    static void Main()
    {
        int opcionPrincipal = 0;

        while (opcionPrincipal != 4)
        {
            Console.WriteLine("MENÚ PRINCIPAL");
            Console.WriteLine("");
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("");
            Console.WriteLine("1. Ingresar usuario");
            Console.WriteLine("");
            Console.WriteLine("2. Modificar usuario");
            Console.WriteLine("");
            Console.WriteLine("3. Calcular datos de consumo");
            Console.WriteLine("");
            Console.WriteLine("4. Salir");
            opcionPrincipal = Convert.ToInt32(Console.ReadLine());

            switch (opcionPrincipal)
            {
                case 1:
                    MenuOpcion1();
                    break;
                case 2:
                    MenuOpcion2();
                    break;
                case 3:
                    MenuOpcion3();
                    break;
                case 4:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }
        }
    }

    static void MenuOpcion1()
    {

        Console.WriteLine("Ingrese sus datos personajes");

        while (true)
        {
            Console.Write("Ingresar cedula para continuar o ingrese fin si desea volver al menu principal:");
            string input = Console.ReadLine();
            if (input.ToLower() == "fin")
                break;

            int cedula;
            while (!int.TryParse(input, out cedula))
            {
                Console.WriteLine("Ingresar un número de cedula válido.");
                Console.Write("Cédula: ");
                input = Console.ReadLine();
            }

            Console.Write("Ingrese el nombre de usuario:");
            string nombre = Console.ReadLine();
            while (string.IsNullOrEmpty(nombre) || double.TryParse(nombre, out _))
            {
                if (double.TryParse(nombre, out _))
                {
                    Console.WriteLine("Por favor, ingrese un nombre válido. No se permiten números.");
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un nombre válido.");
                }
                Console.Write("Ingrese el nombre de usuario:");
                nombre = Console.ReadLine();
            }


            Console.Write("Ingrese el apellido de usuario:");
            string apellido = Console.ReadLine();
            while (string.IsNullOrEmpty(apellido) || double.TryParse(apellido, out _))
            {
                //Si el nombre puede ser convertido a un número 
                if (double.TryParse(apellido, out _))
                {
                    Console.WriteLine("Por favor, ingrese un apellido válido. No se permiten números.");
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un apellido válido.");
                }
                Console.Write("Ingrese el nombre de usuario:");
                nombre = Console.ReadLine();
            }

            
            Console.Write("Ingresar su periodo de consumo: ");
            int periodo_consumo;
            while (!int.TryParse(Console.ReadLine(), out periodo_consumo))
            {
                Console.WriteLine("Ingrese un periodo de consumo  válido.");
                Console.Write("Periodo de consumo: ");
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

            // Agregar el nuevo usuario a la lista
            usuarios.Add(new ListaUsuario(cedula, nombre, apellido, periodo_consumo, estrato, meta_ahorro_energia, consumo_actual_energia, promedio_consumo_agua, consumo_actual_agua));
            Console.WriteLine("");
        }

        // Mostrar las cedulas ingresadas
        Console.WriteLine("\nUsuarios ingresados:");
        Console.WriteLine("");
        foreach (var usuario in usuarios)
        {
            Console.WriteLine($"Cedula: {usuario.Cedula}, Nombre: {usuario.nombre}, Apellido:{usuario.apellido}, Periodo de Consumo: {usuario.periodo_consumo}, Estrato: {usuario.estrato}, Meta Ahorro Energia: {usuario.meta_ahorro_energia}, Consumo Actual Energia: {usuario.consumo_actual_energia}, Promedio Consumo Agua: {usuario.promedio_consumo_agua}, Consumo Actual Agua: {usuario.consumo_actual_agua}");
            Console.WriteLine("");
        }
    }

    static void MenuOpcion2()
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("Seleccione una opción que desea realizar: ");
            Console.WriteLine("");
            Console.WriteLine("1. Actualizar información del usuario");
            Console.WriteLine("");
            Console.WriteLine("2. Eliminar usuario");
            Console.WriteLine("");
            Console.WriteLine("3. Volver al menu principal");

            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                switch (opcion)
                {
                    case 1:
                        ModificarUsuario.ActualizarInformacion(usuarios);
                        break;
                    case 2:
                        ModificarUsuario.EliminarUsuario(usuarios);
                        break;
                    case 3:
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

    static void MenuOpcion3()
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("Bienvenido al sistema Incentivo al ahorro en el consumo de energía");
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("");
            Console.WriteLine("1. Calcular valor a pagar por energía");
            Console.WriteLine("");
            Console.WriteLine("2. Calcular valor a pagar por agua");
            Console.WriteLine("");
            Console.WriteLine("3. Calcular factura de los servicios");
            Console.WriteLine("");
            Console.WriteLine("4. Calcular promedio del consumo actual de energía");
            Console.WriteLine("");
            Console.WriteLine("5. Calcular valor total del descuento de los clientes");
            Console.WriteLine("");
            Console.WriteLine("6. Calcular exceso del agua por encima del promedio");
            Console.WriteLine("");
            Console.WriteLine("7. Calcular exceso de agua por estrato");
            Console.WriteLine("");
            Console.WriteLine("8. Calcular consumo de agua mayor al promedio");
            Console.WriteLine("");
            Console.WriteLine("9. Calcular cliente con mayor desfase en el consumo de energía");
            Console.WriteLine("");
            Console.WriteLine("10. Calcular estrato con mayor ahorro de la cantidad de agua");
            Console.WriteLine("");
            Console.WriteLine("11. Calcular estrato con el mayor y menor consumo de energía");
            Console.WriteLine("");
            Console.WriteLine("12. Calcular valor total del pago por energía y agua");
            Console.WriteLine("");
            Console.WriteLine("13. Calcular mayor consumo agua por periodo de consumo");
            Console.WriteLine("");
            Console.WriteLine("14. Volver al menu principal");

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
                        FuncionesCalculo.CalcularMayorDesfase(usuarios);
                        break;
                    case 10:
                        FuncionesCalculo.CalcularEstratoAhorroMayorCantidadAgua(usuarios);
                        break;
                    case 11:
                        FuncionesCalculo.CalcularEstratoMayorMenorConsumoEnergia(usuarios);
                        break;
                    case 12:
                        FuncionesCalculo.CalcularValorTotalPago(usuarios);
                        break;
                    case 13:
                        Console.Write("Ingrese el periodo de consumo: ");
                        int periodoConsumo = Convert.ToInt32(Console.ReadLine());
                        FuncionesCalculo.CalcularMayorPeriodoConsumoAgua(usuarios, periodoConsumo);
                        break;
                    case 14:
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