namespace PipeLines
{
    using MediatR;

    public class UserLoginCommand : IRequest<bool>
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}