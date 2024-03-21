using AhorroConsumoEnergia;

namespace AhorroConsumoEnergia_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestvalorPagarEnergia()
        {
            int metaAhorroEnergia = 150;
            int consumoActualEnergia = 180;

            var result = FuncionesCalculo.ValorPagarEnergia(metaAhorroEnergia, consumoActualEnergia);
            
            int valor_esperado = 178500;

            Assert.AreEqual(valor_esperado, result);
        }


        [TestMethod]
        public void TestValorPagarAgua()
        {
            // se usa de ejemplo uno de los valores de las 3 cedulas, en este caso los valores son de la cedula 3145
            int promedioConsumoAgua = 25;
            int consumoActualAgua = 20;


            var result = FuncionesCalculo.ValorPagarAgua(promedioConsumoAgua, consumoActualAgua);

            int valor_esperado = 92000;

            Assert.AreEqual(valor_esperado, result);
        }


        [TestMethod]
        public void TestPromedioConsumoEnergia()
        {
            List<ListaUsuario> usuarios = new List<ListaUsuario>();
            usuarios.Add(new ListaUsuario(3145, "Usuario1", "Apellido1", 1, 3, 150, 180, 25, 20));
            usuarios.Add(new ListaUsuario(8947, "Usuario2", "Apellido2", 2, 3, 190, 187, 25, 30));
            usuarios.Add(new ListaUsuario(9812, "Usuario3", "Apellido3", 3, 4, 260, 320, 25, 25));

            double promedio = (180 + 187 + 320) / 3.0;

            double actualPromedio = FuncionesCalculo.PromedioConsumoEnergia(usuarios);

            Assert.AreEqual(promedio, actualPromedio);
        }

        [TestMethod]
        public void TestvalorPagarFactura()
        {
            int valorPagarEnergia = 178500;
            int valorPagarAgua = 92000;

            var result = AhorroConsumoEnergia.FuncionesCalculo.ValorPagarFactura(valorPagarEnergia, valorPagarAgua);
            int valorEsperado = 270500;

            Assert.AreEqual(valorEsperado, result);
        }

        [TestMethod]
        public void TestCalcularDescuentosEnergia()
        {
            List<ListaUsuario> usuarios = new List<ListaUsuario>();
            usuarios.Add(new ListaUsuario(3145, "Usuario1", "Apellido1", 1, 3, 150, 180, 25, 20));
            usuarios.Add(new ListaUsuario(8947, "Usuario2", "Apellido2", 2, 3, 190, 187, 25, 30));
            usuarios.Add(new ListaUsuario(9812, "Usuario3", "Apellido3", 3, 4, 260, 320, 25, 25));

            int costoKilovatio = 850;
            int descuentoUsuario1 = 0; 
            int descuentoUsuario2 = (190 - 187) * costoKilovatio; 
            int descuentoUsuario3 = 0; 

            int totalDescuentosEnergiaEsperado = descuentoUsuario1 + descuentoUsuario2 + descuentoUsuario3;

            // Act
            int totalDescuentosEnergiaActual = FuncionesCalculo.CalcularDescuentosEnergia(usuarios);

            // Assert
            Assert.AreEqual(totalDescuentosEnergiaEsperado, totalDescuentosEnergiaActual, "El total de descuentos de energía calculado no es el esperado.");
        }

        [TestMethod]
        public void TestCalcularExcesoAgua()
        {
            List<ListaUsuario> usuarios = new List<ListaUsuario>();
            usuarios.Add(new ListaUsuario(3145, "Usuario1", "Apellido1", 1, 3, 150, 180, 25, 20));
            usuarios.Add(new ListaUsuario(8947, "Usuario2", "Apellido2", 2, 3, 190, 187, 25, 30));
            usuarios.Add(new ListaUsuario(9812, "Usuario3", "Apellido3", 3, 4, 260, 320, 25, 25));

            int excesoAguaUsuario1 = usuarios[0].consumo_actual_agua - usuarios[0].promedio_consumo_agua; // Cálculo del exceso de agua para el primer usuario
            int excesoAguaUsuario2 = usuarios[1].consumo_actual_agua - usuarios[1].promedio_consumo_agua; // Cálculo del exceso de agua para el segundo usuario
            int excesoAguaUsuario3 = usuarios[2].consumo_actual_agua - usuarios[2].promedio_consumo_agua; // Cálculo del exceso de agua para el tercer usuario

            // Verificación de que el exceso de agua sea positivo, si no, se establece en 0
            if (excesoAguaUsuario1 < 0)
                excesoAguaUsuario1 = 0;
            if (excesoAguaUsuario2 < 0)
                excesoAguaUsuario2 = 0;
            if (excesoAguaUsuario3 < 0)
                excesoAguaUsuario3 = 0;

            int totalExcesoAguaEsperado = excesoAguaUsuario1 + excesoAguaUsuario2 + excesoAguaUsuario3; // Cálculo del total de exceso de agua esperado

            // Act
            int totalExcesoAguaActual = FuncionesCalculo.CalcularExcesoAgua(usuarios); // Llamada al método a probar

            // Assert
            Assert.AreEqual(totalExcesoAguaEsperado, totalExcesoAguaActual);
        }

        /* Falta este test
        [TestMethod]
        public void TestCalcularPorcentajeExcesoAguaPorEstrato()
        {
            List<ListaUsuario> usuarios = new List<ListaUsuario>();
            usuarios.Add(new ListaUsuario(3145, "Usuario1", "Apellido1", 1, 3, 150, 180, 25, 20));
            usuarios.Add(new ListaUsuario(8947, "Usuario2", "Apellido2", 2, 3, 190, 187, 25, 30));
            usuarios.Add(new ListaUsuario(9812, "Usuario3", "Apellido3", 3, 4, 260, 320, 25, 25));
        }*/

        [TestMethod]
        public void TestCalcularConsumoMayorPromedio()
        {
            List<ListaUsuario> usuarios = new List<ListaUsuario>();
            usuarios.Add(new ListaUsuario(3145, "Usuario1", "Apellido1", 1, 3, 150, 180, 25, 20));
            usuarios.Add(new ListaUsuario(8947, "Usuario2", "Apellido2", 2, 3, 190, 187, 25, 30));
            usuarios.Add(new ListaUsuario(9812, "Usuario3", "Apellido3", 3, 4, 260, 320, 25, 25));

            int contadorClientesEsperado = 1; // Solo el Usuario2 tiene un consumo actual de agua mayor que el promedio

            int contadorClientesActual = FuncionesCalculo.CalcularConsumoMayorPromedio(usuarios);

            Assert.AreEqual(contadorClientesEsperado, contadorClientesActual, "El número de clientes con un consumo de agua mayor que el promedio no es el esperado.");
        }

    }
}