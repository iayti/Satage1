namespace Application.VoyagePlan.Queries.GetCities
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Mapster;
    using MapsterMapper;

    using Common.Interfaces;
    using Common.Models;
    using Dto;

    public class GetAllVoyagePlansQuery : IRequestWrapper<List<VoyagePlanDto>>
    {

    }

    public class GetAllVoyagePlansQueryHandler : IRequestHandlerWrapper<GetAllVoyagePlansQuery, List<VoyagePlanDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllVoyagePlansQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<VoyagePlanDto>>> Handle(GetAllVoyagePlansQuery request, CancellationToken cancellationToken)
        {
            List<VoyagePlanDto> list = await _context.VoyagePlans
                .ProjectToType<VoyagePlanDto>(_mapper.Config)
                .ToListAsync(cancellationToken);

            return list.Count > 0 ? ServiceResult.Success(list) : ServiceResult.Failed<List<VoyagePlanDto>>(ServiceError.NotFount);
        }
    }
}
