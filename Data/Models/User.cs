﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class User : IdentityUser
    {
        public ICollection<Question> Questions { get; set; }
        public ICollection<Reply> Replies { get; set; }
    }
}
