using UnityEngine;

namespace SimpleUI
{
    public class FightController : MonoBehaviour
    {
        BattlePlace battlePlace = new BattlePlace();

        public FightUI FightUI;

        private void Start()
        {
            battlePlace.BuildTeam();
            battlePlace.Fight();
        }
    }
}
