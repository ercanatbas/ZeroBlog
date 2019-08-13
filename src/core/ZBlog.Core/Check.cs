using System;
using System.Collections;
using ZBlog.Core.Exceptions;

namespace ZBlog.Core
{
    public static class Check
    {
        public static void NotNullOrEmpty<T>(T value, string parameterName)
        {
            if (value == null)
                throw new ParameterCannotBeNullOrEmptyException(parameterName);
            if (value is string && string.IsNullOrEmpty(value.ToString()))
                throw new ParameterCannotBeNullOrEmptyException($"{parameterName} can not be null or empty!");
            if (value is byte && Convert.ToByte(value) == 0 || value is byte? && (!(value as byte?).HasValue || (value as byte?).Value == 0))
                throw new ParameterValueCannotBeZeroException(parameterName);
            if (value is short && Convert.ToInt16(value) == 0 || value is short? && (!(value as short?).HasValue || (value as short?).Value == 0))
                throw new ParameterValueCannotBeZeroException(parameterName);
            if (value is int && Convert.ToInt32(value) == 0 || value is int? && (!(value as int?).HasValue || (value as int?).Value == 0))
                throw new ParameterValueCannotBeZeroException(parameterName);
            if (value is long && Convert.ToInt64(value) == 0 || value is long? && (!(value as long?).HasValue || (value as long?).Value == 0))
                throw new ParameterValueCannotBeZeroException(parameterName);
            if (value is double && Convert.ToDecimal(value) == 0 || value is double? && (!(value as double?).HasValue || Math.Abs((value as double?).Value) < 0.00001))
                throw new ParameterValueCannotBeZeroException(parameterName);
            if (value is float && Convert.ToDecimal(value) == 0 || value is float? && (!(value as float?).HasValue || Math.Abs((value as float?).Value) < 0.00001))
                throw new ParameterValueCannotBeZeroException(parameterName);
            if ((value as ICollection)?.Count == 0)
                throw new ParameterCannotBeNullOrEmptyException(parameterName);
        }
    }
}
