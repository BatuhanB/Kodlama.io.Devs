using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public AuthService(IRefreshTokenRepository refreshTokenRepository,
                           ITokenHelper tokenHelper,
                           IUserOperationClaimRepository userOperationClaimRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _tokenHelper = tokenHelper;
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
        {
            return _refreshTokenRepository.AddAsync(refreshToken);
        }

        public async Task<AccessToken> CreateAccessToken(User user)
        {
            IPaginate<UserOperationClaim> userOperationClaims =
                                    await _userOperationClaimRepository
                                    .GetListAsync(x => x.UserId == user.Id,
                                    include: x => x.Include(x => x.OperationClaim));

            IList<OperationClaim> operationClaims =
                                    userOperationClaims.Items.Select(x => new OperationClaim
                                    {
                                        Id = x.OperationClaimId,
                                        Name = x.OperationClaim.Name
                                    }).ToList();
            var token = _tokenHelper.CreateToken(user, operationClaims);
            return token;
        }

        public Task<RefreshToken> CreateRefreshToken(User user, string ipAdress)
        {
            return Task.FromResult(_tokenHelper.CreateRefreshToken(user, ipAdress));
        }
    }
}
