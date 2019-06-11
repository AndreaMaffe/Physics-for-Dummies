using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public Cube cube;
    public InitializeButton initializeButton;

    private GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        explosion = Resources.Load<GameObject>("PoffAnimation");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosion, collision.transform.position, Quaternion.identity);
        cube.ReturnToInitialPosition();
        initializeButton.SetOff();
    }
}
