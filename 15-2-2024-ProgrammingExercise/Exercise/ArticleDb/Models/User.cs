﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleDb.Models {
    public class User {
        public int UserId { get; set; }
        public string Username { get; set; }

        public override string ToString() {
            return $"UserId: {UserId}, Username: {Username}";
        }
    }
}