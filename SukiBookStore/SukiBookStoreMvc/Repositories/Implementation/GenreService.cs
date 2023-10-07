using SukiBookStoreMvc.Models.Domain;
using SukiBookStoreMvc.Repositories.Abstrsct;

namespace SukiBookStoreMvc.Repositories.Implementation
{
    public class GenreService : IGenreService
    {
        private readonly DataBaseContext _dataBaseContext;

        public GenreService(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public bool Add(Genre model)
        {
            try
            {

                _dataBaseContext.Genres.Add(model);
                _dataBaseContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                var data = this.FindById(Id);
                if (data == null)
                
                    return false;
                
                _dataBaseContext.Genres.Remove(data);
                _dataBaseContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Genre FindById(int Id)
        {
            return _dataBaseContext.Genres.Find(Id);
        }

        public IEnumerable<Genre> GetAll()
        {
            return _dataBaseContext.Genres.ToList();
        }

        public bool Update(Genre model)
        {
            try
            {

                _dataBaseContext.Genres.Update(model);
                _dataBaseContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
