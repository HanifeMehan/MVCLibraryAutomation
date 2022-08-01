using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Eğer başka katmandaki metodu classı değişkei burada kullanmak istiyorsak o katmanı buraya referans olarak ekleriz.
//References kısmına sağ tıklanıp add reference ile eklenir
namespace DataAccesLayer.Conrete
{
    //Bu sınıfta  tanımlanacak properties sql de bir tabloya karşılık gelecektir.

    //DbContext sınıfı extend edildi.
    public class Context : DbContext
    {
        //Entity katmanında tanımlananan classlar DbSet<> içine sırayla yazılır.

        //Abouts diye verilen kızım sql deki tablonun ismine karşılık gelir
        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Writer> Writers { get; set; }


    }
}
