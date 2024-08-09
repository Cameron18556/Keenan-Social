using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ElDiablo : Role
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void AddToGameObject(GameObject obj)
    {
        var copy = obj.AddComponent<ElDiablo>();
        Player player = obj.GetComponent<Player>();
        player.role = this;
        player.currentCash = startCash;
        //set all role specific feilds here
        GameManager.Instance.roles.Remove(this);
    }

    public override int OnEarn(int currentRate)
    {
        return currentRate;
    }
}
