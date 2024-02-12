using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVoyegerBackend {
    public class Comment {
        public int Id { get; set; }
        public string content { get; set; }
        public DateTime createdAt { get; set; }
        public string userName;
        public string userEmail;
        public int userId;
    }
}
