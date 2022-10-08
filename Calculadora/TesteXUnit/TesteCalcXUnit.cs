using Calculadora;

namespace TesteXUnit

{ 

    public class TesteCalcXUnit
    {
        [Fact]
        public void SomarDoisNumeros()
        {
            //Arrange:
            double pNum = 1;
            double sNum = 2;
            double rNum = 3;

            //Act:

            var resultado = Calculadora.Somar(pNum, sNum);

            //Assert:

            Assert.Equal(rNum, resultado);

        }

        [Theory]
        [InLineData(1, 1, 2)]
        [InLineData(2, 2, 4)]
        [InLineData(2, 3, 5)]

        public void SomarDoisNumerosLista(double pNum, double sNum, double rNum)
        {
            //Act:

            var resultado = Calculadora.Somar(pNum, sNum);

            //Assert:

            Assert.Equal(rNum, resultado);

        }

    }
}
