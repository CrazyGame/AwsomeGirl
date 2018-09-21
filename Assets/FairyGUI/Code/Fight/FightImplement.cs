using System.Collections.Generic;

namespace SimpleUI
{
    public class FightUnit
    {
        public FightElement fightElement { get; set; }
        public FightUnitHud fightUnitHud { get; set; }
        public ReachedGoal reachedGoal { get; set; }


        public List<FightUnit> TargetFightUnits = new List<FightUnit>();


        public void AttackUnit(FightUnit beAttackedUnit)
        {
            if(!IsDead)
            beAttackedUnit.fightUnitHud.DamageToDead(fightElement);
        }
        public bool IsDead { get { return fightUnitHud.IsDead; } }

        public bool TimeToDoAction()
        {
            bool isReachedGoal = reachedGoal.AdvanceToReachedGoal(fightElement.Speed);
            if(isReachedGoal)
            {
                AttackAmount.TotalAttackCount++;
                for (int i = 0; i < TargetFightUnits.Count; i++)
                {
                    AttackUnit(TargetFightUnits[i]);
                }
            }

            return isReachedGoal;
        }

        public AttackAmount AttackAmount = new AttackAmount();
    }


    public class AttackAmount
    {
        public int TotalAttackCount { get; set; }
    }

    public class ReachedGoal
    {
        public int CurrentPostion { get; set; }
        int GoalAmount = 0;
        public ReachedGoal(int goal)
        {
            GoalAmount = goal;
        }

        public bool AdvanceToReachedGoal(int advanceAmount)
        {
            CurrentPostion += advanceAmount;
            if(CurrentPostion >= GoalAmount)
            {
                CurrentPostion = 0;
                return true;
            }
            return false;
        }
    }

    public class FightUnitHud
    {
        public int Health = 100;

        public bool IsDead { get { return Health <= 0; } }

        public bool DamageToDead(FightElement fightElement)
        {
            Health -= fightElement.AttackPower;
            return IsDead;
        }
    }

    public class FightElement
    {
        public int AttackPower = 10;
        public int Speed = 10;
    }


    public class BattlePlace
    {
        public const int TotalAmountToReached = 100;
        FightTeam PlayerFightUnits = new FightTeam();
        FightTeam EnemyFightUnits = new FightTeam();

        public void BuildTeam()
        {
            FightUnitHud playerHud = new FightUnitHud();
            FightElement playerFightElement = new FightElement();
            playerFightElement.AttackPower = 15;
            playerFightElement.Speed = 15;
            ReachedGoal playerreachedGoal = new ReachedGoal(TotalAmountToReached);

            FightUnit playerFightUnit = new FightUnit()
            {
                fightElement = playerFightElement,
                fightUnitHud = playerHud,
                reachedGoal = playerreachedGoal
            };

            FightUnitHud emenyHud = new FightUnitHud();
            FightElement emenyFightElement = new FightElement();
            emenyFightElement.Speed = 10;
            ReachedGoal emenyReachedGoal = new ReachedGoal(TotalAmountToReached);
            FightUnit emenyFightUnit = new FightUnit()
            {
                fightElement = emenyFightElement,
                fightUnitHud = emenyHud,
                reachedGoal = emenyReachedGoal
            };

            playerFightUnit.TargetFightUnits.Add(emenyFightUnit);
            emenyFightUnit.TargetFightUnits.Add(playerFightUnit);

            PlayerFightUnits.fightUnit = playerFightUnit;
            EnemyFightUnits.fightUnit = emenyFightUnit;

        }

        public void Fight()
        {
            int FightRound = 0;
            while (!PlayerFightUnits.fightUnit.IsDead && !EnemyFightUnits.fightUnit.IsDead)
            {
                bool reachedRound = PlayerFightUnits.fightUnit.TimeToDoAction() || EnemyFightUnits.fightUnit.TimeToDoAction();
                if (reachedRound)
                {
                    FightRound++;
                }
            }
            FinishFight();
        }

        public void FinishFight()
        {

        }
    }

    public class FightTeam
    {
        public FightUnit fightUnit { get; set; }
    }
}

