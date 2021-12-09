using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*Programmed by: TYLER KELLEY
 *
 *This is code designed to do some basic stuff with regards to combat.
 * I think there were a great many errors in communication.
 * 
 * I Am Literally not referencing any of the other code because nobody has bothered commenting on it.
 * 
 */
public class CombatStatRelatedNonsense : MonoBehaviour
{

    /*I HONESTLY DOUBT YOU WILL READ THIS, PLEASE SPEI*/

    // Start is called before the first frame update

    //TempStats pStats;
    public Text atkBtnText;
    public Button atkbtn,nxtButton;//okay by setting this public I don't actually need it to be referenced at all apparently I can assign this from the in game gui, might not be "secure" but I like it!
    public Button stancebtn00,stancebtn01, stancebtn02;
    //Button quitButton;
    //GetComponent<TMPro.TextMeshProUGUI>().text
    public TMPro.TextMeshProUGUI PLabel0, PLabel1, ELabel0, ELabel1, Outptr;
    System.Random Rand;
    TempPlayer pStats;
    TempEnemy tEnemy;
    void Start()
    {
        // atkbtn = GetComponentInChildren<Button>();
        atkBtnText.text = "ATTACK";
        atkbtn.onClick.AddListener(TaskOnClick);
        stancebtn00.onClick.AddListener(stancebtn00Click);
        stancebtn01.onClick.AddListener(stancebtn01Click);
        stancebtn02.onClick.AddListener(stancebtn02Click);

        //nxtButton.enabled = false;
        nxtButton.gameObject.SetActive(false);
        //nxtButton.setActive(false);
        nxtButton.GetComponentInChildren<Text>().text = "";
        nxtButton.onClick.AddListener(nextButton);
        Rand = new System.Random();
        //pStats = GetComponent<TempStats>();
        pStats = GetComponentInChildren<TempPlayer>();
        tEnemy = GetComponentInChildren<TempEnemy>();
    }
    private void toggleStanceBtns()
    {
        if(stancebtn00.IsActive())
        {
            stancebtn00.gameObject.SetActive(false);
            stancebtn01.gameObject.SetActive(false);
            stancebtn02.gameObject.SetActive(false);
        }
        else
        {
            stancebtn00.gameObject.SetActive(true);
            stancebtn01.gameObject.SetActive(true);
            stancebtn02.gameObject.SetActive(true);
        }
    }
    private void stancebtn02Click()
    {
        pStats.setStance(2);
    }

    private void stancebtn01Click()
    {
        pStats.setStance(1);
    }

    private void stancebtn00Click()
    {
        pStats.setStance(0);
    }

    private void nextButton()
    {
        Debug.Log("CALLOUT");
        if (nxtButton.GetComponentInChildren<Text>().text == "RESET")
            pStats.PlayerRet();
        else if (nxtButton.GetComponentInChildren<Text>().text == "NEXT")
            tEnemy.getNewEnemy();

        nxtButton.GetComponentInChildren<Text>().text = "";
        nxtButton.gameObject.SetActive(false);
        //nxtButton.interactable = true;
        stancebtn00.gameObject.SetActive(true);
        stancebtn01.gameObject.SetActive(true);
        stancebtn02.gameObject.SetActive(true);
    }

    /*
private void quitBtn()
{
   Debug.Log("QUIT!"); 
}*/
    /*  Combat System Primer;
     *  ---------------------
     *  3 types of armor 3 types of attacks
     *  
     *
     *
     */
    /*
*      COMBAT SYSTEM IS HERE 
* THIS IS WHERE THE COMBAT SYSTEM IS
* 
*/
    public string attack(TempStats atkr, TempStats defndr)
    {
        /*
            some of this is extremely stupid and messy but so what!
         
         */

        int temp0;
        int temp1;
        int temp2;
        int dice1=0;
        int dice2=0;
        int pos=0;
        int neg=0;
        int[] atkrAtks = atkr.getAtks();
        int[] defDef = defndr.getDefs();
        string[] atkTypes = { "impact", "piercing", "energy" };
        string[] defTypes = { "composite", "heavy", "energy" };


        //this is what handles the basic calculations that roughly cover "combat" and "combat orientating"-like things.
        string s = string.Format("{0} attacks {1}", atkr.getName(), defndr.getName());


        if (atkr.getDead())//this is because it's funny. people forgetting they're dead and stuff, etc.
        {
            s = s + " but attack fails because they're already dead.";
            return s;
        }
        else
        {
            temp0 = atkrAtks[0] - defDef[0];
            if (temp0 > 0)
            {
                pos = +temp0;
            }
            else neg = +temp0;
            s = s + string.Format("\n{0} -Type Attacks: {1}", atkTypes[0], temp0);
            temp1 = atkrAtks[1] - defDef[1];
            s = s + string.Format("\n{0} -Type Attacks: {1}", atkTypes[1], temp1);
            if (temp1 > 0)
            {
                pos = +temp1;
            }
            else neg = +temp1;
            temp2 = atkrAtks[2] - defDef[2];
            s = s + string.Format("\n{0} -Type Attacks: {1}", atkTypes[2], temp2);
            if (temp2 > 0)
            {
                pos = +temp2;
            }
            else neg = +temp2;

            //all damage is (number of positive)d6-(number of negative)d6;
            for(int i =0;i<pos;i++)
            {
                dice1 =+ Rand.Next(1, 6);
               
            }
            for (int j = 0; j < neg; j++)
            {
                dice2 =+ Rand.Next(1, 6);
            }

            if (defndr.getStance()== 1)
            {
                dice2 = dice2 * 2;
            }
            if (atkr.getStance() == 1)
            {
                dice2 = 0;
                s = string.Format("{0} holds a defensive stance", atkr.getName());
            }
            if (atkr.getStance() == 2)
            {
                dice1 = 0;
                s = string.Format("{0} charges up a major attack", atkr.getName());
                atkr.setStance(3);
            }
            else
            {

                if (atkr.getStance() == 3)
                {
                    s = string.Format("{0} unleashes a major attack", atkr.getName());
                    dice1 = dice1 * 2;
                }
            }

            defndr.doDamage(dice1-dice2);
        }



        return s;
    }




    private void TaskOnClick()
    {
        Debug.Log("test");
        //Debug.Log(pStats.getName()+" , "+pStats.getHP());
        if (atkBtnText.text == "ATTACK")
        {
            Outptr.SetText(attack(pStats.getTemptStats(), tEnemy.getTemptStats()));
            PLabel0.SetText(pStats.getTemptStats().getHP(), true);
            ELabel0.SetText(tEnemy.getTemptStats().getHP(), true);
            atkBtnText.text = "NEXT";
            toggleStanceBtns();
        }
        else
        {
            Outptr.SetText(attack(tEnemy.getTemptStats(), pStats.getTemptStats()));
            PLabel0.SetText(pStats.getTemptStats().getHP(), true);
            ELabel0.SetText(tEnemy.getTemptStats().getHP(), true);
            atkBtnText.text = "ATTACK";
            toggleStanceBtns();
        }
        pStats.PrintStats();
        tEnemy.PrintStats();
        if (pStats.getStatus() || tEnemy.getStatus())
        {
            Debug.Log("test4");
            if (pStats.getStatus())
            {
                nxtButton.GetComponentInChildren<Text>().text = "RESET";
                nxtButton.gameObject.SetActive(true);
                //nxtButton.interactable = true;
            }
            else if(tEnemy.getStatus())
            {
                nxtButton.GetComponentInChildren<Text>().text = "NEXT";
                nxtButton.gameObject.SetActive(true);
                //nxtButton.interactable = true;
            }
        }
        Debug.Log("test2");
    }

    private void OnGUI()
    {
      
        PLabel0.SetText(pStats.getTemptStats().getHP(), true);
        ELabel0.SetText(tEnemy.getTemptStats().getHP(), true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
