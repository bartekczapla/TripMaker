
using Abp.Application.Services;
using System.Threading.Tasks;


namespace TripMaker.ExternalServices.Interfaces.GooglePlace
{
    public interface IGooglePlacePhotosApiCaller : IApplicationService
    {
        Task<string> GetPhotoAsync(string photoreference, int? maxheight, int? maxwidth);
    }
}
