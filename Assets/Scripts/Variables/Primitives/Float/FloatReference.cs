
namespace Marsheleene.Variables
{
    [System.Serializable]
    public class FloatReference : SingleValueReference<float, FloatVariable>
    {
        public FloatReference() : base() { }
        public FloatReference(bool useConstant) : base(useConstant) { }
        public FloatReference(float value) : base(value) { }
        public FloatReference(float value, bool useConstant) : base(value, useConstant) { }
        public FloatReference(FloatVariable variable) : base(variable) { }
    }
}