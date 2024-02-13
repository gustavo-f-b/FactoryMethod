using FactoryMethod;

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Criando um documento de Pdf:");
GerenciadorDocumento.ManipularDocumento(new CriadorConcretoPdf());

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\nCriando um documento de Excel:");
GerenciadorDocumento.ManipularDocumento(new CriadorConcretoPlanilha());

//Também pode ser feito da seguinte forma

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Criando um documento de Pdf:");
GerenciadorDocumento.ManipularDocumento(new CriadorFactoryPdf());

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\nCriando um documento de Excel:");
GerenciadorDocumento.ManipularDocumento(new CriadorFactoryPlanilha());


Console.ForegroundColor = ConsoleColor.White;
class GerenciadorDocumento
{
    public static void ManipularDocumento(CriadorDocumento documento)
    {
        documento.ManipularDocumento(CriadorDocumento.TipoOperacao.Abrir);
        documento.ManipularDocumento(CriadorDocumento.TipoOperacao.Editar);
        documento.ManipularDocumento(CriadorDocumento.TipoOperacao.Salvar);
        documento.ManipularDocumento(CriadorDocumento.TipoOperacao.Fechar);
    }

    public static void ManipularDocumento(IDocumentoFactory documentoFactory)
    {
        var documento = documentoFactory.CriarDocumento();

        documento.Abrir();
        documento.Editar();
        documento.Salvar();
        documento.Fechar();
    }
}

