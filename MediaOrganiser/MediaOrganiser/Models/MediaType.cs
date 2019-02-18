using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaOrganiser.Models
{
    public class MediaType
    {
        public int Id { get; set; }
        public string MediaTypeName { get; set; }

        public MediaFile File { get; set; }
    }
}
