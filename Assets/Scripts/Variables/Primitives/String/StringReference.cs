
namespace Marsheleene.Variables
{
    [System.Serializable]
    public class StringReference : SingleValueReference<string, StringVariable>
    {
        public StringReference() : base(default, true) { }
        public StringReference(bool useConstant) : base(default, useConstant) { }
        public StringReference(string value) : base(value, true) { }
        public StringReference(string value, bool useConstant) : base(value, useConstant) { }
        public StringReference(StringVariable variable) : base(variable) { }
    }
}