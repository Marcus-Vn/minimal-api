using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Infraestrutura.Db;

namespace Test.Domain.Entidades;

[TestClass]
public class AdministradorServicoTest
{
    private DbContexto CriarContextoDeTeste()
    {
        var options = new DbContextOptionsBuilder<DbContexto>()
            .UseInMemoryDatabase(databaseName: "TesteDb")
            .Options;

        return new DbContexto(options);
    }

    [TestMethod]
    public void TesteBuscaPorId()
    {
        // Arrange
        var context = CriarContextoDeTeste();

        // Limpa a tabela antes do teste
        context.Administradores.RemoveRange(context.Administradores);
        context.SaveChanges();

        var adm = new Administrador
        {
            Email = "teste@teste.com",
            Senha = "teste",
            Perfil = "Adm"
        };

        var administradorServico = new AdministradorServico(context);

        // Act
        administradorServico.Incluir(adm);
        var admBanco = administradorServico.BuscaPorId(adm.Id);

        // Assert
        Assert.IsNotNull(admBanco);
        Assert.AreEqual(adm.Id, admBanco.Id);
    }
}
