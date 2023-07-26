using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class IsotopeCollection : MonoBehaviour
{

    public static IsotopeCollection Global;

    public CollectionPanel collectionPanel;

    //have a list of each type, both so and ui element
    public List<IsotopeSO> battery = new List<IsotopeSO>();
    public List<IsotopeSO> medical = new List<IsotopeSO>();
    public List<IsotopeSO> bio_research = new List<IsotopeSO>();
    public List<IsotopeSO> star = new List<IsotopeSO>();
    public List<IsotopeSO> cancer = new List<IsotopeSO>();
    public List<IsotopeSO> nuclear = new List<IsotopeSO>();


    public GameObject mainMenuCanvas;
    public GameObject mainMenuCamera;
    public Light mainMenuLight;
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



    public void AddIsotope()
    {

        int catagory = Random.Range(0, 6);

        switch (catagory)
        {


            case 0:
                IsotopeSO iso = new IsotopeSO();
                int awardIndex = 0;
                iso.unlocked = true;
                while (iso.unlocked)
                {

                    awardIndex = Random.Range(0, battery.Count);
                    iso = battery[awardIndex];
                }
                iso.unlocked = true;
                collectionPanel.isotopeBatteryButtons[awardIndex].sprite = collectionPanel.discoveredIcon;
                collectionPanel.isotopeBatteryTexts[awardIndex].text = iso.name;
                AwardIsotope(iso);

                break;
            case 1:
                IsotopeSO iso2 = new IsotopeSO();
                int awardIndex2 = 0;
                iso2.unlocked = true;
                while (iso2.unlocked)
                {

                    awardIndex2 = Random.Range(0, medical.Count);
                    iso2 = medical[awardIndex2];
                }
                iso2.unlocked = true;
                collectionPanel.isotopeMedicalButtons[awardIndex2].sprite = collectionPanel.discoveredIcon;
                collectionPanel.isotopeMedicalTexts[awardIndex2].text = iso2.name;
                AwardIsotope(iso2);

                break;
            case 2:
                IsotopeSO iso3 = new IsotopeSO();
                int awardIndex3 = 0;
                iso3.unlocked = true;
                while (iso3.unlocked)
                {

                    awardIndex3 = Random.Range(0, bio_research.Count);
                    iso3 = bio_research[awardIndex3];
                }
                iso3.unlocked = true;
                collectionPanel.isotopeBioButtons[awardIndex3].sprite = collectionPanel.discoveredIcon;
                collectionPanel.isotopeBioTexts[awardIndex3].text = iso3.name;
                AwardIsotope(iso3);

                break;
            case 3:
                IsotopeSO iso4 = new IsotopeSO();
                int awardIndex4 = 0;
                iso4.unlocked = true;
                while (iso4.unlocked)
                {

                    awardIndex4 = Random.Range(0, star.Count);
                    iso4 = star[awardIndex4];
                }
                iso4.unlocked = true;
                collectionPanel.isotopeStarButtons[awardIndex4].sprite = collectionPanel.discoveredIcon;
                collectionPanel.isotopeStarTexts[awardIndex4].text = iso4.name;
                AwardIsotope(iso4);

                break;
            case 4:
                IsotopeSO iso5 = new IsotopeSO();
                int awardIndex5 = 0;
                iso5.unlocked = true;
                while (iso5.unlocked)
                {

                    awardIndex5 = Random.Range(0, cancer.Count);
                    iso5 = cancer[awardIndex5];
                }
                iso5.unlocked = true;
                collectionPanel.isotopeCancerButtons[awardIndex5].sprite = collectionPanel.discoveredIcon;
                collectionPanel.isotopeCancerTexts[awardIndex5].text = iso5.name;
                AwardIsotope(iso5);

                break;
            case 5:
                IsotopeSO iso6 = new IsotopeSO();
                int awardIndex6 = 0;
                iso6.unlocked = true;
                while (iso6.unlocked)
                {

                    awardIndex6 = Random.Range(0, nuclear.Count);
                    iso6 = nuclear[awardIndex6];
                }
                iso6.unlocked = true;
                collectionPanel.isotopeNuclearButtons[awardIndex6].sprite = collectionPanel.discoveredIcon;
                collectionPanel.isotopeNuclearTexts[awardIndex6].text = iso6.name;
                AwardIsotope(iso6);
                break;
        }

    }

    public void AwardIsotope(IsotopeSO iso)
    {
        GameObject awardedParticle = Instantiate(iso.isotopeModel);
        Transform particlePos = PostGameParticles.Global.particlePos;
        awardedParticle.transform.position = particlePos.position;
        //awardText.text = awardedParticle.name;
        GameObject.FindGameObjectWithTag("Player").transform.Find("PostRaceInfo").Find("UI").Find("ParticleName").GetComponent<Text>().text = iso.isotopeName;


    }

    public void LoadMainMenuAct()
    {
        
        SceneManager.UnloadSceneAsync(1);
        mainMenuCanvas.SetActive(true);
        mainMenuCamera.SetActive(true);
        mainMenuLight.intensity = 1f;
    }
}
