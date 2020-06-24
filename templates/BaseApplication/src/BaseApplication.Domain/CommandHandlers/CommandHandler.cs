using System;
using System.Threading;
using System.Threading.Tasks;
using BaseApplication.Domain.Commands;
using MediatR;

namespace BaseApplication.Domain.CommandHandlers
{
    public abstract class CommandHandler<TCommand, TResult> : IRequestHandler<TCommand, CommandResult<TResult>> where TCommand : ICommand<TResult>
    {
        public abstract TResult Handle(TCommand command);

        public Task<CommandResult<TResult>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return ToResult(Handle(request));
            }
            catch (Exception e)
            {
                return ToResult(e);
            }
        }
        
        private static Task<CommandResult<TResult>> ToResult(TResult result)
            => Task.FromResult(new CommandResult<TResult>(result));

        private static Task<CommandResult<TResult>> ToResult(Exception excecao)
            => Task.FromResult(new CommandResult<TResult>(excecao));
    }
}