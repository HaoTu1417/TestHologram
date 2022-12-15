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


        public void OpenClosePageAnim(bool isOpen)
        {
            Sequence sq = DOTween.Sequence();
            //Thực hiện anim mở trang hoặc đóng trang
            if (isOpen)
            {
                sq.Join(currentImg.transform.DOScale(0.25f, 0.25f))
                    .Join(currentImg.DOFade(1f, 0.25f).SetEase(Ease.Linear))
                    .Join(pastImg.transform.DOScale(0f, 0.25f))
                    .Join(pastImg.DOFade(0f, 0.25f).SetEase(Ease.Linear));
            }
            else
            {
                sq.Join(currentImg.transform.DOScale(0.14f, 0.25f))
                    .Join(currentImg.DOFade(0f, 0.25f).SetEase(Ease.Linear))
                    .Join(pastImg.transform.DOScale(0.25f, 0.25f))
                    .Join(pastImg.DOFade(1f, 0.25f).SetEase(Ease.Linear));
            }
        }



        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                OpenClosePageAnim(true);
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                OpenClosePageAnim(false);
            }
        }

    }
}
