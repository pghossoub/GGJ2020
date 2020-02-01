using UnityEngine;

namespace Marsheleene.Architecture
{
    public abstract class GlobalSingletonGameObject<T> : DualBehaviour where T : GlobalSingletonGameObject<T>
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
                        Debug.Log("Creating singleton");
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
                    DontDestroyOnLoad(transform.root.gameObject);
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