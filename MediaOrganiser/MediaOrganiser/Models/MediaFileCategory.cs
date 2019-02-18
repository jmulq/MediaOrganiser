using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaOrganiser.Models
{
    public class MediaFileCategory
    {
        public int MediaFileId  { get; set; }
        public MediaFile MediaFile { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
