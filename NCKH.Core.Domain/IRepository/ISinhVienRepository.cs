using GHM.NailSpa.Domain.ViewModels;
using NCKH.Core.Domain.Models;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Core.Domain.IRepository
{
    public interface ISinhVienRepository
    {
		Task<SearchResult<SinhVienSearchViewModel>> SearchAsync(string id, int page, int pageSize);
		Task<List<SinhVienSearchViewModel>> SelectAllAsync();
		//Task<int> InsertAsync(SinhVien sinhVien);
		//Task<int> UpdateAsync(SinhVien sinhVien);
		//Task<int> DeleteAsync(SinhVien sinhVien);
		//Task<int> ForceDeleteAsync(string id);
		Task<SinhVien> GetInfoAsync(string id);
		//Task<bool> CheckExistsAsync(string id);
		//Task<bool> CheckExistsNameAsync(string id, string name);
	}
}
