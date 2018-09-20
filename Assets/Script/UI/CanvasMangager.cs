using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMangager : MonoBehaviour {
    public GameObject Building;
    public NImage BlackScreen;
    public static CanvasMangager instance;
    public List<GameObject> Obj = new List<GameObject>();

    public List<GameObject> MainTitle = new List<GameObject>();

    public List<GameObject> SubNodeTitle_Eco = new List<GameObject>();
    public List<GameObject> SubNodeTitle_GongYi = new List<GameObject>();
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

    public void TurnOffAllTitle() {
      ONOFF(false, -1, false, MainTitle);
        ONOFF(false, -1, false, SubNodeTitle_Eco);
        ONOFF(false, -1, false, SubNodeTitle_GongYi);
    }


    public void ONOFF(bool ONOFF,int titleNum,bool building,List<GameObject> TitleList) {
        //Debug.Log(ONOFF);
        foreach (var item in Obj)
        {
            item.SetActive(ONOFF);
        }

        for (int i = 0; i < TitleList.Count; i++)
        {
            if (i == titleNum)
            {
                TitleList[i].SetActive(true);
            }
            else {
                TitleList[i].SetActive(false);
            }
        }

        Building.SetActive(building);
    }

    public IEnumerator Fade() {
        BlackScreen.ShowAll(0f);
        yield return new WaitForSeconds(1f);
        BlackScreen.HideAll(.7f);
    }
}
