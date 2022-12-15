using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiTichCoDoHue
{
    public class AudioTesting : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        public void LoadScene()
        {
            // play anim hien ra 
            //sau khi hien xong
            // play am thanh thuyet minh
            AudioController.Instance.PlayAudioByAudioName(AudioList.Dragon);
        }

        // Update is called once per frame
        void Update()
        {



        }
    }

}
