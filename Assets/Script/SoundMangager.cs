using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMangager : MonoBehaviour {
    public AudioSource audioSource;
    public AudioSource BGM;
    public List<AudioClip> audioClips = new List<AudioClip>();
    public static SoundMangager instance;
	// Use this for initialization
	public void initialization() {
        if (instance == null) {
            instance = this;
        }

        ValueSheet.NameAudio_keyValuePairs.Add("Through", audioClips[0]);
        ValueSheet.NameAudio_keyValuePairs.Add("Select", audioClips[1]);
        ValueSheet.NameAudio_keyValuePairs.Add("BGM", audioClips[2]);

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) {
            Select();
        }
    }


    public void GoThrough() {
        //audioSource.loop = true;
        audioSource.clip = ValueSheet.NameAudio_keyValuePairs["Through"];
        audioSource.Play();
    }

    public void StopSound() {
        audioSource.loop = false;
        audioSource.Stop();
    }

    public void Select()
    {
        audioSource.clip = ValueSheet.NameAudio_keyValuePairs["Select"];
        audioSource.PlayOneShot(ValueSheet.NameAudio_keyValuePairs["Select"]);
    }

    public void PlayBGM() {

        BGM.clip = ValueSheet.NameAudio_keyValuePairs["BGM"];
        BGM.PlayOneShot(ValueSheet.NameAudio_keyValuePairs["BGM"]);
    }

    public void StopBGM()
    {
        BGM.Stop();
    }
}
