using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileRcp.Core.Models
{
    public class AuthorizedModel
    {
        public EntryType EntryType { get; set; }
        public DateTime Date { get; set; }
        public int UserIdent { get; set; }
    }
}
