using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {
    public static CameraMover instance;
    
    bool max, min=true;

    private int currentID = 0;
    public int CurrentID {
        get { return currentID; }
        set {
            if (value > ReadJson.NodeList.Count)
            {
                max = true;
                return;
            }
            else if(value <0) {
                min = true;
                return;
            }

            currentID = value;
            max = false;
            min = false;
        }
    }

    public Vector3 tragetRotation;
    public Vector3 tragetPos;
    private Vector3 perviousPos;
    private float easeingValue = 0.05f;
    private float RoteaseingValue = 0.005f;
    public void initialization() {
        if (instance == null) {
            instance = this;
        }

    }

    // Update is called once per frame
    void Update () {
        if (ValueSheet.IsInMainMenu)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))//前进
            {
                CurrentID++;
                if (!max) {
                    tragetPos = new Vector3(tragetPos.x, tragetPos.y, -30 + currentID * ValueSheet.NodeDistance);
                    BottomBarCtr.instance.ChangeDot(CurrentID);
                }
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))//后退
            {
                CurrentID--;

                if (!min) {
                    tragetPos = new Vector3(tragetPos.x, tragetPos.y, -30 + currentID * ValueSheet.NodeDistance);
                    BottomBarCtr.instance.ChangeDot(CurrentID);
                }
            }

            else if (Input.GetKeyDown(KeyCode.A))//显示单个
            {
                perviousPos = transform.position;
                Debug.Log("set false");
               

                HideMainPicture();

                Debug.Log("traget pos");
                tragetPos = ValueSheet.ID_Node_keyValuePairs[currentID].GetComponent<NodeCtr>().cameraSetTrans.position;

                if (currentID % 2 == 0)//偶数向左奇数向右
                {

                    tragetRotation = new Vector3(0, -34.1f, 0);
                    RotateCamera(tragetRotation);
                }
                else
                {
                    tragetRotation = new Vector3(0, 34.1f, 0);
                    RotateCamera(tragetRotation);
                }
                ShowDescription();

                ValueSheet.IsInMainMenu = false;
            }
         
        }
        else {


            if (Input.GetKeyDown(KeyCode.S))
            {//退回主界面
                ValueSheet.IsInMainMenu = true;

                tragetPos = perviousPos;

                ShowMainPicture();

                tragetRotation = Vector3.zero;
                RotateCamera(tragetRotation);
                HideDescription();
            }
        }


        if ((tragetPos - transform.position).magnitude < 0.01f) {
            transform.position = tragetPos;
        }


        transform.position = transform.position + (tragetPos - transform.position) * easeingValue;

    }

    void HideMainPicture() {
        foreach (var item in ValueSheet.nodeCtrs)
        {
            item.HideMainPicture();
        }
    }

    void ShowMainPicture() {
        foreach (var item in ValueSheet.nodeCtrs)
        {
            item.ShowMainPicture();
        }
    }

    void RotateCamera(Vector3 angle)
    {
        LeanTween.rotateY(this.gameObject, angle.y, 1f).setEase(LeanTweenType.easeInOutQuad);

    }


    void ShowDescription() {
        ValueSheet.nodeCtrs[CurrentID].ShowDescription();
    }

    void HideDescription()
    {
        ValueSheet.nodeCtrs[CurrentID].HideDescription();
    }
}
