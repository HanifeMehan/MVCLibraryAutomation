using DataAccesLayer.Abstract;
using DataAccesLayer.Conrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class //T değerinin bir class olması şartı eklendi

    {

        Context c = new Context();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object = c.Set<T>();
        }

        public void Delete(T p)
        {
            var deletedEntity = c.Entry(p);
            deletedEntity.State = EntityState.Deleted;
          //  _object.Remove(p);
            c.SaveChanges();
        }

        //Parametreye bağlı Listeleme işlemini sağlar.
        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);//tek bir değer döndürmek istediğimizde kullanırız.
        }

        public void Insert(T p)
        {
            //Ekleme işlemleri artık Entity üzerinden gerçekleştiriliyor.
            var addedEntity = c.Entry(p);
            addedEntity.State = EntityState.Added;
          //  _object.Add(p);
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            //EntityState kullanılacak. 
            //  Entity State kısaca Entity’imizin o an ki durumunu bildiren bir propertydir.
            //Entity üzerinde yapılan çeşitli işlemler sonrası durumu değişmektedir.
            var updatedEntity = c.Entry(p);
            updatedEntity.State = EntityState.Modified;
              c.SaveChanges();//ilgili entity nin propety leri kaydedilmedi(yeterli değil)
            

        }
    }
}
