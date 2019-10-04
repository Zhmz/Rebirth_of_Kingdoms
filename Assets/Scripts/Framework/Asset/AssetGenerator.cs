using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using LitJson;
using System.IO;
using ROKTool;

namespace ROKCore.ROKAsset
{
    public class AssetGenerator : MonoBehaviour
    {
        RootObject m_AssetDataRoot;

        private void Awake()
        {
            LoadAssetIDsData();
        }

        void LoadAssetIDsData()
        {
            TextAsset jsonText = Resources.Load<TextAsset>("Config/Json/AssetIDs");
            m_AssetDataRoot = JsonMapper.ToObject<RootObject>(jsonText.text);
        }

        AssetGUIData GetAssetGUIDataItem(int assetId)
        {
            if (m_AssetDataRoot != null)
            {
                return m_AssetDataRoot.GUIAssets.Find(x => string.Compare(x.Id, assetId.ToString()) == 0);
            }
            return null;
        }

        public void InstantiateWithAssetBundle(int prefabId, Vector3 pos = default(Vector3))
        {
            ////异步加载
            //StartCoroutine(InstantiateObjectAsync(prefabId, pos));
            //同步加载
            StartCoroutine(InstantiateObject(prefabId, pos));
        }

        IEnumerator InstantiateObjectAsync(int prefabId, Vector3 pos = default(Vector3))
        {
            AssetGUIData item = GetAssetGUIDataItem(prefabId);

            AssetBundle ab = null;
            //if (m_AssetBundleDic.ContainsKey(item.ABName))
            //{
            //    ab = m_AssetBundleDic[item.ABName];
            //    Debug.Log(1);
            //}
            //else
            //{
            string path = Application.streamingAssetsPath + "/AssetBundles/" + item.ABName;
            AssetBundleCreateRequest request = AssetBundle.LoadFromFileAsync(path);
            yield return request;
            ab = request.assetBundle;
            //if (ab != null)
            //{
            //    m_AssetBundleDic.Add(item.ABName, ab);
            //}
            //}

            if (ab != null)
            {
                GameObject go = ab.LoadAsset<GameObject>(item.Name);
                GameObject.Instantiate(go, pos, Quaternion.identity);
                ab.Unload(false);
            }
        }

        public IEnumerator InstantiateObject(int prefabId, Vector3 pos = default(Vector3))
        {
            AssetGUIData item = GetAssetGUIDataItem(prefabId);

            string uri = "file:///" + Application.streamingAssetsPath + "/AssetBundles/" + item.ABName;
            UnityEngine.Networking.UnityWebRequest request =  UnityWebRequestAssetBundle.GetAssetBundle(uri, 0);
            yield return request.SendWebRequest();

            if (request.isNetworkError)
            {
                Debug.Log(request.error);
            }
            else
            {

                //这里handler里的ab是空的

                DownloadHandlerAssetBundle handler = request.downloadHandler as DownloadHandlerAssetBundle;//DownloadHandlerAssetBundle.GetContent(request); 
                if (handler != null)
                {
                    AssetBundle bundle = handler.assetBundle;
                    if (bundle != null)
                    {
                        GameObject prefabAsset = bundle.LoadAsset<GameObject>(item.Name);
                        GameObject.Instantiate(prefabAsset, pos, Quaternion.identity);
                        bundle.Unload(false);
                    }
                }
            }

            request.Dispose();
        }


        //直接加载
        public GameObject InstantiateInEditor(int prefabId, Vector3 pos = default(Vector3))
        {
#if UNITY_EDITOR
            if (m_AssetDataRoot == null)
            {
                return null;
            }

            GameObject result = null;
            AssetGUIData item = m_AssetDataRoot.GUIAssets.Find(x => x.Id == prefabId.ToString());
            if (item == null)
            {
                Debug.Log(string.Format("Id = {0}, the prefab does't exist.", prefabId));
                return null;
            }

            // string path = Application.dataPath + item.Path;
            GameObject prefabAsset = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(item.Path);
            if (prefabAsset != null)
            {
                result = GameObject.Instantiate(prefabAsset, pos, Quaternion.identity);
            }

            return result;
#else
        return null;
#endif
        }






        ////异步加载
        //IEnumerator InstantiateObjectAsync(int assetId, Object obj)
        //{
        //    AssetGUIData data = GetAssetGUIDataItem(assetId);

        //    string path = Application.streamingAssetsPath + "/AssetBundles/" + data.ABName;
        //    if (!Directory.Exists(path))
        //    {
        //        ROKLogger.PrintError("{0} AssetBundle path: {1} doesn't exist.", assetId, path);
        //        throw new FileNotFoundException();
        //    }

        //    AssetBundleCreateRequest request = AssetBundle.LoadFromFileAsync(path);
        //    yield return request;
        //    AssetBundle bundle = request.assetBundle;

        //    if (bundle != null)
        //    {
        //        GameObject asset = bundle.LoadAsset<GameObject>(data.Name);
        //        obj = GameObject.Instantiate(asset, Vector3.zero, Quaternion.identity);
        //        bundle.Unload(false);
        //    }
        //}


        ////UnityWebReq加载
        //IEnumerator InstantiateObjectWebReq(int assetId, Object obj)
        //{
        //    AssetGUIData data = GetAssetGUIDataItem(assetId);

        //    string path = "file:///" + Application.streamingAssetsPath + "/AssetBundles/" + data.ABName;
        //    UnityWebRequest request = UnityWebRequest.Get(path);
        //    yield return request.SendWebRequest();

        //    if(request.isNetworkError)
        //    {
        //        ROKLogger.PrintError("UnityWebRequest errors");
        //    }
        //    else
        //    {

        //    }

        //}


    }
}
