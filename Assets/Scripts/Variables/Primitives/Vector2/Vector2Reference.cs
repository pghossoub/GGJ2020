using UnityEngine;

namespace Marsheleene.Variables
{
    [System.Serializable]
    public class Vector2Reference : SingleValueReference<Vector2, Vector2Variable>
    {
        public Vector2Reference() : base(default, true) { }
        public Vector2Reference(bool useConstant) : base(default, useConstant) { }
        public Vector2Reference(Vector2 value) : base(value, true) { }
        public Vector2Reference(Vector2 value, bool useConstant) : base(value, useConstant) { }
        public Vector2Reference(Vector2Variable variable) : base(variable) { }
    }
}