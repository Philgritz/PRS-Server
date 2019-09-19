using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRS_Server.Models {
    public class Request {

        public Request() {}


        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Description { get; set; } 

        [Required]
        [StringLength(80)]
        public string Justification { get; set; }  
        
        [StringLength(80)]
        public string ReasonRejection { get; set; } //nullable, reasonrejection must be provided when rejected

        [Required]
        [StringLength(20)]
        public string DeliveryMode { get; set; } = "Pickup";

        [Required]
        [StringLength(10)]
        public string Status { get; private set; } = "NEW";

        [Column(TypeName = "decimal(11,2)")]
        public decimal Total { get; private set; } = 0; //auto calculated by adding up lines in request

        public int UserId { get; set; }  //fk to user, auto set to logged in user

        public virtual User User { get; set; }

        //virtual collection of requestline instances in request to hold collection of lines related to this request

        public virtual List<RequestLine> RequestLines { get; set; }


    }
}
