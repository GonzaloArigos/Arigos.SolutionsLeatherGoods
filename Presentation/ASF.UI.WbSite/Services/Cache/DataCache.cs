using ASF.Entities;
using ASF.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Services.Cache
{
    public class DataCache
    {
        #region Singleton
        private static DataCache _instance;
        private static readonly object InstanceLock = new object();
        public static DataCache Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (InstanceLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DataCache();
                        }
                    }
                }
                return _instance;
            }
        }

        public Dictionary<string, string> GetLang(string culture)
        {
            Dictionary<string, string> lista = _cacheService.GetOrAdd(
    ASF.UI.WbSite.Constants.CacheSetting.Language.Key,
    () =>
    {
        LanguageProcess cp = new LanguageProcess();
        return cp.GetLang(culture);
    },
    ASF.UI.WbSite.Constants.CacheSetting.Category.SlidingExpiration
    );
            return lista;
        }

        public Dictionary<string, string> GetNewLang(string culture)
        {
            LanguageProcess cp = new LanguageProcess();
            var retorno = cp.GetLang(culture);
            _cacheService.AddOrUpdate(ASF.UI.WbSite.Constants.CacheSetting.Language.Key, retorno);
            return retorno;

        }
        #endregion

        private readonly ICacheService _cacheService;
        private DataCache()
        {
            _cacheService = DependencyResolver.Current.GetService<ICacheService>();
        }

        public List<Category> CategoryAll()
        {
            List<Category> lista = _cacheService.GetOrAdd(
                ASF.UI.WbSite.Constants.CacheSetting.Category.Key,
                () =>
                {
                    CategoryProcess cp = new CategoryProcess();
                    return cp.SelectList();
                },
                ASF.UI.WbSite.Constants.CacheSetting.Category.SlidingExpiration
                );
            return lista;
        }

        public Category CategoryOne(int id)
        {
            var cache = this.CategoryAll().Where(i => i.Id == id).FirstOrDefault();
            if (cache == null)
            {
                CategoryProcess cp = new CategoryProcess();
                return cp.FindById(id);

            }
            return cache;

        }

    }
}
