
using System;

public class StartUp
{
    static void Main(string[] args)
    {
        Spy spy = new Spy();

        //string result = spy.StealFieldInfo("Hacker", "username", "password");

        string result = spy.CollectGettersAndSetters("Hacker");

        Console.WriteLine(result);
    }
}
