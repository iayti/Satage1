namespace Application.VoyagePlan.Commands.Enroll
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Interfaces;
    using Common.Models;
    using Domain.Entities;
    using Dto;
    using MapsterMapper;
    using Microsoft.EntityFrameworkCore;

    public class EnrollVoyagePlanCommand : IRequestWrapper<EnrolleeDto>
    {
        public int VoyagePlanId { get; set; }
    }

    public class EnrollVoyagePlanCommandHandler : IRequestHandlerWrapper<EnrollVoyagePlanCommand, EnrolleeDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public EnrollVoyagePlanCommandHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<ServiceResult<EnrolleeDto>> Handle(EnrollVoyagePlanCommand request, CancellationToken cancellationToken)
        {
            var count = await _context.Enrollees.CountAsync(x => x.VoyagePlanId == request.VoyagePlanId, cancellationToken: cancellationToken);

            var voyage = await _context.VoyagePlans.Where(x => x.Id == request.VoyagePlanId).FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (count >= voyage.NumberOfSeats) 
                return ServiceResult.Failed<EnrolleeDto>(ServiceError.EnrollmentClosed);
            
            var entity = new Enrollee
            {
                VoyagePlanId = request.VoyagePlanId,
                UserId = _currentUserService.UserId
            };

            _context.Enrollees.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<EnrolleeDto>(entity));

        }
    }
}
