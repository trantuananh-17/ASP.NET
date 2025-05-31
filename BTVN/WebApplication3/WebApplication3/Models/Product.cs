namespace WebApplication3.Models
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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã sản phẩm")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Không được để trống tên sản phẩm")]
        [DisplayName("Tên sản phẩm")]
        [StringLength(50)]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Không được để trống Thông tin chi tiết")]
        [DisplayName("Chi tiết")]
        [Column(TypeName = "text")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Không được để trống Giá nhập")]
        [DisplayName("Giá nhập")]
        [Column(TypeName = "numeric")]
        public decimal PurchasePrice { get; set; }

        [Required(ErrorMessage = "Không được để trống Giá bán")]
        [DisplayName("Giá bán")]
        [Column(TypeName = "numeric")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Không được để trống số lượng")]
        [DisplayName("Số lượng")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Không được để trống năm sx")]
        [DisplayName("Năm sx")]
        [StringLength(20)]
        public string Vintage { get; set; }

        [Required(ErrorMessage = "Không được để trống mã danh mục")]
        [DisplayName("Mã danh mục")]
        [StringLength(10)]
        public string CatalogyID { get; set; }

        [DisplayName("Hình ảnh")]
        [Column(TypeName = "text")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Không được để trống ")]
        [DisplayName("Quốc gia")]
        [StringLength(100)]
        public string Region { get; set; }

        public virtual Catalogy Catalogy { get; set; }
    }
}
