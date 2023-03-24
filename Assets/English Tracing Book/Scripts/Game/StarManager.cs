using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StarManager : MonoBehaviour
{
    public int maxStars = 3; // The maximum number of stars that can be earned in this scene
    public int starsRate = 0; // The current star rating for this scene
    public Image[] stars; // The UI images to display the star rating
    public Sprite starOff; // The sprite for an inactive star
    public Sprite starOn; // The sprite for an active star
    public string shapesManagerReference;
    void Start()
    {
        CalculateStars();
        DisplayStars();
    }

    void CalculateStars()
    {
        ShapesManager shapesManager = GameObject.Find(shapesManagerReference).GetComponent<ShapesManager>();
        int collectedStars = DataManager.GetCollectedStars(shapesManager);
        int starsRate = Mathf.FloorToInt(collectedStars / (shapesManager.shapes.Count * 3.0f) * 3.0f);
    }

    void DisplayStars()
    {
        if (starsRate == 0) // Zero Stars
        {
            stars[0].sprite = starOff;
            stars[1].sprite = starOff;
            stars[2].sprite = starOff;
        }
        else if (starsRate == 1) // One Star
        {
            stars[0].sprite = starOn;
            stars[1].sprite = starOff;
            stars[2].sprite = starOff;
        }
        else if (starsRate == 2) // Two Stars
        {
            stars[0].sprite = starOn;
            stars[1].sprite = starOn;
            stars[2].sprite = starOff;
        }
        else // Three Stars
        {
            stars[0].sprite = starOn;
            stars[1].sprite = starOn;
            stars[2].sprite = starOn;
        }
    }
}

