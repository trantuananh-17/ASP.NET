using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TH01ASP.Models
{
    public class NhanVien
    {
        public NhanVien()
        {
        }

        public NhanVien(string firstname, string lastname, string gioitinh, string thangsinh, string namsinh, string sothich, double luong, double ngaylv)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.gioitinh = gioitinh;
            this.thangsinh = thangsinh;
            this.namsinh = namsinh;
            this.sothich = sothich;
            this.luong = luong;
            this.ngaylv = ngaylv;
        }

        public string firstname { get; set; }
        public string lastname { get; set; }
        public string gioitinh { get; set; }
        public string thangsinh { get; set; }
        public string namsinh { get; set; }
        public string sothich { get; set; }
        public double luong { get; set; }
        public double ngaylv { get; set; }
        public double luongthuc
        {
            get
            {
                if (ngaylv >= 25) return luong * 1.1;
                else if (ngaylv >= 20) return luong * 1.05;
                else return luong;
            }
        }


    }
}