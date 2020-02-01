
namespace Marsheleene.Variables
{
    [System.Serializable]
    public class BoolReference : SingleValueReference<bool, BoolVariable>
    {
        public BoolReference() : base() { }
        public BoolReference(bool value) : base(true, value) { }
        public BoolReference(bool value, bool useConstant) : base(value, useConstant) { }
        public BoolReference(BoolVariable variable) : base(variable) { }
    }
}