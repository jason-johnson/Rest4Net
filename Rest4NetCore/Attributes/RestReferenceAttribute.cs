using System;
namespace Rest4NetCore.Attributes
{
    public enum RestReferenceType { Attribute, Element }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class RestReferenceAttribute : Attribute
    {
        public RestReferenceAttribute(string name, Type controller, string methodName, RestReferenceType referenceType = RestReferenceType.Attribute)
        {
            Name = name;
            Controller = controller;
            MethodName = methodName;
            ReferenceType = referenceType;
        }

        public string Name { get; }
        public Type Controller { get; }
        public string MethodName { get; }
        public RestReferenceType ReferenceType { get; }
    }
}
