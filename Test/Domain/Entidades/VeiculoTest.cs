using MinimalApi.Dominio.Entidades;

namespace Test.Domain.Entidades;

[TestClass]

public class VeiculoTest
{
    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        //Arrange
        var veiculo = new Veiculo();

        //Act
        veiculo.Id = 1;
        veiculo.Nome = "Onix";
        veiculo.Marca = "Chevrolet";
        veiculo.Ano = 2000;

        //Assert
        Assert.AreEqual(1, veiculo.Id);
        Assert.AreEqual("Onix", veiculo.Nome);
        Assert.AreEqual("Chevrolet", veiculo.Marca);
        Assert.AreEqual(2000, veiculo.Ano);
    }
}