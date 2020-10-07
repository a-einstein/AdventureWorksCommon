using System.Diagnostics;
using System.Runtime.Serialization;

namespace RCS.AdventureWorks.Common.DomainClasses
{
    [DataContract]
    // Note this is not implemented in Mono.
    [DebuggerDisplay("{Id.HasValue ? Id.Value : 0}, {Name}, {ProductListPrice}, {Quantity}, {Value}")]
    public class CartItem : DomainClass
    {
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
        #endregion

        // TODO Make this partial?
        #region Additional members
        int quantity;

        public int Quantity
        {
            get => quantity;
            set
            {
                // The condition prevented binding between control and viewmodel to loop.
                if (quantity != value)
                {
                    quantity = value;
                    Value = ProductListPrice * Quantity;
                    RaisePropertyChanged(nameof(Quantity));
                }
            }
        }

        decimal value;

        public decimal Value
        {
            get => value;
            set
            {
                if (this.value != value)
                {
                    this.value = value;
                    RaisePropertyChanged(nameof(Value));
                }
            }
        }
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
    }
}
