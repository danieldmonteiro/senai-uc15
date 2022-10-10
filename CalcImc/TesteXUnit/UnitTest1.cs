using CalcImc;

namespace TesteXUnit;

public class UnitTest1
{
    [Theory]
    [InlineData(100, 1.7, "Obesidade grau 1")]
    [InlineData(90, 1.8, "Sobrepeso")]
    [InlineData(60, 1.6, "Peso normal")]
    public void TesteCalcImc(double kg, double altura, string resultadoTeste)
    {
        //Act
        var resultadoImc = Calculadora.CalcularImc(kg, altura);

        //Assert
        Assert.Equal(resultadoTeste, resultadoImc);
    }
}
