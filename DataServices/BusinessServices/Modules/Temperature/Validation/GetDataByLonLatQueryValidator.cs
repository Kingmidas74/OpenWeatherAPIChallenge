using System;
using FluentValidation;

namespace BusinessServices.Modules.ParentModule
{
    public class GetDataByLonLatQueryValidator:AbstractValidator<GetDataByLonLatQuery>
    {
        public GetDataByLonLatQueryValidator()
        {
            RuleFor(x=>x.Lattitude)
                .NotEmpty();
            RuleFor(x=>x.Longitude)
                .NotEmpty();
        }
    }
}