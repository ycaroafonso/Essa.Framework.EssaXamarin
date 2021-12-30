namespace Essa.Framework.Util.Util
{
    using Plugin.LocalNotification;
    using System;


    public interface ILocalNotificacaoService
    {
        void Cadastrar(string titulo, string corpo, int notificationId, DateTime dataNotificacao);

        void Cancelar(int notificationId);
    }

    public class LocalNotificacaoService : ILocalNotificacaoService
    {
        public LocalNotificacaoService()
        {
        }


        public void Cadastrar(string titulo, string corpo, int notificationId, DateTime dataNotificacao)
        {
            var notification = new NotificationRequest
            {
                NotificationId = notificationId,
                Title = titulo,
                Description = corpo,
                ReturningData = "Dummy data", // Returning data when tapped on notification.
                NotifyTime = dataNotificacao // Used for Scheduling local notification, if not specified notification will show immediately.
            };
            NotificationCenter.Current.Show(notification);
        }

        public void Cancelar(int notificationId)
        {
            NotificationCenter.Current.Cancel(notificationId);
        }

        public void CancelarTodos()
        {
            NotificationCenter.Current.CancelAll();
        }
    }
}
