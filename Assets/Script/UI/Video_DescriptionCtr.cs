using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video_DescriptionCtr : MonoBehaviour {
    public Animator animator;

    public void initialization() {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {

	}

    public void TriggerAnimation() {

        animator.SetTrigger("Defalut");

    }
}
