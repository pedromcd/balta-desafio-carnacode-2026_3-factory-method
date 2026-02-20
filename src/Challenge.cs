using System;

namespace DesignPatternChallenge
{
    // ============================
    // 1) Produto (Interface)
    // ============================

    public interface INotification
    {
        void Send(string recipient, string title, string message);
    }

    // ============================
    // 2) Produtos Concretos
    // ============================

    public class EmailNotification : INotification
    {
        public void Send(string recipient, string title, string message)
        {
            Console.WriteLine($"📧 Email para {recipient}");
            Console.WriteLine($"   Assunto: {title}");
            Console.WriteLine($"   Mensagem: {message}");
        }
    }

    public class SmsNotification : INotification
    {
        public void Send(string recipient, string title, string message)
        {
            Console.WriteLine($"📱 SMS para {recipient}");
            Console.WriteLine($"   Mensagem: {message}");
        }
    }

    public class PushNotification : INotification
    {
        public void Send(string recipient, string title, string message)
        {
            Console.WriteLine($"🔔 Push para {recipient}");
            Console.WriteLine($"   Título: {title}");
            Console.WriteLine($"   Mensagem: {message}");
        }
    }

    public class WhatsAppNotification : INotification
    {
        public void Send(string recipient, string title, string message)
        {
            Console.WriteLine($"💬 WhatsApp para {recipient}");
            Console.WriteLine($"   Mensagem: {message}");
        }
    }

    // ============================
    // 3) Creator (Factory Method)
    // ============================

    public abstract class NotificationCreator
    {
        // Factory Method
        public abstract INotification CreateNotification();

        // Template Method (lógica comum)
        public void Notify(string recipient, string title, string message)
        {
            var notification = CreateNotification();
            notification.Send(recipient, title, message);
        }
    }

    // ============================
    // 4) Concrete Creators
    // ============================

    public class EmailNotificationCreator : NotificationCreator
    {
        public override INotification CreateNotification()
        {
            return new EmailNotification();
        }
    }

    public class SmsNotificationCreator : NotificationCreator
    {
        public override INotification CreateNotification()
        {
            return new SmsNotification();
        }
    }

    public class PushNotificationCreator : NotificationCreator
    {
        public override INotification CreateNotification()
        {
            return new PushNotification();
        }
    }

    public class WhatsAppNotificationCreator : NotificationCreator
    {
        public override INotification CreateNotification()
        {
            return new WhatsAppNotification();
        }
    }

    // ============================
    // 5) Cliente (Não conhece classes concretas)
    // ============================

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Notificações (Factory Method) ===\n");

            NotificationCreator email = new EmailNotificationCreator();
            email.Notify("cliente@email.com", "Pedido Confirmado", "Seu pedido 12345 foi confirmado!");

            Console.WriteLine();

            NotificationCreator sms = new SmsNotificationCreator();
            sms.Notify("+5511999999999", "", "Pedido 12346 confirmado!");

            Console.WriteLine();

            NotificationCreator push = new PushNotificationCreator();
            push.Notify("device-token-abc123", "Pedido Enviado", "Rastreamento BR123456789");

            Console.WriteLine();

            NotificationCreator whatsapp = new WhatsAppNotificationCreator();
            whatsapp.Notify("+5511888888888", "", "Pagamento pendente de R$ 150,00");

            Console.ReadLine();
        }
    }
}