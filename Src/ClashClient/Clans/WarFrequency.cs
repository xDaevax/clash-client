using System;
using System.Runtime.Serialization;

namespace ClashClient.Clans {
    /// <summary>
    /// Type used to represent different war frequency options.
    /// </summary>
    [Serializable]
    public enum WarFrequency : int {
        /// <summary>
        /// Default option.
        /// </summary>
        [EnumMember(Value = "unknown")]
        Unknown = 0,

        /// <summary>
        /// War frequency set to never.
        /// </summary>
        [EnumMember(Value = "never")]
        Never = 1,

        /// <summary>
        /// War occurrs less than once per week.
        /// </summary>
        [EnumMember(Value = "lessThanOncePerWeek")]
        LessThanOncePerWeek = 2,

        /// <summary>
        /// War occurrs once a week.
        /// </summary>
        [EnumMember(Value = "oncePerWeek")]
        OncePerWeek = 3,

        /// <summary>
        /// War occurs a couple of times per week.
        /// </summary>
        [EnumMember(Value = "moreThanOncePerWeek")]
        MoreThanOncePerWeek = 4,

        /// <summary>
        /// War is started as soon as it is ended.
        /// </summary>
        [EnumMember(Value = "always")]
        Always = 5
    } // end class WarFrequence
} // end nmaespace
