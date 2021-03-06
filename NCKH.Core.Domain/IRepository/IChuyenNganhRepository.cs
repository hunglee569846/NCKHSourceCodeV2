using NCKH.Core.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Core.Domain.IRepository
{
   public interface IChuyenNganhRepository
    {
        Task<ChuyenNganhViewModel> ChiTietChuyenNganh(string id);
        Task<List<ChuyenNganhViewModel>> SelectAllAsync();
    }
}
