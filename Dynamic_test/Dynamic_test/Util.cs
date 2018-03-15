using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Dynamic_test
{
    class Util<T>
    {
        public TResult CallInterface<TResult>(Expression<Func<T, TResult>> lambdaExp)  // На вход функции - лямбда выражение
        {
            Console.WriteLine(lambdaExp.ToString());

            var exp = lambdaExp.Body as MethodCallExpression;               // Получаем тело лямбды
            var methName = exp.Method.Name;                                 // Если лямбда содержит вызов функции получаем ее ПОЛНОЕ имя
            var meth = exp.Method;              // Получаем только имя метода

            Console.WriteLine("Calling exp {0}, methName {1}, meth {2}", exp.ToString(), methName, meth.ToString());

            var allParameters = from element in exp.Arguments   // список аргументов в методе в лямбде
                                select processArgument(element);

            foreach (var parm in allParameters)
                Console.WriteLine(
                "\tParameter type = {0}, Value = {1}",
                parm.Item1, parm.Item2);
            
            return default(TResult);
        }


        // Если вдруг параметр функции это еще одно лямбда выражение, чтоб его, и его разбираем
        private Tuple<Type, object> processArgument(Expression element)
        {
            object argument = default(object);

            LambdaExpression l = Expression.Lambda( Expression.Convert(element, element.Type));
            Console.WriteLine("l = {0}", l.ToString());
            Type parmType = l.ReturnType;

            argument = l.Compile().DynamicInvoke();

            return Tuple.Create(parmType, argument);
        }
    }

    class ClientContactType
    {
        private string WorkPhoneVar = "";
        public string WorkPhone
        {
            get { return WorkPhoneVar; }
            set { WorkPhoneVar = value; }
        }

        public string HomePhone { get; set; }

        public int RetValue(string i)
        {
            return i.Length;
        }
    }
}
