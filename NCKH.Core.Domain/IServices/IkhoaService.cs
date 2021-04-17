﻿using NCKH.Core.Domain.ViewModel;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Core.Domain.IServices
{
    public interface IkhoaService
    {
        Task<SearchResult<KhoaViewModel>> SelectAllAsync(int page, int pageSize);
    }
}
