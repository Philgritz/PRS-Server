using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PRS_Server.Models {
    public class Product {

        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string PartNbr { get; set; }  //unique

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(11,2)")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(30)]
        public string Unit { get; set; }

        [StringLength(255)]
        public string PhotoPath { get; set; }

        [Required]
        public int VendorId { get; set; }  //fk to vendor

        public virtual Vendor Vendor { get; set; }

        public Product() {

        }



    }
}
