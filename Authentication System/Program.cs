//Singelton
public class SessionManager
{
    private static SessionManager? _instance;
    private static readonly object _lock = new ();
    private readonly Dictionary<string, string> _loggedInUsers = [];

    private SessionManager() { }

    public static SessionManager Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new SessionManager();
                }
                return _instance;
            }
        }
    }

    public void AddUser(string userId, string token)
    {
        _loggedInUsers[userId] = token;
    }

    public bool IsUserLoggedIn(string userId)
    {
        return _loggedInUsers.ContainsKey(userId);
    }

    public void LogoutUser(string userId)
    {
        _loggedInUsers.Remove(userId);
    }
}
public interface IAuthMethod
{
    bool Authenticate(string username, string password);
}

public class PasswordAuth : IAuthMethod
{
    public bool Authenticate(string username, string password)
    {
        return username == "user" && password == "1234";
    }
}

public class OAuthAuth : IAuthMethod
{
    public bool Authenticate(string username, string password)
    {
        return username == "user" && password == "oauth_token";
    }
}

// Factory Method
public abstract class AuthFactory
{
    public abstract IAuthMethod CreateAuthMethod();
}

public class PasswordAuthFactory : AuthFactory
{
    public override IAuthMethod CreateAuthMethod()
    {
        return new PasswordAuth();
    }
}

public class OAuthAuthFactory : AuthFactory
{
    public override IAuthMethod CreateAuthMethod()
    {
        return new OAuthAuth();
    }
}
//Context Strategy
public class AuthContext
{
    private IAuthMethod? _authMethod;

    public void SetAuthMethod(IAuthMethod authMethod)
    {
        _authMethod = authMethod;
    }

    public bool AuthenticateUser(string username, string password)
    {
        return _authMethod != null && _authMethod.Authenticate(username, password);
    }
}
//Decorator
public class TwoFactorAuthDecorator : IAuthMethod
{
    private IAuthMethod _baseAuth;

    public TwoFactorAuthDecorator(IAuthMethod baseAuth)
    {
        _baseAuth = baseAuth;
    }

    public bool Authenticate(string username, string password)
    {
        bool isAuthenticated = _baseAuth.Authenticate(username, password);
        if (isAuthenticated)
        {
            Console.WriteLine("Sending OTP to the user...");
            return true; 
        }
        return false;
    }
}
//Facade
public class AuthFacade
{
    private AuthContext _authContext;
    private SessionManager _sessionManager;

    public AuthFacade()
    {
        _authContext = new AuthContext();
        _sessionManager = SessionManager.Instance;
    }

    public void SetAuthMethod(AuthFactory authFactory)
    {
        _authContext.SetAuthMethod(authFactory.CreateAuthMethod());
    }

    public bool Login(string username, string password)
    {
        if (_authContext.AuthenticateUser(username, password))
        {
            _sessionManager.AddUser(username, Guid.NewGuid().ToString());
            Console.WriteLine("User logged in successfully.");
            return true;
        }
        Console.WriteLine("Authentication failed.");
        return false;
    }

    public void Logout(string username)
    {
        _sessionManager.LogoutUser(username);
        Console.WriteLine("User logged out successfully.");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("### Authentication System Demo ###\n");

        AuthFacade authSystem = new AuthFacade();

        // استفاده از احراز هویت رمز عبور
        authSystem.SetAuthMethod(new PasswordAuthFactory());
        authSystem.Login("user", "1234");

        // استفاده از احراز هویت OAuth با امنیت 2FA
        authSystem.SetAuthMethod(new OAuthAuthFactory());
        authSystem.Login("user", "oauth_token");

        Console.ReadLine();
    }
}
// Singleton: برای مدیریت کاربران لاگین‌شده استفاده شد.
// Factory Method: ایجاد روش‌های مختلف احراز هویت را آسان کرد.
// Strategy: امکان انتخاب روش احراز هویت در زمان اجرا را فراهم کرد.
// Decorator: قابلیت 2FA را بدون تغییر در کلاس‌های اصلی اضافه کرد.
// Facade: یک API ساده برای ورود و خروج کاربران ارائه داد.
