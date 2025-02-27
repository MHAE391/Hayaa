using Business.DTOs.Agency;
using Business.DTOs.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.AgencyUseCases.Preview
{
    public record GetAgencyByIdQuery : IRequest<ResponseDTO<PreviewAgancyDTO>>  
    {
        public int Id { get; set; }
    }
}
