using DataAccesLayer.Abstract;
using DataAccesLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntityFramework
{
    //Katmanların birbirlriyle haberleşip her classın kendi işini yapmasını sağlarız
  public class EFCategoryDal : GenericRepository<Category>, ICategoryDal
    {


    }
}
