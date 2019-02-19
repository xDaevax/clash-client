using System;
using System.Collections.Generic;
using System.Reflection;

namespace ClashClient.Common.Extensions {
    /// <summary>
    /// Type that defines extension methods that can be used on any object instance.  Additions to this type should not be made lightly.
    /// </summary>
    public static class ObjectExtensions {
        #region --Static Fields--

        private static readonly MethodInfo _cloneMethod = typeof(object).GetMethod("MemberwiseClone", BindingFlags.NonPublic | BindingFlags.Instance);

        #endregion

        #region --Methods--

        /// <summary>
        /// Recursively iterates of the fields in the <paramref name="typeToReflect"/> using reflection to copy the values and structure of the <paramref name="originalObject"/>.
        /// </summary>
        /// <param name="originalObject">The original instance being cloned.</param>
        /// <param name="visited">The collection of items that have already been copied.</param>
        /// <param name="cloneObject">The instance being created via the copy.</param>
        /// <param name="typeToReflect">The current type which fields are being extracted from (unless the type is primitive).</param>
        /// <param name="bindingFlags">The <see cref="BindingFlags"/> used to target type members.</param>
        /// <param name="filter">Used to explicitly filter out fields.</param>
        private static void CopyFields(object originalObject, IDictionary<object, object> visited, object cloneObject, Type typeToReflect, BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy, Func<FieldInfo, bool> filter = null) {
            foreach (FieldInfo fieldInfo in typeToReflect.GetFields(bindingFlags)) {
                if (filter != null && filter(fieldInfo) == false) {
                    continue;
                }

                if (IsPrimitive(fieldInfo.FieldType)) {
                    continue;
                }

                var originalFieldValue = fieldInfo.GetValue(originalObject);
                var clonedFieldValue = InternalCopy(originalFieldValue, visited);
                fieldInfo.SetValue(cloneObject, clonedFieldValue);
            }
        } // end method CopyFields

        /// <summary>
        /// Attempts to copy the private fields of the given <paramref name="originalObject"/> to the cloned object.
        /// </summary>
        /// <param name="originalObject">The instance being copied.</param>
        /// <param name="visited">The dictionary of properties that have already been copied.</param>
        /// <param name="cloneObject">The object being created via copy.</param>
        /// <param name="typeToReflect">The current <see cref="Type"/> being copied.</param>
        private static void RecursiveCopyBaseTypePrivateFields(object originalObject, IDictionary<object, object> visited, object cloneObject, Type typeToReflect) {
            if (typeToReflect.BaseType != null) {
                RecursiveCopyBaseTypePrivateFields(originalObject, visited, cloneObject, typeToReflect.BaseType);
                CopyFields(originalObject, visited, cloneObject, typeToReflect.BaseType, BindingFlags.Instance | BindingFlags.NonPublic, info => info.IsPrivate);
            }
        } // end method RecursiveCopyBaseTypePrivateFields

        #endregion

        #region --Functions--

        /// <summary>
        /// Creates a deep-copy of the object.  Be careful when using this method as it will double the memory used to store the given <paramref name="originalObject"/>.
        /// </summary>
        /// <param name="originalObject"></param>
        /// <returns>A deep-copy of the given <paramref name="originalObject"/>.</returns>
        public static object Copy(this object originalObject) {
            return InternalCopy(originalObject, new Dictionary<object, object>(new ReferenceEqualityComparer()));
        } // end function Copy

        /// <summary>
        /// Creates a deep-copy of the <paramref name="original"/>.  Be careful when using this method as it will double the moemory used to store the given <paramref name="original"/>.
        /// </summary>
        /// <typeparam name="T">The <typeparamref name="T"/> instance being cloned.</typeparam>
        /// <param name="original">The <typeparamref name="T"/> instance to copy.</param>
        /// <returns>A deep-copy of the given <paramref name="original"/>.</returns>
        public static T Copy<T>(this T original) {
            return (T)Copy((object)original);
        } // end function Copy

        /// <summary>
        /// Performs actual copy logic, taking into account all of the different types in an object graph.
        /// </summary>
        /// <param name="originalObject">The instance being copied.</param>
        /// <param name="visited">The members that have already been converted / copied.</param>
        /// <returns>A deep-copy of the <paramref name="originalObject"/>.</returns>
        private static object InternalCopy(object originalObject, IDictionary<object, object> visited) {
            if (originalObject == null) {
                return null;
            }

            var typeToReflect = originalObject.GetType();

            if (IsPrimitive(typeToReflect)) {
                return originalObject;
            }

            if (visited.ContainsKey(originalObject)) {
                return visited[originalObject];
            }

            if (typeof(Delegate).IsAssignableFrom(typeToReflect)) {
                return null;
            }

            var cloneObject = _cloneMethod.Invoke(originalObject, null);
            if (typeToReflect.IsArray) {
                var arrayType = typeToReflect.GetElementType();
                if (IsPrimitive(arrayType) == false) {
                    Array clonedArray = (Array)cloneObject;
                    clonedArray.ForEach((Array, indicies) => Array.SetValue(InternalCopy(clonedArray.GetValue(indicies), visited), indicies));
                }
            }

            visited.Add(originalObject, cloneObject);
            CopyFields(originalObject, visited, cloneObject, typeToReflect);
            RecursiveCopyBaseTypePrivateFields(originalObject, visited, cloneObject, typeToReflect);

            return cloneObject;
        } // end function InternalCopy

        /// <summary>
        /// Identifies whether the current type is primitive.  This can be used elsewhere for detection, but its primary use
        /// is in attempting to perform a deep-copy of an object graph and determining how to do perform the copy.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> being extended</param>
        /// <returns>true if the type is considered to be primitive; false otherwise</returns>
        public static bool IsPrimitive(this Type type) {
            if (type == typeof(string)) {
                return true;
            }

            return (type.IsValueType && type.IsPrimitive);
        } // end function IsPrimitive

        #endregion
    } // end class ObjectExtensions
} // end namespace
