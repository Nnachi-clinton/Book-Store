using SukiBookStoreMvc.Models.Domain;

namespace SukiBookStoreMvc.Repositories.Abstrsct
{
    public interface IAuthorService
    {
        bool Add(Author model);
        bool Update(Author model);
        bool Delete(int id);
        Author FindById(int id);
        IEnumerable<Author> GetAll();
    }
}
