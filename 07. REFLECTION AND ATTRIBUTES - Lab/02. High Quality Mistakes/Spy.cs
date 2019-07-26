using System;
using System.Linq;
using System.Reflection;
using System.Text;


public class Spy
{
    public string AnalyzeAcessModifiers(string className)
    {
        Type type = Type.GetType(className);

        FieldInfo[] fields = type.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public);

        MethodInfo[] publicMethods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);

        MethodInfo[] nonPublicMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        StringBuilder sb = new StringBuilder();

        foreach (FieldInfo field in fields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach(MethodInfo method in nonPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }

        foreach (MethodInfo method in publicMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }

        return sb.ToString().TrimEnd();

    }
}
