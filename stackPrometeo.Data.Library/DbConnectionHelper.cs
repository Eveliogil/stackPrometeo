using System;
using System.Data;

namespace stackPrometeo.Data.Library
{
    public static class DbConnectionHelper
    {
        public static T GetData<T>(this IDataReader reader, string columnName)
        {

            if (Convert.IsDBNull(reader[columnName]))
                throw new DataException(string.Format("The column {0} cant be null", columnName));

            if (reader[columnName].GetType() != typeof(T))
                throw new InvalidCastException(string.Format("Column {0}, can't be casted to {1}", columnName, typeof(T)));

            return (T)reader[columnName];
        }

        public static Nullable<T> GetNullableData<T>(this IDataReader reader, string columnName) where T : struct
        {

            if (Convert.IsDBNull(reader[columnName]))
                return null;

            if (reader[columnName].GetType() != typeof(T))
                throw new InvalidCastException(string.Format("Column {0}, can't be casted to {1}", columnName, typeof(T)));

            return (T)reader[columnName];
        }
        public static T GetData<T>(this IDataReader reader, string columnName, T defaultValue)
        {
            if (Convert.IsDBNull(reader[columnName]))
                return defaultValue;

            if (reader[columnName].GetType() != typeof(T))
                throw new InvalidCastException(string.Format("Column {0}, can't be casted to {1}", columnName, typeof(T)));

            return (T)reader[columnName];
        }

        public static bool IsDbNull(this IDataReader reader, string columnName)
        {
            return reader[columnName] == DBNull.Value;
        }

        public static T GetEnumValue<T>(this IDataReader reader, string columnName, T defaultValue) where T : struct
        {
            if (IsDbNull(reader, columnName))
                return defaultValue;

            string value = reader[columnName].ToString();
            T v;
            if (Enum.TryParse(value, true, out v))
            {
                return v;
            }

            return defaultValue;
        }

    }
}
