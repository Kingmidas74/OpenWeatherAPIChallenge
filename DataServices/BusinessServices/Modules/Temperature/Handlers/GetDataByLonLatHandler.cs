using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Domain;
using DataAccess;

namespace BusinessServices.Modules.ParentModule
{
    public class GetDataByLonLatHandler: IRequestHandler<GetDataByLonLatQuery, Temperatures>
    {        
        private WeatherClient WeatherClient;

        public GetDataByLonLatHandler(WeatherClient weatherClient)
        {
            this.WeatherClient = weatherClient;
        }
        
        public async Task<Temperatures> Handle(GetDataByLonLatQuery request, CancellationToken cancellationToken)
        {
            return await this.WeatherClient.GetData(request.Lattitude, request.Longitude,cancellationToken);
        }
    }
}