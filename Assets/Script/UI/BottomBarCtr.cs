using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBarCtr : MonoBehaviour {
    public static BottomBarCtr instance;
    public Color HighlightColor;
    public GameObject dot;
    public List<NImage> dots = new List<NImage>();

    public NImage perviousDot;
    public NImage CurrentDot;

    public void initialization() {
        for (int i = 0; i < ReadJson.NodeList.Count; i++)
        {
            GameObject g = Instantiate(dot);
            g.transform.SetParent(this.transform);
            dots.Add(g.GetComponent<NImage>());

        }
        foreach (var item in dots)
        {
            item.initialization();
        }

        CurrentDot = dots[CameraMover.instance.CurrentID];
        CurrentDot.ChangeColor(HighlightColor, .5f);

        if (instance == null) {
            instance = this;
        }
    }

    public void ChangeDot(int num) {
        perviousDot = CurrentDot;
        if (perviousDot != null) {
            perviousDot.ChangeColor(Color.white, .5f);
        }
   

        CurrentDot = dots[num];
        CurrentDot.ChangeColor(HighlightColor, .5f);
    }

}
