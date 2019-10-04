using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ROKGUI
{
    public class BaseUIView : MonoBehaviour
    {
        public virtual void SetActive(bool value)
        {
            this.gameObject.SetActive(value);
        }
    }
}
