using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace E_Mailer
{
    public static class RunCommandAsync
    {

        public static T GetPropertyValue <T>(this Expression<Func<T>>lambda)
        {
            return lambda.Compile().Invoke();
        }

        public static void SetPropertyValue<T>(this Expression<Func<T>> lambda, T value)
        {
            //Converts lambda () => some.Property  to some.Property
            var expression = (lambda as LambdaExpression).Body as MemberExpression;

            var propertyInfo = (PropertyInfo)expression.Member;
            var target = lambda.Compile().DynamicInvoke();

            propertyInfo.SetValue(target, value);
        }

        /// <summary>
        /// Runs a command if the updating flag is not set.
        /// If the flag is true (indicating the function is already running) then the action is not run.
        /// If the flag is false (indicating no running function) then the action is run.
        /// Once the action is finished if it was run, then the flag is reset to false
        /// </summary>
        /// <param name="updatingFlag">The boolean property flag defining if the command is already running</param>
        /// <param name="action">The action to run if the command is not already running</param>
        /// <returns></returns>
        public async static Task RunCommand(Expression<Func<bool>> updatingFlag, Func<Task> action)
        {
            //Check if flag prperty is true = function is running
            if (updatingFlag.GetPropertyValue())
                return;

            updatingFlag.SetPropertyValue(true);


            /*
            // Lock to ensure single access to check
            lock (mPropertyValueCheckLock)
            {
                // Check if the flag property is true (meaning the function is already running)
                if (updatingFlag.GetPropertyValue())
                    return;

                // Set the property flag to true to indicate we are running
                updatingFlag.SetPropertyValue(true);
            }

            try
            {
                // Run the passed in action
                await action();
            }
            finally
            {
                // Set the property flag back to false now it's finished
                updatingFlag.SetPropertyValue(false);
            }*/
        }
    }
}
