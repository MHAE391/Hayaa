using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class FaxBranch
    {
        public int FaxId { get; set; }
        public int BranchId { get; set; }
        public virtual Fax Fax { get; set; }
        public virtual Branch Branch { get; set; }

    }
}
