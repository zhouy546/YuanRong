using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUI : MonoBehaviour {
    public GameObject NodeL_Default;
    public GameObject NodeR_Default;
    public GameObject NodeL_Style00;
    public GameObject NodeR_Style00;
    public GameObject NodeL_Style01;
    public GameObject NodeR_Style01;

    public static List<GameObject> NodeObject = new List<GameObject>();
    public void initialization() {
      
        for (int i = 0; i < ReadJson.NodeList.Count; i++)
        {
            if (i % 2 == 0)
            {
                Vector3 pos = new Vector3(-30,16.3f, i * ValueSheet.NodeDistance);
                
                if (i == 10)
                {
                    CreateObject(NodeL_Style01, i, pos);
                }
                else {
                    CreateObject(NodeL_Default, i, pos);
                }
               
            }
            else {
                
                Vector3 pos = new Vector3(30, 16.3f, i * ValueSheet.NodeDistance);
               //Debug.Log("RIFHT");
                if (i == 9)
                {
                    CreateObject(NodeR_Style00, i, pos);
                    
                }
                else {
                    CreateObject(NodeR_Default, i, pos);
                } 
            }
            ValueSheet.ID_Node_keyValuePairs.Add(ReadJson.NodeList[i].ID, NodeObject[i]);


        }

        //foreach (var item in ValueSheet.ID_Node_keyValuePairs)
        //{
        //    Debug.Log("key: "+item.Key.ToString() + "value: " + item.Value.name.ToString());
        //}
    }

    private void CreateObject(GameObject g,int i , Vector3 pos) {

         g = Instantiate(g, pos, Quaternion.identity);

        g.name = i.ToString();

        ValueSheet.nodeCtrs.Add(g.GetComponent<NodeCtr>());

        g.GetComponent<NodeCtr>().FloatingAniamtion();

        NodeObject.Add(g);

    }
}
