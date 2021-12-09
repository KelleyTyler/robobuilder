using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Math.Random;

public class ScrapPile : MonoBehaviour
{

    System.Random Rand;
    List<GameObject> arList;
    GameObject gOb1;
    // Start is called before the first frame update
    void Start()
    {
        arList = new List<GameObject>();
        arList.Add(GameObject.Find("Leg 5"));
        arList.Add(GameObject.Find("Leg 4"));
        arList.Add(GameObject.Find("Leg 3"));
        arList.Add(GameObject.Find("Leg 2"));
        arList.Add(GameObject.Find("Arm 1"));
        foreach (GameObject a in arList)
        {
            a.SetActive(false);
        }
        
        Rand = new System.Random();
    }

    public string getRandomNumber()
    {
        foreach (GameObject x in arList)
        {
            x.SetActive(false);
        }

        int a = Rand.Next(0, 5);

        Debug.Log("A debug log from the random number generator... in this case it's: "+a+"  or "+arList[a].ToString());
        arList[a].SetActive(true);
        return arList[a].ToString();


    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
