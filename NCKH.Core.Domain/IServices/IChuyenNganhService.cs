using NCKH.Core.Domain.ViewModel;
using NCKH.Infrastruture.Binding.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Core.Domain.IServices
{
    public interface IChuyenNganhService
    {
        Task<ActionResultResponese<ChuyenNganhViewModel>> ChiTietChuyenNganh(string Id);
        Task<List<ChuyenNganhViewModel>> SelectAllAsync();
    }
}
