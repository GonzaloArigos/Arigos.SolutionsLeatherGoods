using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Framework;

namespace ASF.Business
{
    public static class LangBusiness
    {

        public static Dictionary<string, string> GetLang(string culture)
        {
            Data.LangDAC DAC = new Data.LangDAC();
            var retorno = new Entities.Language();
            
            var nomap = DAC.GetLang(culture);
            retorno.LocaleStringResource = new List<Entities.LocaleStringResource>();
            Framework.Utilities.ReflectionUtilities.MapObjects(nomap, retorno);

            foreach(var item in nomap.LocaleStringResource)
            {
                var localstringrs = new Entities.LocaleStringResource();
                var localrskey = new Entities.LocaleResourceKey();
                Framework.Utilities.ReflectionUtilities.MapObjects(item, localstringrs);
                Framework.Utilities.ReflectionUtilities.MapObjects(item.LocaleResourceKey, localrskey);
                retorno.LocaleStringResource.Add(localstringrs);
                retorno.LocaleStringResource.Where(i => i.Id == localstringrs.Id).FirstOrDefault().LocaleResourceKey = localrskey;
                
            }

            Dictionary<string, string> _Idioma = new Dictionary<string, string>();

            foreach(var item in retorno.LocaleStringResource)
            {
                _Idioma.Add(item.LocaleResourceKey.Name, item.ResourceValue);

            }
                   
            return _Idioma;
        }

    }
}
