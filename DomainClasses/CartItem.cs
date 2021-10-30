using RCS.AdventureWorks.Common.Interfaces;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace RCS.AdventureWorks.Common.DomainClasses
{
    [DataContract]
    // Note this is not implemented in Mono.
    [DebuggerDisplay("{Name} : {ProductListPrice} x {Quantity}")]
    public class CartItem : DomainClass
    {
        // Note this contains an arbitrary selection of properties copied from Product,
        // to which it could just refer by ProductId.
        #region DataMembers
        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public string ProductSize { get; set; }

        [DataMember]
        public string ProductSizeUnitMeasureCode { get; set; }

        [DataMember]
        public string ProductColor { get; set; }

        [DataMember]
        public decimal ProductListPrice { get; set; }

        /// <summary>
        /// Actively adaptable by user.
        /// </summary>
        [DataMember]
        public int Quantity { get; set; }
        #endregion

        #region Construction
        public CartItem()
        { }

        public CartItem(IShoppingProduct product)
        {
            ProductId = product.Id.Value;
            Name = product.Name;
            ProductSize = product.Size;
            ProductSizeUnitMeasureCode = product.SizeUnitMeasureCode;
            ProductColor = product.Color;
            ProductListPrice = product.ListPrice;

            Quantity = 1;
        }

        public CartItem Copy()
        {
            // TODO This could use the constructor if CartItem : IShoppingProduct.
            return new CartItem()
            {
                ProductId = ProductId,
                Name = Name,
                ProductSize = ProductSize,
                ProductSizeUnitMeasureCode = ProductSizeUnitMeasureCode,
                ProductColor = ProductColor,
                ProductListPrice = ProductListPrice,

                Quantity = Quantity
            };
        }
        #endregion

        #region CRUD
        public void Update(CartItem proxy)
        {
            // TODO Simplify this, as only Quantity could change.
            // Which is a matter of the whole CartItem, which could just refer by ProductId.

            ProductId = proxy.ProductId;
            Name = proxy.Name;
            ProductSize = proxy.ProductSize;
            ProductSizeUnitMeasureCode = proxy.ProductSizeUnitMeasureCode;
            ProductColor = proxy.ProductColor;
            ProductListPrice = proxy.ProductListPrice;

            Quantity = proxy.Quantity;
        }
        #endregion
    }
}
