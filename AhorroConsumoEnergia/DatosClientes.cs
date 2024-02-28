using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhorroConsumoEnergia
{
    public static class DatosClientes
    {
        public static Dictionary<int, Dictionary<string, int>> ObtenerClientes()
        {
            return new Dictionary<int, Dictionary<string, int>>()
        {
            {3145, new Dictionary<string, int>() {{"estrato", 3}, {"meta_ahorro_energia", 150}, {"consumo_actual_energia", 180}, {"promedio_consumo_agua", 25}, {"consumo_actual_agua", 20}}},
            {8947, new Dictionary<string, int>() {{"estrato", 3}, {"meta_ahorro_energia", 190}, {"consumo_actual_energia", 187}, {"promedio_consumo_agua", 25}, {"consumo_actual_agua", 30}}},
            {9812, new Dictionary<string, int>() {{"estrato", 4}, {"meta_ahorro_energia", 260}, {"consumo_actual_energia", 320}, {"promedio_consumo_agua", 25}, {"consumo_actual_agua", 25}}}
        };
        }
    }
}
