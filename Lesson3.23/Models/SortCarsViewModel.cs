using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson3._23.Models
{
    public class SortCarsViewModel
    {
       public IEnumerable<Car> Cars { get; set; }
        public bool SortAsc { get; set; }
    }
}
