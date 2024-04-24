using System.Text;

namespace WatchShop_Core.Models.Messages.Request
{
    public class PostMessageModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Message { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Имя: {FirstName}");
            sb.AppendLine($"Фамилия: {LastName}");
            sb.AppendLine($"Email: {Email}");
            sb.AppendLine($"Телефон: {Phone}");
            sb.AppendLine($"Сообщение: {Message}");

            return sb.ToString();
        }
    }
}
