using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarmaCustomerService.Dto
{
    public class LisTrakRequestDto
    {
        public string EmailAddress { get; set; }
        public int ListId { get; set; }
        public string ListName { get; set; }
    }
}
