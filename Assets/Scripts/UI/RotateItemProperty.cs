using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiTichCoDoHue
{
    public class RotateItemProperty : MonoBehaviour
    {
        [SerializeField] Transform Point;
        [SerializeField] RectTransform Rect1;
        [SerializeField] RectTransform Rect2;
        [SerializeField] RectTransform Rect3;
        [SerializeField] RectTransform Rect4;
        [SerializeField] RectTransform Rect5;
        [SerializeField] List<RotateImgeSingle> rotateImgeSingles;
        [SerializeField] int MinIndex, MaxIndex;
        [SerializeField] List<RectTransform> rectTransformsToUse;
        [SerializeField] int DefautChoseIndex = 3;
        private int currentIndex;
        private int ChoseIndex = -1;

        // Start is called before the first frame update
        void Start()
        {
            ChoseIndex = DefautChoseIndex;
            CreateListRectTransformsToUse();
            SetTransformForObjects();
            SetCenterNum();
            MinIndex = rotateImgeSingles.Count;
            MaxIndex = rotateImgeSingles.Count;

        }
        public int ExportChoseIndex()
        {
            return ChoseIndex;
        }
        void CountChoseIndex()
        {
            ChoseIndex = rotateImgeSingles.Count - MinIndex;
        }
        public void CreateListRectTransformsToUse()
        {
            rectTransformsToUse = new List<RectTransform>();
            int CenterNum = rotateImgeSingles.Count;
            for (int i = 0; i <= (rotateImgeSingles.Count * 2 - 2); i++)
            {
                if (i < CenterNum - 2)
                {
                    rectTransformsToUse.Add(Rect1);
                }
                else if (i == CenterNum - 2)
                {
                    rectTransformsToUse.Add(Rect2);
                }
                else if (i == CenterNum - 1)
                {
                    rectTransformsToUse.Add(Rect3);
                }
                else if (i == CenterNum)
                {
                    rectTransformsToUse.Add(Rect4);
                }
                else
                {
                    rectTransformsToUse.Add(Rect5);
                }
            }
        }
        public void SetMinIndex(int input)
        {
            if (input < MinIndex) { MinIndex = input; MaxIndex = MinIndex + (rotateImgeSingles.Count - 1); }
            CountChoseIndex();
        }
        public void SetMaxIndex(int input)
        {
            if (input > MaxIndex) { MaxIndex = input; MinIndex = MaxIndex - (rotateImgeSingles.Count - 1); }

            CountChoseIndex();
        }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                MoveToNext();
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                MoveToPrevious();
            }
        }
        void MoveToNext()
        {
            if (MaxIndex < (rotateImgeSingles.Count * 2 - 1))
            {
                Debug.Log("Truot phai");
                MinIndex++;
                foreach (RotateImgeSingle x in rotateImgeSingles)
                {
                    x.MoveToNext();
                }
            }
            else
            {
                Debug.Log("Da qua toi tan cung ben phai");
            }
        }
        void MoveToPrevious()
        {
            if (MinIndex > 1)
            {
                Debug.Log("Truot trai");
                MaxIndex--;
                foreach (RotateImgeSingle x in rotateImgeSingles)
                {
                    x.MoveToPrevious();
                }
            }
            else
            {
                Debug.Log("Da qua toi tan cung ben trai");
            }
        }
        void SetCenterNum()
        {

            foreach (var x in rotateImgeSingles)
            {
                x.SetCenterNum(rotateImgeSingles.Count);
            }
        }
        private void SetTransformForObjects()
        {
            foreach (var x in rotateImgeSingles)
            {
                x.SetRectTranform(rectTransformsToUse);
            }
        }
    }
}