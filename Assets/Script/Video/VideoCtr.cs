using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoCtr : MonoBehaviour {
    public bool SentOnce = false;

    public static VideoCtr instance;
    MediaPlayer mediaPlayer;
    public DisplayUGUI FullScreenVideoPlayer;
    public void initialization() {

        if(instance == null)
        {
            instance = this;
        }
        mediaPlayer = this.GetComponent<MediaPlayer>();

    }

    public void LoadVideoAndPlay(string path) {

        mediaPlayer.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, path, true);
      
    }

    public void Update()
    {
       // Debug.Log(FullScreenVideoPlayer.CurrentMediaPlayer.Control.IsFinished());
        if (FullScreenVideoPlayer.CurrentMediaPlayer.Control.IsFinished()) {
            if (!SentOnce) {
                SentOnce = true;
                SendUPDData.instance.SentMessage();
                DealWithUDPMessage.instance.GoingBack();
            }

        }
    }


    public void StopFullScreenVideoPlayer() {
        LeanTween.value(1f, 0f, .4f).setOnUpdate(delegate (float value){
            FullScreenVideoPlayer.color = new Color(255f, 255f, 255f, value);
        }).setOnComplete(delegate() {
            stopVideo();
        });
         
    }

    public void PlayFullScreenVideoPlayer(string path, bool isLoop = true) {
      
        LeanTween.value(0f, 1f, .4f).setOnUpdate(delegate (float value)
        {
            FullScreenVideoPlayer.color = new Color(255f, 255f, 255f, value);
        }).setOnComplete(delegate ()
        {
            mediaPlayer.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, path, true);
            mediaPlayer.m_Control.SetLooping(isLoop);
        });
         
    }

    public void stopVideo() {
        mediaPlayer.Stop();
    }

}
