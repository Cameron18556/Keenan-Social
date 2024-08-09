using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Role : MonoBehaviour
{
    public string description = "this is the defualt role description";

    public int standerdIncome;

    public int startCash;

    public bool meetingWinCondition = false;

    public abstract void AddToGameObject(GameObject obj);

    public abstract int OnEarn(int currentRate);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
