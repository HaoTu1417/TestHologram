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
        [SerializeField] private Transform point1;
        [SerializeField] private Transform point2;
        private Vector2 pos1;
        private Vector2 pos2;
        
        void Update()
        {
            ChangeCamView();
        }
        private void Angle(int fov, Rect rect, Vector2 pos1, Vector2 pos2) // Set Angle for Preview Camera.
        {
            previewCam.fieldOfView = fov;
            previewCam.rect = new Rect(rect);
            point1.localPosition = pos1;
            point2.localPosition = pos2;
            transform.position = (point1.position + point2.position) / 2;
            transform.position -= transform.forward * 7; ;
        }
        private void CheckPos() // Check Pos when receive data from other script.
        {
            //pos1 = data1;
            //pos2 = data2;
            pos1.x = Mathf.Clamp(pos1.x, -0.5f, 0.5f);
            pos1.y = Mathf.Clamp(pos1.y, -0.5f, 0.5f);
            pos2.x = Mathf.Clamp(pos2.x, -0.5f, 0.5f);
            pos2.y = Mathf.Clamp(pos2.y, -0.5f, 0.5f);
        }
        private void ChangeCamView() // Change Preview Camera Angle.
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                pos1 = new Vector2(-0.125f, 0.5f);
                pos2 = new Vector2(-0.5f, -0.5f);
                CheckPos();
                Angle(33, new Rect(0f, 0f, 0.5f, 1f), pos1, pos2);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                pos1 = new Vector2(0.125f, 0.5f);
                pos2 = new Vector2(-0.125f, -0.5f);
                CheckPos();
                Angle(33, new Rect(0f, 0f, 0.5f, 1f), pos1, pos2); 
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                pos1 = new Vector2(0.5f, 0.5f);
                pos2 = new Vector2(0.125f, -0.5f);
                CheckPos();
                Angle(37, new Rect(0f, 0f, 0.5f, 1f), pos1, pos2);
            }
        }
    }
}


