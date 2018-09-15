using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUI : MonoBehaviour {
    public GameObject[] Parents;

    public GameObject NodeL_Default;
    public GameObject NodeR_Default;
    public GameObject NodeL_Style00;
    public GameObject NodeR_Style00;
    public GameObject NodeL_Style01;
    public GameObject NodeR_Style01;

    public static List<GameObject> NodeObject = new List<GameObject>();

    public static List<GameObject> ECO_NodeObject = new List<GameObject>();

    public static List<GameObject> Gongyi_NodeObject = new List<GameObject>();

    public void initialization() {
      
        for (int i = 0; i < ReadJson.NodeList.Count; i++)
        {
            if (i % 2 == 0)
            {
                Vector3 pos = new Vector3(-30,16.3f, i * ValueSheet.NodeDistance);
                
                if (i == 10)
                {
                    CreateObject(NodeL_Style01, i, pos, NodeObject, Parents[0], ValueSheet.nodeCtrs);
                }
                else {
                    CreateObject(NodeL_Default, i, pos, NodeObject, Parents[0], ValueSheet.nodeCtrs);
                }
               
            }
            else {
                
                Vector3 pos = new Vector3(30, 16.3f, i * ValueSheet.NodeDistance);
               //Debug.Log("RIFHT");
                if (i == 9)
                {
                    CreateObject(NodeR_Style00, i, pos, NodeObject, Parents[0], ValueSheet.nodeCtrs);
                    
                }
                else {
                    CreateObject(NodeR_Default, i, pos, NodeObject, Parents[0], ValueSheet.nodeCtrs);
                } 
            }
            ValueSheet.ID_Node_keyValuePairs.Add(ReadJson.NodeList[i].ID, NodeObject[i]);
        }


        CreateDefault(ReadJson.ECO_NodeList.Count, NodeL_Default, NodeR_Default, ValueSheet.ID_ECO_Node_keyValuePairs, ECO_NodeObject, Parents[1], ValueSheet.ECO_nodeCtrs);

        CreateDefault(ReadJson.Gongyi_NodeList.Count, NodeL_Default, NodeR_Default, ValueSheet.ID_Gongyi_Node_keyValuePairs, Gongyi_NodeObject,Parents[2], ValueSheet.Gongyi_nodeCtrs);

    }


    void CreateDefault(int count, GameObject Prefabs_L, GameObject Prefabs_R, Dictionary<int, GameObject> keyValuePairs,List<GameObject> nodeObj,GameObject parent, List<NodeCtr> nodeCtr)
    {
        for (int j = 0; j < count; j++)
        {
            if (j % 2 == 0)
            {
                Vector3 pos = new Vector3(-30, 16.3f, j * ValueSheet.NodeDistance);
                CreateObject(Prefabs_L, j, pos, nodeObj, parent, nodeCtr);
            }
            else
            {
                Vector3 pos = new Vector3(30, 16.3f, j * ValueSheet.NodeDistance);
                CreateObject(Prefabs_R, j, pos, nodeObj, parent, nodeCtr);
            }
            keyValuePairs.Add(ReadJson.ECO_NodeList[j].ID, nodeObj[j]);
        }
    }

    private void CreateObject(GameObject g,int i , Vector3 pos,List<GameObject> nodeobj,GameObject parent,List<NodeCtr> nodeCtr) {

         g = Instantiate(g, pos, Quaternion.identity);

        g.name = i.ToString();

        nodeCtr.Add(g.GetComponent<NodeCtr>());

        g.GetComponent<NodeCtr>().FloatingAniamtion();

        g.transform.SetParent(parent.transform);

        nodeobj.Add(g);

    }
}
