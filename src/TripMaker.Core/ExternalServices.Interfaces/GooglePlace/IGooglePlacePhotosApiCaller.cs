
using Abp.Application.Services;
using Abp.Domain.Services;
using System.Threading.Tasks;


namespace TripMaker.ExternalServices.Interfaces.GooglePlace
{
    public interface IGooglePlacePhotosApiCaller : IDomainService
    {
        Task<string> GetPhotoAsync(string photoreference, int? maxheight, int? maxwidth);
    }
}
