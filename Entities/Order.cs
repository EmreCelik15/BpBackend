using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public string OrderName { get; set; }
        public string Installment { get; set; }
        
    }
}
