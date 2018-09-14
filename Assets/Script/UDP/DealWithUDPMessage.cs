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

public class DealWithUDPMessage : MonoBehaviour {
    public GameObject wellMesh;
    private string dataTest;
   // public static char[] sliceStr;
    private Vector3 CamRotation;
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

            if (dataTest == "10000")
            {
               
                SoundMangager.instance.Select();
                Debug.Log("返回");
                VideoCtr.instance.stopVideo();
               VideoCtr.instance.PlayFullScreenVideoPlayer(ValueSheet.screenProtect);
                VideoCtr.instance.SentOnce = false;
                wellMesh.SetActive(false);
                CameraMover.instance.SetCameraTransDefault();
                CameraMover.instance.HideAllDescription();
                //CameraMover.instance.HideMainPicture();

                CanvasMangager.instance.ONOFF(false);
               StartCoroutine( CanvasMangager.instance.Fade());
            }
            else if (dataTest == "10001")
            {

               // Debug.Log("开发管理项目");
                StartCoroutine(CameraMover.instance.initialization());
                VideoCtr.instance.StopFullScreenVideoPlayer();
                CanvasMangager.instance.ONOFF(true);
                StartCoroutine(CanvasMangager.instance.Fade());
            }
            else if (dataTest == "10013") {

            }
            else if (dataTest == "10014")
            {

            }
            else if (dataTest == "10015")
            {
                SoundMangager.instance.Select();
                CameraMover.instance.GoingInTheWell();
                wellMesh.SetActive(true);
                CanvasMangager.instance.ONOFF(false);
                StartCoroutine(CanvasMangager.instance.Fade());
                VideoCtr.instance.StopFullScreenVideoPlayer();
            }
            else if (dataTest == "10016")
            {
                SoundMangager.instance.Select();
                CameraMover.instance.LookWellLeft();

            }
            else if (dataTest == "10017")
            {
                SoundMangager.instance.Select();
                CameraMover.instance.LookWellMid();
            }
            else if (dataTest == "10018")
            {
                SoundMangager.instance.Select();
                CameraMover.instance.LookWellRight();
            }
            else if (dataTest == "10019")
            {
                SoundMangager.instance.Select();
                VideoCtr.instance.PlayFullScreenVideoPlayer(ValueSheet.CultureAndECON, true);
                CanvasMangager.instance.ONOFF(false);
                StartCoroutine(CanvasMangager.instance.Fade());
            }
            else if (dataTest == "10020")
            {
                SoundMangager.instance.Select();
                VideoCtr.instance.PlayFullScreenVideoPlayer(ValueSheet.ProjcetHighLight, false);
                CanvasMangager.instance.ONOFF(false);
                StartCoroutine(CanvasMangager.instance.Fade());
            }
            else if (dataTest == "10021")
            {
                Debug.Log("running");
                SoundMangager.instance.Select();
                VideoCtr.instance.PlayFullScreenVideoPlayer(ValueSheet.Gongyi, true);
                CanvasMangager.instance.ONOFF(false);
                StartCoroutine(CanvasMangager.instance.Fade());
            }
            else if (dataTest == "10022")
            {
                SoundMangager.instance.Select();
                VideoCtr.instance.PlayFullScreenVideoPlayer(ValueSheet.Co, true);
                CanvasMangager.instance.ONOFF(false);
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


    private void Update()
    {


        //Debug.Log("数据：" + dataTest);  
    }

}
