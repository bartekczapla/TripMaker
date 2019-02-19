using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Events.Bus.Entities;
using Abp.Events.Bus.Handlers;
using Abp.Threading;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TripMaker.Authorization.Users;

namespace TripMaker.Plan
{
    public class EventDatabaseUpdater : IEventHandler<EventSearchPlace>, ITransientDependency
    {
        public ILogger Logger { get; set; }
        private readonly IRepository<SearchedPlace> _searchPlaceRepository;

        public EventDatabaseUpdater(IRepository<SearchedPlace> searchPlaceRepository)
        {
            _searchPlaceRepository = searchPlaceRepository;
            Logger = NullLogger.Instance;
        }

        public void HandleEvent(EventSearchPlace eventData)
        {
            AsyncHelper.RunSync(() => _searchPlaceRepository.InsertAsync(new SearchedPlace(eventData.Entity.PlaceId, eventData.Entity.PlaceName)));
        }
    }
}
