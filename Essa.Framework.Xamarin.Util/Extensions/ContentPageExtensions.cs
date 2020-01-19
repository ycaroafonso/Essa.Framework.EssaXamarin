﻿namespace Essa.Framework.XamarinUtil.Extensions
{
    using Essa.Framework.XamarinUtil.Interface;
    using System.Threading.Tasks;
    using Xamarin.Forms;


    public static class ContentPageExtensions
    {

        public static async Task DisplayAlertAsync(this ContentPage page, IDisplayAlert displayAlert)
        {
            await page.DisplayAlert(displayAlert.title, displayAlert.message, displayAlert.cancel);
        }
        public static async Task DisplayAlertAsync(this ContentPage page, IRetornarMensagemDisplayAlert displayAlert)
        {
            await page.DisplayAlertAsync(displayAlert.Mensagem);
        }
    }
}
