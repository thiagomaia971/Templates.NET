using System;
using BaseApplication.Domain.Commands;

namespace BaseApplication.Domain.CommandHandlers
{
    public class SampleCommandHandler : CommandHandler<SampleCommand, int>
    {
        public override int Handle(SampleCommand command) 
            => new Random().Next();
    }
}