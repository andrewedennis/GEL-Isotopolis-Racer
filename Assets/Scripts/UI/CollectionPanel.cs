using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CollectionPanel : MonoBehaviour
{
    [Header("Battery")]
    public List<Image> isotopeBatteryButtons = new List<Image>();
    public List<TMPro.TMP_Text> isotopeBatteryTexts = new List<TMPro.TMP_Text>();
    [Header("Medical")]
    public List<Image> isotopeMedicalButtons = new List<Image>();
    public List<TMPro.TMP_Text> isotopeMedicalTexts = new List<TMPro.TMP_Text>();
    [Header("Bio Research")]
    public List<Image> isotopeBioButtons = new List<Image>();
    public List<TMPro.TMP_Text> isotopeBioTexts = new List<TMPro.TMP_Text>();
    [Header("Star Material")]
    public List<Image> isotopeStarButtons = new List<Image>();
    public List<TMPro.TMP_Text> isotopeStarTexts = new List<TMPro.TMP_Text>();
    [Header("Structure")]
    public List<Image> isotopeCancerButtons = new List<Image>();
    public List<TMPro.TMP_Text> isotopeCancerTexts = new List<TMPro.TMP_Text>();
    [Header("Nuclear Power")]
    public List<Image> isotopeNuclearButtons = new List<Image>();
    public List<TMPro.TMP_Text> isotopeNuclearTexts = new List<TMPro.TMP_Text>();

    public Sprite discoveredIcon;
    public Sprite undiscoveredIcon;

    public Transform isotopePreviewLocation;
    public GameObject isotopePreview;
    public TMPro.TMP_Text isotopeText;




    public void SwapPanel(string PanelName)
    {

        //make the index we choose the current top child

        GameObject.Find(PanelName).transform.SetAsLastSibling();

        switch (PanelName)
        {

            case "Battery":
                SelectIsotopeAutomatic(0);
                break;
            case "Medical":
                SelectIsotopeAutomatic(1);
                break;
            case "Bio Research":
                SelectIsotopeAutomatic(2);
                break;
            case "Star":
                SelectIsotopeAutomatic(3);
                break;
            case "Cancer":
                SelectIsotopeAutomatic(4);
                break;
            case "Nuclear Power":
                SelectIsotopeAutomatic(5);
                break;
        }


    }

    public void SelectIsotopeAutomatic(int panelIndex)
    {


        if (isotopePreview != null)
        {
            Destroy(isotopePreview);
        }

        List<IsotopeSO> isoList = new List<IsotopeSO>();

        switch (panelIndex)
        {
            case 0:
                isoList = IsotopeCollection.Global.battery;
                break;
            case 1:
                isoList = IsotopeCollection.Global.medical;
                break;
            case 2:
                isoList = IsotopeCollection.Global.bio_research;
                break;
            case 3:
                isoList = IsotopeCollection.Global.star;
                break;
            case 4:
                isoList = IsotopeCollection.Global.cancer;
                break;
            case 5:
                isoList = IsotopeCollection.Global.nuclear;
                break;

        }


        int foundIndex = 999;

        for(int i = 0; i < isoList.Count; i++){


            if (isoList[i].unlocked)
            {
                foundIndex = i;
                break;
            }

        }

        if(foundIndex != 999)
        {

            IsotopeSO iso = isoList[foundIndex];
            isotopePreview = Instantiate(iso.isotopeModel);
            isotopePreview.transform.localScale = new Vector3(50, 50, 50);
            isotopePreview.transform.position = isotopePreviewLocation.position;
            isotopeText.text = iso.isotopeName;
        }
    }


    public void SelectIsotopeManual(string panelCommaIsotope)
    {

        string[] splitPanelCommaIsotope = panelCommaIsotope.Split(',');

        List<IsotopeSO> isoList = new List<IsotopeSO>();

        switch (splitPanelCommaIsotope[0])
        {

            case "battery":
                isoList = IsotopeCollection.Global.battery;
                break;

            case "medical":
                isoList = IsotopeCollection.Global.medical;
                break;

            case "bio_research":
                isoList = IsotopeCollection.Global.bio_research;
                break;

            case "cancer":
                isoList = IsotopeCollection.Global.cancer;

                break;

            case "star":
                isoList = IsotopeCollection.Global.star;

                break;

            case "nuclear":
                isoList = IsotopeCollection.Global.nuclear;

                break;


        }

        IsotopeSO iso = isoList[int.Parse(splitPanelCommaIsotope[1])];

        if (iso.unlocked)
        {

            if(isotopePreview != null)
            {

                Destroy(isotopePreview);
            }
            GameObject go = Instantiate(iso.isotopeModel);
            go.transform.localScale = new Vector3(50, 50, 50);
            go.transform.position = isotopePreviewLocation.position;
            isotopeText.text = iso.isotopeName;
        }
    }

}
