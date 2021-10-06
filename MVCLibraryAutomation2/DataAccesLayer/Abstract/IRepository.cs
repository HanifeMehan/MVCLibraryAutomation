using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
    public interface IRepository<T>//T değeri döndürürüz bu da bizim türümüzü temsil eder
    {

        //CRUD
        // Metot tanımlarken Type  Name();


        //Sınıfları listeleriz
        List<T> List();

        //Ekleme işlemi için void kullanıyoruz.Ekleme işlemi için parametreye ihtiyaç duyarız.
        void Insert(T p); // p bizim parametremizdir.

        T Get(Expression<Func<T, bool>> filter);//İstenilen veriyi görüntülemek için kullanırız.

        void Update(T p);

        void Delete(T p);

        //Şartlı Listeleme işlemi yapılır.
        List<T> List(Expression<Func<T, bool>> filter);//Tüm listeyi görüntülemek için kullanırız

        //Metotlar oluşturulduktan sonra yeni bir class oluşturulup(GenericRepository) bu metodların görev ataması yapılır.
    }
}
