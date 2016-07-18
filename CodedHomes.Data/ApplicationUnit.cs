using System;
using CodedHomes.Models;

namespace CodedHomes.Data
{
    public class ApplicationUnit : IDisposable
    {
        private DataContext _context = new DataContext();
        private IRepository<Home> _homes = null;
        private IRepository<User> _user = null;

        public IRepository<Home> Homes
        {
            get
            {
                if (this._homes == null)
                {
                    this._homes = new GenricRepository<Home>(this._context);

                }
                return this._homes;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (this._user == null)
                {
                    this._user = new GenricRepository<User>(this._context);

                }
                return this._user;
            }
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        public void Dispose()
        {
            if (this._context != null)
            {
                this._context.Dispose();
            }
        }
    }
}
