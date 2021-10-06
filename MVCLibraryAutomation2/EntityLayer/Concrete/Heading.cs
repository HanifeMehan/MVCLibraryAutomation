using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Heading
    {
        //prop yazıp 2 kez tab a basılırsa property oluşturabiliriz.
        [Key]
        public int HeadingID { get; set; }

        [StringLength(50)]
        public String HeadingName { get; set; }
        public DateTime HeadingDate { get; set; }
        public bool HeadingStatus { get; set; }


        ///////İlişkili Alanlar
        public int CategoryID { get; set; }

        //Category sınıfından Category isminde bir propertie oluştururuz.
        public virtual Category Category { get; set; }
        public ICollection<Content> Contents { get; set; }

        //Başlığı açan kişinin ID sini görmemiz gerekir
        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }


    }
}
