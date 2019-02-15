using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaOrganiser.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }

        public MediaFile File { get; set; }
        
    }
}
