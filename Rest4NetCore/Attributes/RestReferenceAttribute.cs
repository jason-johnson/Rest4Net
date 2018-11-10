using System;
namespace Rest4NetCore.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true, Inherited = true)]
    public class RestReferenceAttribute : Attribute
    {
        public RestReferenceAttribute()
        {
        }
    }
}
