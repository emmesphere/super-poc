using SuperPoc.BuildingBlocks.Application.Abstractions.Commands;
using SuperPoc.BuildingBlocks.Application.Abstractions.Queries;

namespace SuperPoc.BuildingBlocks.Application.Abstractions
{
    public interface IDispatcher
    {
        Task<TResponse> Send<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default);
        Task<TResponse> Query<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default);
    }
}

