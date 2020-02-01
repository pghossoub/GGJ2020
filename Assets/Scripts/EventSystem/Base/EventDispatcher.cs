using System;
using System.Collections.Generic;

using Marsheleene.Architecture;

namespace Marsheleene.Events
{
    public class EventDispatcher : GlobalManager<EventDispatcher>
    {
        #region System

        private void Update()
        {
            InvokePendingActions();
        }

        #endregion


        #region GlobalManager

        protected override void InitAwake()
        {
        }

        #endregion


        #region Main

        public void Invoke(Action action)
        {
            lock (_pendingActions)
            {
                _pendingActions.Enqueue(action);
            }
        }

        private void InvokePendingActions()
        {
            lock (_pendingActions)
            {
                while (_pendingActions.Count > 0)
                {
                    _pendingActions.Dequeue().Invoke();
                }
            }
        }

        #endregion


        #region Private & protected

        private Queue<Action> _pendingActions = new Queue<Action>();

        #endregion
    }
}