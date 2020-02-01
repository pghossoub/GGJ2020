using System;
using UnityEngine;

namespace Marsheleene.Variables
{
    [Serializable]
    public class IntReference : SingleValueReference<int, IntVariable>
    {
        public IntReference() : base(0, true) { }
        public IntReference(bool useConstant) : base(0, useConstant) { }
        public IntReference(int value) : base(value, true) { }
        public IntReference(int value, bool useConstant) : base(value, useConstant) { }
        public IntReference(IntVariable variable) : base(variable) { }
    }
}