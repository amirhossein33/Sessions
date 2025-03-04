using System;

namespace ChainOfResponsibilityPattern
{
    // Define message priority levels
    public enum MessagePriority
    {
        Normal,
        High
    }

    // Message class containing text and priority level
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

    // Interface for message handlers
    public interface IReceiver
    {
        bool HandleMessage(Message message);
    }

    // Main handler that passes the message down the chain
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

    // Fax error handler
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
                Console.WriteLine("📠 FaxErrorHandler processed: {0} - Priority: {1}",
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

    // Email error handler
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
                Console.WriteLine("📧 EmailErrorHandler processed: {0} - Priority: {1}",
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

    // Main program class to execute the processing chain
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n🔗 *** Chain of Responsibility Pattern Demo *** 🔗\n");

            // Create error handlers
            IReceiver emailHandler = new EmailErrorHandler(null);
            IReceiver faxHandler = new FaxErrorHandler(emailHandler);

            // Start the processing chain
            IssueRaiser raiser = new IssueRaiser(faxHandler);

            // Create test messages
            Message m1 = new("Fax is reaching late to the destination.", MessagePriority.Normal);
            Message m2 = new("Emails are not reaching destinations.", MessagePriority.High);
            Message m3 = new("In Email, CC field is disabled always.", MessagePriority.Normal);
            Message m4 = new("Fax is not reaching destination.", MessagePriority.High);

            // Send messages for processing
            raiser.RaiseMessage(m1);
            raiser.RaiseMessage(m2);
            raiser.RaiseMessage(m3);
            raiser.RaiseMessage(m4);

            Console.ReadKey();
        }
    }
}
