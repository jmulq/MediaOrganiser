using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaOrganiser.Models;

namespace MediaOrganiser.ViewModels
{
    public class CreateMediaFile
    {
        public List<Category> Categories { get; set; }
        public MediaFile MediaFile { get; set; }
    }
}
