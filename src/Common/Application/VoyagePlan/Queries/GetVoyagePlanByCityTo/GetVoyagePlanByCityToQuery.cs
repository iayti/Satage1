namespace Application.VoyagePlan.Queries.GetVoyagePlanByCityFrom
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Mapster;
    using MapsterMapper;

    using Dto;
    using Common.Interfaces;
    using Common.Models;

    public class GetVoyagePlanByCityToQuery : IRequestWrapper<VoyagePlanDto>
    {
        public string param { get; set; }
    }

    public class GetCityByCityToQueryHandler : IRequestHandlerWrapper<GetVoyagePlanByCityToQuery, VoyagePlanDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCityByCityToQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<VoyagePlanDto>> Handle(GetVoyagePlanByCityToQuery request, CancellationToken cancellationToken)
        {
            VoyagePlanDto plan = await _context.VoyagePlans
                .Where(x => x.CityTo.Name.Contains(request.param))
                .ProjectToType<VoyagePlanDto>(_mapper.Config)
                .FirstOrDefaultAsync(cancellationToken);

            return plan != null ? ServiceResult.Success(plan) : ServiceResult.Failed<VoyagePlanDto>(ServiceError.NotFount);
        }
    }
}
