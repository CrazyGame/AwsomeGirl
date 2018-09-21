using UnityEngine;
using UnityEngine.UI;

namespace SimpleUI
{
    public class FightUI : MonoBehaviour
    {


        public Button testButton;

        public RectTransform followTarget;
        MoveUIUnit moveUIUnit;
        private void Start()
        {
            moveUIUnit = new MoveUIUnit(followTarget);
            testButton.onClick.AddListener(() => 
            {
                moveUIUnit.ResetPostion();
            });
        }

        private void FixedUpdate()
        {
            moveUIUnit.StarMove();
        }
    }

    public class MoveUIUnit
    {
        public RectTransform target;
        public float spriteMoveSpeed = 770.0f;
        public float maxPostion = 770.0f;
        Vector2 InitPostion = Vector2.zero;

        bool startMove = false;

        public MoveUIUnit(RectTransform target)
        {
            this.target = target;
            InitPostion = target.anchoredPosition;
        }

        public void StarMove()
        {
            if(!startMove)
            {
                bool finishmove = FinishMovement();
                if(finishmove)
                {
                    startMove = true;
                }
            }
        }

        public void ResetPostion()
        {
            if(startMove)
            {
                target.anchoredPosition = InitPostion;
                startMove = false;
            }        
        }


        bool FinishMovement()
        {
            if (target != null)
            {
                Vector2 tempPostion = target.anchoredPosition;
                tempPostion.x += spriteMoveSpeed * Time.deltaTime;
                if (tempPostion.x >= maxPostion)
                {
                    target.anchoredPosition = tempPostion;
                    return true;
                }
                target.anchoredPosition = tempPostion;
            }
            return false;
        }
    }
}
