using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video_DescriptionCtr : MonoBehaviour {
    public Animator animator;
    public DisplayUGUI displayUGUI;

    public void initialization() {
        animator = this.GetComponent<Animator>();
        displayUGUI = GetComponentInChildren<DisplayUGUI>();
        displayUGUI._mediaPlayer = FindObjectOfType<MediaPlayer>();
    }

    // Update is called once per frame
    void Update () {

	}

    public void TriggerAnimation() {

        animator.SetTrigger("Defalut");

    }
}
