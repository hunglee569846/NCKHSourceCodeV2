using NCKH.Core.Domain.IRepository;
using NCKH.Core.Domain.IServices;
using NCKH.Core.Domain.ViewModel;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Core.Infrastructure.Services
{
    public class KhoaService : IkhoaService
    {
        private readonly IKhoaRepository _IkhoaRepository;
        public KhoaService(IKhoaRepository khoaRepository)
        {
            _IkhoaRepository = khoaRepository;

        }
        public async Task<SearchResult<KhoaViewModel>> SelectAllAsync(int page, int pageSize)
        {
            return await _IkhoaRepository.SelectAllAsync(page, pageSize);
        }
    }
}
