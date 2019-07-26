using System;
using System.Linq;
using System.Reflection;

public class Tracker
{
    public  void PrintMethodsByAuthor()
    {
        Type type = typeof(StartUp);

        MethodInfo [] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        foreach(MethodInfo method in methods)
        {
            if(method.CustomAttributes.Any( x => x.AttributeType == typeof(AuthorAttribute)))
            {
                var attributes = method.GetCustomAttributes(false);
                   
                foreach(AuthorAttribute atr in attributes)
                {
                    Console.WriteLine($"{method.Name} is written by {atr.Name}");
                }
            }
        }
    }
}

