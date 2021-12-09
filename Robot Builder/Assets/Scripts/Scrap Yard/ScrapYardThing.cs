using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* NOTE THIS IS THE SCRIPT FOR THE SCRAPYARD'S ROLL BUTTON,
 * YES I COULD MAKE IT MORE EFFICIENT BUT I'm not
 
     */

public class ScrapYardThing : MonoBehaviour
{
    public Button btn00;//this is
    public ScrapPile ScrapPile;
    //public Sprite img0,img1, img2, img3, img4;
    public Sprite img00, img01, img02, img03, img04, img05, img06, img07;
    public Image imgBlank;
    /*public Texture txtr00;*/
    public Text tMesh;
    // Start is called before the first frame update
    void Start()
    {
        
        btn00 = GetComponentInChildren<Button>();
        btn00.onClick.AddListener(TaskOnClick);

        /*
            This is pretty bad;

         */
        ScrapPile = GetComponentInChildren<ScrapPile>();


        tMesh = GetComponentInChildren<Text>();
        /*img00 = GetComponentInChildren<UnityEngine.Sprite>();
        img01 = GetComponentInChildren<UnityEngine.Sprite>();
        img02 = GetComponentInChildren<UnityEngine.Sprite>();
        img03 = GetComponentInChildren<UnityEngine.Sprite>();
        img04 = GetComponentInChildren<UnityEngine.Sprite>();
        img05 = GetComponentInChildren<UnityEngine.Sprite>();
        img06 = GetComponentInChildren<UnityEngine.Sprite>();
        img07 = GetComponentInChildren<UnityEngine.Sprite>();
        imgBlank = GetComponentInChildren<Image>();*/

                
    }

    public void TaskOnClick()
    {
        Debug.Log("HA HA HA MESSAGE OUT");
        tMesh.text = ScrapPile.getRandomNumber();
        imgBlank.sprite = img00;
    }

    public void OUTPUTTER()
    {
        
            //SceneManager.LoadScene(sceneBuildIndex: 1);
            Debug.Log("HA HA HA MESSAGE OUT");

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
