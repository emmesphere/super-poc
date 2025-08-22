using Microsoft.Extensions.DependencyInjection;
using SuperPoc.BuildingBlocks.Application.Abstractions;
using SuperPoc.BuildingBlocks.Application.Abstractions.Commands;
using SuperPoc.BuildingBlocks.Application.Abstractions.Queries;
using SuperPoc.BuildingBlocks.Application.Behaviors;

namespace SuperPoc.BuildingBlocks.Application.Dispatcher
{
    public class Dispatcher : IDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public Dispatcher(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;
        public async Task<TResponse> Send<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default)
        {
            var handler = _serviceProvider.GetRequiredService<ICommandHandler<ICommand<TResponse>, TResponse>>();
            var pipeline = _serviceProvider.GetServices<IPipelineBehavior<ICommand<TResponse>, TResponse>>().Reverse();

            Func<Task<TResponse>> handlerDelegate = () => handler.Handle(command, cancellationToken);

            foreach (var behavior in pipeline)
            {
                var next = handlerDelegate;
                handlerDelegate = () => behavior.Handle(command, cancellationToken, next);
            }

            return await handlerDelegate();
        }

        public async Task<TResponse> Query<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default)
        {
            var handler = _serviceProvider.GetRequiredService<IQueryHandler<IQuery<TResponse>, TResponse>>();
            return await handler.Handle(query, cancellationToken);
            throw new NotImplementedException();
        }
    }
}
