using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Desafio2_DES.Common;
using Desafio2_DES.Entities;

namespace Desafio2_DES.BL.Profiles
{
    public class ParticipanteProfile : Profile
    {
        public ParticipanteProfile()
        {
            CreateMap<Participante, ParticipanteDto>();
            CreateMap<CreateParticipanteDto, Participante>();
        }
    }
}