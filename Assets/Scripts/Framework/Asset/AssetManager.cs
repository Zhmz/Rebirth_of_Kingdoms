using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ROKGUI;
using System.Reflection;
using ROKTool;

namespace ROKCore.ROKAsset
{
    public class AssetManager : BaseModule
    {
        public override EModuleType ModuleType
        {
            get { return EModuleType.Assets; }
        }

        public static AssetManager Instance
        {
            get
            {
                return ModuleManager.Instance.GetModule(EModuleType.Assets) as AssetManager;
            }
        }

        AssetGenerator m_Generator;
        public AssetGenerator Generator
        {
            get
            {
                if (m_Generator == null)
                {
                    GameObject generatorPrefab = Resources.Load<GameObject>("Prefabs/Asset/AssetGenerator");
                    if (generatorPrefab != null)
                    {
                        GameObject go = GameObject.Instantiate(generatorPrefab);
                        if (go != null)
                        {
                            m_Generator = go.GetComponent<AssetGenerator>();
                        }
                    }
                }
                return m_Generator;
            }
        }

        public override void Init()
        {
            base.Init();

            //InstantiateWithAssetBundle(101, new Vector3(3, 0, 0));
            //InstantiateWithAssetBundle(102, new Vector3(-3, 0, 0));
        }

        public override void ShutDown()
        {
            base.ShutDown();
        }

        public void InstantiateWithAssetBundle(int prefabId,GameObject go, Vector3 pos = default(Vector3))
        {
            Debug.Log("1111");
            if (Generator != null)
            {
                Generator.InstantiateWithAssetBundle(prefabId,go, pos);
            }
        }

        public GameObject InstantiateInEditor(int prefabId, Vector3 pos = default(Vector3))
        {
            if (Generator != null)
            {
                return Generator.InstantiateInEditor(prefabId, pos);
            }
            return null;
        }


        //实例化controller
        public T InstantiateController<T>(int userContext = 0) where T:BaseUIController
        {
            T controller = null;

            try
            {
                Type ctrlType = typeof(T);
                object obj = Activator.CreateInstance(ctrlType);
                controller = obj as T;

                if (controller == null)
                {
                    ROKLogger.PrintError("Instantiate Controller {0} Failed.", ctrlType.FullName);
                    return null;
                }

                if (controller.GenerateView())
                {
                    controller.Init();
                }
                else
                {
                    ROKLogger.PrintError("Instantiate View {0} Failed.", ctrlType.FullName);
                }
            }
            catch
            {
                //发生异常，返回类型的默认值
                return default(T);
            }

            return controller;
        }
    }
}
