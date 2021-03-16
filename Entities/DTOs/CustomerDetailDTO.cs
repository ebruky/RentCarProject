using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CustomerDetailDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }

        public string  CompanyName { get; set; }

        public string Email { get; set; }
    }
}
