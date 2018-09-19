//*********************❤*********************
// 
// 文件名（File Name）：	DealWithUDPMessage.cs
// 
// 作者（Author）：			LoveNeon
// 
// 创建时间（CreateTime）：	Don't Care
// 
// 说明（Description）：	接受到消息之后会传给我，然后我进行处理
// 
//*********************❤*********************

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Linq;

public class DealWithUDPMessage : MonoBehaviour {
    public static DealWithUDPMessage instance;

    public GameObject wellMesh;
    private string dataTest;
   // public static char[] sliceStr;
    private Vector3 CamRotation;

    public LogoWellCtr logoWellCtr;
    //private bool enterTrigger, exitTrigger;
    /// <summary>
    /// 消息处理
    /// </summary>
    /// <param name="_data"></param>
    public void MessageManage(string _data)
    {
        if (_data != "")
        {
            dataTest = _data;

            Debug.Log(dataTest);

            if (dataTest == "10000")//返回
            {
                GoingBack();
                SoundMangager.instance.StopBGM();
            }
            else if (dataTest == "10001")//开发管理项目
            {

               // Debug.Log(ValueSheet.nodeCtrs.Count);
                GoToOcean(ValueSheet.nodeCtrs, MainCtr.instance.defaultNodeParentCtr,0);

            }

            else if (dataTest == "10015")//荣誉墙
            {
                MainCtr.instance.TurnOffAll();

                SoundMangager.instance.Select();
                CameraMover.instance.GoingInTheWell();
                wellMesh.SetActive(true);
                CanvasMangager.instance.ONOFF(false,-1);
                StartCoroutine(CanvasMangager.instance.Fade());
                VideoCtr.instance.StopFullScreenVideoPlayer();
            }
            else if (dataTest == "10016")//荣誉墙 左
            {
                SoundMangager.instance.Select();
                CameraMover.instance.LookWellLeft();

            }
            else if (dataTest == "10017")//荣誉墙 中
            {
                SoundMangager.instance.Select();
                CameraMover.instance.LookWellMid();
            }
            else if (dataTest == "10018")//荣誉墙 右
            {
                SoundMangager.instance.Select();
                CameraMover.instance.LookWellRight();
            }
            else if (dataTest == "10019")//商业文化
            {
                GoToOcean(ValueSheet.ECO_nodeCtrs, MainCtr.instance.eCONodeParentCtr,1);

            }
            else if (dataTest == "10013")
            {//商业文化左移动
                foreach (var item in ValueSheet.ECO_nodeCtrs)
                {
                    item.imageClusterCtr.MoveLeft();
                }

            }
            else if (dataTest == "10014")
            {//商业文化右移动
                foreach (var item in ValueSheet.ECO_nodeCtrs)
                {
                    item.imageClusterCtr.MoveRight();
                }
            }


            else if (dataTest == "10020")//项目高光
            {
                LoadMainVideo();
            }
            else if (dataTest == "10021")//公益
            {
                GoToOcean(ValueSheet.Gongyi_nodeCtrs, MainCtr.instance.gongyiNodeParentCtr,2);

            }
            else if (dataTest == "10023")
            {//公益左移动
                foreach (var item in ValueSheet.Gongyi_nodeCtrs)
                {
                    item.imageClusterCtr.MoveLeft();
                }

            }
            else if (dataTest == "10024")
            {//公益右移动
                foreach (var item in ValueSheet.Gongyi_nodeCtrs)
                {
                    item.imageClusterCtr.MoveRight();
                }
            }

            else if (dataTest == "10022")
            {
                SoundMangager.instance.Select();
                logoWellCtr.TurnOnLogoWell();
                VideoCtr.instance.StopFullScreenVideoPlayer();
                CanvasMangager.instance.ONOFF(false,-1);
                StartCoroutine(CanvasMangager.instance.Fade());
            }



            if (int.Parse(dataTest) >= 10002 && int.Parse(dataTest) <= 10012) {


                Debug.Log("移动");
                if (dataTest == "10002")
                {
                    CameraMover.instance.CurrentID = 0;
                }
                else if (dataTest == "10003")
                {
                    CameraMover.instance.CurrentID = 1;
                }
                else if (dataTest == "10004")
                {
                    CameraMover.instance.CurrentID = 2;
                }
                else if (dataTest == "10005")
                {
                    CameraMover.instance.CurrentID = 3;
                }
                else if (dataTest == "10006")
                {
                    CameraMover.instance.CurrentID = 4;
                }
                else if (dataTest == "10007")
                {
                    CameraMover.instance.CurrentID = 5;
                }
                else if (dataTest == "10008")
                {
                    CameraMover.instance.CurrentID = 6;
                }
                else if (dataTest == "10009")
                {
                    CameraMover.instance.CurrentID = 7;
                }
                else if (dataTest == "10010")
                {
                    CameraMover.instance.CurrentID = 8;
                }
                else if (dataTest == "10011")
                {
                    CameraMover.instance.CurrentID = 9;
                }
                else if (dataTest == "10012")
                {
                    CameraMover.instance.CurrentID = 10;
                }
            }
             

        }
       
    }




    public void GoToOcean(List<SubNodeCTR> _nodeCtrs, CTR _ctr, int titleNum)
    {
        // ValueSheet.CurrentNodeCtr = _nodeCtrs;
        ToOceanGeneral(new Vector3(0, 15.3f, 300f), new Vector3(0, 33.3f, -68.1f), true,  titleNum, _ctr);

        _nodeCtrs[0].imageClusterCtr.MoveRight();
       // MainCtr.instance.TURN_ON_OFFChild_Sub(_ctr, true, _nodeCtrs);

    }


    public void GoToOcean(List<NodeCtr> _nodeCtrs, DefaultNodeParentCtr _ctr,int titleNum) {
        // ValueSheet.CurrentNodeCtr = _nodeCtrs;
        ToOceanGeneral(new Vector3(0, 15.3f, 300f), new Vector3(0, 15.3f, -30f),true, titleNum, _ctr);
        // MainCtr.instance.TURN_ON_OFFChild_Default(_ctr, true, _nodeCtrs);
        BottomBarCtr.instance.UpdateBottomBar(CameraMover.instance.CurrentID + 1, ReadJson.NodeList.Count);
    }

    void ToOceanGeneral(Vector3 pos,Vector3 _targetPos,bool isTurnOnSideImage,int Title,CTR ctr)
    {

        logoWellCtr.TurnOffLogoWell();
        MainCtr.instance.TurnOnOne(ctr);
        SoundMangager.instance.Select();
        VideoCtr.instance.StopFullScreenVideoPlayer();
        StartCoroutine(CameraMover.instance.initialization(pos, _targetPos));

        CanvasMangager.instance.ONOFF(isTurnOnSideImage, Title);
        StartCoroutine(CanvasMangager.instance.Fade());

        SoundMangager.instance.StopBGM();
        SoundMangager.instance.PlayBGM();
      

    }

    public void GoingBack() {

        ReplaceFullScreenVideo(ValueSheet.screenProtect);

    }

    public void LoadMainVideo() {
        ReplaceFullScreenVideo(ValueSheet.ProjcetHighLight,false);
        SoundMangager.instance.StopBGM();
    }


    public void ReplaceFullScreenVideo(string videoName,bool isLoop = true) {
        MainCtr.instance.TurnOffAll();
        wellMesh.SetActive(false);
        logoWellCtr.TurnOffLogoWell();
        SoundMangager.instance.Select();
        VideoCtr.instance.stopVideo();
        VideoCtr.instance.PlayFullScreenVideoPlayer(videoName,isLoop);
        VideoCtr.instance.SentOnce = false;


        CameraMover.instance.SetCameraTransDefault(new Vector3(0, 15.3f, 300f));
        CameraMover.instance.HideAllDescription();
        //CameraMover.instance.HideMainPicture();

        CanvasMangager.instance.ONOFF(false,-1);
        StartCoroutine(CanvasMangager.instance.Fade());
    }

    public void Start()
    {
        if (instance == null) {
            instance = this;
        }
    }


    private void Update()
    {


        //Debug.Log("数据：" + dataTest);  
    }

}
