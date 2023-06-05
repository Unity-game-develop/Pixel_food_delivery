using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NOOD;

public enum AnimationVariable
{
    Idle,
    Walk,
    Pickup,
}

namespace Game.PlayerZone
{
    public class PlayerAnimation : MonoBehaviour
    {
        #region AnimationText
        [SerializeField] private CustomDictionary<AnimationVariable, string> animationDic = new CustomDictionary<AnimationVariable, string>();
        #endregion
        private Animator anim;
        private SpriteRenderer sr;
        // Start is called before the first frame update
        void Start()
        {
            anim = gameObject.GetComponent<Animator>();
            sr = gameObject.GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        
        public void AnimateWalk()
        {
            anim.SetBool(animationDic[AnimationVariable.Walk], true);
        }

        public void AnimateIdle()
        {
            anim.SetBool(animationDic[AnimationVariable.Walk], false);
        }

        public void TurnLeft(bool isLeft)
        {
            sr.flipX = isLeft;
        }
    }
}
