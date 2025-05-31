using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TH03ASP.Models
{
    public class SanPham
    {
        public string masp { get; set; }
        public string tensanpham { get; set; }
        public int soluong { get; set; }
        public decimal giatien { get; set; }
        public int giamgia { get; set; }
        public decimal thanhtien
        {
            get
            {
                if (this.giatien == 0) return soluong * giatien;
                else return soluong * giatien * 0.9m;

            }
        }

        public SanPham(string masp, string tensanpham, int soluong, decimal giatien, int giamgia)
        {
            this.masp = masp;
            this.tensanpham = tensanpham;
            this.soluong = soluong;
            this.giatien = giatien;
            this.giamgia = giamgia;
        }

        public SanPham()
        {
        }
    }
}