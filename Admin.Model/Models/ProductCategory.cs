using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Admin.Model.Abstract;

namespace Admin.Model.Models
{
    [Table("ProductCategories")]
    public class ProductCategory : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [Required]
        [MaxLength(256)]
        public string Alias { set; get; }//Tên ko dấu

        [MaxLength(500)]
        public string Description { set; get; }      
        public int? DisplayOrder { set; get; }       
        public bool Status { set; get; }
        public virtual IEnumerable<Product> Products { set; get; }
    }
}