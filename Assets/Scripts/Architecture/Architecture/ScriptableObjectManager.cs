using UnityEngine;

namespace Marsheleene.Architecture
{
    public abstract class ScriptableObjectManager : ScriptableObject
    {
        public static ScriptableObjectManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<ScriptableObjectManager>();
                    if (_instance == null)
                    {
                        //ScriptableObjectUtility.CreateAsset<ScriptableObjectManager>();
                    }
                }
                return _instance;
            }
        }

        public ScriptableObjectManager()
        {
            if (_instance != null)
            {
                Destroy(this);
            }
            else
            {
                _instance = (ScriptableObjectManager)this;
            }
        }

        private static ScriptableObjectManager _instance;
    }
}