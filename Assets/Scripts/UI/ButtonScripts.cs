using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiTichCoDoHue
{
    public class ButtonScripts : MonoBehaviour
    {
        [SerializeField] RotateItemProperty RotateItemScript;
        [SerializeField] int Index =-1;

        public void ChoseObject()
        {
            Debug.Log("Chọn Item :" + RotateItemScript.ExportChoseIndex());
        }
    }
}
