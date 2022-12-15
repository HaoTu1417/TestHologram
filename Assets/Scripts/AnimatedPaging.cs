using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace DiTichCoDoHue
{
    public class AnimatedPaging : MonoBehaviour
    {
        [SerializeField] private Image currentImg;
        [SerializeField] private Image pastImg;

        public void OpenPageAnim()
        {
            Sequence sq = DOTween.Sequence();
            //sq.Join(currentImg.transform.DOScale(0.25f, 0.75f).From(0.14f))
            //    .Join(currentImg.DOFade(1f, 0.75f).From(0f))
            //    .Join(pastImg.transform.DOScale(0f, 0.5f).From(0.25f))
            //    .Join(pastImg.DOFade(0f, 0.5f).From(1f));
        }

        public void ClosePageAnim()
        {
            Sequence sq = DOTween.Sequence();
            //sq.Join(currentImg.transform.DOScale(0.14f, 0.5f).From(0.25f))
            //    .Join(currentImg.DOFade(0f, 0.5f).From(1f))
            //    .Join(pastImg.transform.DOScale(0.25f, 0.75f).From(0f))
            //    .Join(pastImg.DOFade(1f, 0.75f).From(0f));
        }



        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                OpenPageAnim();
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                ClosePageAnim();
            }
        }

    }
}
