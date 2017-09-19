using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ASF.Framework.Utilities
{
    public class ReflectionUtilities
    {
        // http://rogeralsing.com/2008/02/28/linq-expressions-creating-objects/
        // As an laternative just call: dynamic badge = Activator.CreateInstance(badgeMapping.BadgeClass);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        /// <returns></returns>
        public delegate T ObjectActivator<out T>(params object[] args);

        public static ObjectActivator<T> GetActivator<T>(ConstructorInfo ctor)
        {
            var paramsInfo = ctor.GetParameters();

            // Create a single param of type object[]
            var param = Expression.Parameter(typeof(object[]), "args");

            var argsExp = new Expression[paramsInfo.Length];

            //pick each arg from the params array and create a typed expression of them
            for (var i = 0; i < paramsInfo.Length; i++)
            {
                Expression index = Expression.Constant(i);
                var paramType = paramsInfo[i].ParameterType;

                Expression paramAccessorExp = Expression.ArrayIndex(param, index);

                Expression paramCastExp = Expression.Convert(paramAccessorExp, paramType);

                argsExp[i] = paramCastExp;
            }

            // Make a NewExpression that calls the //ctor with the args we just created
            var newExp = Expression.New(ctor, argsExp);

            // Create a lambda with the New expression as body and our param object[] as arg
            var lambda = Expression.Lambda(typeof(ObjectActivator<T>), newExp, param);

            // Compile it
            var compiled = (ObjectActivator<T>)lambda.Compile();

            return compiled;
        }

        public static void MapObjects(object source, object destination)
        {
            Type sourcetype = source.GetType();
            Type destinationtype = destination.GetType();

            var sourceProperties = sourcetype.GetProperties();
            var destionationProperties = destinationtype.GetProperties();

            var commonproperties = from sp in sourceProperties
                                   join dp in destionationProperties on new { sp.Name, sp.PropertyType } equals
                                       new { dp.Name, dp.PropertyType }
                                   select new { sp, dp };

            foreach (var match in commonproperties)
            {
                match.dp.SetValue(destination, match.sp.GetValue(source, null), null);
            }
        }
    }
}
