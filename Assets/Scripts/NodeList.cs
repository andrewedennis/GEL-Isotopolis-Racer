using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeList : MonoBehaviour
{

    public static NodeList Global;
    public Transform[] nodes;


    private void Awake()
    {

        Global = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
