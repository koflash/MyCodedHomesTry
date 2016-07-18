using CodedHomes.Models;
using System.Data.Entity;

namespace CodedHomes.Data
{
    class UserRepository : GenricRepository<User>
    {
        public UserRepository(DbContext context) :
            base(context)
        { }

    }
}