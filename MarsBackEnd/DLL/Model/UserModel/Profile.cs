﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Model.UserModel
{
    public class Profile
    {
        public long Id { get; set; }

        public byte Age { get; set; }

        public string Address { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }
        public List<Apointment>? Apointments { get; set; }
    }
}
