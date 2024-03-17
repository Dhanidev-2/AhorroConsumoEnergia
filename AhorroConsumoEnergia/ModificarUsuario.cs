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
            Console.Write("Ingrese el número de cédula del cliente: ");
            int cedula = Convert.ToInt32(Console.ReadLine());

            ListaUsuario clienteEncontrado = usuario.Find(x => x.Cedula == cedula);

            if (clienteEncontrado != null)
            {
                bool actualizarOtraOpcion = true;

                while (actualizarOtraOpcion)
                {
                    Console.WriteLine("Seleccione que información desea actualizar:");
                    Console.WriteLine("1. Estrato");
                    Console.WriteLine("2. Meta de ahorro de energía");
                    Console.WriteLine("3. Consumo actual de energía");
                    Console.WriteLine("4. Promedio de consumo de agua");
                    Console.WriteLine("5. Consumo actual de agua");
                    Console.WriteLine("6. Finalizar actualización");

                    int opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            Console.Write("Nuevo estrato: ");
                            clienteEncontrado.estrato = Convert.ToInt32(Console.ReadLine());
                            break;

                        case 2:
                            Console.Write("Nueva meta de ahorro de energía: ");
                            clienteEncontrado.meta_ahorro_energia = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 3:
                            Console.Write("Nuevo consumo actual de energía: ");
                            clienteEncontrado.consumo_actual_energia = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 4:
                            Console.Write("Nuevo promedio de consumo de agua: ");
                            clienteEncontrado.promedio_consumo_agua = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 5:
                            Console.Write("Nuevo consumo actual de agua: ");
                            clienteEncontrado.consumo_actual_agua = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 6:
                            Console.WriteLine("Finalizando actualización...");
                            actualizarOtraOpcion = false;
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                    
                }
                Console.WriteLine($"La información del usuario ha sido actualizada: Cédula{cedula}, Estrato: {clienteEncontrado.estrato}, Meta Ahorro Energia: {clienteEncontrado.meta_ahorro_energia}, Consumo Actual Energia: {clienteEncontrado.consumo_actual_energia}, Promedio Consumo Agua: {clienteEncontrado.promedio_consumo_agua}");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }

        public static void EliminarUsuario(List<ListaUsuario> usuario)
        {
            Console.Write("Ingrese el número de cédula del cliente: ");
            int cedula = Convert.ToInt32(Console.ReadLine());

            ListaUsuario clienteEncontrado = usuario.Find(x => x.Cedula == cedula);

            if (clienteEncontrado != null)
            {
                usuario.Remove(clienteEncontrado);
                Console.WriteLine($"Ha eliminado el cliente con cédula: {cedula}");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }
    }
}
