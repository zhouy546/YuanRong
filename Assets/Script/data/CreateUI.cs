using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUI : MonoBehaviour {
    public GameObject NodeL;
    public GameObject NodeR;

   public static List<GameObject> NodeObject = new List<GameObject>();
    public void initialization() {
      
        for (int i = 0; i < ReadJson.NodeList.Count; i++)
        {
            if (i % 2 == 0)
            {
                Vector3 pos = new Vector3(-30,16.3f, i * ValueSheet.NodeDistance);
                GameObject g = Instantiate(NodeL, pos,Quaternion.identity);
                g.name = i.ToString();
                ValueSheet.nodeCtrs.Add(g.GetComponent<NodeCtr>());
                NodeObject.Add(g);
                if (i == 10)
                {
                 
                    g.GetComponent<NodeCtr>().uIStyle = NodeCtr.UIStyle.Style01;
                }
            }
            else {
                
                Vector3 pos = new Vector3(30, 16.3f, i * ValueSheet.NodeDistance);
                GameObject g = Instantiate(NodeR, pos, Quaternion.identity);
                ValueSheet.nodeCtrs.Add(g.GetComponent<NodeCtr>());
                g.name = i.ToString();
                NodeObject.Add(g);


            }
            ValueSheet.ID_Node_keyValuePairs.Add(ReadJson.NodeList[i].ID, NodeObject[i]);
        }

        //foreach (var item in ValueSheet.ID_Node_keyValuePairs)
        //{
        //    Debug.Log("key: "+item.Key.ToString() + "value: " + item.Value.name.ToString());
        //}
    }
}
