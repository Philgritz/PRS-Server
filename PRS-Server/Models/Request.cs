using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRS_Server.Models {
    public class Request {


        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Description { get; set; } 

        [Required]
        [StringLength(80)]
        public string Justification { get; set; }  
        
        [StringLength(80)]
        public string ReasonRejection { get; set; } //nullable

        [Required]
        [StringLength(20)]
        public string DeliveryMode { get; set; } = "Pickup";

        [Required]
        [StringLength(10)]
        public string Status { get; private set; } = "NEW";

        [Required]
        [Column(TypeName = "decimal(11,2)")]
        public decimal Total { get; private set; } = 0;

        [Required]
        public int UserId { get; set; }  //fk to user

        public virtual User User { get; set; }

        public Request() {

        }



    }
}
