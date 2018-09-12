using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeCtr : MonoBehaviour {

    public enum UIStyle { defalue,Style01}

    public UIStyle uIStyle;

    public NImage nImageMainImage;

    public NImage nImageDescriptionImage;

    public List<GameObject> DescriptionUI = new List<GameObject>();

    public Transform cameraSetTrans;

    public Video_DescriptionCtr descriptionCtr;
        
    // Use this for initialization
    void Start () {

    }

    public void initialization(Sprite Mainsprite,Sprite BGDescriptionImage) {
        nImageMainImage.initialization();
        nImageDescriptionImage.initialization();
        SetupMainImage(Mainsprite);
        SetupUpBgImage(BGDescriptionImage);

        foreach (var item in DescriptionUI)
        {
            item.GetComponent<Video_DescriptionCtr>().initialization();
        }

        switch (uIStyle)
        {
            case UIStyle.defalue:
                descriptionCtr = DescriptionUI[0].GetComponent<Video_DescriptionCtrDefault>();
                break;
            case UIStyle.Style01:
                descriptionCtr = DescriptionUI[1].GetComponent<Video_DescriptionStyle01>();
                break;
            default:
                break;
        }

    }


    void SetupMainImage(Sprite sprite) {
        nImageMainImage.image.sprite = sprite;
    }

    void SetupUpBgImage(Sprite sprite) {
        nImageDescriptionImage.image.sprite = sprite;
    }

    public void SetupDescruptionUI() {
        //switch (switch_on)
        //{
        //    default:
        //}
    }


    public void PlayVideo() {

      string path =   ReadJson.NodeList[CameraMover.instance.CurrentID].VideoName;
        VideoCtr.instance.LoadVideoAndPlay(path);
    }

    public void StopVideo() {
        VideoCtr.instance.stopVideo();
    }

    public void ShowDescription() {

        descriptionCtr.TriggerAnimation();
        showDescriptionBGImage();
        PlayVideo();
    }


    public void HideDescription() {
        descriptionCtr.TriggerAnimation();
        hideDescriptionBGImage();

        StopVideo();
    }


    public void HideMainPicture() {
        nImageMainImage.HideAll(.2f);
    }

    public void ShowMainPicture()
    {
        nImageMainImage.ShowAll(2);
    }


    public void showDescriptionBGImage() {
        nImageDescriptionImage.ShowAll();
    }

    public void hideDescriptionBGImage()
    {
        nImageDescriptionImage.HideAll();
    }
}
