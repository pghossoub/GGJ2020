using System;
using UnityEngine;

namespace Marsheleene.Extensions
{
    public class DebugExtensions
    {
        public static void MultiLog(Array messages)
        {
            string[] output = new string[messages.Length];
            for (int i = 0; i < messages.Length; i++)
            {
                output[i] = $"({messages.GetValue(i).ToString()})";
            }

            Debug.Log(String.Join(", ", output));
        }

        public static void DrawArrow2D(Vector2 origin, Vector2 end)
        {
            Vector2 direction = (end - origin).normalized;

            Debug.DrawLine(origin, end);

            Vector3 right = Quaternion.LookRotation(direction, Vector2Extensions.up) * Quaternion.Euler(210, 0, 0) * new Vector3(1, 0, 1);
            Vector3 left = Quaternion.LookRotation(direction, Vector2Extensions.up) * Quaternion.Euler(150, 0, 0) * new Vector3(-1, 0, 1);
            Debug.DrawRay(end, right * 0.20f);
            Debug.DrawRay(end, left * 0.20f);
        }

        public static void DrawArrow2D(Vector2 origin, Vector2 end, Color color)
        {
            Vector2 direction = (end - origin).normalized;

            Debug.DrawLine(origin, end, color);

            Vector3 right = Quaternion.LookRotation(direction, Vector2Extensions.up) * Quaternion.Euler(210, 0, 0) * new Vector3(1, 0, 1);
            Vector3 left = Quaternion.LookRotation(direction, Vector2Extensions.up) * Quaternion.Euler(150, 0, 0) * new Vector3(-1, 0, 1);
            Debug.DrawRay(end, right * 0.20f, color);
            Debug.DrawRay(end, left * 0.20f, color);
        }
    }
}