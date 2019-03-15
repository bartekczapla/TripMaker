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
using TripMaker.ExternalServices.Interfaces;
using TripMaker.Home;
using TripMaker.Plan.Events;

namespace TripMaker.Plan
{
    public class EventDatabaseUpdater : IEventHandler<EventSearchPlace>, IEventHandler<EventExternalServicesJSON>, ITransientDependency
    {
        public ILogger Logger { get; set; }
        private readonly ISearchedPlacesManager _searchedPlacesManager;
        private readonly IExternalServicesJsonManager _externalServicesJsonManager;

        public EventDatabaseUpdater(ISearchedPlacesManager searchedPlacesManager, IExternalServicesJsonManager externalServicesJsonManager)
        {
            _searchedPlacesManager = searchedPlacesManager;
            _externalServicesJsonManager = externalServicesJsonManager;
            Logger = NullLogger.Instance;
        }

        public void HandleEvent(EventSearchPlace eventData)
        {
            AsyncHelper.RunSync(() => _searchedPlacesManager.InsertOrUpdateAsync(eventData.Entity.PlaceId, eventData.Entity.PlaceName));
        }

        public void HandleEvent(EventExternalServicesJSON eventData)
        {
            AsyncHelper.RunSync(() => _externalServicesJsonManager.InsertAsync(eventData.Entity));
        }
    }
}
