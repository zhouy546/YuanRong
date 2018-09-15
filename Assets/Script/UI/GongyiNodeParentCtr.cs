using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GongyiNodeParentCtr : CTR
{
    public static GongyiNodeParentCtr instance;



    public override void initialization() {
        base.initialization();
        if (instance == null)
        {
            instance = this;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
