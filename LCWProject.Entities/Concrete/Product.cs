using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCWProject.Entities.Interfaces;

namespace LCWProject.Entities.Concrete
{
    public class Product:BaseEntity,IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
