using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace SimpleUI
{
    public class FightUI : MonoBehaviour
    {

        public Button testButton;
        public Transform MoveUnitParent;

		private void Start()
		{
			
		}
	}



    public class MoveUnitManger
    {
        public MoveUIUnit PlayerMoveUnit { get; set; }
        public MoveUIUnit EnemyMoveUnit { get; set; }
    }

    public class MoveUIUnit
    {
        public RectTransform target;
        public float spriteMoveSpeed = 770.0f;
        public float maxPostion = 770.0f;
        Vector2 InitPostion = Vector2.zero;

        bool loopingMove = false;

        FightUnit fightUnit;

        public MoveUIUnit(FightUnit fightUnit,Transform targetParent)
        {
            this.fightUnit = fightUnit;
            GameObject moveUnitGo = new GameObject(fightUnit.SpriteAssetName.Name);
            target = moveUnitGo.AddComponent<RectTransform>();
            moveUnitGo.transform.SetParent(targetParent);
            Image image = moveUnitGo.AddComponent<Image>();
            image.sprite = fightUnit.SpriteUnitIcon.GetSprite();

            target.sizeDelta = new Vector2(32, 64);
            target.anchoredPosition = new Vector2(0, -38);
            target.anchorMin = new Vector2(0, 1);
            target.anchorMax = new Vector2(0, 1);

        }

        public MoveUIUnit(RectTransform target)
        {
            this.target = target;
            InitPostion = target.anchoredPosition;
        }


        public void StartMovement()
        {
            loopingMove = true;
        }

        public void EndMovement()
        {
            loopingMove = false;
        }

        public void LoopMovement()
        {
            if(loopingMove)
            {
                bool finishmove = FinishMovement();
                if(finishmove)
                {
                    loopingMove = false;
                }
            }
        }

        public void ResetPostion()
        {
            if(loopingMove)
            {
                target.anchoredPosition = InitPostion;
                loopingMove = false;
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
