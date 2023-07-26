using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBeam : MonoBehaviour
{

    public List<Transform> beamPos = new List<Transform>();
    private LineRenderer lineRend;
    public GameObject beamMidPointGO;

    // Start is called before the first frame update
    void Start()
    {
   
        lineRend = GetComponent<LineRenderer>();
        lineRend.positionCount = beamPos.Count;
        List<Vector3> beamVecPos = new List<Vector3>();
        
        for(int i = 0; i < beamPos.Count; i++)
        {

            beamVecPos.Add(beamPos[i].position);

        }
        
        lineRend.SetPositions(beamVecPos.ToArray());


        CreateParticleBeamCollider(beamVecPos);

    }

    // Update is called once per frame
    void Update()
    {
        


    }

    void CreateParticleBeamCollider(List<Vector3> beamVecPos)
    {

        for (int i = 0; i < beamVecPos.Count; i++)
        {
            if (beamVecPos[i] == beamVecPos[beamVecPos.Count-1])
            {
                break;
            }

            //get the mid point between current element and next element

            float midx = beamVecPos[i].x + (beamVecPos[i + 1].x - beamVecPos[i].x) / 2;
            float midy = beamVecPos[i].y + (beamVecPos[i + 1].y - beamVecPos[i].y) / 2;
            float midz = beamVecPos[i].z + (beamVecPos[i + 1].z - beamVecPos[i].z) / 2;

            Vector3 midPointVector = new Vector3(midx, midy, midz);

            GameObject midPoint = Instantiate(beamMidPointGO, transform);
            midPoint.transform.position = midPointVector;
            midPoint.transform.LookAt(beamPos[i + 1]);

            CapsuleCollider midPointCollider = midPoint.GetComponent<CapsuleCollider>();
            float radiusZ = Vector3.Distance(beamVecPos[i], beamVecPos[i + 1]);
            midPointCollider.height = radiusZ;
        }
    }

}
