using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace ROKEditor
{
    public class AssetBundleBuilder
    {
        [MenuItem("AssetBundles/Create AssetBundle")]
        static void CreateAssetBundle()
        {
            //Object[] selectedAssets = Selection.GetFiltered<Object>(SelectionMode.DeepAssets);

            //foreach (Object obj in selectedAssets)
            //{
            //string sourcePath = AssetDatabase.GetAssetPath(obj);
            //string targetPath = Application.dataPath + "/StreamingAssets/" + obj.name + ".assetbundle";
            string dir = Application.dataPath + "/StreamingAssets/AssetBundles";
            Debug.LogError(dir);
            if (!Directory.Exists(dir))
            {
                DirectoryInfo info = Directory.CreateDirectory(dir);
                Debug.Log(info.FullName);
            }
            //bool isSucceed =
#if UNITY_EDITOR
            AssetBundleManifest mani = BuildPipeline.BuildAssetBundles(dir, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
            //BuildPipeline.BuildAssetBundle(obj, null, targetPath, BuildAssetBundleOptions.None);
#elif UNITY_ANDROID
                    //false;//BuildPipeline.BuildAssetBundle(obj, null, targetPath, BuildAssetBundleOptions.None, BuildTarget.Android);
#elif UNITY_IPHONE
                    //false;//BuildPipeline.BuildAssetBundle(obj, null, targetPath, BuildAssetBundleOptions.None, BuildTarget.iOS);
#endif
            //if (isSucceed)
            //{
            //    Debug.Log("build success.");
            //}
            //else
            //{
            //    Debug.Log("build failure.");
            //}
            //}

            AssetDatabase.Refresh();
        }

        //        [MenuItem("AssetBundleEditor/Create AssetBundles All")]
        //        static void CreateAssetBundleAll()
        //        {
        //            Caching.CleanCache();
        //            string targetPath = Application.dataPath + "/StreamingAssets/ALL.assetbundle";

        //            Object[] selectedAssets = Selection.GetFiltered<Object>(SelectionMode.DeepAssets);

        //            foreach (Object obj in selectedAssets)
        //            {
        //                Debug.Log("obj.name = " + obj.name);
        //            }

        //            bool isSucceed =
        //#if UNITY_EDITOR
        //                BuildPipeline.BuildAssetBundle(null, selectedAssets, targetPath, BuildAssetBundleOptions.None);
        //#elif UNITY_ANDROID
        //                BuildPipeline.BuildAssetBundle(null, selectedAssets, targetPath, BuildAssetBundleOptions.None, BuildTarget.Android);
        //#elif UNITY_IPHONE
        //                BuildPipeline.BuildAssetBundle(null, selectedAssets, targetPath, BuildAssetBundleOptions.None, BuildTarget.iOS);
        //#endif
        //            if (isSucceed)
        //            {
        //                Debug.Log("All build success.");
        //            }
        //            else
        //            {
        //                Debug.Log("All build failure.");
        //            }

        //            AssetDatabase.Refresh();
        //        }
    }
}
