//====================================================================================================
// Base code generated with LeatherGoods
// Architecture Solutions Foundation
//
// Generated by academic at LeatherGoods V 1.0 
//====================================================================================================

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;


namespace ASF.Entities
{
    /// <summary>
    /// Represents a row of entity data.
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class CartItem : EntityBase
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Id")]
        [Browsable(false)]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Cart Id")]
        public int CartId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Product Id")]
        public int ProductId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Price")]
        public double Price { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Quantity")]
        public int Quantity { get; set; }


        [DataMember]
        [DisplayName("Product")]
        public Product Product { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Created On")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Created By")]
        public int? CreatedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Changed On")]
        public DateTime ChangedOn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [DisplayName("Changed By")]
        public int? ChangedBy { get; set; }

        
    }
}
