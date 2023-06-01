namespace baitapltw.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int Id { get; set; }

        [StringLength(500)]
        //Model DataAnnotations
        [Required(ErrorMessage = "Vui long nhap tieu de")]
        public string Title { get; set; }
        [StringLength(4000)]
        public string Detail { get; set; }

        [StringLength(200)]
        public string FeatureImage { get; set; }
        [ForeignKey("Category")]
        public int ProductCateId { get; set; }

        [StringLength(500)]
        public string Des { get; set; }
        
        public virtual Category Category { get; set; }
    }
}
