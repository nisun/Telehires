using System.Linq;
using Telehire.BusinessLogic.Domain;

namespace Telehire.BusinessLogic.Services
{
    /// <summary>
    /// Repository
    /// </summary>
    public partial interface IRepository<T, TId>
        where T : BaseEntity<TId>
        where TId : struct
    {
        T GetById(object id);
        void SaveOrUpdate(T entity);

        void StartTransaction();
        void Update(T entity);
        void Save(T entity);
        void RollBackTransaction();
        void CommitTransaction();
        void Flush();
        void Clear();
        void Delete(T entity);
        void Refresh(T entity);
        IQueryable<T> Table { get; }

        void ExecuteStoredProcedureUpdate(string StoredName, params object[] parameters);
    }
}
