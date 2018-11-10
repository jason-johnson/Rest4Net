using System;
namespace Rest4NetCore.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class RestEntrypointAttribute : Attribute
    {
    }
}
