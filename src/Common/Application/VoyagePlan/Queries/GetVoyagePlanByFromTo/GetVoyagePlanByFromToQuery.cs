namespace Application.VoyagePlan.Queries.GetVoyagePlanByFromTo
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Interfaces;
    using Common.Models;
    using Dto;
    using Mapster;
    using MapsterMapper;
    using Microsoft.EntityFrameworkCore;

    public class GetVoyagePlanByFromToQuery : IRequestWrapper<VoyagePlanDto>
    {
        public int CityFromId { get; set; }
        public int CityToId { get; set; }
    }

    public class GetVoyagePlanByFromToQueryHandler : IRequestHandlerWrapper<GetVoyagePlanByFromToQuery, VoyagePlanDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetVoyagePlanByFromToQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<VoyagePlanDto>> Handle(GetVoyagePlanByFromToQuery request, CancellationToken cancellationToken)
        {
            VoyagePlanDto plan = await _context.VoyagePlans
                .Include(c => c.CityFrom)
                .Include(c => c.CityTo)
                .Include(s => s.Stops)
                .Where(x => x.CityToId == request.CityToId && (x.CityFromId == request.CityFromId || x.Stops.FirstOrDefault(s => s.CityId == request.CityFromId) != null) && x.Publish)
                .ProjectToType<VoyagePlanDto>(_mapper.Config)
                .FirstOrDefaultAsync(cancellationToken);

            return plan != null ? ServiceResult.Success(plan) : ServiceResult.Failed<VoyagePlanDto>(ServiceError.NotFount);
        }
    }
}
