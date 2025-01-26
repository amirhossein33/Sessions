namespace SOLID.Sample1
{
    //False
    public class UserCreator
    {
        public void CreateUser(string username, string email, string password)
        {
            // Validation logic
            if (!ValidateEmail(email))
            {
                throw new ArgumentException("Invalid email format.");
            }
            // Business rules
            // Database persistence
            SaveUserToDatabase(username, email, password);
        }
        private bool ValidateEmail(string email)
        {
            return default;
            // Validation logic
        }
        private void SaveUserToDatabase(string username, string email, string password)
        {
            // Database persistence logic
        }
    }
}
//True
public class UserValidator
{
    public bool ValidateEmail(string email)
    {
        return default;
        // Validation logic
    }
}
public class UserRepository
{
    public void SaveUser(string username, string email, string password)
    {
        // Database persistence logic
    }
}
public class UserCreator
{
    private readonly UserValidator _validator;
    private readonly UserRepository _repository;
    public UserCreator(UserValidator validator, UserRepository repository)
    {
        _validator = validator;
        _repository = repository;
    }
    public void CreateUser(string username, string email, string password)
    {
        if (!_validator.ValidateEmail(email))
        {
            throw new ArgumentException("Invalid email format.");
        }
        // Business rules
        _repository.SaveUser(username, email, password);
    }
}