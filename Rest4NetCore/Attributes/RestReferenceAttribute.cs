using System;
namespace Rest4NetCore.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class RestReferenceAttribute : Attribute
    {
        public RestReferenceAttribute(string name, Type controller, string methodName)
        {
            Name = name;
            Controller = controller;
            MethodName = methodName;
        }

        public string Name { get; }
        public Type Controller { get; }
        public string MethodName { get; }
    }
}
