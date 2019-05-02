using System;
using System.Runtime.Serialization;

namespace ClashClient.War {
    /// <summary>
    /// Enumeration that represents the possible war outcomes.
    /// </summary>
    [Serializable]
    public enum WarOutcome {
        /// <summary>
        /// The war was a tie
        /// </summary>
        [EnumMember(Value = null)]
        Tie = 0,

        /// <summary>
        /// The war was a win from the perspective of the current clan.
        /// </summary>
        [EnumMember(Value = "win")]
        Win = 1,

        /// <summary>
        /// The war was a loss from the perspective of the current clan.
        /// </summary>
        [EnumMember(Value = "lose")]
        Loss = 2
    } // end WarOutcome enumeration
} // end namespace
