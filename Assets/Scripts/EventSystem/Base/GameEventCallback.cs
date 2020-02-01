using UnityEngine;

using UltEvents;

namespace Marsheleene.Events
{
    /// <summary>
    /// 
    /// </summary>
    [System.Serializable]
    public class GameEventCallback : UltEvent<MonoBehaviour> { }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GameEventCallback<T> : UltEvent<MonoBehaviour, T> where T : GameEventData { }
}