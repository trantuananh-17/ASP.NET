namespace WebApplication4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [Required(ErrorMessage = "Không được bỏ trống mã sản phẩm")]
        [DisplayName("Mã sản phẩm")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống tên sản phẩm")]
        [DisplayName("Tên sản phẩm")]
        [StringLength(50)]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống chi tiết")]
        [DisplayName("Chi tiết")]
        [Column(TypeName = "text")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống giá nhập")]
        [DisplayName("Giá nhập")]
        [Column(TypeName = "numeric")]
        public decimal PurchasePrice { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống Giá bán")]
        [DisplayName("Giá bán")]
        [Column(TypeName = "numeric")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống số lượng")]
        [DisplayName("Số lượng")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống năm sản xuất")]
        [DisplayName("Năm sản xuất")]
        [StringLength(20)]
        public string Vintage { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống mã danh mục")]
        [DisplayName("Mã danh mục")]
        [StringLength(10)]
        public string CatalogyID { get; set; }

        [DisplayName("Hình ảnh")]
        [Column(TypeName = "text")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống quốc gia")]
        [DisplayName("Quốc gia")]
        [StringLength(100)]
        public string Region { get; set; }

        public virtual Catalogy Catalogy { get; set; }
    }
}
