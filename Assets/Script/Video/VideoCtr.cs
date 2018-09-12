using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoCtr : MonoBehaviour {
    public static VideoCtr instance;
    MediaPlayer mediaPlayer;

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

    public void stopVideo() {
        mediaPlayer.Stop();
    }

}
