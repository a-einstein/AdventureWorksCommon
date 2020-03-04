using System.Diagnostics;
using System.Runtime.Serialization;

namespace RCS.AdventureWorks.Common.DomainClasses
{
    [DataContract]
    // Note this is not implemented in Mono.
    [DebuggerDisplay("{Id.HasValue ? Id.Value : 0}, {Name}, {ProductListPrice}, {Quantity}, {Value}")]
    public class CartItem : DomainClass
    {
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

        int _quantity;

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                Value = ProductListPrice * Quantity;
                RaisePropertyChanged(nameof(Quantity));
            }
        }

        decimal _value;

        public decimal Value
        {
            get { return _value; }
            set
            {
                this._value = value;
                RaisePropertyChanged(nameof(Value));
            }
        }
    }
}
