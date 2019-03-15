using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripMaker.ExternalServices.Entities.Models;
using TripMaker.ExternalServices.Interfaces;

namespace TripMaker.ExternalServices.Core
{
    public class ExternalServicesJsonManager : IExternalServicesJsonManager
    {
        private readonly IRepository<ExternalServicesJSON> _repository;

        public ExternalServicesJsonManager(IRepository<ExternalServicesJSON> repository)
        {
            _repository = repository;
        }

        public async Task InsertAsync(ExternalServicesJSON entity)
        {
            if(entity != null)
                await _repository.InsertAsync(entity);
        }
    }
}
