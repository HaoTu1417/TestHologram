using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Lean;
namespace DiTichCoDoHue
{
    public class ChoseLanguage : MonoBehaviour
    {
        TMP_Dropdown m_Dropdown;
        Language language;

        // Start is called before the first frame update
        void Start()
        {
            //Fetch the Dropdown GameObject
            m_Dropdown = GetComponent<TMP_Dropdown>();
            //Add listener for when the value of the Dropdown changes, to take action
            m_Dropdown.onValueChanged.AddListener(delegate
            {
                DropdownValueChanged(m_Dropdown);
            });
        }

        //Ouput the new value of the Dropdown into Text
        void DropdownValueChanged(TMP_Dropdown change)
        {
            language = (Language)change.value;
            Debug.Log(language.ToString());
            Lean.Localization.LeanLocalization.SetCurrentLanguageAll(language.ToString());
        }
    }
    public enum Language
    {
        Vietnamese,
        English
    }
}
