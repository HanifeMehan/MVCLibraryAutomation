using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcLibraryAutomation.Controllers
{
    public class Content
    {

        [Key]
        public int ContentID { get; set; }

        [StringLength(1000)]
        public string ContentValue { get; set; }

        public DateTime ContentTime { get; set; }

        //Content Writer : Bu yazı kim tarafından yazıldı
        //Content Header : Bu yazı hangi başlığa yazıldı

        ////İlişkili Alanlar
        public int HeadingId { get; set; }
        public virtual Heading Heading { get; set; }

        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }

    }
}

