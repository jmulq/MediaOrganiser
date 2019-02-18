using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaOrganiser.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public IList<MediaFileCategory> MediaFiles { get; set; }

        
    }
}
