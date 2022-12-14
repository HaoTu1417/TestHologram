using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace DiTichCoDoHue
{
    public class PreviewCamera : MonoBehaviour
    {
        [SerializeField] private Camera previewCam;
        [SerializeField] private Object anRong;


        void Start()
        {

        }

        void Update()
        {
            ChangeCamView();
        }

        private void Angle(int fov, Rect rect, Vector3 transform)
        {
            //previewCam.fieldOfView = 33;
            //previewCam.rect = new Rect(0f, 0f, 0.5f, 1f);
            //previewCam.transform.position = new Vector3(-0.3f, -0.05f, 1.5f);
            previewCam.fieldOfView = fov;
            previewCam.rect = new Rect(rect);
            previewCam.transform.localPosition = transform;
        }

        public void ChangeCamView()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Angle(33, new Rect(0f, 0f, 0.5f, 1f), new Vector3(-0.3f, -0.05f, 1.5f));
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                Angle(33, new Rect(0f, 0f, 0.5f, 1f), new Vector3(-0.13f, -0.132f, 1.125f));
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Angle(37, new Rect(0f, 0f, 0.5f, 1f), new Vector3(0.415f, -0.048f, 1.19f));
            }
        }
    }
}

