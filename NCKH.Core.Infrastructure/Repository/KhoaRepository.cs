using Dapper;
using NCKH.Core.Domain.IRepository;
using NCKH.Core.Domain.ViewModel;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Core.Infrastructure.Repository
{
    public class KhoaRepository : IKhoaRepository
    {
		private readonly string _connectionString;
		private readonly string _IKhoaRepository;
		public KhoaRepository(string connectionString)
		{
			_connectionString = connectionString;
		}

		public async Task<SearchResult<KhoaViewModel>> SelectAllAsync(int page, int pageSize)
		{
			using (SqlConnection conn = new SqlConnection(_connectionString))
			{
				if (conn.State == ConnectionState.Closed)
					await conn.OpenAsync();
				DynamicParameters param = new DynamicParameters();
				param.Add("@Page", page);
				param.Add("@PageSize", pageSize);
				using (var multi = await conn.QueryMultipleAsync("[dbo].[spKhoa_SelectAll]", param, commandType: CommandType.StoredProcedure))
				{
					var totalrow = (await multi.ReadAsync<int>()).SingleOrDefault();
					var listKhoas = (await multi.ReadAsync<KhoaViewModel>()).ToList();
					var listBoMons = (await multi.ReadAsync<BoMonSearchViewModel>()).ToList();
					if (listKhoas == null)
					{
						return new SearchResult<KhoaViewModel> { TotalRows = 0, Data = null };
					}
					else
					{
						listKhoas.ForEach(x =>
						{
							x.ListBoMon = listBoMons.Where(iu => iu.IdKhoa == x.Id).ToList();

						});

						return new SearchResult<KhoaViewModel>
						{
							TotalRows = totalrow,
							Data = listKhoas
						};
					}
				}
			}
		}
	}
}
