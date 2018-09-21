using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using SimpleUI;



public class FightTest {

    [Test]
    public void FightTestSimplePasses()
    {
        int TotalAmountToReached = 100;

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

        int FightRound = 0;

        while (!playerFightUnit.IsDead && !emenyFightUnit.IsDead)
        {
           bool reachedRound =   playerFightUnit.TimeToDoAction() || emenyFightUnit.TimeToDoAction();
            if(reachedRound)
            {
                FightRound++;
            }
        }

        Assert.AreEqual(FightRound, 11);
        Assert.AreEqual(playerFightUnit.IsDead, false);
        Assert.AreEqual(emenyFightUnit.IsDead, true);
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator FightTestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}
