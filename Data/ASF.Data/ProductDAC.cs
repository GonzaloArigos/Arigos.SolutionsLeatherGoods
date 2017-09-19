//====================================================================================================
// Base code generated with LeatherGoods - ASF.Data
// Architecture Solutions Foundation
//
// Generated by academic at LeatherGoods V 1.0 
//====================================================================================================

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ASF.Entities;

namespace ASF.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductDAC : DataAccessComponent
    {
        private LeatherGoodsEntities db = new LeatherGoodsEntities();
        public List<Product> GetAll()
        {
            return db.Product.ToList();
        }

    }
}

