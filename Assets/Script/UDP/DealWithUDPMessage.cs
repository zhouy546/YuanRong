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
                SoundMangager.instance.currentBGM = "";
                SoundMangager.instance.StopBGM();
            }
            else if (dataTest == "10001")//开发管理项目
            {

                // Debug.Log(ValueSheet.nodeCtrs.Count);
                GoToOcean(ValueSheet.nodeCtrs, MainCtr.instance.defaultNodeParentCtr, 0, CanvasMangager.instance.MainTitle);

            }

            else if (dataTest == "10017")//荣誉墙
            {
                MainCtr.instance.TurnOffAll();

                SoundMangager.instance.Select();

                SoundMangager.instance.StopBGM();
                SoundMangager.instance.PlayBGM("BGM");
                CameraMover.instance.GoingInTheWell();
                wellMesh.SetActive(true);
                CanvasMangager.instance.TurnOffAllTitle();
                StartCoroutine(CanvasMangager.instance.Fade());
                VideoCtr.instance.StopFullScreenVideoPlayer();
            }
            else if (dataTest == "10018")//荣誉墙 左
            {
                SoundMangager.instance.Select();
                CameraMover.instance.LookWellLeft();

            }
            else if (dataTest == "10019")//荣誉墙 中
            {
                SoundMangager.instance.Select();
                CameraMover.instance.LookWellMid();
            }
            else if (dataTest == "10020")//荣誉墙 右
            {
                SoundMangager.instance.Select();
                CameraMover.instance.LookWellRight();
            }
            else if (dataTest == "10021")//商业文化
            {
                GoToOcean(ValueSheet.ECO_nodeCtrs, MainCtr.instance.eCONodeParentCtr, 1, CanvasMangager.instance.SubNodeTitle_Eco);
                foreach (var item in ValueSheet.ECO_nodeCtrs)
                {
                    //item.imageClusterCtr.Display(0,CanvasMangager.instance.SubNodeTitle_Eco);
                    item.imageClusterCtr.GoToTarget(0, CanvasMangager.instance.SubNodeTitle_Eco);
                }

            }
            else if (dataTest == "10022")
            {//金鸡湖双年展
                foreach (var item in ValueSheet.ECO_nodeCtrs)
                {
                    //item.imageClusterCtr.Display(0,CanvasMangager.instance.SubNodeTitle_Eco);
                    item.imageClusterCtr.GoToTarget(0, CanvasMangager.instance.SubNodeTitle_Eco);
                }

            }
            else if (dataTest == "10023")
            {//圆融艺术中心
                foreach (var item in ValueSheet.ECO_nodeCtrs)
                {
                    ///item.imageClusterCtr.Display(1, CanvasMangager.instance.SubNodeTitle_Eco);
                    item.imageClusterCtr.GoToTarget(1, CanvasMangager.instance.SubNodeTitle_Eco);
                }
            }



            else if (dataTest == "10024")//社会责任
            {
                GoToOcean(ValueSheet.Gongyi_nodeCtrs, MainCtr.instance.gongyiNodeParentCtr, 0, CanvasMangager.instance.SubNodeTitle_GongYi);
                foreach (var item in ValueSheet.Gongyi_nodeCtrs)
                {
                    item.imageClusterCtr.GoToTarget(0, CanvasMangager.instance.SubNodeTitle_GongYi);
                }


            }
            else if (dataTest == "10025")
            {//社会公益
                foreach (var item in ValueSheet.Gongyi_nodeCtrs)
                {
                    item.imageClusterCtr.GoToTarget(0, CanvasMangager.instance.SubNodeTitle_GongYi);
                }

            }
            else if (dataTest == "10026")
            {//文化体育
                foreach (var item in ValueSheet.Gongyi_nodeCtrs)
                {
                    item.imageClusterCtr.GoToTarget(1, CanvasMangager.instance.SubNodeTitle_GongYi);
                }
            }
            else if (dataTest == "10027")
            {//希望关怀
                foreach (var item in ValueSheet.Gongyi_nodeCtrs)
                {
                    item.imageClusterCtr.GoToTarget(2, CanvasMangager.instance.SubNodeTitle_GongYi);
                }
            }
            else if (dataTest == "10028")
            {//志愿活动
                foreach (var item in ValueSheet.Gongyi_nodeCtrs)
                {
                    item.imageClusterCtr.GoToTarget(3, CanvasMangager.instance.SubNodeTitle_GongYi);
                }
            }

            else if (dataTest == "10029")//形象短片
            {
                LoadMainVideo();
            }

            else if (dataTest == "10030")//合作伙伴
            {
                SoundMangager.instance.Select();
                logoWellCtr.SetTargetPostition();
                logoWellCtr.TurnOnLogoWell();
                VideoCtr.instance.StopFullScreenVideoPlayer();
                CanvasMangager.instance.TurnOffAllTitle();
                StartCoroutine(CanvasMangager.instance.Fade());

                SoundMangager.instance.StopBGM();
                SoundMangager.instance.PlayBGM("BGM");
            }
            else if (dataTest == "10031")
            {//音乐开
                SoundMangager.instance.SetMainVideoVolume(false);
                SoundMangager.instance.PlayBGM(SoundMangager.instance.currentBGM);



            }
            else if (dataTest == "10032")
            {//音乐关
                SoundMangager.instance.SetMainVideoVolume(true);

                SoundMangager.instance.StopBGM();
            }



            if (int.Parse(dataTest) >= 10002 && int.Parse(dataTest) <= 10016) {
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
                else if (dataTest == "10013")
                {
                    CameraMover.instance.CurrentID = 11;
                }
                else if (dataTest == "10014")
                {
                    CameraMover.instance.CurrentID = 12;
                }
                else if (dataTest == "10015")
                {
                    CameraMover.instance.CurrentID = 13;
                }
                else if (dataTest == "10016")
                {
                    CameraMover.instance.CurrentID = 14;
                }
            }
             

        }
       
    }




    public void GoToOcean(List<SubNodeCTR> _nodeCtrs, CTR _ctr, int titleNum, List<GameObject> TitleList)
    {
        // ValueSheet.CurrentNodeCtr = _nodeCtrs;
        ToOceanGeneral(new Vector3(0, 15.3f, 300f), new Vector3(0, 33.3f, -68.1f), true,  titleNum,false, _ctr, TitleList);

        _nodeCtrs[0].imageClusterCtr.Display(0, TitleList);
       // MainCtr.instance.TURN_ON_OFFChild_Sub(_ctr, true, _nodeCtrs);

    }


    public void GoToOcean(List<NodeCtr> _nodeCtrs, DefaultNodeParentCtr _ctr,int titleNum, List<GameObject> TitleList) {
        // ValueSheet.CurrentNodeCtr = _nodeCtrs;
        ToOceanGeneral(new Vector3(0, 15.3f, 300f), new Vector3(0, 15.3f, -30f),true, titleNum,true, _ctr, TitleList);
        // MainCtr.instance.TURN_ON_OFFChild_Default(_ctr, true, _nodeCtrs);
        BottomBarCtr.instance.UpdateBottomBar(CameraMover.instance.CurrentID + 1, ReadJson.NodeList.Count);
    }

    void ToOceanGeneral(Vector3 pos,Vector3 _targetPos,bool isTurnOnSideImage,int Title,bool building,CTR ctr,List<GameObject> TitleList)
    {

        logoWellCtr.TurnOffLogoWell();
        MainCtr.instance.TurnOnOne(ctr);
        SoundMangager.instance.Select();
        VideoCtr.instance.StopFullScreenVideoPlayer();
        StartCoroutine(CameraMover.instance.initialization(pos, _targetPos));
        CanvasMangager.instance.TurnOffAllTitle();
        CanvasMangager.instance.ONOFF(isTurnOnSideImage, Title, building, TitleList);
        StartCoroutine(CanvasMangager.instance.Fade());

        SoundMangager.instance.StopBGM();
        SoundMangager.instance.PlayBGM("BGM");
      

    }

    public void GoingBack() {

        ReplaceFullScreenVideo(ValueSheet.screenProtect);

    }

    public void LoadMainVideo() {
        ReplaceFullScreenVideo(ValueSheet.ProjcetHighLight,false);
        SoundMangager.instance.StopBGM();
    }


    public void ReplaceFullScreenVideo(string videoName,bool isLoop = true) {
        Debug.Log(SoundMangager.instance.isMute);
        if (SoundMangager.instance.isMute)
        {
            SoundMangager.instance.SetMainVideoVolume(true);
        }
        else {
            SoundMangager.instance.SetMainVideoVolume(false);
        }

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

        CanvasMangager.instance.TurnOffAllTitle();
       // CanvasMangager.instance.ONOFF(false,-1,false);
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
