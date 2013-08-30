using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarmaCustomerService.Dto
{
    public class LisTrakSubscriberDto
    {
        public string Email { get; set; }
        public int ListId { get; set; }
        public string ListName { get; set; }
        public Guid? ConsumerTouchPointId { get; set; }
    }
}
