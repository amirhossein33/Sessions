using System;

namespace ChainOfResponsibilityPattern
{
    // تعیین سطح اولویت پیام‌ها
    public enum MessagePriority
    {
        Normal,
        High
    }

    // کلاس پیام شامل متن و سطح اولویت
    public class Message
    {
        public string Text;
        public MessagePriority Priority;

        public Message(string msg, MessagePriority p)
        {
            Text = msg;
            Priority = p;
        }
    }

    // اینترفیس پردازشگر درخواست‌ها
    public interface IReceiver
    {
        bool HandleMessage(Message message);
    }

    // پردازشگر اصلی که پیام را به زنجیره پردازش ارسال می‌کند
    public class IssueRaiser
    {
        private IReceiver firstReceiver;

        public IssueRaiser(IReceiver firstReceiver)
        {
            this.firstReceiver = firstReceiver;
        }

        public void RaiseMessage(Message message)
        {
            if (firstReceiver != null)
                firstReceiver.HandleMessage(message);
        }
    }

    // پردازشگر مشکلات مربوط به فکس
    public class FaxErrorHandler : IReceiver
    {
        private IReceiver nextReceiver;

        public FaxErrorHandler(IReceiver nextReceiver)
        {
            this.nextReceiver = nextReceiver;
        }

        public bool HandleMessage(Message message)
        {
            if (message.Text.Contains("Fax"))
            {
                Console.WriteLine("📠 FaxErrorHandler پردازش شد: {0} - اولویت: {1}",
                    message.Text, message.Priority);
                return true;
            }
            else if (nextReceiver != null)
            {
                return nextReceiver.HandleMessage(message);
            }
            return false;
        }
    }

    // پردازشگر مشکلات مربوط به ایمیل
    public class EmailErrorHandler : IReceiver
    {
        private IReceiver nextReceiver;

        public EmailErrorHandler(IReceiver nextReceiver)
        {
            this.nextReceiver = nextReceiver;
        }

        public bool HandleMessage(Message message)
        {
            if (message.Text.Contains("Email"))
            {
                Console.WriteLine("📧 EmailErrorHandler پردازش شد: {0} - اولویت: {1}",
                    message.Text, message.Priority);
                return true;
            }
            else if (nextReceiver != null)
            {
                return nextReceiver.HandleMessage(message);
            }
            return false;
        }
    }

    // کلاس اصلی برنامه برای اجرای زنجیره پردازش
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n🔗 *** Chain of Responsibility Pattern Demo *** 🔗\n");

            // ایجاد پردازشگرهای خطا
            IReceiver emailHandler = new EmailErrorHandler(null);
            IReceiver faxHandler = new FaxErrorHandler(emailHandler);

            // شروع زنجیره‌ی پردازش
            IssueRaiser raiser = new IssueRaiser(faxHandler);

            // ایجاد پیام‌های تستی
            Message m1 = new ("Fax is reaching late to the destination.", MessagePriority.Normal);
            Message m2 = new ("Emails are not reaching destinations.", MessagePriority.High);
            Message m3 = new ("In Email, CC field is disabled always.", MessagePriority.Normal);
            Message m4 = new ("Fax is not reaching destination.", MessagePriority.High);

            // ارسال پیام‌ها برای پردازش
            raiser.RaiseMessage(m1);
            raiser.RaiseMessage(m2);
            raiser.RaiseMessage(m3);
            raiser.RaiseMessage(m4);

            Console.ReadKey();
        }
    }
}
