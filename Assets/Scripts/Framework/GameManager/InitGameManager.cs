using UnityEngine;
using System.Collections;

namespace ROKCore
{
    public class InitGameManager : MonoBehaviour
    {
        void Awake()
        {
            ModuleManager.Instance.Initialize();
        }
    }
}