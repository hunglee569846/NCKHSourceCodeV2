using GHM.NailSpa.Domain.ViewModels;
using NCKH.Core.Domain.IRepository;
using NCKH.Core.Domain.IServices;
using NCKH.Infrastruture.Binding.IServices;
using NCKH.Infrastruture.Binding.Models;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Core.Infrastructure.Services
{
    public class SinhVienService : ISinhVienService
    {
		private readonly ISinhVienRepository _sinhVienRepository;
		//private readonly IResourceService<GhmNailSpaResource> _ghmNailSpaResource;
		public SinhVienService(ISinhVienRepository sinhVienRepository)
		{
			_sinhVienRepository = sinhVienRepository;
			
		}


		public async Task<SearchResult<SinhVienSearchViewModel>> SearchAsync(string id,int page, int pageSize)
		{
			return await _sinhVienRepository.SearchAsync(id,page, pageSize);
		}


		public async Task<List<SinhVienSearchViewModel>> SelectAllAsync()
		{
			return await _sinhVienRepository.SelectAllAsync();
		}
		public async Task<ActionResultResponese<SinhVienDetailViewModel>> GetDetailAsync(string id)
		{
			var info = await _sinhVienRepository.GetInfoAsync(id);
			if (info == null)
				return new ActionResultResponese<SinhVienDetailViewModel>(-1, "Không tồn tại.","SinhVien");

			var sinhVienDetail = new SinhVienDetailViewModel
			{
				Id = info.Id,
				MaSinhVien = info.MaSinhVien,
				HoDem = info.HoDem,
				Ten = info.Ten,
				HoTen = info.HoTen,
				HomThu = info.HomThu,
				IdLop = info.IdLop,
				MaLop = info.MaLop,
				DienThoai = info.DienThoai,
				NgayTao = info.NgayTao,
				IsActive = info.IsActive,
			};
			return new ActionResultResponese<SinhVienDetailViewModel>
			{
				Code = 1,
				Data = sinhVienDetail
			};
		}


	}



}

