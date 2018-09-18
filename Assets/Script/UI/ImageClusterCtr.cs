using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageClusterCtr : MonoBehaviour {
    public List<Image> images = new List<Image>();
    public List<NImage> Nimages = new List<NImage>();
    [System.Serializable]
    public struct LeftTrans {
        public Vector3 TargetRotation;
        public float Target_Z_Position;
    }

    [System.Serializable]
    public struct MidTrans
    {
        public Vector3 TargetRotation;
        public float Target_Z_Position;
    }

    [System.Serializable]
    public struct RightTrans
    {
        public Vector3 TargetRotation;
        public float Target_Z_Position;
    }

    public LeftTrans leftTrans;
    public RightTrans rightTrans;
    public MidTrans midTrans;

    public int NumOfSection = 4;

    private int num =0;
    public int Num {
        get { return num; }
        set
        {
            if (value < 0 || value > images.Count- NumOfSection)
            {
                return;
            }

            num = value;
        }
    }

    public int MoveStep = 53;//cell size + spacing
    // Use this for initialization
    void Start () {
        foreach (var item in images)
        {
            item.GetComponent<NImage>().initialization();
            Nimages.Add(item.GetComponent<NImage>());
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A)) {
            MoveLeft();
        } else if (Input.GetKeyDown(KeyCode.D)) {
            MoveRight();
        }
	}

   public void MoveRight() {
        // Debug.Log("MoveRight");
        for (int i = 0; i < NumOfSection; i++)
        {
            Num--;
            Move(MovePos(Num), .5f);
            RotateNode(Num);
            MoveNodeZ(Num);

        }
    }

    public void MoveLeft() {
        for (int i = 0; i < NumOfSection; i++)
        {
            //Debug.Log("MoveLeft");
            Num++;
            Move(MovePos(Num), .5f);
            RotateNode(Num);
            MoveNodeZ(Num);
        }
    }

    private void Move(Vector3 pos, float time)
    {

        LeanTween.moveLocal(this.gameObject, pos, time);


    }

    private void RotateNode(int num) {
        
        LeanTween.rotateLocal(images[num].gameObject, leftTrans.TargetRotation, .2f);
      
        LeanTween.rotateLocal(images[num+1].gameObject, midTrans.TargetRotation, .2f);
        
        LeanTween.rotateLocal(images[num+2].gameObject, rightTrans.TargetRotation, .2f);
        
        LeanTween.rotateLocal(images[num + 3].gameObject, midTrans.TargetRotation, .2f);

    }

    private void MoveNodeZ(int num)
    {
        LeanTween.moveLocalZ(images[num].gameObject, leftTrans.Target_Z_Position, .2f);
        LeanTween.moveLocalZ(images[num+1].gameObject, midTrans.Target_Z_Position, .2f);
        LeanTween.moveLocalZ(images[num+2].gameObject, rightTrans.Target_Z_Position, .2f);
        LeanTween.moveLocalZ(images[num+3].gameObject, midTrans.Target_Z_Position, .2f);
    }

    Vector3 MovePos(int num) {
        return new Vector3( -117- num * MoveStep , transform.localPosition.y, transform.localPosition.z);
    }
}
