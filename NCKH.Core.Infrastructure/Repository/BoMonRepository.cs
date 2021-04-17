using Dapper;
using NCKH.Core.Domain.IRepository;
using NCKH.Core.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Core.Infrastructure.Repository
{
    public class BoMonRepository : IBoMonRepository
    {
        private readonly string _connectionString;
        private readonly string _IBoMonRepository;
        public BoMonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<List<BoMonSearchViewModel>> SelectAllAsync()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    await conn.OpenAsync();
                var Result = await conn.QueryAsync<BoMonSearchViewModel>("[dbo].[spBoMo_SelectAll]");
                return Result.ToList();
            }

        }
    }
}
