using UnityEngine;

namespace Marsheleene.Architecture
{
    public class GameObjectBehaviour : DualBehaviour
    {
        #region System

        protected virtual void Awake()
        {
            _transform = GetComponent<Transform>();
        }

        #endregion


        #region Private & Protected

        protected Transform _transform;

        #endregion
    }
}