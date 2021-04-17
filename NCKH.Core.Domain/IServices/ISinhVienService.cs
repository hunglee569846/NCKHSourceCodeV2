using GHM.NailSpa.Domain.ViewModels;
using NCKH.Infrastruture.Binding.Models;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Core.Domain.IServices
{
    public interface ISinhVienService
    {
		Task<SearchResult<SinhVienSearchViewModel>> SearchAsync(string id,int page, int pageSize);
		Task<List<SinhVienSearchViewModel>> SelectAllAsync();
		//Task<ActionResultResponese<string>> InsertAsync(string creatorId, string creatorFullName, string creatorAvatar, SinhVienMeta sinhVienMeta);
		//Task<ActionResultResponese<string>> UpdateAsync(string lastUpdateUserId, string lastUpdateFullName, string lastUpdateAvatar, string id, SinhVienMeta sinhVienMeta);
		//Task<ActionResultResponese> DeleteAsync(string deleteUserId, string deleteFullName, string deleteAvatar, string id);
		Task<ActionResultResponese<SinhVienDetailViewModel>> GetDetailAsync(string id);
	}
}
