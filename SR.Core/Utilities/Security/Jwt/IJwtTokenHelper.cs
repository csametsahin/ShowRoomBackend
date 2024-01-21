using SR.Entities.Concrete.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Core.Utilities.Security.Jwt
{
    public interface IJwtTokenHelper
    {
        Task<TokenResponse> CreateToken(User user);
    }
}
