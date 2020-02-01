using UnityEngine;

namespace Marsheleene.Variables
{
    [System.Serializable]
    public class Vector3Reference : SingleValueReference<Vector3, Vector3Variable>
    {
        public Vector3Reference() : base(default, true) { }
        public Vector3Reference(bool useConstant) : base(default, useConstant) { }
        public Vector3Reference(Vector3 value) : base(value, true) { }
        public Vector3Reference(Vector3 value, bool useConstant) : base(value, useConstant) { }
        public Vector3Reference(Vector3Variable variable) : base(variable) { }
    }
}