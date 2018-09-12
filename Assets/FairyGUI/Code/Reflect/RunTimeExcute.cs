using System.Reflection;

namespace RunTimeExcuteSpace
{
    /*
     * Example Usage:
     * 
       public partial class CreateInstanceMapping
       {
           public void CreateRoleWindowMapping()
           {
                //Do Somthing
           }
       }
    *  
    *  
    *  RunTimeExcute.GenericExcuteMethod<CreateInstanceMapping>("CreateRoleWindowMapping");
    */

    public class RunTimeExcute
    {
        public static void GenericExcuteMethod<T>(string MethodName, params object[] parametersValues) where T : new()
        {
            T instance = new T();
            MethodInfo methodInfo = instance.GetType().GetMethod(MethodName);
            if(methodInfo != null)
            {
                methodInfo.Invoke(instance, parametersValues);
            }
        }
    }
}

