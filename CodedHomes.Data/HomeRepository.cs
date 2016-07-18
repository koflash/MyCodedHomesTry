using CodedHomes.Models;
using System.Data.Entity;

namespace CodedHomes.Data
{
    class HomeRepository : GenricRepository<Home>
    {
        public HomeRepository(DbContext context) :
            base(context) { }
        
    }
}
