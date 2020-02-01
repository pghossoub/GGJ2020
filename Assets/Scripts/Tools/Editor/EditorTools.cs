#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Linq;

namespace Marsheleene.Tools
{
    public class EditorTools
    {
        public enum BackgroundStyle
        {
            None,
            HelpBox,
            Darken,
            Lighten
        }

        public static readonly float HORIZONTAL_SPACING = 10;
        public static readonly float VERTICAL_SPACING = EditorGUIUtility.standardVerticalSpacing;

        public static readonly RectOffset BOX_PADDING = EditorStyles.helpBox.padding;
        public static readonly float BOX_PADDING_INNER = BOX_PADDING.bottom;
        public static readonly float BOX_PADDING_OUTER = 6f;

        public static readonly float SINGLE_LINE_HEIGHT = EditorGUIUtility.singleLineHeight;
        public static readonly float ICON_WIDTH = 20;
        public static readonly float CHECKBOX_WIDTH = 10;

        public static readonly Color DARKEN_COLOUR = new Color(0.0f, 0.0f, 0.0f, 0.2f);
        public static readonly Color LIGHTEN_COLOUR = new Color(1.0f, 1.0f, 1.0f, 0.2f);

        public static readonly GUIStyle STYLE_RIGHT_ALIGN = new GUIStyle(GUI.skin.label)
        {
            alignment = TextAnchor.MiddleRight
        };

        public static readonly GUIStyle STYLE_CENTER_ALIGN = new GUIStyle(GUI.skin.label)
        {
            alignment = TextAnchor.MiddleCenter
        };

        public static readonly GUIStyle STYLE_CENTER_ALIGN_BOLD = new GUIStyle(GUI.skin.label)
        {
            alignment = TextAnchor.MiddleCenter,
            fontStyle = FontStyle.Bold
        };

        public static readonly GUIStyle STYLE_BOLD = new GUIStyle(GUI.skin.label)
        {
            fontStyle = FontStyle.Bold
        };

        public static readonly GUIStyle STYLE_BOX = EditorStyles.helpBox;

        public static Rect Next(Rect basePosition, Rect rect)
        {
            rect.x += rect.width + HORIZONTAL_SPACING;
            return rect;
        }

        public static Rect Remaining(Rect basePosition, Rect rect)
        {
            Rect r = Next(basePosition, rect);
            r.width = basePosition.width - (rect.x - basePosition.x) - rect.width - HORIZONTAL_SPACING;
            return r;
        }

        public static Rect NewLine(Rect basePosition, Rect rect)
        {
            rect.x = basePosition.x;
            rect.width = basePosition.width;
            rect.y += rect.height + VERTICAL_SPACING;
            return rect;
        }

        public static Rect PaddedNewLine(Rect basePosition, Rect rect)
        {
            rect.x = basePosition.x + BOX_PADDING_INNER;
            rect.width = basePosition.width - BOX_PADDING_INNER * 2;
            rect.y += rect.height + VERTICAL_SPACING + BOX_PADDING_INNER * 2;
            return rect;
        }

        public static Rect BoxedRect(Rect rect)
        {
            return BoxedRect(rect, BOX_PADDING, BackgroundStyle.HelpBox);
        }

        public static Rect BoxedRect(Rect rect, BackgroundStyle style)
        {
            return BoxedRect(rect, BOX_PADDING, style);
        }

        public static Rect BoxedRect(Rect rect, int padding)
        {
            var offset = new RectOffset(padding, padding, padding, padding);
            return BoxedRect(rect, offset, BackgroundStyle.HelpBox);
        }

        public static Rect BoxedRect(Rect rect, int padding, BackgroundStyle style)
        {
            var offset = new RectOffset(padding, padding, padding, padding);
            return BoxedRect(rect, offset, style);
        }

        public static Rect BoxedRect(Rect rect, RectOffset offset, BackgroundStyle style)
        {
            rect = offset.Add(rect);
            DrawBackground(rect, style);
            return offset.Remove(rect);
        }

        public static Rect BoxedRects(params Rect[] rects)
        {
            return BoxedRects(BOX_PADDING, BackgroundStyle.HelpBox, rects);
        }

        public static Rect BoxedRects(int padding, params Rect[] rects)
        {
            var offset = new RectOffset(padding, padding, padding, padding);
            return BoxedRects(offset, BackgroundStyle.HelpBox, rects);
        }

        public static Rect BoxedRects(BackgroundStyle style, params Rect[] rects)
        {
            return BoxedRects(BOX_PADDING, style, rects);
        }

        public static Rect BoxedRects(int padding, BackgroundStyle style, params Rect[] rects)
        {
            var offset = new RectOffset(padding, padding, padding, padding);
            return BoxedRects(offset, style, rects);
        }

        public static Rect BoxedRects(RectOffset offset, BackgroundStyle style, params Rect[] rects)
        {
            if (rects.Length == 0)
            {
                return new Rect();
            }

            float xMin = rects.Min(r => r.xMin);
            float yMin = rects.Min(r => r.yMin);
            float xMax = rects.Max(r => r.xMax);
            float yMax = rects.Max(r => r.yMax);
            Rect rect = Rect.MinMaxRect(xMin, yMin, xMax, yMax);

            return BoxedRect(rect, offset, style);
        }

        public static void DrawBackground(Rect rect, BackgroundStyle style)
        {
            switch (style)
            {
                case BackgroundStyle.HelpBox:
                    EditorGUI.HelpBox(rect, string.Empty, MessageType.None);
                    break;

                case BackgroundStyle.Darken:
                    EditorGUI.DrawRect(rect, DARKEN_COLOUR);
                    break;

                case BackgroundStyle.Lighten:
                    EditorGUI.DrawRect(rect, LIGHTEN_COLOUR);
                    break;
            }
        }
    }
}
#endif