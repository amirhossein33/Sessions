//Singleton
public class UserManager
{
    private static UserManager _instance;
    private static readonly object _lock = new();
    private List<string> _users = [];

    private UserManager() { }

    public static UserManager Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new UserManager();
                }
                return _instance;
            }
        }
    }

    public void AddUser(string username)
    {
        _users.Add(username);
    }

    public bool UserExists(string username)
    {
        return _users.Contains(username);
    }
}
public interface IUserRole
{
    void AccessRights();
}

public class AdminRole : IUserRole
{
    public void AccessRights()
    {
        Console.WriteLine("Admin: Full access to the system.");
    }
}

public class EmployeeRole : IUserRole
{
    public void AccessRights()
    {
        Console.WriteLine("Employee: Limited access to work-related data.");
    }
}

public class GuestRole : IUserRole
{
    public void AccessRights()
    {
        Console.WriteLine("Guest: View public information only.");
    }
}


// Factory Method
public abstract class RoleFactory
{
    public abstract IUserRole CreateRole();
}

public class AdminFactory : RoleFactory
{
    public override IUserRole CreateRole()
    {
        return new AdminRole();
    }
}

public class EmployeeFactory : RoleFactory
{
    public override IUserRole CreateRole()
    {
        return new EmployeeRole();
    }
}

public class GuestFactory : RoleFactory
{
    public override IUserRole CreateRole()
    {
        return new GuestRole();
    }
}
public interface IInternalAuth
{
    void Authenticate(string username, string password);
}

public interface IExternalAuth
{
    void AuthenticateWithProvider(string token);
}

public class PasswordAuth : IInternalAuth
{
    public void Authenticate(string username, string password)
    {
        Console.WriteLine($"احراز هویت {username} با رمز عبور انجام شد.");
    }
}

public class GoogleAuth : IExternalAuth
{
    public void AuthenticateWithProvider(string token)
    {
        Console.WriteLine("احراز هویت با Google انجام شد.");
    }
}

// Abstract Factory
public interface IAuthFactory
{
    IInternalAuth CreateInternalAuth();
    IExternalAuth CreateExternalAuth();
}

public class AuthFactory : IAuthFactory
{
    public IInternalAuth CreateInternalAuth()
    {
        return new PasswordAuth();
    }

    public IExternalAuth CreateExternalAuth()
    {
        return new GoogleAuth();
    }
}
//Chain of Responsibility
public abstract class SecurityCheck
{
    protected SecurityCheck _next;

    public void SetNext(SecurityCheck next)
    {
        _next = next;
    }

    public abstract void HandleRequest(string username);
}

public class AccountStatusCheck : SecurityCheck
{
    public override void HandleRequest(string username)
    {
        Console.WriteLine($"بررسی وضعیت حساب کاربری {username}...");
        _next?.HandleRequest(username);
    }
}

public class OTPCheck : SecurityCheck
{
    public override void HandleRequest(string username)
    {
        Console.WriteLine($"ارسال کد OTP برای {username}...");
        _next?.HandleRequest(username);
    }
}
// Visitor
public interface IVisitor
{
    void Visit(User user);
}

public class PermissionChecker : IVisitor
{
    public void Visit(User user)
    {
        Console.WriteLine($"Permission Check {user.Username}...");
    }
}

public class User
{
    public string Username { get; set; }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("### User Authentication System ###\n");

        // مدیریت کاربران
        UserManager.Instance.AddUser("ali");

        // ایجاد نقش
        RoleFactory roleFactory = new AdminFactory();
        IUserRole admin = roleFactory.CreateRole();
        admin.AccessRights();

        // احراز هویت
        IAuthFactory authFactory = new AuthFactory();
        IInternalAuth internalAuth = authFactory.CreateInternalAuth();
        internalAuth.Authenticate("ali", "password123");

        // پردازش امنیت
        SecurityCheck accountCheck = new AccountStatusCheck();
        SecurityCheck otpCheck = new OTPCheck();
        accountCheck.SetNext(otpCheck);
        accountCheck.HandleRequest("ali");

        // بررسی سطح دسترسی
        User user = new () { Username = "ali" };
        IVisitor permissionChecker = new PermissionChecker();
        user.Accept(permissionChecker);

        Console.ReadLine();
    }
}
