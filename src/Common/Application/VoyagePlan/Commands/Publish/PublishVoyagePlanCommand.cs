namespace Application.VoyagePlan.Commands.Publish
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Interfaces;
    using Common.Models;
    using Dto;
    using MapsterMapper;

    public class PublishVoyagePlanCommand : IRequestWrapper<VoyagePlanDto>
    {
        public int Id { get; set; }
        public bool Publish { get; set; }
    }

    public class PublishVoyagePlanCommandHandler : IRequestHandlerWrapper<PublishVoyagePlanCommand, VoyagePlanDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PublishVoyagePlanCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<VoyagePlanDto>> Handle(PublishVoyagePlanCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.VoyagePlans.FindAsync(request.Id);

            if (entity == null)
            {
                return ServiceResult.Failed<VoyagePlanDto>(ServiceError.NotFount);
            }

            entity.Publish = request.Publish;

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<VoyagePlanDto>(entity));
        }
    }
}
