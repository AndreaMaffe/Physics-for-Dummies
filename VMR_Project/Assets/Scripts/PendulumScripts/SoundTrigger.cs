using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public GameObject pendulumBodyCentre;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == pendulumBodyCentre)
        {
            AudioManager.instance.PlaySound(SoundType.Ding);
        }
    }
}
