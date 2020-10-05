using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{

    public GameObject waterParticles;
    public GameObject terrainParticles;

    void Start()
    {
        Destroy(gameObject, 10f);
    }


    private void OnCollisionEnter(Collision collision)
    {
        var layerID = collision.collider.gameObject.layer;
        var layerName = LayerMask.LayerToName(layerID);

        GameObject particlesObject = null;

        if (layerName == "Water")
            particlesObject = waterParticles;

        if (layerName == "Terrain")
            particlesObject = terrainParticles;

        var position = collision.GetContact(0).point;

        Instantiate(particlesObject, position, Quaternion.identity);
        Destroy(gameObject);

    }

}
