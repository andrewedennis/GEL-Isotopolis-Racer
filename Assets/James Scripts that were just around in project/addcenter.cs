using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class addcenter : MonoBehaviour
{

    public GameObject go;

    // Start is called before the first frame update
    void Start()
    {


        GameObject boy = Instantiate(go);
        boy.transform.position = GetComponent<MeshRenderer>().bounds.center;
        boy.transform.position = new Vector3(boy.transform.position.x + 11.25f, boy.transform.position.y, boy.transform.position.z );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
