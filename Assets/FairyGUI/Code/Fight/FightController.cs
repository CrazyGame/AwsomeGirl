using UnityEngine;

namespace SimpleUI
{
    public class FightController : MonoBehaviour
    {
        BattlePlace battlePlace = new BattlePlace();
        MoveUnitManger moveUnitManger = new MoveUnitManger();

        public FightUI FightUI;


        private void Start()
        {



            battlePlace.BuildTeam();


            MoveUIUnit playerMoveUnit = new MoveUIUnit(battlePlace.PlayerTeam.fightUnit, FightUI.MoveUnitParent);
            MoveUIUnit enemyMoveUnit = new MoveUIUnit(battlePlace.EnemyTeam.fightUnit, FightUI.MoveUnitParent);

            moveUnitManger.EnemyMoveUnit = enemyMoveUnit;
            moveUnitManger.PlayerMoveUnit = playerMoveUnit;


            battlePlace.Fight();



        }

		private void FixedUpdate()
		{
            moveUnitManger.PlayerMoveUnit.LoopMovement();
            moveUnitManger.EnemyMoveUnit.LoopMovement();
		}
	}
}
