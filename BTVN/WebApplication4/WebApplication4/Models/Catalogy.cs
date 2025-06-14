﻿namespace WebApplication4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Catalogy")]
    public partial class Catalogy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Catalogy()
        {
            Products = new HashSet<Product>();
        }

        [Required(ErrorMessage = "Không được bỏ trống mã danh mục")]
        [DisplayName("Mã danh mục")]
        [StringLength(10)]
        public string CatalogyID { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống tên danh mục")]
        [DisplayName("Tên danh mục")]
        [StringLength(50)]
        public string CatalogyName { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống chi tiết danh mục")]
        [DisplayName("Chi tiết danh mục")]
        [StringLength(100)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
