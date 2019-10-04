using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

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

            InstantiateWithAssetBundle(101, new Vector3(3, 0, 0));
            InstantiateWithAssetBundle(102, new Vector3(-3, 0, 0));
        }

        public override void ShutDown()
        {
            base.ShutDown();
        }

        public void InstantiateWithAssetBundle(int prefabId, Vector3 pos = default(Vector3))
        {
            if (Generator != null)
            {
                Generator.InstantiateWithAssetBundle(prefabId, pos);
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
    }
}
