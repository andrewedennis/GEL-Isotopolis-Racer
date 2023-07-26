using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsotopeUnlock : MonoBehaviour
{






    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void UpdateCollection() {
        for (int counter = 1; counter <= PlayerPrefs.GetFloat("SaveScore"); counter++)
        {
            GameObject.Find("Isotope Select Panel").transform.Find(counter.ToString()).gameObject.SetActive(true);
           
            //GameObject.Find(counter.ToString()).gameObject.SetActive(true);
        }

        for (int counter = 1; counter > PlayerPrefs.GetFloat("SaveScore"); counter++)
        {
            GameObject.Find("Isotope Select Panel").transform.Find(counter.ToString()).gameObject.SetActive(false);
        
            //GameObject.Find(counter.ToString()).gameObject.SetActive(true);
        }

       // Debug.LogError(PlayerPrefs.GetFloat("SaveScore"));

    }


    public void ResetPrefs()
    {
        PlayerPrefs.DeleteAll();
        //Debug.LogError(PlayerPrefs.GetFloat("SaveScore"));
    }


}
