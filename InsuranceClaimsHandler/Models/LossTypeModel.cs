using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceClaimsHandler.Models
{
    public class LossTypeModel
    {
        public int LossTypeId { get; set; }
        public string LossTypeCode { get; set; }
        public string LossTypeDesc { get; set; }
        public bool Active { get; set; }
        public DateTime LastUpdatedDate{ get; set; }
        public int LastUpdatedId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedId { get; set; }

    }
}
