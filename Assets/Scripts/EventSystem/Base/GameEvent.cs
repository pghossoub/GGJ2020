using System.Collections.Generic;

using UnityEngine;

namespace Marsheleene.Events
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "Events/Game Event")]
    public  class GameEvent : ScriptableObject
    {
        public void Raise(MonoBehaviour sender)
        {
            // Create of copy of the list, in the case listeners are unregistered during callbacks
            var list = new List<IGameEventListener>(_listeners);
            list.ForEach(listener => listener.OnEventRaised(sender));
        }

        public void RaiseAsync(MonoBehaviour sender)
        {
            // Create of copy of the list, in the case listeners are unregistered during callbacks
            var list = new List<IGameEventListener>(_listeners);
            list.ForEach(listener => listener.OnEventRaisedAsync(sender));
        }

        public void Raise()
        {
            Raise(null);
        }

        public void RaiseAsync()
        {
            RaiseAsync(null);
        }

        public void RegisterListener(IGameEventListener listener)
        {
            if (_lookup.ContainsKey(listener))
            {
                return;
            }
            _lookup[listener] = _listeners.AddLast(listener);
        }

        public void UnregisterListener(IGameEventListener listener)
        {
            if (_lookup.TryGetValue(listener, out LinkedListNode<IGameEventListener> node))
            {
                _lookup.Remove(listener);
                _listeners.Remove(node);
            }
        }

        private readonly LinkedList<IGameEventListener> _listeners = new LinkedList<IGameEventListener>();
        private readonly Dictionary<IGameEventListener, LinkedListNode<IGameEventListener>> _lookup = new Dictionary<IGameEventListener, LinkedListNode<IGameEventListener>>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GameEvent<T> : ScriptableObject where T : GameEventData
    {
        [SerializeField]
        private T _eventData = null;

        public T EventData { get { return _eventData; } }

        public void Raise(MonoBehaviour sender, T eventData)
        {
            // Create of copy of the list, in the case listeners are unregistered during callbacks
            var list = new List<IGameEventListener<T>>(_listeners);
            list.ForEach(listener => listener.OnEventRaised(sender, eventData));
        }

        public void RaiseAsync(MonoBehaviour sender, T eventData)
        {
            // Create of copy of the list, in the case listeners are unregistered during callbacks
            var list = new List<IGameEventListener<T>>(_listeners);
            list.ForEach(listener => listener.OnEventRaisedAsync(sender, eventData));
        }

        public void Raise(MonoBehaviour sender)
        {
            Raise(sender, default);
        }

        public void RaiseAsync(MonoBehaviour sender)
        {
            RaiseAsync(sender, default);
        }

        public void Raise()
        {
            Raise(null, default);
        }

        public void RaiseAsync()
        {
            Raise(null, default);
        }

        public void RegisterListener(IGameEventListener<T> listener)
        {
            if (_lookup.ContainsKey(listener))
            {
                return;
            }
            _lookup[listener] = _listeners.AddLast(listener);
        }

        public void UnregisterListener(IGameEventListener<T> listener)
        {
            if (_lookup.TryGetValue(listener, out LinkedListNode<IGameEventListener<T>> node))
            {
                _lookup.Remove(listener);
                _listeners.Remove(node);
            }
        }

        private readonly LinkedList<IGameEventListener<T>> _listeners = new LinkedList<IGameEventListener<T>>();
        private readonly Dictionary<IGameEventListener<T>, LinkedListNode<IGameEventListener<T>>> _lookup = new Dictionary<IGameEventListener<T>, LinkedListNode<IGameEventListener<T>>>();
    }
}