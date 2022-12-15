using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiTichCoDoHue
{
    public class AnimatedController : MonoBehaviour
    {
        [SerializeField] private List<AnimatedPaging> pagings;

        public void PagingAnimation(int page)
        {
            if (page >= 0 && page < pagings.Count)
            {
                for (int i = 0; i < pagings.Count; i++)
                {
                    pagings[i].OpenClosePageAnim(i == page);
                }
            }
        }

        // dùng để test anim qua trang
        void Update()
        {
            if (Input.anyKey)
            {
                if (int.TryParse(Input.inputString, out int targetPage))
                {

                    PagingAnimation(targetPage);
                }
            }
        }
    }
}
