using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StarDisplay : MonoBehaviour {

    [SerializeField] int stars = 100;
    TextMeshProUGUI starText;

	void Start () {
        starText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
	}

    void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }

    public bool HaveEnoughStars(int amount)
    {
        return stars >= amount;
    }

    public void AddStars(int stars)
    {
        this.stars += stars;
        UpdateDisplay();
    }

    public void SubtractStars(int stars)
    {
        if (this.stars >= stars)
        {
            this.stars -= stars;
            UpdateDisplay();
        }
    }
	
}
