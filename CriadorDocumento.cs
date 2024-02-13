namespace FactoryMethod
{
    //Dessa forma também pode ser inserido algumas regras de negócio para valição, por exemplo.
    public abstract class CriadorDocumento
    {
        public abstract IDocumento DocumentoFactory();

        public enum TipoOperacao
        {
          Abrir = 1,
          Editar = 2,
          Salvar = 3,
          Fechar = 4
        }

        //Caso tenha alguma regra de negócio para validar caminho do arquivo e afins...
        private bool Validar()
        {
            //Código de validação...
            return true;
        }

        public void ManipularDocumento(TipoOperacao tipoOperacao)
        {
            _ = Validar();

            //Chama a fábrica de métodos para criar o documeto
            var documento = DocumentoFactory();

            switch (tipoOperacao)
            {
                case TipoOperacao.Abrir:
                    documento.Abrir();
                    break;
                case TipoOperacao.Editar:
                    documento.Editar();
                    break;
                case TipoOperacao.Salvar:
                    documento.Salvar();
                    break;
                case TipoOperacao.Fechar:
                    documento.Fechar();
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

        }
    }

    //Para uso mais simples sem a necessidade direta de adicionar regra de negócio.
    public interface IDocumentoFactory
    {
        IDocumento CriarDocumento();
    }


    //Criador do tipo Pdf.
    public class CriadorFactoryPdf : IDocumentoFactory
    {
        public IDocumento CriarDocumento()
            => new Pdf();
    }

    //Criador do tipo Planilha.
    public class CriadorFactoryPlanilha : IDocumentoFactory
    {
        public IDocumento CriarDocumento()
            => new Planilha();
    }

    //Criador concreto que sobrescreve o factory method DocumentoFactory() e altera o tipo do documento resultante para PDF.
    public class CriadorConcretoPdf : CriadorDocumento
    {
        public override IDocumento DocumentoFactory()
            => new Pdf();
    }

    //Criador concreto que sobrescreve o factory method DocumentoFactory() e altera o tipo do documento resultante para Excel.
    public class CriadorConcretoPlanilha : CriadorDocumento
    {
        public override IDocumento DocumentoFactory()
            => new Planilha();
    }

    //Implentação concreta da interface dos métodos com regras para o tipo de documento Pdf.
    class Pdf : IDocumento
    {
        public void Abrir()
        {
            //Código para abrir o arquivo PDF...
            Console.WriteLine("Abrindo PDF....");
        }

        public void Editar()
        {
            //Código para editar o arquivo PDF...
            Console.WriteLine("Editando PDF....");
        }

        public void Fechar()
        {
            //Código para editar o arquivo PDF...
            Console.WriteLine("Fechando PDF....");
        }

        public void Salvar()
        {
            //Código para editar o arquivo PDF...
            Console.WriteLine("Salvando PDF....");
        }
    }

    //Implentação concreta da interface dos métodos com regras para o tipo de documento Excel.
    class Planilha : IDocumento
    {
        public void Abrir()
        {
            //Código para abrir o arquivo excel...
            Console.WriteLine("Abrindo Planilha....");
        }

        public void Editar()
        {
            //Código para editar o arquivo excel...
            Console.WriteLine("Editando Planilha....");
        }

        public void Fechar()
        {
            //Código para fechar o arquivo excel...
            Console.WriteLine("Fechando Planilha....");
        }

        public void Salvar()
        {
            //Código para salvar o arquivo excel...
            Console.WriteLine("Salvando Planilha....") ;
        }
    }


    //A interface IDocumento será nosso produto abstrato.
    public interface IDocumento
    {
        void Abrir();
        void Salvar();
        void Editar();
        void Fechar();
    }
}
