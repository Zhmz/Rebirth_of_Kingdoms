using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace ROKEditor
{
    public class AssetBundleEditWindow : EditorWindow
    {
        [MenuItem("AssetBundles/AssetBundleEditWindow")]
        static void Init()
        {
            AssetBundleEditWindow window = EditorWindow.GetWindow<AssetBundleEditWindow>(false, "Editor AssetBundle Window", true);
            window.Show();
        }

        string abName;
        Object[] assets;

        void OnGUI()
        {
            abName = EditorGUILayout.TextField("请输入AB包的名字：", abName);

            EditorGUILayout.LabelField("已选中的物体：");
            if (assets != null && assets.Length > 0)
            {
                for (int i = 0; i < assets.Length; i++)
                {
                    Object obj = assets[i];
                    EditorGUILayout.LabelField((i + 1).ToString() + obj.name);
                }
            }

            if (GUILayout.Button("确定", GUILayout.Width(200)))
            {
                if (!string.IsNullOrEmpty(abName))
                {
                    foreach (Object obj in assets)
                    {
                        string assetPath = AssetDatabase.GetAssetPath(obj);
                        AssetImporter importer = AssetImporter.GetAtPath(assetPath);
                        importer.assetBundleName = abName;

                        Debug.Log(string.Format("Success set Gameobject = {0}, ABName = {1}", obj.name, abName));
                    }
                }
            }
        }

        void OnSelectionChange()
        {
            assets = Selection.GetFiltered<Object>(SelectionMode.DeepAssets);
            this.Repaint();
        }
    }
}
