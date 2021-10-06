using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        [StringLength(500)]
        public string CategoryDescription { get; set; }

        //Category de durumu aktif ya da pasif yapma işlemini düşüneceğiz. Mesela silme işleminde
        // Category'si yazılım olan heading lerde silinecek bunun olamaması için  kaldırmak yerine pasif hale getireceğiz.
        public bool CategoryStatus { get; set; }


        ////İlişkili Alanlar
        // 1->n lik bir ilişki kuruldu
        public ICollection<Heading> Headings { get; set; }
    }
}
