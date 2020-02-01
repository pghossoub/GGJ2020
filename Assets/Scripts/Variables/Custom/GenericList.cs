using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;

namespace Marsheleene.Variables
{
    public abstract class GenericList<T> : ScriptableObject
    {
        #region Public

        public List<T> m_list;

        #endregion

    }
}