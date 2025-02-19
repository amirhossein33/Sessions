namespace PipeLines
{
    using MediatR;
  
    using System.Threading;
    using System.Threading.Tasks;

    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, bool>
    {
        public Task<bool> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }
    }
}
