using UnityEngine;

namespace Marsheleene.Architecture
{
    public abstract class OneShotBehaviour : DualBehaviour
    {
        #region System

        protected virtual void Awake()
        {
            _transform = GetComponent<Transform>();
        }

        protected virtual void Update()
        {
            if (_doRun)
            {
                _doRun = false;
                RunOnce();
            }
        }

        #endregion


        #region Main

        public abstract void RunOnce();

        #endregion


        #region Private and protected 

        protected Transform _transform;
        private bool _doRun = true;

        #endregion
    }
}
