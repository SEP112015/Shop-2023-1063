using System.Linq.Expressions;


namespace Shop.Common.Data.Respository
{

     /// <summary>
     /// Interfaces bases para los repositorios de datos
     /// </summary>
     /// <typeparam name="TEntity">Entidad con la que se va  a trabajar</typeparam>
     /// <typeparam name="TType">Id por donde se va a buscar</typeparam>
    public interface IBaseRepository<TEntity, TType> where TEntity : class
    {
        void Save(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        List<TEntity> GetAll();
        TEntity GetEntityBy(TType id);
        bool Exists(Expression<Func<TEntity, bool>> filter);

    }
}
