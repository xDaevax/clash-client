using System;
using System.Runtime.Serialization;

namespace ClashClient.Players {
    /// <summary>
    /// Enumeration type that specifies possible values for the target or "location" for achievements, troops, etc.
    /// </summary>
    [Serializable]
    public enum VillageTarget : int {
        /// <summary>
        /// Default value
        /// </summary>
        [EnumMember(Value = null)]
        Unknown = 0,

        /// <summary>
        /// The achievement is related to the home village.
        /// </summary>
        [EnumMember(Value = "home")]
        Home = 1,

        /// <summary>
        /// The achievement is related to the builder base.
        /// </summary>
        [EnumMember(Value = "builderBase")]
        Builder = 2
    } // end enum VillageTarget
} // end namespace
