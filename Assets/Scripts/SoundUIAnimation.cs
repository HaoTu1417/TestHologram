using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiTichCoDoHue
{
    public class SoundUIAnimation : MonoBehaviour
    {
        [SerializeField] RectTransform soundUIMask;

        // Sound UI
        [SerializeField] Transform soundUITransform_1;
        [SerializeField] GameObject equalizer_1;
        [SerializeField] Transform soundUITransform_2;
        [SerializeField] GameObject equalizer_2;

        [SerializeField] float speed = 50f;

        [SerializeField] bool isSoundPlaying;

        float startPosX;
        float stopPosX;
        bool canMoveToStartPos_1 = false;
        bool canMoveToStartPos_2 = false;

        void Awake()
        {
            stopPosX = soundUIMask.rect.width;
            if (soundUITransform_1.localPosition.x >= soundUITransform_2.localPosition.x)
            {
                stopPosX += soundUITransform_1.localPosition.x;
                startPosX -= soundUITransform_2.localPosition.x;
            }
            else
            {
                stopPosX += soundUITransform_2.localPosition.x;
                startPosX -= soundUITransform_1.localPosition.x;
            }

            isSoundPlaying = false;

            // Hide equalizer
            equalizer_1.SetActive(false);
            equalizer_2.SetActive(false);
        }

        /// <summary>
        /// Call when playing sound
        /// </summary>
        public void SoundBegin()
        {
            if (!isSoundPlaying)
            {
                isSoundPlaying = true;
            }
        }

        /// <summary>
        /// Call when stop sound
        /// </summary>
        public void SoundStop()
        {
            if (isSoundPlaying)
            {
                isSoundPlaying = false;
            }
        }

        void HandleSoundUI(ref Transform soundUITransform, ref GameObject equalizer, ref bool canMoveToStartPos)
        {
            if (canMoveToStartPos)
            {
                soundUITransform.localPosition = new Vector3(-startPosX, 0f, 0f);
                canMoveToStartPos = false;

                if (isSoundPlaying)
                {
                    if (!equalizer.activeInHierarchy)
                        equalizer.SetActive(true);
                }
                else
                {
                    equalizer.SetActive(false);
                }
            }

            Vector3 step = speed * Time.fixedDeltaTime * new Vector3(1f, 0f, 0f);
            if ((soundUITransform.localPosition + step).x < stopPosX)
            {
                soundUITransform.localPosition += step;
            }
            else
            {
                soundUITransform.localPosition = new Vector3(stopPosX, 0f, 0f);
                canMoveToStartPos = true;
            }
        }

        void FixedUpdate()
        {
            HandleSoundUI(ref soundUITransform_1, ref equalizer_1, ref canMoveToStartPos_1);
            HandleSoundUI(ref soundUITransform_2, ref equalizer_2, ref canMoveToStartPos_2);
        }
    }
}