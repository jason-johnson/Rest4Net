using System;
namespace Rest4NetCore.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = true)]
    public class RestContractAttribute : Attribute
    {
        public Type ModelClass { get; set; }
        public string Version { get; set; } = "1.0";

        public RestContractAttribute(Type modelClass)
        {
            ModelClass = modelClass;
        }
    }
}
