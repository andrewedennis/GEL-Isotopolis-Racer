using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PostGameParticles : MonoBehaviour
{

    public static PostGameParticles Global;
    public Transform particlePos;
    public Text awardText;
    public List<GameObject> particleList = new List<GameObject>();
    private void Awake()
    {

        Global = this;
    }

    public void PostGameAwards()
    {
        int indx = Random.Range(0, particleList.Count-1);

        GameObject awardedParticle = Instantiate(particleList[indx]);
        awardedParticle.transform.position = particlePos.position;
        //awardText.text = awardedParticle.name;
        GameObject.FindGameObjectWithTag("Player").transform.Find("PostRaceInfo").Find("UI").Find("ParticleName").GetComponent<Text>().text = awardedParticle.name;
    }

}
