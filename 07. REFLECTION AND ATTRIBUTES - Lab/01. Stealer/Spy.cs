using System;
using System.Linq;
using System.Reflection;
using System.Text;


public class Spy
{
    public string StealFieldInfo(string className, params string[] requestedFilds)
    {
        Type type = Type.GetType(className);

        if (type == null)
        {
            throw new Exception("Invalid class name!");
        }

        FieldInfo[] allFields = type.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        FieldInfo[] fields = allFields.Where(f => requestedFilds.Contains(f.Name)).ToArray();

        object classInstance = Activator.CreateInstance(type);

        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Class under investigation: {className}");

        foreach (FieldInfo field in fields)
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().TrimEnd();
    }
}
