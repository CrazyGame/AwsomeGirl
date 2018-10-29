using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightPrototoUI : MonoBehaviour
{
    public ActorIconManger actorIconManger { get; set; }
    public ActorCommandManger actorCommandManger { get; set; }
    public ActorFightManger actorFightManger { get; set; }

    public RectTransform playerIconTrans;
    public RectTransform enemyIconTrans;


    public Button fightButton;
    public Button defenseButton;

    public Image playerImage;
    public Image enemyImgage;

    private void Start()
    {
        buildActors();
    }

    void buildActors()
    {
        actorIconManger = new ActorIconManger();
        actorIconManger.playerRole = new ActorIconRole(actorIconManger, playerIconTrans) { MoveForwardSpeed = 150 };
        actorIconManger.enemyRole = new ActorIconRole(actorIconManger, enemyIconTrans) { MoveForwardSpeed = 250 };
        
        actorCommandManger = new ActorCommandManger(fightButton, defenseButton);
        actorFightManger = new ActorFightManger() {
            playerRole = playerImage,
            enemyRole = enemyImgage
        };

        actorCommandManger.fightPrototoUI = this;
        actorIconManger.Next = actorCommandManger;
        actorCommandManger.Next = actorFightManger;
        actorFightManger.Next = actorIconManger;
        actorIconManger.IsValid(true);
        actorIconManger.DoAction();
    }


    public void ResetIconPostion()
    {
        actorIconManger.enemyRole.ResetPostion();
        actorIconManger.playerRole.ResetPostion();

    }

}




public class PlayerActor : IActor
{
    IActor Actor;
    public PlayerActor(IActor actor)
    {
        Actor = actor;
    }

    public void DoAction()
    {
       
    }
}

public class EnemyActor : IActor
{
    IActor Actor;
    public EnemyActor(IActor actor)
    {
        Actor = actor;
    }

    public void DoAction()
    {
    }
}


public class RoleActor : IActor
{
    IActorManger Manger;
    RectTransform roleTrans;
    public RoleActor(IActorManger actorManger,RectTransform targetReference)
    {
        Manger = actorManger;
        roleTrans = targetReference;
    }

    public void DoAction()
    {
        
    }
}


public class ValiedClass
{
   public bool IsValied { get; set; }
}



public class ActorIconRole:IActor
{
    IActorManger Manger;
    RectTransform roleTrans;
    Vector2 InitPostion = Vector2.zero;

    public void ToggleActive(bool state)
    {
        //roleTrans.gameObject.SetActive(state);
    }

    public float MoveForwardSpeed = 200;
    public float RoundMax = 700;
    public float CurrentPostion { get; set; }

    public bool IsOnRoundMaxPositon()
    {
        return roleTrans.anchoredPosition.x >= RoundMax;
    }

    public ActorIconRole(IActorManger actorManger, RectTransform targetReference)
    {
        Manger = actorManger;
        roleTrans = targetReference;
        InitPostion = targetReference.anchoredPosition;
    }

    public void ResetPostion()
    {
        CurrentPostion = 0;
        UpdatePositon();
    }


    void UpdatePositon()
    {
        Vector2 tempPosition = roleTrans.anchoredPosition;
        tempPosition.x = CurrentPostion;

        roleTrans.anchoredPosition = tempPosition;
    }

    public void DoAction()
    {
        CurrentPostion += MoveForwardSpeed;
        if (CurrentPostion > RoundMax)
        {
            CurrentPostion = CurrentPostion - RoundMax + InitPostion.x;
        }
        UpdatePositon();
        Manger.IsValid(false);
        Manger.Next.IsValid(true);
    }
}

public class ActorIconManger : IActorManger
{
   public ActorIconRole playerRole { get; set; }
   public ActorIconRole enemyRole { get; set; }
   ValiedClass valiedClass = new ValiedClass() { IsValied = false};

    public void IsValid(bool isValied)
    {
        valiedClass.IsValied = isValied;
        List<ActorIconRole> actorIconRoles = new List<ActorIconRole>();
        actorIconRoles.Add(playerRole);
        actorIconRoles.Add(enemyRole);
        for (int i = 0; i < actorIconRoles.Count; i++)
        {
            actorIconRoles[i].ToggleActive(isValied);
        }
    }

    public IActorManger Next
    {
        get;set;
    }


    public void DoAction()
    {

        if (!valiedClass.IsValied) return;
        List<ActorIconRole> actorIconRoles = new List<ActorIconRole>();
        actorIconRoles.Add(playerRole);
        actorIconRoles.Add(enemyRole);
        for (int i = 0; i < actorIconRoles.Count; i++)
        {
            actorIconRoles[i].DoAction();
        }

        valiedClass.IsValied = false;
        Next.IsValid(true);
    }
}


public class ActorFightManger : IActorManger
{
    public Image playerRole { get; set; }
    public Image enemyRole { get; set; }

    public FightPrototoUI fightPrototoUI { get; set; }

    ValiedClass valiedClass = new ValiedClass() { IsValied = false };

    public void AttackPlayer()
    {
        playerRole.fillAmount -= 0.2f;
    }

    public void AttackEnemy()
    {
        enemyRole.fillAmount -= 0.2f;
    }

    public IActorManger Next
    {
        get;set;
    }

    public void IsValid(bool isValied)
    {
        valiedClass.IsValied = isValied;
    }

    public void DoAction()
    {

        if (valiedClass.IsValied)
        {
            AttackPlayer();
            valiedClass.IsValied = false;
            Next.IsValid(true);
            Next.DoAction();
        }
    }
}


public class ActorCommandManger : IActorManger
{
    public FightPrototoUI fightPrototoUI { get; set;}

    ValiedClass valiedClass = new ValiedClass() { IsValied = false };

    public ActorCommandManger(Button fightButton,Button defense)
    {
        fightButton.onClick.AddListener(FightAction);
        defense.onClick.AddListener(DefenseAction);
    }

    void FightAction()
    {
        if (!valiedClass.IsValied) return;

        fightPrototoUI.actorFightManger.AttackEnemy();
        DoAction();
    }

    void DefenseAction()
    {
        if (!valiedClass.IsValied) return;
        DoAction();
    }


    public IActorManger Next
    {
        get;set;
    }

    public void IsValid(bool isValied)
    {
        valiedClass.IsValied = isValied;
    }

    public void DoAction()
    {
        valiedClass.IsValied = false;
        Next.IsValid(true);
        Next.DoAction();
    }
}


public interface IActor
{
    void DoAction();
}

public interface IActorManger
{
    void DoAction();
    IActorManger Next { get; set; }
    void IsValid(bool isValied);
}
