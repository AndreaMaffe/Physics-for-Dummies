using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public GameObject pendulumBodyCentre;

    private bool firstCollisionHappened;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == pendulumBodyCentre && !firstCollisionHappened)
        {
            AudioManager.instance.PlaySound(SoundType.Ding);
        }

        firstCollisionHappened = true;
    }
}
