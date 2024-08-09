using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Section : MonoBehaviour
{
    public int flatRate;
    public string sectionName;

    public UnityAction operation;
    // Start is called before the first frame update
    void Start()
    {
        operation += Operate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Operate()
    {
        GameManager.Instance.playerTurns[GameManager.Instance.currentPlayerId].GetComponent<Player>().AddMoney(flatRate);
    }
}
