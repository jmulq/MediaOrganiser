﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaOrganiser.Models
{
    public class MediaFile
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int MediaTypeID { get; set; }
        public string Name { get; set; }
        public byte[] Thumbnail { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Date created")]
        public DateTime DateCreated
        {
            //Set to current datetime if null (on creation)
            get
            {
                //get => dateCreated ?? DateTime.Now;
                //OR
                //return this.dateCreated.HasValue
                //? this.dateCreated.Value
                //    : DateTime.Now;
                return dateCreated ?? DateTime.Now;
            }
            set { dateCreated = value; }
        }

        private DateTime? dateCreated = null;

        [DataType(DataType.DateTime)]
        [Display(Name = "Date modified")]

        public DateTime DateModified
        {
            get { return dateModified ?? DateTime.Now; }
            set { dateModified = value; }
        }

        private DateTime? dateModified = null;

        [Display(Name = "Size (MB)")]
        public byte SizeMB { get; set; }
    }
}