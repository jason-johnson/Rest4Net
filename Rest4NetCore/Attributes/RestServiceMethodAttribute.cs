using System;
namespace Rest4NetCore.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class RestServiceMethodAttribute : Attribute
    {
        public RestServiceMethodAttribute()
        {
        }
    }
}
