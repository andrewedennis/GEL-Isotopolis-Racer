using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Handles the selection of characters on the main menu
/// James 8/17
/// </summary>
public class CharacterSelectUI : MonoBehaviour
{

    public List<ParticleRacer> racers = new List<ParticleRacer>();
    VerticalLayoutGroup racerSelectLayout;
    [SerializeField]
    private GameObject characterSelectButton;
    public ParticleRacer currentRacer = null;

    private void Awake()
    {

        racerSelectLayout = GetComponent<VerticalLayoutGroup>();
        foreach(ParticleRacer r in racers)
        {

            //create a button with the name of the 
            var button = Instantiate(characterSelectButton, transform);
            button.GetComponentInChildren<Text>().text = r.name;
            button.GetComponent<Button>().onClick.AddListener( () => ChangeSelectedRacer(button));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSelectedRacer(GameObject go)
    {

        switch (go.GetComponentInChildren<Text>().text)
        {

            case "Iron":
                foreach(ParticleRacer r in racers)
                {
                    if (r.name == "Iron")
                    {
                        if(currentRacer != r)
                        {
                            currentRacer = r;
                        }
                    }
                }
                break;
            case "Uranium":
                foreach (ParticleRacer r in racers)
                {
                    if (currentRacer != r)
                    {
                        currentRacer = r;
                    }
                }
                break;
            case "Calcium 48":
                foreach (ParticleRacer r in racers)
                {
                    if (currentRacer != r)
                    {
                        currentRacer = r;
                    }
                }
                break;
            case "Tin":
                foreach (ParticleRacer r in racers)
                {
                    if (currentRacer != r)
                    {
                        currentRacer = r;
                    }
                }
                break;
        }

    }
}
