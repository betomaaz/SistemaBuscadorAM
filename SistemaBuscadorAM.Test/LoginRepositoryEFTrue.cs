using Microsoft.AspNetCore.Http;
using SistemaBuscadorAM.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBuscadorAM.Test
{
    public class LoginRepositoryEFTrue : ILoginRepository
    {
        public void SetSessionAndCookie(HttpContext context)
        {

        }

        public async Task<bool> UserExist(string usuario, string password)
        {
            return await Task.FromResult(true);
        }
    }
}
