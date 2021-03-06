﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions
{
    /// <summary>
    ///     Provides extensions methods to the Object class.
    /// </summary>
    internal static class ObjectExtensions
    {
        /// <summary>
        ///     Throws if the specified object is null.
        /// </summary>
        /// <param name="inputValue"> The object. </param>
        /// <param name="argumentName"> The argumentName. </param>
        /// <exception cref="ArgumentNullException">Thrown if the argument is null.</exception>
        public static void ArgumentNotNull([ValidatedNotNull] this object inputValue, string argumentName)
        {
            if (ReferenceEquals(inputValue, null))
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        /// <summary>
        ///     Throws if the specified string is null or empty.
        /// </summary>
        /// <param name="inputValue"> The string. </param>
        /// <param name="argumentName"> The argumentName. </param>
        /// <exception cref="ArgumentNullException">Thrown if the argument is null or empty.</exception>
        public static void ArgumentNotNullOrEmpty([ValidatedNotNull] this string inputValue, string argumentName)
        {
            if (string.IsNullOrEmpty(inputValue))
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        /// <summary>
        ///     Performs an as operation on the supplied object.
        /// </summary>
        /// <typeparam name="T"> The target type of the as operation. </typeparam>
        /// <param name="inputValue"> The object. </param>
        /// <returns> The result of the as operation. </returns>
        public static T As<T>(this object inputValue) where T : class
        {
            return inputValue as T;
        }

        /// <summary>
        ///     Casts the specified obj.
        /// </summary>
        /// <typeparam name="T"> The target type of the cast. </typeparam>
        /// <param name="inputValue"> The object. </param>
        /// <returns> The result of the cast. </returns>
        public static T CastTo<T>(this object inputValue)
        {
            return (T)inputValue;
        }

        /// <summary>
        ///     Evaluates type compatibility.
        /// </summary>
        /// <typeparam name="T"> The type to evaluate against. </typeparam>
        /// <param name="inputValue"> The object to evaluate compatibility for. </param>
        /// <returns> True if the object is compatible otherwise false. </returns>
        public static bool Is<T>(this object inputValue)
        {
            return inputValue is T;
        }

        /// <summary>
        ///     Determines whether the specified object is not null.
        /// </summary>
        /// <param name="inputValue"> The object. </param>
        /// <returns>
        ///     <c>true</c> if the specified object is not null; otherwise, <c>false</c> .
        /// </returns>
        public static bool IsNotNull([ValidatedNotNull] this object inputValue)
        {
            return !ReferenceEquals(inputValue, null);
        }

        /// <summary>
        ///     Determines whether the specified object is null.
        /// </summary>
        /// <param name="inputValue"> The object. </param>
        /// <returns>
        ///     <c>true</c> if the specified object is null; otherwise, <c>false</c> .
        /// </returns>
        public static bool IsNull([ValidatedNotNull] this object inputValue)
        {
            return ReferenceEquals(inputValue, null);
        }

        /// <summary>
        ///     Returns an IEnumerable(of T) containing the supplied object as it's only entry.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of IEnumerable to return.
        /// </typeparam>
        /// <param name="item">
        ///     The item to be used to create the enumerable.
        /// </param>
        /// <returns>
        ///     An IEnumerable(of T) containing the supplied object.
        /// </returns>
        public static IEnumerable<T> MakeEnumeration<T>(this T item)
        {
            var results = new List<T>();
            results.Add(item);
            return results;
        }

        /// <summary>
        ///     Converts a hashtable into an enumerable of KeyValue pairs.
        /// </summary>
        /// <param name="hashtable">The hashtable To convert.</param>
        /// <returns>An enumerable of Key-Value pairs.</returns>
        public static IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs(this Hashtable hashtable)
        {
            if (hashtable == null)
            {
                return Enumerable.Empty<KeyValuePair<string, string>>();
            }

            var keys = new List<KeyValuePair<string, string>>();
            foreach (object key in hashtable.Keys)
            {
                keys.Add(new KeyValuePair<string, string>(key.ToString(), hashtable[key].ToString()));
            }

            return keys;
        }
    }
}
