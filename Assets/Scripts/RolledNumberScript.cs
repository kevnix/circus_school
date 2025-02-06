using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RolledNumberScript : MonoBehaviour
{
    DiceRollScript diceRollScript;
    [SerializeField]
    TMP_Text rolledNumberText;

    void Awake()
    {
        diceRollScript = FindObjectOfType<DiceRollScript>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (diceRollScript != false) 
        {
            if (diceRollScript.isLanded)
            {
                rolledNumberText.text = diceRollScript.diceFaceNumber;
            } else
            {
                rolledNumberText.text = "?";
            }
        } else
        {
            Debug.LogError("DiceRollScript not found in the scene!");
        }
    }
}
