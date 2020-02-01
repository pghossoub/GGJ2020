using UnityEngine;

namespace Marsheleene.Architecture
{
    public abstract class SceneSingletonGameObject<T> : DualBehaviour where T : SceneSingletonGameObject<T>
    {
        #region Public

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();
                    if (_instance == null)
                    {
                        new GameObject(typeof(T).Name).AddComponent<T>();
                    }
                }
                return _instance;
            }
        }

        #endregion


        #region System

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                if (Application.isPlaying)
                {
                    _instance = (T)this;
                    InitAwake();
                }
            }
        }

        #endregion


        #region Private and protected

        protected abstract void InitAwake();

        private static T _instance;

        #endregion
    }
}