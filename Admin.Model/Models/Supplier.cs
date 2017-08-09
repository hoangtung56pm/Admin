using Admin.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Model.Models
{
    [Table("Suppliers")]
    public class Supplier: Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }        
        [Required]
        [MaxLength(256)]
        public string SupplierName { set; get; }

        [Required]
        [MaxLength(256)]
        public string SupplierAddress { set; get; }

        [Required]
        [MaxLength(256)]
        public string SupplierEmail { set; get; }

        [Required]
        [MaxLength(50)]
        public string SupplierMobile { set; get; }

    }
}
