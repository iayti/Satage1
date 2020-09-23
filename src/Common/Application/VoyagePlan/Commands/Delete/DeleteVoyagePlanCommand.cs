namespace Application.VoyagePlan.Commands.Delete
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using MapsterMapper;

    using Common.Interfaces;
    using Common.Models;
    using Dto;
    
    public class DeleteVoyagePlanCommand : IRequestWrapper<VoyagePlanDto>
    {
        public int Id { get; set; }
    }

    public class DeleteVoyagePlanCommandHandler : IRequestHandlerWrapper<DeleteVoyagePlanCommand, VoyagePlanDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeleteVoyagePlanCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<VoyagePlanDto>> Handle(DeleteVoyagePlanCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.VoyagePlans
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return ServiceResult.Failed<VoyagePlanDto>(ServiceError.NotFount);
            }

            _context.VoyagePlans.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<VoyagePlanDto>(entity));
        }
    }
}
