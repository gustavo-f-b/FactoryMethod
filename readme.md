
#  Factory Method

  
Vamos criar uma situação prática para aplicar o padrão Factory Method, focada no desenvolvimento de um aplicativo de gerenciamento de documentos. Imagine que você está construindo um sistema que precisa suportar diferentes tipos de documentos, como textos, planilhas e apresentações. Cada tipo de documento tem sua própria maneira de ser criado, editado e salvo. No entanto, o aplicativo deve ser capaz de tratar todos esses documentos de forma genérica em muitos pontos do sistema, como na interface do usuário, onde o usuário pode escolher criar um novo documento de qualquer tipo.

### Contexto

O sistema deve permitir ao usuário criar diferentes tipos de documentos sem saber os detalhes da criação de cada tipo específico. Além disso, o sistema deve ser extensível para que novos tipos de documentos possam ser adicionados no futuro sem a necessidade de modificar o código que utiliza os documentos.

## Estrutura

1.  **Produto Abstrato (`IDocumento`):** Uma interface que define a operação comum a todos os documentos concretos que serão criados. Por exemplo, pode incluir métodos como `abrir()`, `salvar()`, `editar()` e `fechar()`.
    
2.  **Produtos Concretos (`Pdf`, `Planilha`,):** Classes que implementam a interface `IDocumento`, representando diferentes tipos de documentos que o aplicativo pode criar.
    
3.  **Criador Abstrato (`IDocumentoFactory`):** Uma interface que declara o método fábrica, por exemplo, `criarDocumento(): IDocumento`.
    
4.  **Criadores Concretos (`CriadorFactoryPdf`, `CriadorFactoryPlanilha`):** Classes que implementam a interface `IDocumentoFactory`, cada uma responsável por criar instâncias de um tipo específico de documento.
    

## Situação Prática para Implementar

Você deve implementar o padrão Factory Method no seu sistema de gerenciamento de documentos seguindo estes passos:

1.  **Definir a interface `Documento`** com os métodos comuns necessários.
    
2.  **Implementar as classes concretas `Texto`, `Planilha`** que representam os diferentes tipos de documentos.
    
3.  **Criar a interface `DocumentoFactory`** com um método `criarDocumento()`.
    
4.  **Implementar as classes `CriadorFactoryPlanilha`, `CriadorFactoryPdf`**, cada uma criando o tipo correspondente de documento.
    

## **Observação**

 Também foi criado a classe abstrata **`CriadorDocumento`** que contém um método abstrato  `documentoFactory(): IDocumento` , **enum `TipoOperacao` ( `Abrir`,  `Editar`,  `Salvar`,  `Fechar`)**,  método  `Validar()` e outro  `ManipularDocumento(tipoOperacao: TipoOperacao)`. Essa classe abstrata pode ser usada para casos que contenha alguma regra de negócio comum antes de executar os métodos comuns.