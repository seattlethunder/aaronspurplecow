using NHibernate;
using PurpleCow.Common.Models;

namespace PurpleCow.Data
{
    public class NHibernateMapperSession : IMapperSession
    {
        private readonly ISession _session;
        private ITransaction _transaction;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public NHibernateMapperSession(ISession session)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _session = session;
        }

        public IQueryable<Image> Images => _session.Query<Image>();

        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }

        public async Task Commit()
        {
            await _transaction.CommitAsync();
        }

        public async Task Rollback()
        {
            await _transaction.RollbackAsync();
        }

        public void CloseTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public async Task Save(Image entity)
        {
            await _session.SaveOrUpdateAsync(entity);
        }

        public async Task Delete(Image entity)
        {
            await _session.DeleteAsync(entity);
        }

        /// <summary>
        /// TODO: need to use queryover in order select a list of data async
        /// </summary>
        /// <returns></returns>
        public List<Image> GetImages()
        {
             return _session.Query<Image>().ToList();
        }
    }
}
