using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECONodeParentCtr : CTR
{
    public static ECONodeParentCtr instance;



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
