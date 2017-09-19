using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.Entities
{
   public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LanguageCulture { get; set; }
        public string FlagImageFileName { get; set; }
        public bool RightToLeft { get; set; }
               
        public virtual ICollection<LocaleStringResource> LocaleStringResource { get; set; }
    }
}
