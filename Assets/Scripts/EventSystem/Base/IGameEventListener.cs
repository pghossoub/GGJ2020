using UnityEngine;

namespace Marsheleene.Events
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGameEventListener
    {
        void OnEventRaised(MonoBehaviour sender);
        void OnEventRaisedAsync(MonoBehaviour sender);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGameEventListener<T> where T : GameEventData
    {
        void OnEventRaised(MonoBehaviour sender, T data);
        void OnEventRaisedAsync(MonoBehaviour sender, T data);
    }
}