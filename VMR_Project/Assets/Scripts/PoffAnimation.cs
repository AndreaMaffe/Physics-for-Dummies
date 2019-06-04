using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoffAnimation : MonoBehaviour
{
    public SpriteRenderer cloud1;
    public SpriteRenderer cloud2;
    public SpriteRenderer cloud3;

    private float cloudVelocity;
    private int timer;

    private void Start()
    {
        cloudVelocity = 0.004f;
        timer = 0;
        AudioManager.instance.PlaySound(SoundType.HardPop);
    }

    void Update()
    {
        //move the clouds in different directions
        cloud1.transform.position += Vector3.up * cloudVelocity;
        cloud2.transform.position += new Vector3(1,-1, 0) * cloudVelocity;
        cloud3.transform.position += new Vector3(-1, -1, 0) * cloudVelocity;

        float alpha = (255f - timer) / 255;  //transparency normalized in [0, 1]

        cloud1.color = new Color(cloud1.color.r, cloud1.color.g, cloud1.color.b, alpha);
        cloud2.color = new Color(cloud1.color.r, cloud1.color.g, cloud1.color.b, alpha);
        cloud3.color = new Color(cloud1.color.r, cloud1.color.g, cloud1.color.b, alpha);

        timer+=2;

        if (timer >= 255)
            Destroy(this.gameObject);
    }
}
