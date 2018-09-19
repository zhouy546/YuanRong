using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMangager : MonoBehaviour {
    public GameObject Building;
    public NImage BlackScreen;
    public static CanvasMangager instance;
    public List<GameObject> Obj = new List<GameObject>();

    public List<GameObject> Title = new List<GameObject>();
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

    public void ONOFF(bool ONOFF,int titleNum) {
        Debug.Log(ONOFF);
        foreach (var item in Obj)
        {
            item.SetActive(ONOFF);
        }

        for (int i = 0; i < Title.Count; i++)
        {
            if (i == titleNum)
            {
                Title[i].SetActive(true);
            }
            else {
                Title[i].SetActive(false);
            }
        }

        Building.SetActive(ONOFF);
    }

    public IEnumerator Fade() {
        BlackScreen.ShowAll(0f);
        yield return new WaitForSeconds(1f);
        BlackScreen.HideAll(.7f);
    }
}
