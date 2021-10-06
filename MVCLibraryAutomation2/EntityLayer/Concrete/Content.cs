using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Content
    {

        [Key]
        public int ContentID { get; set; }

        [StringLength(1000)]
        public string ContentValue { get; set; }

        public DateTime ContentTime { get; set; }
        public bool ContentStatus { get; set; }

        //Content Writer : Bu yazı kim tarafından yazıldı
        //Content Header : Bu yazı hangi başlığa yazıldı

        ////İlişkili Alanlar
        public int HeadingID { get; set; }
        public virtual Heading Heading { get; set; }

        public int? WriterID { get; set; }
        public virtual Writer Writer { get; set; }

    }
}

