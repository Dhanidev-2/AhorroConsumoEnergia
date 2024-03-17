using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhorroConsumoEnergia
{
    public class ListaUsuario
    {
        public int cedula, estrato, meta_ahorro_energia, consumo_actual_energia, promedio_consumo_agua, consumo_actual_agua;

        public int Cedula
        {
            get
            {
                return cedula;
            }

            set
            {
                cedula = value;
            }
        }

        public ListaUsuario(int cedula, int estrato, int meta_ahorro_energia, int consumo_actual_energia, int promedio_consumo_agua, int consumo_actual_agua)
        {
            this.cedula = cedula;
            this.estrato = estrato;
            this.meta_ahorro_energia = meta_ahorro_energia;
            this.consumo_actual_energia = consumo_actual_energia;
            this.promedio_consumo_agua = promedio_consumo_agua;
            this.consumo_actual_agua = consumo_actual_agua;
        }
    }
}
