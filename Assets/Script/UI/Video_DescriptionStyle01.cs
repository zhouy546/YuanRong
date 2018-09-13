using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video_DescriptionStyle01 : Video_DescriptionCtr
{
    public List<Sprite> LeftSpriteList = new List<Sprite>();
    public List<Sprite> RightSpriteList = new List<Sprite>();


    void Start()
    {

    }

    public override void initialization()
    {
        base.initialization();
        foreach (var item in nImagesDescription)
        {
            item.initialization();
        }
    }

    public override void setupImage(List<Sprite> sprites)
    {
        for (int i = 0; i < sprites.Count; i++)
        {
            if (i % 2 == 0)
            {
                LeftSpriteList.Add(sprites[i]);
            }
            else {
                RightSpriteList.Add(sprites[i]);
            }
        }

        StartCoroutine(AnimationLoop());
    }

    IEnumerator AnimationLoop() {
        for (int i = 0; i < LeftSpriteList.Count; i++)
        {
           
            nImagesDescription[0].image.sprite = LeftSpriteList[i];
            nImagesDescription[1].image.sprite = RightSpriteList[i];

            yield return new WaitForSeconds(5f);
        }

        StartCoroutine(AnimationLoop());

    }

    

    public override void setupImage(Sprite L_sprite, Sprite R_sprite)
    {

    }
}
