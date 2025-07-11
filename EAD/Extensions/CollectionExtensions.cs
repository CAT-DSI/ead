using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace EAD.Extensions
{
    /// <summary>
    /// Extensions methods for <see cref="IEnumerable{T}" />
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Adding <paramref name="obj"/> object into <paramref name="list"/>
        /// </summary>
        /// <param name="list">Objects list</param>
        /// <param name="obj">Object to add</param>
        public static void AddObject<T>(this ConcurrentBag<T> list, T obj)
        {
            if (list != null && obj != null)
            {
                list.Add(obj);
            }
        }

        /// <summary>
        /// Checking if <paramref name="list"/> is valid
        /// </summary>
        /// <param name="list">Objects list</param>
        /// <param name="minLength">Minimum list length</param>
        public static bool IsValid<T>(this IEnumerable<T> list, int minLength = 1)
        {
            return list != null && list.Count() >= minLength;
        }

        /// <summary>
        /// Converting <see cref="byte"/>[] into SID
        /// </summary>
        /// <param name="bytes"><see cref="byte"/> array</param>
        public static string ToSid(this byte[] bytes)
        {
            if (bytes != null && bytes.Length > 0)
            {
                string sidString;

                if (!ConvertSidToStringSid(bytes, out IntPtr ptrSid))
                {
                    return null;
                }

                try
                {
                    sidString = Marshal.PtrToStringAuto(ptrSid);
                }
                finally
                {
                    Marshal.FreeHGlobal(ptrSid);
                }

                return sidString;
            }
            else
            {
                return null;
            }
        }

        [DllImport("advapi32", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ConvertSidToStringSid([MarshalAs(UnmanagedType.LPArray)] byte[] pSID, out IntPtr ptrSid);
    }
}
