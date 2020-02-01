using UnityEngine;

namespace Marsheleene.Variables
{
    [System.Serializable]
    public abstract class SingleValueReference<T, U> where U : SingleValueVariable<T>
    {
        [SerializeField]
        protected bool _useConstant = true;

        [SerializeField]
        protected T _constantValue;

        public U Variable;

        public SingleValueReference() : this(default, true)
        { }

        public SingleValueReference(bool useConstant) : this(default, useConstant)
        { }

        public SingleValueReference(T value) : this(value, true)
        { }

        public SingleValueReference(T value, bool useConstant)
        {
            _constantValue = value;
            _useConstant = useConstant;
        }

        public SingleValueReference(U variable)
        {
            _useConstant = false;
            Variable = variable;
        }

        public T Value
        {
            get
            {
                return _useConstant ? _constantValue : Variable != null ? Variable.Value : default;
            }
            set
            {
                if (_useConstant)
                {
                    Debug.LogWarning("Cannot set a constant variable");
                }
                else
                {
                    Variable.Value = value;
                }
            }
        }
    }
}
