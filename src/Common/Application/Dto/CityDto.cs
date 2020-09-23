﻿namespace Application.Dto
{
    using System.Collections.Generic;

    using Mapster;

    using Domain.Entities;

    public class CityDto : IRegister
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CreateDate { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<City, CityDto>()
            .Map(dest => dest.CreateDate,
                src => $"{src.CreateDate.ToShortDateString()}");
        }
    }
}
