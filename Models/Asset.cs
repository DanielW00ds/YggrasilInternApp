using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ModelLiberary
{
    public class Asset
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public decimal Capacity { get; set; }


        public decimal Longtitude { get; set; }
        public decimal Latitude { get; set; }
        public DateTime ContractStart { get; set; }
        public DateTime ContractEnd { get; set; }


        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedAt { get; set; }


        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }

        public Area Area { get; set; }
        public Counterpart Counterpart { get; set; }
        public AssetType AssetType { get; set; }
        public TechnologyType technologyType { get; set; }
        public State state { get; set; }

    }
}
