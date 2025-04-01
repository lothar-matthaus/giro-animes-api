using Giro.Animes.Application.Responses.Base;
using Giro.Animes.Domain.ValueObjects;
using System.Net;

namespace Giro.Animes.Application.Responses
{
    public class NotificationResponse : ApiResponse
    {
        /// <summary>
        /// Lista de notificações da aplicação (erros, alertas, etc)
        /// </summary>
        public IEnumerable<Notification> List { get; private set; }

        /// <summary>
        /// Cria uma instância de NotificationResponse com sucesso e sem notificações (erros, alertas, etc)
        /// </summary>
        /// <param name="notifications"></param>
        /// <param name="isSuccess"></param>
        /// <param name="httpStatusCode"></param>
        /// <param name="message"></param>
        private NotificationResponse(IEnumerable<Notification> notifications, bool isSuccess, HttpStatusCode httpStatusCode, string message) : base(isSuccess, httpStatusCode, message)
        {
            List = notifications;
        }

        public static NotificationResponse Create(IEnumerable<Notification> notifications, bool isSuccess, HttpStatusCode httpStatusCode, string message)
        {
            return new NotificationResponse(notifications, isSuccess, httpStatusCode, message);
        }

    }
}
