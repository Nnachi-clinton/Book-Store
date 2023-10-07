using SukiBookStoreMvc.Models.Domain;

namespace SukiBookStoreMvc.Repositories.Abstrsct
{
    public interface IGenreService
    {
        bool Add(Genre model);

        bool Update(Genre model);

        bool Delete(int Id);

        Genre FindById(int Id);

        IEnumerable<Genre> GetAll();

    }
}
