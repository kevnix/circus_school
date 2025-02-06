using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
public class DiceRollScript : MonoBehaviour
{   
    Rigidbody body;

    Vector3 position;
   [SerializeField]private float maxRandForceVal, startRollingForce;
    float forceX, forceY, forceZ;
    public string diceFaceNumber;
    public bool isLanded = false;
    public bool firstThrow = false;

    void Awake()
    {
        Initialize();
        
    }

    private void Initialize()
    {
        body = GetComponent<Rigidbody>();
        body.isKinematic = true;
        position = transform.position;
        transform.rotation = new Quaternion(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360), 0);
    }

    public void RollDice()
    {
        body.isKinematic = false;
        forceX = Random.Range(0, maxRandForceVal);
        forceY = Random.Range(0, maxRandForceVal);
        forceZ = Random.Range(0, maxRandForceVal);
        body.AddForce(Vector3.up * Random.Range(800, startRollingForce));
        body.AddTorque(forceX, forceY, forceZ);
    }

    public void ResetDice()
    {
        body.isKinematic=true;
        firstThrow = false;
        isLanded = false;
        transform.position = position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(body != null)
        {
            if(Input.GetMouseButton(0) && isLanded || Input.GetMouseButton(0) && !firstThrow)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit))
                {
                    if(hit.collider != null && hit.collider.gameObject == this.gameObject)
                    {
                        if(!firstThrow)
                        {   
                            firstThrow = true;
                            
                        }

                        RollDice();
                    }
                }
            }
        }
    }
}
