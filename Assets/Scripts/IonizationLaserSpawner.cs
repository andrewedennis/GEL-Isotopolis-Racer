using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IonizationLaserSpawner : MonoBehaviour
{
    public float xMinRadius;
    public float xMaxRadius;
    public float yMinRadius;
    public float yMaxRadius;
    public float zMinRadius;
    public float zMaxRadius;

    public GameObject laserPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomizeIonizationBeam()
    {

        if (Random.value >= 0.5)
        {
            if(Random.value >= 0.5)
            {

                if (Random.value >= 0.5)
                {

                    SpawnIonizationBeam(1, 1, 1);

                }
                else
                {

                    SpawnIonizationBeam(1, 1, -1);

                }

            }
            else
            {
                if (Random.value >= 0.5)
                {

                    SpawnIonizationBeam(1, -1, 1);

                }
                else
                {

                    SpawnIonizationBeam(1, -1, -1);
                }

            }
        }
        else
        {
            if (Random.value >= 0.5)
            {

                if (Random.value >= 0.5)
                {

                    SpawnIonizationBeam(-1, 1, 1);

                }
                else
                {

                    SpawnIonizationBeam(-1, -1, 1);

                }

            }
            else
            {

                if (Random.value >= 0.5)
                {

                    SpawnIonizationBeam(-1, -1, 1);

                }
                else
                {

                    SpawnIonizationBeam(-1, -1, -1);

                }

            }

        }

    }

    void SpawnIonizationBeam(int stateX, int stateY, int stateZ)
    {

        float x = Random.Range(xMinRadius, xMaxRadius) * stateX;
        float y = Random.Range(yMinRadius, yMaxRadius) * stateY;
        float z = Random.Range(zMinRadius, zMaxRadius) * stateZ;

        GameObject laserInst = Instantiate(laserPrefab);
        laserInst.transform.position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z);


    }
}
