using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarrelSteinberg : Role
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
        var copy = obj.AddComponent<DarrelSteinberg>();
        Player player = obj.GetComponent<Player>();
        player.role = this;
        player.currentCash = startCash;
        //set all role specific feilds here
        GameManager.Instance.roles.Remove(this);
    }

    public override int OnEarn(int currentRate)
    {
        return currentRate * 2;
    }
}
