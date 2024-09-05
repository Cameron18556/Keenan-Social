using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Section : MonoBehaviour
{
    public int flatRate;
    public string sectionName;

    public int origanalPrice;

    public int currentPrice;

    public float stockPercentage;

    public int perTurnPriceIncrease;

    public Player owner;

    public UnityAction operation;
    // Start is called before the first frame update
    public virtual void Start()
    {
        operation += Operate;
    }

    public virtual void Operate()
    {
        GameManager.Instance.playerTurns[GameManager.Instance.currentPlayerId].GetComponent<Player>().AddMoney(flatRate);
        owner.TurnOver();
    }

    public virtual void GetBought()
    {
        if(GameManager.Instance.activePlayer.ownedSections.Contains(this))
        {
            GameManager.Instance.ShowMessage("you own this place dumbass");
            return;
        }

        if (GameManager.Instance.activePlayer.currentCash >= currentPrice)
        {
            GameManager.Instance.activePlayer.currentCash -= currentPrice;
            GameManager.Instance.activePlayer.ownedSections.Add(this);
            owner = GameManager.Instance.activePlayer;

            currentPrice = origanalPrice;

            GameManager.Instance.activePlayer.TurnOver();
        }
        else
        {
            string input = "you cannot buy this section it costs " + currentPrice + "and you only have" + GameManager.Instance.activePlayer.currentCash;
            GameManager.Instance.ShowMessage(input);
        }
    }
}
