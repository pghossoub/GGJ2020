using UnityEngine;

using Marsheleene.Variables;

namespace Marsheleene.Architecture
{
    public abstract class DualBehaviour : MonoBehaviour
    {
        #region Public

        [Header("Debug")]

        public BoolReference m_isDebugMode;

        [Header("Game states")]

        public BoolReference m_isGameInteractible;
        public BoolReference m_isGamePaused;

        #endregion
    }
}