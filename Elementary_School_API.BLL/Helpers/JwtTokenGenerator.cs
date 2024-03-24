using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Elementary_School_API.BLL.Helpers
{
	public static class JwtTokenGenerator
	{


		public static string GenerateJwtIdentityToken(IConfiguration configuration,string userName)
		{

			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]!));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			var claims = new List<Claim>()
			{
				new Claim(ClaimTypes.Name, userName)
				
			};

			var token = new JwtSecurityToken(
				issuer: configuration["JWT:Issuer"],
				audience: configuration["JWT:Audience"],
				claims: claims,
				expires: DateTime.Now.AddMinutes(60),
				signingCredentials: credentials
			);

			var jwt = new JwtSecurityTokenHandler().WriteToken(token);

			return jwt;

		}


	}

	
}
