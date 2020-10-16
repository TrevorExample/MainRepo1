using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InnovativeRecoveryReports.Models
{
    public class Placement
    {
        [Key]
        public int ClientNumber { get; set; }
        public int ManagementNumber { get; set; }
        public string Community { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        public string TenantCode { get; set; }
        public DateTime ListedDate { get; set; }
        public DateTime MoveInDate { get; set; }
        public DateTime MoveOutDate { get; set; }
        public Decimal Principal { get; set; }
        public Decimal amtdueclient { get; set; }
        public Decimal amtremaining { get; set; }
    }
}
