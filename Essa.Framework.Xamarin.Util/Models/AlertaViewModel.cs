using System;
using System.Collections.Generic;
using System.Text;

namespace Essa.Framework.Util.Models
{
    public class AlertaViewModel
    {
        public AlertaViewModel() { }
        public AlertaViewModel(string tipo, string mensagemErro, string botaoCancelar)
        {
            Tipo = tipo;
            MensagemErro = mensagemErro;
            BotaoCancelar = botaoCancelar;
        }

        public string MensagemErro { get; set; }
        public string Tipo { get; set; }
        public string BotaoCancelar { get; set; }
    }
}
