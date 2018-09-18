using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoWellCtr : MonoBehaviour {
    public List<MeshRenderer> meshRenderers = new List<MeshRenderer>();
    List<int> intList = new List<int>();
    public int numPopOut=10;

    public float ZmoveDis=-.3f;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

	}


    public void TurnOnLogoWell() {
        this.gameObject.SetActive(true);
        StartCoroutine(Move(1f, .4f));
        Camera.main.transform.position = new Vector3(0f, 33.3f, -68.1f);
    }



    public void TurnOffLogoWell()
    {
        this.gameObject.SetActive(false);
        StopAllCoroutines();
    }


    public IEnumerator Move(float time,float waitTime)
    {

        List<int> currentintList = new List<int>();
        currentintList = CreateList();
        foreach (var item in currentintList)
        {
            yield return new  WaitForSeconds(.04f);
            float z = meshRenderers[item].gameObject.transform.localPosition.z + ZmoveDis;
            LeanTween.moveLocalZ(meshRenderers[item].gameObject, z, time);
        }

        yield return new WaitForSeconds(time+ waitTime);

        foreach (var item in currentintList)
        {
            yield return new WaitForSeconds(.04f);
            float z = meshRenderers[item].gameObject.transform.localPosition.z - ZmoveDis;
            LeanTween.moveLocalZ(meshRenderers[item].gameObject, z, time);
        }
        yield return new WaitForSeconds(time+ waitTime);
        currentintList.Clear();

        StartCoroutine(Move(time, waitTime));
    }


    bool keepgoing = true;
    List<int> CreateList() {
        intList.Clear();
        for (int i = 0; i < numPopOut; i++)
        {    
        keepgoing = true;
        while (keepgoing) {

            int num = Random.Range(0, meshRenderers.Count - 1);

                if (!intList.Contains(num))
                {
                    keepgoing = false;
                    intList.Add(num);
                }
            }

        }
        return intList;
    }
}
