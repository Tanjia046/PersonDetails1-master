using PersonDetails.Models;

namespace PersonDetails.Repositories.Interface
{
    public interface IPersonsRepository : IRepository<Persons>
    {
        void Add(Persons model);
    }
}