using RCS.AdventureWorks.Common.Interfaces;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace RCS.AdventureWorks.Common.DomainClasses
{
    // Note these classes in fact are DTO's too.
    [DataContract]
    // Note this is not implemented in Mono.
    [DebuggerDisplay("{Id.HasValue ? Id.Value : 0}, {Name}")]
    public abstract class DomainClass : IEmptyAble
    {
        #region DataMembers
        // This has been made nullable for practical reasons, 
        // particularly to enable empty elements in dropdown lists.
        // These elements can also be convenient for filtering.
        // Besides that a new object to be inserted may not have a true Id yet.
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public string Name { get; set; }
        #endregion

        #region Utility
        public override string ToString()
        {
            return Name;
        }
        #endregion

        #region IEmptyAble
        public bool IsEmpty => !Id.HasValue;
        #endregion
    }
}