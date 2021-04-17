using Dapper;
using GHM.NailSpa.Domain.ViewModels;
using Microsoft.Extensions.Logging;
using NCKH.Core.Domain.IRepository;
using NCKH.Core.Domain.Models;
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
    public class SinhVienRepository : ISinhVienRepository
    {
		
		private readonly string _connectionString;
		private readonly ILogger<SinhVienRepository> _logger;

		public SinhVienRepository(string connectionString, ILogger<SinhVienRepository> logger)
		{
			_connectionString = connectionString;
			_logger = logger;
		}

		public async Task<SearchResult<SinhVienSearchViewModel>> SearchAsync(string id, int page, int pageSize)
		{
			try
			{
				using (SqlConnection con = new SqlConnection(_connectionString))
				{
					if (con.State == ConnectionState.Closed)
						await con.OpenAsync();

					DynamicParameters param = new DynamicParameters();
					param.Add("@page", page);
					param.Add("@Id", id);
					param.Add("@pageSize", pageSize);

					using (var multi = await con.QueryMultipleAsync("[dbo].[spSinhVien_Search]", param, commandType: CommandType.StoredProcedure))
					{
						return new SearchResult<SinhVienSearchViewModel>
						{
							TotalRows = (await multi.ReadAsync<int>()).SingleOrDefault(),
							Data = (await multi.ReadAsync<SinhVienSearchViewModel>()).ToList()
						};
					}
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "[dbo].[spSinhVien_Search] SearchAsync SinhVienRepository Error.");
				return new SearchResult<SinhVienSearchViewModel> { TotalRows = 0, Data = null };
			}
		}


		public async Task<List<SinhVienSearchViewModel>> SelectAllAsync()
		{
			try
			{
				using (SqlConnection con = new SqlConnection(_connectionString))
				{
					if (con.State == ConnectionState.Closed)
						await con.OpenAsync();

					var results = await con.QueryAsync<SinhVienSearchViewModel>("[dbo].[spSinhVien_SelectAll]");
					return results.ToList();
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "[dbo].[spSinhVien_SelectAll] SelectAllAsync SinhVienRepository Error.");
				return new List<SinhVienSearchViewModel>();
			}
		}

		public async Task<SinhVien> GetInfoAsync(string id)
		{
			try
			{
				using (SqlConnection con = new SqlConnection(_connectionString))
				{
					if (con.State == ConnectionState.Closed)
						await con.OpenAsync();

					DynamicParameters param = new DynamicParameters();
					param.Add("@Id", id);
					return await con.QuerySingleOrDefaultAsync<SinhVien>("[dbo].[spSinhVien_SelectByID]", param, commandType: CommandType.StoredProcedure);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "[dbo].[spSinhVien_SelectByID] GetInfoAsync SinhVienRepository Error.");
				return null;
			}
		}

	}
}
