﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Teams
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<People> TeamMember {  get; set; }
    }
}
