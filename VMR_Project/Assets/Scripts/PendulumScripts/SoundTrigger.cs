using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public GameObject pendulumBody;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == pendulumBody)
        {
            AudioManager.instance.PlaySound(SoundType.Ding);
        }
    }
}
