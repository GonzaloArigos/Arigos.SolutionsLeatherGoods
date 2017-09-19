using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.Data
{
   public class LangDAC
    {
        private LeatherGoodsEntities db = new LeatherGoodsEntities();

        public Language GetLang(string culture)
        {
            var ret = db.Language.Where(i => i.LanguageCulture == culture).FirstOrDefault();

            return ret;
                }
    }
}
