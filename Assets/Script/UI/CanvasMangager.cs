using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMangager : MonoBehaviour {
    public GameObject Building;
    public NImage BlackScreen;
    public static CanvasMangager instance;
    public List<GameObject> Obj = new List<GameObject>();
        // Use this for initialization
    public void initialization() {
        if (instance == null) {
            instance = this;
        }
        BlackScreen.initialization();


    }

    // Update is called once per frame
    void Update () {
		
	}

    public void ONOFF(bool ONOFF) {
        foreach (var item in Obj)
        {
            item.SetActive(ONOFF);
        }
        Building.SetActive(ONOFF);
    }

    public IEnumerator Fade() {
        BlackScreen.ShowAll(0f);
        yield return new WaitForSeconds(.3f);
        BlackScreen.HideAll(1);
    }
}
