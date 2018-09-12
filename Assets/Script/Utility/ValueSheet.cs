using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueSheet : MonoBehaviour {
    public static float NodeDistance = 30f;
    public static Dictionary<int, GameObject> ID_Node_keyValuePairs = new Dictionary<int, GameObject>();
    public static Dictionary<int, List<Sprite>> DescriptionkeyValuePairs = new Dictionary<int, List<Sprite>>();

    public static List<NodeCtr> nodeCtrs = new List<NodeCtr>();

    public static bool IsInMainMenu = true;


}
