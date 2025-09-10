using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Infraestrutura.Db;
using System.Reflection;
using DotNetEnv;

namespace Test.Domain.Entidades;

[TestClass]

public class AdministradorServicoTest
{
    private DbContexto CriarContextoDeTeste()
    {
        // Caminho da pasta raiz da solução (3 níveis acima de bin/Debug/net9.0)
        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var solutionRoot = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", "..", ".."));

        // Carrega .env da raiz
        Env.Load(Path.Combine(solutionRoot, ".env"));

        // Caminho do appsettings.json dentro do projeto Test
        var testProjectPath = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));
        
        var builder = new ConfigurationBuilder()
            .SetBasePath(testProjectPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        var configuration = builder.Build();

        var rawConn = configuration.GetConnectionString("MySql");
        var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

        if (string.IsNullOrEmpty(rawConn))
            throw new InvalidOperationException("Connection string 'mysql' não encontrada no appsettings.json");

        if (string.IsNullOrEmpty(dbPassword))
            throw new InvalidOperationException("Variável DB_PASSWORD não encontrada no .env ou ambiente");

        // Substitui placeholder pelo valor real
        var conn = rawConn.Replace("{DB_PASSWORD}", dbPassword);
        Console.WriteLine(conn);

        var optionsBuilder = new DbContextOptionsBuilder<DbContexto>();
        optionsBuilder.UseMySql(conn, ServerVersion.AutoDetect(conn));

        return new DbContexto(configuration);
    }

    [TestMethod]
    public void TesteBuscaPorId()
    {
        //Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

        var adm = new Administrador();
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";

        var administradorServico = new AdministradorServico(context);

        //Act
        administradorServico.Incluir(adm);
        var admBanco = administradorServico.BuscaPorId(adm.Id);

        //Assert
        Assert.AreEqual(1, admBanco?.Id);
    }
}