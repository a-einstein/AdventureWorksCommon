using System.Diagnostics;
using System.Runtime.Serialization;

namespace RCS.AdventureWorks.Common.DomainClasses
{
    [DataContract]
    // Note this is not implemented in Mono.
    [DebuggerDisplay("{ProductCategoryId}, {Id}, {Name}")]
    public class ProductSubcategory : DomainClass
    {
        [DataMember]
        // Nullable because of void elements.
        public int? ProductCategoryId { get; set; }
    }
}