using System;
using System.Runtime.Serialization;

namespace ClashClient.Clans {
    /// <summary>
    /// Enumeration that contains the options for membership in a clan.
    /// </summary>
    [Serializable]
    public enum MembershipType : int {
        /// <summary>
        /// Default option
        /// </summary>
        [EnumMember(Value = "unknown")]
        Unknown = 0,

        /// <summary>
        /// Anyone can join the clan at any time.
        /// </summary>
        [EnumMember(Value = "open")]
        Open = 1,

        /// <summary>
        /// Only invited users can join.
        /// </summary>
        [EnumMember(Value = "inviteOnly")]
        InviteOnly = 2,

        /// <summary>
        /// Clan is currently not accepting new membership.
        /// </summary>
        [EnumMember(Value = "closed")]
        Closed = 3
    } // end enumeration MembershipType
} // end namespace
