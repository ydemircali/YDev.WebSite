namespace YDev.Service.TokenService
{
    public interface ITokenService
    {
        string GetToken(string username, string password);
    }
}