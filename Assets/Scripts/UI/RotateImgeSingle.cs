using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace DiTichCoDoHue
{
    public class RotateImgeSingle : MonoBehaviour
    {
        [SerializeField] RotateItemProperty ControllerScript;
        [SerializeField] List<RectTransform> Rectransforms;
        [SerializeField] int currentIndex;
        readonly float duration = .5f;
        private RectTransform RectTransform;
        [SerializeField] int CenterNum;
        private void Start()
        {
            RectTransform = GetComponent<RectTransform>();
        }
        public void SetRectTranform(List<RectTransform> transformsinput)
        {
            Rectransforms = new List<RectTransform>();
            Rectransforms = transformsinput;
        }
        public void SetCenterNum(int Lenght)
        {
            CenterNum = Lenght;
        }
        public void MoveToNext()
        {


            MoveAndChangeTransform(Rectransforms[currentIndex]);
            currentIndex++;
            ControllerScript.SetMaxIndex(currentIndex);


        }
        void MoveAndChangeTransform(RectTransform rectTransformTarget)
        {

            Sequence se = DOTween.Sequence();
            se.Join(gameObject.transform.DOMove(rectTransformTarget.position, duration)).Join(gameObject.transform.DORotateQuaternion(rectTransformTarget.rotation, duration))
                .Join(RectTransform.DOSizeDelta(rectTransformTarget.sizeDelta, duration));

        }
        public void MoveToPrevious()
        {
            // thay doi index
            // animate thay doi sang target transfom (position, rotaion, scale)           
            MoveAndChangeTransform(Rectransforms[currentIndex - 2]);
            currentIndex--;
            ControllerScript.SetMinIndex(currentIndex);
        }

    }

}