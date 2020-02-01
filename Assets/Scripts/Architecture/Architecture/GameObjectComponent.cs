using System;
using UnityEngine;

namespace Marsheleene.Architecture
{
    public abstract class GameObjectComponent : GameObjectBehaviour
    {
        #region Public

        private enum UpdateType
        {
            UPDATE_EVERY_FRAME,
            UPDATE_EVERY_N_MS,
            UPDATE_EVERY_N_FRAMES
        }

        [Header("Update type")]

        [SerializeField]
        private UpdateType _updateType;

        [SerializeField]
        [Tooltip("Shall this component react to the pause variable?")]
        private bool _usePause;

        [Header("Update rate")]
        [Tooltip("Time in ms between updates. Leave 0 to udpate every frame.")]
        [Range(0, float.MaxValue)]
        [SerializeField]
        private float _timeBetweenUpdates;

        [Tooltip("Number of frames between updates. Leave 0 to update every frame.")]
        [Range(0, int.MaxValue)]
        [SerializeField]
        private int _framesBetweenUpdates;

        #endregion


        #region System

        private void Update()
        {
            switch (_updateType)
            {
                case UpdateType.UPDATE_EVERY_FRAME:
                {
                    NormalUpdate();
                    break;
                }
                case UpdateType.UPDATE_EVERY_N_FRAMES:
                {
                    UUpdate(() => SteppedUpdate(), ref _normalUpdateCounter, _framesBetweenUpdates, 1);
                    break;
                }
                case UpdateType.UPDATE_EVERY_N_MS:
                {
                    UUpdate(() => SteppedUpdate(), ref _normalUpdateCounter, _timeBetweenUpdates, Time.deltaTime);
                    break;
                }
            }
        }

        private void FixedUpdate()
        {
            switch (_updateType)
            {
                case UpdateType.UPDATE_EVERY_FRAME:
                {
                    NormalFixedUpdate();
                    break;
                }
                case UpdateType.UPDATE_EVERY_N_FRAMES:
                {
                    UUpdate(() => SteppedFixedUpdate(), ref _FixedUpdateCounter, _framesBetweenUpdates, 1);
                    break;
                }
                case UpdateType.UPDATE_EVERY_N_MS:
                {
                    UUpdate(() => SteppedFixedUpdate(), ref _FixedUpdateCounter, _timeBetweenUpdates, Time.fixedDeltaTime);
                    break;
                }
            }
        }

        private void LateUpdate()
        {
            switch (_updateType)
            {
                case UpdateType.UPDATE_EVERY_FRAME:
                {
                    NormalLateUpdate();
                    break;
                }
                case UpdateType.UPDATE_EVERY_N_FRAMES:
                {
                    UUpdate(() => SteppedLateUpdate(), ref _LateUpdateCounter, _framesBetweenUpdates, 1);
                    break;
                }
                case UpdateType.UPDATE_EVERY_N_MS:
                {
                    UUpdate(() => SteppedLateUpdate(), ref _LateUpdateCounter, _timeBetweenUpdates, Time.deltaTime);
                    break;
                }
            }
        }

        #endregion


        #region Main

        /// <summary>
        /// Update called every frame, without being affected by GameManager's pause
        /// </summary>
        protected virtual void NormalUpdate() { }

        /// <summary>
        /// Update called every x ms, without being affected by GameManager's pause
        /// </summary>
        protected virtual void SteppedUpdate() { }

        /// <summary>
        /// FixedUpdate called every frame, without being affected by GameManager's pause
        /// </summary>
        protected virtual void NormalFixedUpdate() { }

        /// <summary>
        /// FixedUpdate called every x ms, without being affected by GameManager's pause
        /// </summary>
        protected virtual void SteppedFixedUpdate() { }

        /// <summary>
        /// LateUpdate called every frame, without being affected by GameManager's pause
        /// </summary>
        protected virtual void NormalLateUpdate() { }

        /// <summary>
        /// LateUpdate called every x ms, without being affected by GameManager's pause
        /// </summary>
        protected virtual void SteppedLateUpdate() { }

        #endregion


        #region Private and protected

        private void UUpdate(Action callback, ref float counter, float threshold, float step)
        {
            if (counter < threshold)
            {
                if (_usePause && m_isGamePaused.Value)
                {
                    return;
                }
                counter += step;
            }
            callback.Invoke();
            counter = 0;
        }

        private float _normalUpdateCounter;
        private float _FixedUpdateCounter;
        private float _LateUpdateCounter;

        #endregion
    }
}