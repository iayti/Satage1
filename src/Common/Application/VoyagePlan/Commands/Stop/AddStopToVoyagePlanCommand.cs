namespace Application.VoyagePlan.Commands.Stop
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Interfaces;
    using Common.Models;
    using Domain.Entities;
    using Dto;
    using MapsterMapper;

    public class AddStopToVoyagePlanCommand : IRequestWrapper<StopDto>
    {
        public int CityId { get; set; }

        public int VoyagePlanId { get; set; }
    }

    public class AddStopToVoyagePlanCommandHandler : IRequestHandlerWrapper<AddStopToVoyagePlanCommand, StopDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AddStopToVoyagePlanCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<StopDto>> Handle(AddStopToVoyagePlanCommand request, CancellationToken cancellationToken)
        {
            var entity = new Stop
            {
                VoyagePlanId = request.VoyagePlanId,
                CityId = request.CityId
            };

            _context.Stops.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<StopDto>(entity));
        }
    }
}
