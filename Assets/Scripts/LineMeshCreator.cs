using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class LineMeshCreator : MonoBehaviour
{

    private void Start()
    {
        LineRenderer lineRend = GetComponent<LineRenderer>();
        MeshCollider meshColl = gameObject.AddComponent<MeshCollider>();


        Mesh mesh = new Mesh();
        lineRend.BakeMesh(mesh,Camera.main, true);
        meshColl.sharedMesh = mesh;
        meshColl.convex = true;
        meshColl.isTrigger = true;
    }

}
