using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhorroConsumoEnergia
{
    public class ModificarUsuario
    {
        public static void ActualizarInformacion(List<ListaUsuario> usuario)
        {
            Console.WriteLine("");
            Console.Write("Ingrese el número de cédula del cliente: ");
            Console.WriteLine("");
            int cedula = Convert.ToInt32(Console.ReadLine());

            var clienteEncontrado = usuario.Find(x => x.Cedula == cedula);

            if (clienteEncontrado != null)
            {
                bool actualizarOtraOpcion = true;

                while (actualizarOtraOpcion)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Seleccione que información desea actualizar:");
                    Console.WriteLine("");
                    Console.WriteLine("1. Nombre");
                    Console.WriteLine("");
                    Console.WriteLine("2. Apellido");
                    Console.WriteLine("");
                    Console.WriteLine("3. Periodo de consumo");
                    Console.WriteLine("");
                    Console.WriteLine("4. Estrato");
                    Console.WriteLine("");
                    Console.WriteLine("5. Meta de ahorro de energía");
                    Console.WriteLine("");
                    Console.WriteLine("6. Consumo actual de energía");
                    Console.WriteLine("");
                    Console.WriteLine("7. Promedio de consumo de agua");
                    Console.WriteLine("");
                    Console.WriteLine("8. Consumo actual de agua");
                    Console.WriteLine("");
                    Console.WriteLine("9. Finalizar actualización");
                    Console.WriteLine("");

                    int opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            Console.Write("");
                            Console.Write("Nuevo Nombre: ");
                            Console.WriteLine("");
                            clienteEncontrado.nombre = Console.ReadLine();
                            break;

                        case 2:
                            Console.Write("");
                            Console.Write("Nuevo Apellido: ");
                            Console.WriteLine("");
                            clienteEncontrado.apellido = Console.ReadLine();
                            break;

                        case 3:
                            Console.Write("");
                            Console.Write("Nuevo periodo de consumo: ");
                            Console.WriteLine("");
                            clienteEncontrado.periodo_consumo = Convert.ToInt32(Console.ReadLine());
                            break;

                        case 4:
                            Console.Write("");
                            Console.Write("Nuevo estrato: ");
                            Console.WriteLine("");
                            clienteEncontrado.estrato = Convert.ToInt32(Console.ReadLine());
                            break;

                        case 5:
                            Console.Write("");
                            Console.Write("Nueva meta de ahorro de energía: ");
                            Console.WriteLine("");
                            clienteEncontrado.meta_ahorro_energia = Convert.ToInt32(Console.ReadLine());
                            break;

                        case 6:
                            Console.Write("");
                            Console.Write("Nuevo consumo actual de energía: ");
                            Console.WriteLine("");
                            clienteEncontrado.consumo_actual_energia = Convert.ToInt32(Console.ReadLine());
                            break;

                        case 7:
                            Console.Write("");
                            Console.Write("Nuevo promedio de consumo de agua: ");
                            Console.WriteLine("");
                            clienteEncontrado.promedio_consumo_agua = Convert.ToInt32(Console.ReadLine());
                            break;

                        case 8:
                            Console.Write("");
                            Console.Write("Nuevo consumo actual de agua: ");
                            Console.WriteLine("");
                            clienteEncontrado.consumo_actual_agua = Convert.ToInt32(Console.ReadLine());
                            break;

                        case 9:
                            Console.Write("");
                            Console.WriteLine("Finalizando actualización...");
                            Console.WriteLine("");
                            actualizarOtraOpcion = false;
                            break;
                        default:
                            Console.Write("");
                            Console.WriteLine("Opción no válida.");
                            Console.WriteLine("");
                            break;
                    }

                }
                Console.WriteLine($"La información del usuario ha sido actualizada: Cédula {cedula}, Nombre {clienteEncontrado.nombre}, Apellido {clienteEncontrado.apellido}, periodo consumo {clienteEncontrado.periodo_consumo}, Estrato: {clienteEncontrado.periodo_consumo}, Meta Ahorro Energia: {clienteEncontrado.meta_ahorro_energia}, Consumo Actual Energia: {clienteEncontrado.consumo_actual_energia}, Promedio Consumo Agua: {clienteEncontrado.promedio_consumo_agua}");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
                Console.WriteLine("");
            }
        }

        public static void EliminarUsuario(List<ListaUsuario> usuario)
        {
            Console.Write("Ingrese el número de cédula del cliente: ");
            Console.WriteLine("");
            int cedula = Convert.ToInt32(Console.ReadLine());

            var clienteEncontrado = usuario.Find(x => x.Cedula == cedula);

            if (clienteEncontrado != null)
            {
                usuario.Remove(clienteEncontrado);
                Console.WriteLine($"Ha eliminado el cliente con cédula: {cedula}");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
                Console.WriteLine("");
            }
        }

    }

}