using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeCtr : MonoBehaviour {

    public enum UIStyle { defalue, Style00, Style01 }

    public UIStyle uIStyle;

    public NImage nImageMainImage;

    public NImage nImageDescriptionBGImage;

    public List<Sprite> nImagesDescription = new List<Sprite>();

    public Video_DescriptionCtr DescriptionUI;

    public Transform cameraSetTrans;



    // Use this for initialization
    void Start() {

    }

    public void FloatingAniamtion() {

    }

    public void initialization(Sprite Mainsprite,Sprite BGDescriptionImage) {
        nImageMainImage.initialization();
        nImageDescriptionBGImage.initialization();
        SetupMainImage(Mainsprite);
        SetupUpBgImage(BGDescriptionImage);


       DescriptionUI.initialization();
 

        SetupDescriptionImage();

    }

    private void SetupDescriptionImage()
    {
        nImagesDescription= ValueSheet.DescriptionkeyValuePairs[int.Parse(this.name)];

        // Debug.Log(nImagesDescription.Count);
        DescriptionUI.setupImage(nImagesDescription);
    }


    void SetupMainImage(Sprite sprite) {
        nImageMainImage.image.sprite = sprite;
    }

    void SetupUpBgImage(Sprite sprite) {
        nImageDescriptionBGImage.image.sprite = sprite;
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

        DescriptionUI.TriggerAnimation(true);
        showDescriptionBGImage();
        PlayVideo();
    }


    public void HideDescription() {
        DescriptionUI.TriggerAnimation(false);
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
        nImageDescriptionBGImage.ShowAll();
    }

    public void hideDescriptionBGImage()
    {
        nImageDescriptionBGImage.HideAll();
    }
}
