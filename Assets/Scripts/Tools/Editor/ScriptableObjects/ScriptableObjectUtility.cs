#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.IO;

namespace Marsheleene.Tools
{
    public static class ScriptableObjectUtility
    {
        public static T CreateAsset<T>(string name = "") where T : ScriptableObject
        {
            T asset = ScriptableObject.CreateInstance<T>();

            //string path = AssetDatabase.GetAssetPath(Selection.activeObject);
            string path = "Assets/Resources";
            //else if (Path.GetExtension(path) != "")
            //{
            //    path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
            //}

            if (string.IsNullOrWhiteSpace(name))
            {
                name = typeof(T).Name;
            }

            string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath($"{path}/{name}.asset");

            AssetDatabase.CreateAsset(asset, assetPathAndName);

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;

            return asset;
        }
    }
}
#endif