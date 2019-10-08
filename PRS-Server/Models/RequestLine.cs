using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace PRS_Server.Models {

    public class RequestLine {

        public int Id { get; set; }

        public int RequestId { get; set; }

        public int ProductId { get; set; }
        
        [Range(0,int.MaxValue)]
        public int Quantity { get; set; } = 1; 


        
        public virtual Product Product { get; set; }

        [JsonIgnore]     
        public virtual Request Request { get; set; }




    }
}
