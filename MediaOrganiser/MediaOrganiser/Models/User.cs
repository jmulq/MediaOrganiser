﻿using System.Collections.Generic;

namespace MediaOrganiser.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return $"{FullName} + {LastName}";
            }
        }
    }
}