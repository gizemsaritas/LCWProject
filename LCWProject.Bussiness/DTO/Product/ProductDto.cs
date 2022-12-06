using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCWProject.Bussiness.DTO.Product
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
