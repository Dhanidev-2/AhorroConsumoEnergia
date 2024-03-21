using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhorroConsumoEnergia
{
    public class ListaUsuario
    {
        public int cedula, periodo_consumo, estrato, meta_ahorro_energia, consumo_actual_energia, promedio_consumo_agua, consumo_actual_agua;
        public string nombre, apellido;

        
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

        public ListaUsuario(int cedula, string nombre, string apellido, int periodo_consumo, int estrato, int meta_ahorro_energia, int consumo_actual_energia, int promedio_consumo_agua, int consumo_actual_agua)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.apellido = apellido;
            this.periodo_consumo = periodo_consumo;
            this.estrato = estrato;
            this.meta_ahorro_energia = meta_ahorro_energia;
            this.consumo_actual_energia = consumo_actual_energia;
            this.promedio_consumo_agua = promedio_consumo_agua;
            this.consumo_actual_agua = consumo_actual_agua;
        }
    }
}
