using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class PNRInfo
    {
        public string Pnr { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public override bool Equals(object _other) {
            if(_other == null) return false;
            PNRInfo other = _other as PNRInfo;
            return (this.Pnr == other.Pnr && this.CreatedAt.Equals(other.CreatedAt));
        }
    }
}
