using MediatR;

namespace BaseApplication.Domain.Commands
{
    public interface ICommand<TResult> : IRequest<CommandResult<TResult>>
    {
    }
}