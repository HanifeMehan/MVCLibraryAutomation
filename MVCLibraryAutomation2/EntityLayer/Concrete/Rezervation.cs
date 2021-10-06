using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Rezervation
    {

        [Key]
        public int UserID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }


        public bool HeadingStatus { get; set; }

        public ICollection<Heading> Headings { get; set; }

        public int HeadingId { get; set; }
        public virtual Heading Heading { get; set; }

        public string HeadingName { get; set; }

    }
}
