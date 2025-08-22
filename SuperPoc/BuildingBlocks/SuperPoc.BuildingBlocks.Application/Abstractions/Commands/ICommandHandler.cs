namespace SuperPoc.BuildingBlocks.Application.Abstractions.Commands
{
    public interface ICommandHandler<in TCommand, TResponse> where TCommand : ICommand<TResponse> { 
        Task<TResponse> Handle(TCommand command, CancellationToken cancellationToken = default);
    }
}
