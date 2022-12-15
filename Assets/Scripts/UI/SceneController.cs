using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiTichCoDoHue
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField] GameObject[] ListSceneLayout;
        [SerializeField] GameObject ObjectScreen3;

        // Start is called before the first frame update
        void Start()
        {
            ListSceneLayout = GameObject.FindGameObjectsWithTag("SceneLayout");
            //OpenScene
            OpenScene(0);
        }

        // Update is called once per frame
    
        private void OpenScene(int IndexScene)
        {
            if (ListSceneLayout.Length != 0)
            {
                foreach (var x in ListSceneLayout)
                {
                    x.SetActive(false);
                }
                ListSceneLayout[IndexScene].SetActive(true);
                //Active Object Of Screen 3
                if (IndexScene == 1)
                {
                    ObjectScreen3.SetActive(true);
                }
                else
                {
                    ObjectScreen3.SetActive(false);
                }
            }
        }
        public void Btn_KhoiDong()
        {
            OpenScene(1);
        }
        public void Btn_ChoseCenterObject()
        {
            OpenScene(2);


        }
        public void Btn_Back()
        {
            OpenScene(1);
        }
    }
}
