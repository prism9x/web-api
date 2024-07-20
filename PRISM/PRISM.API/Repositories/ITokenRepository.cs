﻿using Microsoft.AspNetCore.Identity;

namespace PRISM.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
