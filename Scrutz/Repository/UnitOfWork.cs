using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Scrutz.Data;
using Scrutz.Repository.Interface;
using System;

namespace Scrutz.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ScrutzContext _context;

        public UnitOfWork(ScrutzContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
