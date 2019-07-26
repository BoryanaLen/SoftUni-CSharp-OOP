using System;
using System.Linq;
using System.Reflection;
using System.Text;


public class Spy
{
    public string CollectGettersAndSetters(string className)
    {
        Type type = Type.GetType(className);

        MethodInfo[] allMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        MethodInfo[] geterMethods = allMethods.Where(m => m.Name.StartsWith("get")).ToArray();

        MethodInfo[] seterMethods = allMethods.Where(m => m.Name.StartsWith("set")).ToArray();

        StringBuilder sb = new StringBuilder();

        foreach(MethodInfo method in geterMethods)
        {
            sb.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (MethodInfo method in seterMethods)
        {
            sb.AppendLine($"{method.Name} will set field of {method.GetParameters().FirstOrDefault().ParameterType}");
        }


        return sb.ToString().TrimEnd();
    }
}
