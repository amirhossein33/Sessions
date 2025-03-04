
namespace CustomersHelp
{
    //Singleton
    public class SupportRequestManager
    {
        private static readonly Lazy<SupportRequestManager> _instance =
            new(() => new SupportRequestManager());
        private readonly Queue<string> _requests = new();

        private SupportRequestManager() { }

        public static SupportRequestManager Instance => _instance.Value;

        public void AddRequest(string request)
        {
            _requests.Enqueue(request);
        }

        public string? GetNextRequest()
        {
            return _requests.Count > 0 ? _requests.Dequeue() : null;
        }
    }

    public interface ISupportRequest
    {
        void ProcessRequest();
    }

    public class TechnicalSupportRequest : ISupportRequest
    {
        public void ProcessRequest()
        {
            Console.WriteLine("Support Request");
        }
    }

    public class FinancialSupportRequest : ISupportRequest
    {
        public void ProcessRequest()
        {
            Console.WriteLine("Process Request Completed.");
        }
    }

    public class SuggestionRequest : ISupportRequest
    {
        public void ProcessRequest()
        {
            Console.WriteLine("SuggestionRequest.");
        }
    }

    // Factory Method
    public abstract class SupportRequestFactory
    {
        public abstract ISupportRequest CreateRequest();
    }

    public class TechnicalRequestFactory : SupportRequestFactory
    {
        public override ISupportRequest CreateRequest()
        {
            return new TechnicalSupportRequest();
        }
    }

    public class FinancialRequestFactory : SupportRequestFactory
    {
        public override ISupportRequest CreateRequest()
        {
            return new FinancialSupportRequest();
        }
    }

    public interface IEmailSupport
    {
        void SendEmailResponse();
    }

    public interface IPhoneSupport
    {
        void MakeCall();
    }

    public class EmailSupport : IEmailSupport
    {
        public void SendEmailResponse()
        {
            Console.WriteLine("Email Response Sended.");
        }
    }

    public class PhoneSupport : IPhoneSupport
    {
        public void MakeCall()
        {
            Console.WriteLine("Called to Customer");
        }
    }

    // Abstract Factory
    public interface ICommunicationFactory
    {
        IEmailSupport CreateEmailSupport();
        IPhoneSupport CreatePhoneSupport();
    }

    public class CommunicationFactory : ICommunicationFactory
    {
        public IEmailSupport CreateEmailSupport()
        {
            return new EmailSupport();
        }

        public IPhoneSupport CreatePhoneSupport()
        {
            return new PhoneSupport();
        }
    }
    //Chain of Responsibility
    public abstract class RequestApproval
    {
        protected RequestApproval _next;

        public void SetNext(RequestApproval next)
        {
            _next = next;
        }

        public abstract void HandleRequest(string request);
    }

    public class UserValidation : RequestApproval
    {
        public override void HandleRequest(string request)
        {
            Console.WriteLine($"Validating user for request {request}...");
            _next?.HandleRequest(request);
        }
    }

    public class SecurityCheck : RequestApproval
    {
        public override void HandleRequest(string request)
        {
            Console.WriteLine($"Performing security check for request {request}...");
            _next?.HandleRequest(request);
        }
    }

    public interface IVisitor
    {
        void Visit(SupportRequest request);
    }
    //visitor
    public class VIPRequestChecker : IVisitor
    {
        public void Visit(SupportRequest request)
        {
            Console.WriteLine($"Checking VIP status for request {request.RequestType}...");
        }
    }


    public class SupportRequest
    {
        public string RequestType { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("### Support Ticket System ###\n");

            // مدیریت درخواست‌ها
            SupportRequestManager.Instance.AddRequest("Request#001");

            // ایجاد درخواست جدید
            SupportRequestFactory requestFactory = new TechnicalRequestFactory();
            ISupportRequest request = requestFactory.CreateRequest();
            request.ProcessRequest();

            // انتخاب روش ارتباط با مشتری
            ICommunicationFactory communicationFactory = new CommunicationFactory();
            IEmailSupport emailSupport = communicationFactory.CreateEmailSupport();
            emailSupport.SendEmailResponse();

            // پردازش تأییدیه‌ها
            RequestApproval userCheck = new UserValidation();
            RequestApproval securityCheck = new SecurityCheck();
            userCheck.SetNext(securityCheck);
            userCheck.HandleRequest("Request#001");

            // بررسی VIP
            SupportRequest supportRequest = new SupportRequest { RequestType = "Technical" };
            IVisitor vipChecker = new VIPRequestChecker();
            supportRequest.Accept(vipChecker);

            Console.ReadLine();
        }
    }
}