using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response
{
    public class ResponseDTO <T> where T : class
    {
        public bool IsSuccess { get; set; }
        public IEnumerable<string>? Errors { get; set; }
        public T? Data { get; set; }
    }
}
