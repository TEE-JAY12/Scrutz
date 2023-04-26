using Scrutz.Data;
using System;

namespace Scrutz.Repository
{
    public abstract class BaseRepo
    {
        protected readonly ScrutzContext _context;

        public BaseRepo(ScrutzContext context)
        {
            _context = context;
        }
    }
}
