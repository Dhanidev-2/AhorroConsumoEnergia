using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhorroConsumoEnergia
{
    public class FuncionesCalculo
    {
        public static void CalcularValorPagarEnergia(Dictionary<int, Dictionary<string, int>> clientes)
        {
            Console.Write("Ingrese el número de cédula del cliente: ");
            int cedula = Convert.ToInt32(Console.ReadLine());

            if (clientes.ContainsKey(cedula)) //Busca la cedula del cliente en el diccionario clientes
            {
                int valorPagarEnergia = ValorPagarEnergia(clientes[cedula]["meta_ahorro_energia"], clientes[cedula]["consumo_actual_energia"]);
                Console.WriteLine($"Valor a pagar por servicios de energía: ${valorPagarEnergia}");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }

        private static int ValorPagarEnergia(int metaAhorroEnergia, int consumoActualEnergia)
        {
            int costoKilovatio = 850;
            int valorParcial = consumoActualEnergia * costoKilovatio;
            int valorIncentivo = (metaAhorroEnergia - consumoActualEnergia) * costoKilovatio;
            return valorParcial - valorIncentivo;
        }

        public static void CalcularValorPagarAgua(Dictionary<int, Dictionary<string, int>> clientes)
        {
            Console.Write("Ingrese el número de cédula del cliente: ");
            int cedula = Convert.ToInt32(Console.ReadLine());

            if (clientes.ContainsKey(cedula))
            {
                int valorPagarAgua = ValorPagarAgua(clientes[cedula]["promedio_consumo_agua"], clientes[cedula]["consumo_actual_agua"]);
                Console.WriteLine($"Valor a pagar por agua: ${valorPagarAgua}");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }

        private static int ValorPagarAgua(int promedioConsumoAgua, int consumoActualAgua)
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

        public static void CalcularPromedioConsumoEnergiaCliente(Dictionary<int, Dictionary<string, int>> clientes)
        {
            double promedioConsumoEnergia = CalcularPromedioConsumoEnergia(clientes);
            Console.WriteLine($"Promedio del consumo actual de energía: {promedioConsumoEnergia}");
        }

        private static double CalcularPromedioConsumoEnergia(Dictionary<int, Dictionary<string, int>> clientes)
        {
            int totalConsumoEnergia = 0;
            int totalClientes = clientes.Count;

            foreach (var cliente in clientes.Values)
            {
                totalConsumoEnergia += cliente["consumo_actual_energia"];
            }

            return (double)totalConsumoEnergia / totalClientes;
        }

        public static void CalcularValorPagarFactura(Dictionary<int, Dictionary<string, int>> clientes)
        {
            Console.Write("Ingrese el número de cédula del cliente: ");
            int cedula = Convert.ToInt32(Console.ReadLine());

            if (clientes.ContainsKey(cedula))
            {
                int valorPagarEnergia = ValorPagarEnergia(clientes[cedula]["meta_ahorro_energia"], clientes[cedula]["consumo_actual_energia"]);
                int valorPagarAgua = ValorPagarAgua(clientes[cedula]["promedio_consumo_agua"], clientes[cedula]["consumo_actual_agua"]);

                int totalFacturaServicios = ValorPagarFactura(valorPagarEnergia, valorPagarAgua);

                Console.WriteLine($"Total de la factura de servicios: ${totalFacturaServicios}");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }

        private static int ValorPagarFactura(int valorPagarEnergia, int valorPagarAgua)
        {
            int totalFactura = valorPagarEnergia + valorPagarAgua;

            return totalFactura;
        }      

        public static int CalcularDescuentosEnergia(Dictionary<int, Dictionary<string, int>> clientes)
        {
            int totalDescuentos = 0;

            foreach (var cliente in clientes.Values)
            {
                int metaAhorroEnergia = cliente["meta_ahorro_energia"];
                int consumoActualEnergia = cliente["consumo_actual_energia"];

                // Valor a pagar sin descuento
                int valorParcial = consumoActualEnergia * 850;

                // Valor a pagar con descuento
                int valorIncentivo = (metaAhorroEnergia - consumoActualEnergia) * 850;
                int valorPagarConDescuento = valorParcial - valorIncentivo;

                int descuento = valorParcial - valorPagarConDescuento;

                totalDescuentos += descuento;
            }

            return totalDescuentos;
        }

        public static int CalcularExcesoAgua(Dictionary<int, Dictionary<string, int>> clientes)
        {
            int totalExcesoAgua = 0;

            foreach (var cliente in clientes.Values)
            {
                int promedioConsumoAgua = cliente["promedio_consumo_agua"];
                int consumoActualAgua = cliente["consumo_actual_agua"];

                if (consumoActualAgua > promedioConsumoAgua)
                {
                    // Cantidad de metros cúbicos consumidos por encima del promedio
                    int excesoAgua = consumoActualAgua - promedioConsumoAgua;

                    totalExcesoAgua += excesoAgua;
                }
            }

            return totalExcesoAgua;
        }

        public static void CalcularPorcentajeExcesoAguaPorEstrato(Dictionary<int, Dictionary<string, int>> clientes)
        {
            Dictionary<int, int> totalExcesoAguaPorEstrato = new Dictionary<int, int>();

            Dictionary<int, int> totalAguaPorEstrato = new Dictionary<int, int>();

            foreach (var cliente in clientes.Values)
            {
                int estrato = cliente["estrato"];
                int promedioConsumoAgua = cliente["promedio_consumo_agua"];
                int consumoActualAgua = cliente["consumo_actual_agua"];

                // Verifica si el estrato ya está en los diccionarios, si no lo crea
                if (!totalExcesoAguaPorEstrato.ContainsKey(estrato))
                {
                    totalExcesoAguaPorEstrato[estrato] = 0;
                    totalAguaPorEstrato[estrato] = 0;
                }

                totalAguaPorEstrato[estrato] += consumoActualAgua;

                if (consumoActualAgua > promedioConsumoAgua)
                {
                    // Metros cúbicos consumidos por encima del promedio
                    int excesoAgua = consumoActualAgua - promedioConsumoAgua;

                    totalExcesoAguaPorEstrato[estrato] += excesoAgua;
                }
            }

            Console.WriteLine("Porcentaje de consumo excesivo de agua por estrato:");
            foreach (var estrato in totalExcesoAguaPorEstrato.Keys)
            {
                double porcentaje = (double)totalExcesoAguaPorEstrato[estrato] / totalAguaPorEstrato[estrato] * 100;
                Console.WriteLine($"Estrato {estrato}: {porcentaje}%");
            }
        }

        public static int CalcularConsumoMayorPromedio(Dictionary<int, Dictionary<string, int>> clientes)
        {
            int contadorClientes = 0;

            foreach (var cliente in clientes.Values)
            {
                int promedioConsumoAgua = cliente["promedio_consumo_agua"];
                int consumoActualAgua = cliente["consumo_actual_agua"];

                if (consumoActualAgua > promedioConsumoAgua)
                {
                    contadorClientes++;
                }
            }

            return contadorClientes;
        }



    }
}
