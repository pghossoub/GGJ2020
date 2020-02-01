using UnityEngine;

namespace Marsheleene.Architecture
{
    public class ScriptableObjectManagerList : MonoBehaviour
    {
        [SerializeField]
        private ScriptableObjectManager[] _list;

        private void Awake()
        {
            //_list = (ScriptableObjectManager[])Resources.FindObjectsOfTypeAll(typeof(ScriptableObjectManager));
        }
    }
}