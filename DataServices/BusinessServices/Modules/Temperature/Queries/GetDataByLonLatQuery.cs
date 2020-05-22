using Domain;
using MediatR;

namespace BusinessServices.Modules.ParentModule
{
    public class GetDataByLonLatQuery:IRequest<Temperatures>
    {
        public double Lattitude {get;set;}
        public double Longitude {get;set;}
    }
}