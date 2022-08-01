using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcLibraryAutomation.Controllers
{
    public class Writer
    {

        [Key]
        public int WriterID { get; set; }

        [StringLength(50)]
        public string WriterName { get; set; }

        [StringLength(50)]
        public string WriterSurname { get; set; }


        [StringLength(100)]
        public string WriterImage { get; set; }


        [StringLength(50)]
        public string WriterMail { get; set; }


        [StringLength(20)]
        public string WriterPassword { get; set; }


        ////İlişkili Alanlar

        //Amaç başlık hangi yazar tarafından oluşturuldu.
        public ICollection<Heading> Headings { get; set; }
        public ICollection<Content> Contents { get; set; }//sen content e git adında content olsun şeklinde yorumlanabilir.
    }
}

