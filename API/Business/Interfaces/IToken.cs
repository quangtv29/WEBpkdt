using API.Entities;

namespace API.Business.Interfaces
{
    public interface IToken
    {
        string CreateToken(Account account);
    }
}
