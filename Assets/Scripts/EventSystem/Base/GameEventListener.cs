using System.Threading.Tasks;

using UnityEngine;

using Marsheleene.Extensions;

namespace Marsheleene.Events
{
    /// <summary>
    /// 
    /// </summary>
    public class GameEventListener : MonoBehaviour, IGameEventListener
    {
        public GameEvent Event;
        public GameEventCallback Callback;

        private void OnEnable()
        {
            GameEvent e = Event.Ref();
            if (e == null)
            {
                Debug.LogWarning("Event not assigned for listener [" + GetType().Name + "] in object [" + gameObject.name + "]");
                return;
            }
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            GameEvent e = Event.Ref();
            if (e == null)
            {
                Debug.LogWarning("Event not assigned for listener [" + GetType().Name + "] in object [" + gameObject.name + "]");
                return;
            }
            Event.UnregisterListener(this);
        }

        public void OnEventRaised(MonoBehaviour sender)
        {
            Callback.Invoke(sender);
        }

        public void OnEventRaisedAsync(MonoBehaviour sender)
        {
            Task.Run(async () => await InvokeCallback(sender));
        }

        private async Task InvokeCallback(MonoBehaviour sender)
        {
            EventDispatcher.Instance.Invoke(() => Callback.Invoke(sender));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GameEventListener<T> : MonoBehaviour, IGameEventListener<T> where T : GameEventData
    {
        public abstract GameEvent<T> Event();
        public abstract GameEventCallback<T> Callback();

        private void OnEnable()
        {
            GameEvent<T> e = Event().Ref();
            if (e == null)
            {
                Debug.LogWarning("Event not assigned for listener [" + GetType().Name + "] in object [" + gameObject.name + "]");
                return;
            }
            Event().RegisterListener(this);
        }

        private void OnDisable()
        {
            GameEvent<T> e = Event().Ref();
            if (e == null)
            {
                Debug.LogWarning("Event not assigned for listener [" + GetType().Name + "] in object [" + gameObject.name + "]");
                return;
            }
            Event().UnregisterListener(this);
        }

        public void OnEventRaised(MonoBehaviour sender, T data)
        {
            Callback().Invoke(sender, data);
        }

        public void OnEventRaisedAsync(MonoBehaviour sender, T data)
        {
            Task.Run(async () => await InvokeCallback(sender, data));
        }

        private async Task InvokeCallback(MonoBehaviour sender, T data)
        {
            EventDispatcher.Instance.Invoke(() => Callback().Invoke(sender, data));
        }
    }
}