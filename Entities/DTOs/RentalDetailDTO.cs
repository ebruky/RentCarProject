using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailDTO
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string UserNameLastName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int CarId { get; set; }

        public int TotalPrice { get; set; }
    }
}
