namespace NCKH.Core.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class GiangVien
    {
        public string Id { get; set; }
        public string MaGiangVien { get; set; }
        public string HoDem { get; set; }
        public string Ten { get; set; }
        public string HoTen { get; set; }
        public string HomThu { get; set; }
        public string MaBoMon { get; set; }
        public string GhiChu { get; set; }
        public string DonViCongTac { get; set; }
        public string DienThoai { get; set; }
        public int? SoDeTai { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsActive { get; set; }
    }
}
