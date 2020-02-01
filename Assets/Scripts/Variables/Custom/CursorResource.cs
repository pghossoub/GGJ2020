using UnityEngine;

namespace Marsheleene.Variables
{
    [CreateAssetMenu(menuName = "Variables/Cursor Resource")]
    public class CursorResource : ScriptableObject
    {
        public Texture2D m_cursorTexture;
        public Vector2 m_cursorHotSpot;
    }
}