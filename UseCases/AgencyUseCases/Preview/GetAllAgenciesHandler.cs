using Business.DTOs.Agency;
using Business.DTOs.Response;
using Business.Repositories.Agencies;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.AgencyUseCases.Preview
{
    public class GetAllAgenciesHandler(IAgencyRepository repo) : IRequestHandler<GetAllAgenciesQuery, ResponseDTO<IEnumerable<PreviewAgancyDTO>>>
    {
        public async Task<ResponseDTO<IEnumerable<PreviewAgancyDTO>>> Handle(GetAllAgenciesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<PreviewAgancyDTO> data =( await repo.GetAllAgenciesAsync() ).Select(x => new PreviewAgancyDTO { Name  = x.Name , Id = x.Id }).ToList() ;
            return new ResponseDTO<IEnumerable<PreviewAgancyDTO>>
            {
                IsSuccess = true,
                Data = data
            }; 
        }
    }
}
