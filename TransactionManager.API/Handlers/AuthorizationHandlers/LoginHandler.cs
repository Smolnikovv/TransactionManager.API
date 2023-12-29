using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TransactionManager.API.Commands.Authorization;
using TransactionManager.API.Configs;
using TransactionManager.API.Entities;
using TransactionManager.API.Models.Authorization;

namespace TransactionManager.API.Handlers.AuthorizationHandlers
{
    public class LoginHandler : IRequestHandler<LoginCommand, JwtToken>
    {
        private readonly DatabaseContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;
        public LoginHandler(DatabaseContext context, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public async Task<JwtToken> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var res = new JwtToken();
            var user = _context
                .Users
                .FirstOrDefault(x => x.Name == request.LoginDto.Name);

            if (user == null)
            {
                res.Code = -1;
                res.Token = "";
                return res;
            }

            PasswordVerificationResult result = _passwordHasher.VerifyHashedPassword(user,user.Password,request.LoginDto.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                res.Code = -1;
                res.Token = "";
                return res;
            }

            List<Claim> claims = new List<Claim>
            {
                new Claim("UserId", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim("AccountBalance",user.AccountBalance.ToString())
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            SigningCredentials cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            DateTime expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);
            JwtSecurityToken token = new JwtSecurityToken(_authenticationSettings.JwtIssuser,
                _authenticationSettings.JwtIssuser,
                claims,
                expires: expires,
                signingCredentials: cred);
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            res.Code = 1;
            res.Token = tokenHandler.WriteToken(token);
            return await Task.FromResult(res);
        }
    }
}
