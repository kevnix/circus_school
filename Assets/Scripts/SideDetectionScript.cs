using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideDetectionScript : MonoBehaviour
{
    DiceRollScript diceRollScript;

    void Awake()
    {
        diceRollScript = FindObjectOfType<DiceRollScript>();
    }

    private void OnTriggerStay(Collider sideCollider)
    {
        if(diceRollScript != null)
        {
            if(diceRollScript.GetComponent<Rigidbody>().velocity == Vector3.zero)
            {
                diceRollScript.isLanded = true;
                diceRollScript.diceFaceNumber = sideCollider.name;
            } else
            {
                diceRollScript.isLanded = false;
            }
        }
        else
        {
            Debug.LogError("DicerollScript not found in a scene!");
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
}
