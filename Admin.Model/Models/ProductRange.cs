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
    [Table("ProductRanges")]
    public class ProductRange : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [Required]
        [MaxLength(256)]
        [Column(TypeName = "varchar")]
        public string ParcelID { set; get; }//ID lô hàng 

        [Required]
        
        public int ProductID { set; get; }
        public string Code { set; get; } // cấu trúc : MaSP-Lô-Ngày:lần nhập
        public string IsSell { set; get; }
        public bool IsWarranty { set; get; }//sp có bảo hành hay ko

        public int Warranty { set; get; }// thời gian bảo hành

        public DateTime ProduceDate { set; get; }//Ngày sx
        [MaxLength(500)]
        public string Description { set; get; }
        public int Quantity { set; get; }
               
        //[Required]
        //[ForeignKey("SupplierID")]
        //public int SupplierID { set; get; }
        //public virtual IEnumerable<Supplier> Suppliers { set; get; }
        [ForeignKey("ProductID")]
        public virtual Product Product { set; get; }
    }
}
