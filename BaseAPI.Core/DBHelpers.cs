using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseAPI.Core
{
    public static class DBHelpers
    {
        /// <summary>
        /// This method Checks for the DBNull value, If the given value is DBNull returns given default value, else returns actual value.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="value">Value to check DBNull.</param>
        /// <param name="defaultValue">DefaultValue value to return incase od DBNull.</param>
        /// <returns>If the given value is DBNull returns default value, else returns actual value.</returns>
        public static T CastDBNullTo<T>(object value, T defaultValue)
        {
            return (value != DBNull.Value) ? (T)value : defaultValue;
        }

        /// <summary>
        /// This method Checks for the DBNull value, If the given value is DBNull returns null, else returns actual value.
        /// </summary>
        /// <param name="value">Value to check DBNull.</param>
        /// <returns>If the given value is DBNull returns null, else returns actual value.</returns>
        public static object CheckDBNullValue(object value)
        {
            return (value != DBNull.Value) ? value : null;
        }

        /// <summary>
        /// This method Checks for the Null value, If the given value is Null returns DBNull, else returns actual value.
        /// </summary>
        /// <param name="value">Value to check Null.</param>
        /// <returns>If the given value is Null returns DBNull, else returns actual value.</returns>
        public static object CheckNullValue(object value)
        {
            return (value != null) ? value : DBNull.Value;
        }

    }

}
