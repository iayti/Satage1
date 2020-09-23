namespace Application.VoyagePlan.Commands.Create
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Interfaces;
    using Common.Models;
    using Domain.Entities;
    using Dto;
    using MapsterMapper;

    public class CreateVoyagePlanCommand : IRequestWrapper<VoyagePlanDto>
    {
        public int? CityFromId { get; set; }

        public int? CityToId { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public int NumberOfSeats { get; set; }
    }

    public class CreateVoyagePlanCommandHandler : IRequestHandlerWrapper<CreateVoyagePlanCommand, VoyagePlanDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CreateVoyagePlanCommandHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<ServiceResult<VoyagePlanDto>> Handle(CreateVoyagePlanCommand request, CancellationToken cancellationToken)
        {
            var entity = new VoyagePlan
            {
                CityFromId = request.CityFromId,
                CityToId = request.CityToId,
                Date = request.Date,
                Description = request.Description,
                NumberOfSeats = request.NumberOfSeats,
                UserId = _currentUserService.UserId,
                CurrentCapacity = 0,
                Publish = false,
            };

            _context.VoyagePlans.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<VoyagePlanDto>(entity));
        }
    }
}
