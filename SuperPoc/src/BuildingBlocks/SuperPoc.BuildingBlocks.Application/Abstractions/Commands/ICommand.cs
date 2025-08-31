namespace SuperPoc.BuildingBlocks.Application.Abstractions.Commands
{
    public interface ICommand<out TResponse> { }
    
    public interface ICommand : ICommand<Unit> { }

    public record Unit;
}
