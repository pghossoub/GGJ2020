using UnityEngine;

namespace Marsheleene.Variables
{
    [System.Serializable]
    public abstract class SingleValueVariable<T> : ScriptableObject
    {
        public T Value;

        public void SetValue(T value)
        {
            Value = value;
        }

        public void SetValue(SingleValueVariable<T> variable)
        {
            Value = variable.Value;
        }
    }
}