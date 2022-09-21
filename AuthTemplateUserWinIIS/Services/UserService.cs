namespace WebApi.Services;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

public interface IUserService
{
    string AuthenticateResponse();
}

public class UserService : IUserService
{

    public UserService()
    {
    }

    public string AuthenticateResponse()
    {
        //Public/private keys match after verification
        // authentication successful so generate jwt token
        var token = generateJwtToken();

        return token;
    }

    // helper methods

    private string generateJwtToken()
    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("Secret"));
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            //Subject = new ClaimsIdentity(new[] {new Claim("id", user.Id.ToString())}), // We can add what claims we want here in the token ?!
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}