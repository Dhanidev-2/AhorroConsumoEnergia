using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhorroConsumoEnergia
{
    public class FuncionesCalculo
    {

        public static void CalcularValorPagarEnergia(List<ListaUsuario> usuario)
        {
            Console.Write("Ingrese el número de cédula del cliente: ");
            int cedula = Convert.ToInt32(Console.ReadLine());

            var clienteEncontrado = usuario.Find(x => x.Cedula == cedula);

            if (clienteEncontrado != null)
            {
                int valorPagarEnergia = ValorPagarEnergia(clienteEncontrado.meta_ahorro_energia, clienteEncontrado.consumo_actual_energia);
                Console.WriteLine($"Valor a pagar por servicios de energía: ${valorPagarEnergia}");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }

        public static int ValorPagarEnergia(int metaAhorroEnergia, int consumoActualEnergia)
        {
            int costoKilovatio = 850;
            int valorParcial = consumoActualEnergia * costoKilovatio;
            int valorIncentivo = (metaAhorroEnergia - consumoActualEnergia) * costoKilovatio;
            return valorParcial - valorIncentivo;
        }

        public static void CalcularValorPagarAgua(List<ListaUsuario> usuario)
        {
            Console.Write("Ingrese el número de cédula del cliente: ");
            int cedula = Convert.ToInt32(Console.ReadLine());

            var clienteEncontrado = usuario.Find(x => x.Cedula == cedula);

            if (clienteEncontrado != null)
            {
                int valorPagarAgua = ValorPagarAgua(clienteEncontrado.promedio_consumo_agua, clienteEncontrado.consumo_actual_agua);
                Console.WriteLine($"Valor a pagar por servicios de energía: ${valorPagarAgua}");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }

        public static int ValorPagarAgua(int promedioConsumoAgua, int consumoActualAgua)
        {
            int costoMetroCubicoAgua = 4600;
            if (consumoActualAgua <= promedioConsumoAgua)
            {
                return consumoActualAgua * costoMetroCubicoAgua;
            }
            else
            {
                int excesoAgua = consumoActualAgua - promedioConsumoAgua;
                return (promedioConsumoAgua * costoMetroCubicoAgua) + (excesoAgua * 2 * costoMetroCubicoAgua);
            }
        }

        public static void CalcularPromedioConsumoEnergiaClientes(List<ListaUsuario> usuarios)
        {
            double promedioConsumoEnergia = PromedioConsumoEnergia(usuarios);
            Console.WriteLine($"Promedio del consumo actual de energía: {promedioConsumoEnergia}");
        }

        public static double PromedioConsumoEnergia(List<ListaUsuario> usuarios)
        {
            int totalConsumoEnergia = 0;
            int totalClientes = usuarios.Count;

            foreach (var usuario in usuarios)
            {
                totalConsumoEnergia += usuario.consumo_actual_energia;
            }

            return (double)totalConsumoEnergia / totalClientes;
        }

        public static void CalcularValorPagarFactura(List<ListaUsuario> usuario)
        {
            Console.Write("Ingrese el número de cédula del cliente: ");
            int cedula = Convert.ToInt32(Console.ReadLine());

            var clienteEncontrado = usuario.Find(x => x.Cedula == cedula);

            if (clienteEncontrado != null)
            {
                int valorPagarEnergia = ValorPagarEnergia(clienteEncontrado.meta_ahorro_energia, clienteEncontrado.consumo_actual_energia);
                int valorPagarAgua = ValorPagarAgua(clienteEncontrado.promedio_consumo_agua, clienteEncontrado.consumo_actual_agua);

                int totalFacturaServicios = ValorPagarFactura(valorPagarEnergia, valorPagarAgua);

                Console.WriteLine($"Valor a pagar por servicios de energía: ${totalFacturaServicios}");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }

        public static int ValorPagarFactura(int valorPagarEnergia, int valorPagarAgua)
        {
            int totalFactura = valorPagarEnergia + valorPagarAgua;

            return totalFactura;
        }

        public static int CalcularDescuentosEnergia(List<ListaUsuario> usuarios)
        {
            int totalDescuentosEnergia = 0;
            bool hayDescuentos = false;

            foreach (var usuario in usuarios)
            {
                int metaAhorroEnergia = usuario.meta_ahorro_energia;
                int consumoActualEnergia = usuario.consumo_actual_energia;

                if (consumoActualEnergia <= metaAhorroEnergia)
                {
                    // Valor a pagar sin descuento
                    int costoKilovatio = 850;
                    int valorParcial = consumoActualEnergia * costoKilovatio;

                    // Valor a pagar con descuento
                    int valorIncentivo = (metaAhorroEnergia - consumoActualEnergia) * costoKilovatio;
                    int valorPagarConDescuento = valorParcial - valorIncentivo;

                    int descuento = valorParcial - valorPagarConDescuento;

                    totalDescuentosEnergia += descuento;
                    hayDescuentos = true;
                }
            }

            if (!hayDescuentos)
            {
                Console.WriteLine("No hay clientes con descuento.");
            }

            return totalDescuentosEnergia;
        }

        public static int CalcularExcesoAgua(List<ListaUsuario> usuarios)
        {
            int totalExcesoAgua = 0;

            foreach (var usuario in usuarios)
            {
                int promedioConsumoAgua = usuario.promedio_consumo_agua;
                int consumoActualAgua = usuario.consumo_actual_agua;

                if (consumoActualAgua > promedioConsumoAgua)
                {
                // Cantidad de metros cúbicos consumidos por encima del promedio
                    int excesoAgua = consumoActualAgua - promedioConsumoAgua;

                    totalExcesoAgua += excesoAgua;
                }
            }

            return totalExcesoAgua;
        }

        public static void CalcularPorcentajeExcesoAguaPorEstrato(List<ListaUsuario> usuarios)
        {
            Dictionary<int, int> totalExcesoAguaPorEstrato = new Dictionary<int, int>();
            int totalExcesoAgua = 0;

            foreach (var usuario in usuarios)
            {
                int estrato = usuario.estrato;
                int promedioConsumoAgua = usuario.promedio_consumo_agua;
                int consumoActualAgua = usuario.consumo_actual_agua;

                // Verifica si el estrato ya está en los diccionarios, si no lo crea
                if (!totalExcesoAguaPorEstrato.ContainsKey(estrato))
                {
                    totalExcesoAguaPorEstrato[estrato] = 0;
                }

                if (consumoActualAgua > promedioConsumoAgua)
                {
                    // Metros cúbicos consumidos por encima del promedio
                    int excesoAgua = consumoActualAgua - promedioConsumoAgua;

                    totalExcesoAguaPorEstrato[estrato] += excesoAgua;
                    totalExcesoAgua += excesoAgua;
                }
            }

            Console.WriteLine("Porcentaje de consumo excesivo de agua por estrato:");
            foreach (var estrato in totalExcesoAguaPorEstrato.Keys)
            {
                double porcentaje = (double)totalExcesoAguaPorEstrato[estrato] / totalExcesoAgua * 100;
                Console.WriteLine($"Estrato {estrato}: {porcentaje}%");
            }
        }


        public static int CalcularConsumoMayorPromedio(List<ListaUsuario> usuarios)
        {
            int contadorClientes = 0;

            foreach (var usuario in usuarios)
            {
                int promedioConsumoAgua = usuario.promedio_consumo_agua;
                int consumoActualAgua = usuario.consumo_actual_agua;

                if (consumoActualAgua > promedioConsumoAgua)
                {
                    contadorClientes++;
                }
            }

            return contadorClientes;
        }
    }
}