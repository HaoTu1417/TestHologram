using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Localization;

namespace DiTichCoDoHue
{
    public class LanguageManager : MonoBehaviour
    {
        [SerializeField] GameObject parent;

        // Start is called before the first frame update
        void Start()
        {
            List<LeanPhrase> phrases = new List<LeanPhrase>();
            phrases.AddRange(parent.GetComponentsInChildren<LeanPhrase>());

            foreach (LeanPhrase phrase in phrases)
            {
                var data = DataLoader.Instance.GetData(phrase.gameObject.name);
                for (int i = 0; i < data.Count; i++)
                {
                    if (data[i].langCode == "vi")
                    {
                        phrase.AddEntry("Vietnamese", data[i].content);
                    }

                    if (data[i].langCode == "en")
                    {
                        phrase.AddEntry("English", data[i].content);
                    }
                }

            }
            Debug.Log(phrases[0].Entries);
        }


    }
}
