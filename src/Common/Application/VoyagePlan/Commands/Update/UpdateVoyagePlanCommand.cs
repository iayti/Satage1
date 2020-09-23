namespace Application.VoyagePlan.Commands.Update
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Interfaces;
    using Common.Models;
    using Dto;
    using MapsterMapper;

    public class UpdateVoyagePlanCommand : IRequestWrapper<VoyagePlanDto>
    {
        public int Id { get; set; }
        public int? CityFromId { get; set; }

        public int? CityToId { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public int NumberOfSeats { get; set; }
    }

    public class UpdateVoyagePlanCommandHandler : IRequestHandlerWrapper<UpdateVoyagePlanCommand, VoyagePlanDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateVoyagePlanCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResult<VoyagePlanDto>> Handle(UpdateVoyagePlanCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.VoyagePlans.FindAsync(request.Id);

            if (entity == null)
            {
                return ServiceResult.Failed<VoyagePlanDto>(ServiceError.NotFount);
            }

            entity.Date = request.Date;
            entity.CityFromId = request.CityFromId;
            entity.CityToId = request.CityToId;
            entity.Description = request.Description;
            entity.NumberOfSeats = request.NumberOfSeats;

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<VoyagePlanDto>(entity));
        }
    }
}
