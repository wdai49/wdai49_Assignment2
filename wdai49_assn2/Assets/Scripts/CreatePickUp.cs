using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePickUp : MonoBehaviour
{
    public GameObject prefeb;
    GameObject pickup;
    float randomNumber;
    float posX, posZ, angle;
    public float radius;
    public int numPickup;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numPickup; i++)
        {
            angle = i * 2f * Mathf.PI / numPickup;
            randomNumber = Random.value;
            posX = Mathf.Cos(angle) * radius;
            posZ = Mathf.Sin(angle) * radius;


            pickup = Instantiate<GameObject>(prefeb);
            if (randomNumber < 0.3f)
            {
                Renderer rend = pickup.GetComponent<Renderer>();
                rend.material.color = Color.green;
                pickup.tag = "green";
            }
            else if (randomNumber < 0.6f)
            {
                pickup.GetComponent<Renderer>().material.color = Color.magenta;
                pickup.tag = "magenta";
            }
            else
            {
                pickup.GetComponent<Renderer>().material.color = Color.red;
                pickup.tag = "red";
            }

            pickup.transform.position = new Vector3(posX, 0.5f, posZ);
        }
    }

}
