using GraphQL;
using GraphQL.Language.AST;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nursry.Web.GraphQL.Types
{
    public class MyTimeSpanSecondsGraphType : ScalarGraphType
    {
        public override object ParseLiteral(IValue value)
        {
            if (value is IntValue intValue)
            {
                return TimeSpan.FromSeconds(intValue.Value);
            }
            if (value is LongValue longValue)
            {
                return TimeSpan.FromSeconds(longValue.Value);
            }
            if (value is TimeSpanValue tsValue)
            {
                return tsValue.Value;
            }
            return null;
        }

        public override object ParseValue(object value)
        {
            if(value is int)
            {
                return TimeSpan.FromSeconds((int)value);
            }
            return ValueConverter.ConvertTo(value, typeof(TimeSpan));
        }

        public override object Serialize(object value)
        {
            if (value is TimeSpan timeSpan)
            {
                return (long)timeSpan.TotalSeconds;
            }
            if (value is int)
            {
                return TimeSpan.FromSeconds((int)value);
            }

            return null;
        }
    }
}
