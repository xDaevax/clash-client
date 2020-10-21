// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "Required to be read / write by the Framework", Scope = "member", Target = "~P:ClashClient.Common.Caching.CacheConfigurationSection.Preferences")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:ClashClient.Common.Extensions.ArrayTraverse.Position")]
[assembly: SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification = "Set is clear-enough in this context and should not create any conflicts.", Scope = "member", Target = "~M:ClashClient.Common.Caching.ICacheProvider.Set``1(System.String,ClashClient.Common.Caching.CacheEntry{``0})")]
[assembly: SuppressMessage("Design", "CA1010:Generic interface should also be implemented", Justification = "This is used in custom configuration; the generic type would never be used.", Scope = "type", Target = "~T:ClashClient.Common.Caching.CachePreferencesCollection")]
