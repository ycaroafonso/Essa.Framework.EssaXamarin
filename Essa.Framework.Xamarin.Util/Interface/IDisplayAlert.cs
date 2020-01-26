namespace Essa.Framework.Util.Interface
{
    using Essa.Framework.Util.Models.Enums;


    public interface IDisplayAlert
    {
        SituacaoMensagemEnum SituacaoMensagem { get; }

        string title { get; }
        string message { get; }
        string cancel { get; }


        string accept { get; }

        //void Ok(string titulo, string conteudo = "");
        void Sucesso(string titulo, string conteudo = "");
        void Erro(string titulo, string conteudo = "");
    }



    public interface IRetornarMensagemDisplayAlert
    {
        IDisplayAlert Mensagem { get; }
    }
}
