namespace Application.VoyagePlan.Queries.GetCityById
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

    public class GetVoyagePlanByIdQuery : IRequestWrapper<VoyagePlanDto>
    {
        public int Id { get; set; }
    }

    public class GetCityByIdQueryHandler : IRequestHandlerWrapper<GetVoyagePlanByIdQuery, VoyagePlanDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCityByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<VoyagePlanDto>> Handle(GetVoyagePlanByIdQuery request, CancellationToken cancellationToken)
        {
            VoyagePlanDto plan = await _context.VoyagePlans
                .Where(x => x.Id == request.Id)
                .ProjectToType<VoyagePlanDto>(_mapper.Config)
                .FirstOrDefaultAsync(cancellationToken);

            return plan != null ? ServiceResult.Success(plan) : ServiceResult.Failed<VoyagePlanDto>(ServiceError.NotFount);
        }
    }
}
