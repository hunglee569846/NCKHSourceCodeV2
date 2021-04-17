using NCKH.CoreToken.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.CoreToken.Domain.IServices
{
    public interface IAdminBoService
    {
        // Help check authentication
        Task<UserToken> Authentication(string username, string password);

        // Help refresh token
        ResponseApi RefeshToken(string refreshToken);
    }
}
