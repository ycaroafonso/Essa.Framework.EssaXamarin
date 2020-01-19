namespace Essa.Framework.XamarinUtil.Util
{
    using Essa.Framework.XamarinUtil.Interface;
    using Essa.Framework.XamarinUtil.Models.Enums;

    public class DisplayAlertUtil : IDisplayAlert
    {
        public SituacaoMensagemEnum SituacaoMensagem { get; private set; }

        public string title { get; set; }

        public string message { get; set; }

        public string cancel { get; set; }

        public string accept { get; set; }


        public DisplayAlertUtil() { }

        public DisplayAlertUtil(string title) : this(title, string.Empty, "Ok") { }
        public DisplayAlertUtil(string title, string message) : this(title, message, "Ok") { }

        public DisplayAlertUtil(string title, string message, string cancel)
        {
            this.title = title;
            this.message = message;
            this.cancel = cancel;
        }

        public DisplayAlertUtil(string title, string message, string accept, string cancel) : this(title, message, cancel)
        {
            this.accept = accept;
        }

        private void Ok(string titulo, string conteudo = "")
        {
            title = titulo;
            message = conteudo;
            cancel = "OK";
            accept = null;
        }

        public void Sucesso(string titulo, string conteudo = "")
        {
            SituacaoMensagem = SituacaoMensagemEnum.Sucesso;
            Ok(titulo, conteudo);
        }
        public void Erro(string titulo, string conteudo = "")
        {
            SituacaoMensagem = SituacaoMensagemEnum.Erro;
            Ok(titulo, conteudo);
        }
    }
}
