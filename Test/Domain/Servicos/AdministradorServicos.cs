private DbContexto CriarContextoDeTeste()
{
    // Caminho da pasta raiz da solução (3 níveis acima de bin/Debug/net9.0)
    var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    var solutionRoot = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", "..", ".."));

    // Caminho do appsettings.json dentro do projeto Test
    var testProjectPath = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));

    var builder = new ConfigurationBuilder()
        .SetBasePath(testProjectPath)
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

    var configuration = builder.Build();

    // Lê a connection string MySql diretamente
    var conn = configuration.GetConnectionString("MySql");

    if (string.IsNullOrEmpty(conn))
        throw new InvalidOperationException("Connection string 'MySql' não encontrada no appsettings.json");

    Console.WriteLine(conn);

    var optionsBuilder = new DbContextOptionsBuilder<DbContexto>();
    optionsBuilder.UseMySql(conn, ServerVersion.AutoDetect(conn));

    return new DbContexto(configuration);
}
