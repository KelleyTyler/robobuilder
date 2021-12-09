using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Tyler Kelley
 *this is entirely for the purposes of working out a combat system where I don't have to worry at all about systems I'm not exactly sure of.
*:MonoBehaviour
*/
public class TempStats
{
    string thingName;
    int maxHp;//this is the theoretical max HP;
    int cHp; //this is real hp;
    int stance;
    int[] weap0;
        //armor stats;
    /*int armor0;
    int armor1;
    int armor2;*/

    int[] armor0;
    /*0=composite;
     * 1=heavy;
     * 2=energy;
     *  this.armor0 = armor0;
        this.armor1 = armor1;
        this.armor2 = armor2;
     * 
     */
  

    public TempStats(string name, int hp, int weap0, int weap1, int weap2, int armor0,int armor1, int armor2)
    {
        this.stance = 0;
        this.thingName = name;
        this.maxHp = hp;
        this.cHp = hp;
        this.weap0 = new int[] { weap0, weap1, weap2 }; 
        this.armor0 = new int[] { armor0, armor1, armor2 };
        
    }

    public string getName()
    {
        return this.thingName;
    }

    public string getHP()
    {
        return string.Format("HP:{0}/{1}",cHp,maxHp);
    }
    public bool getDead()
    {
        if (cHp > 0)
        {
            return false;
        }
        else
        {
            return true;
        }

    }

    public int[] getAtks()
    {
        return this.weap0;
    }
    public int[] getDefs()
    {
        return this.armor0;
    }
    public int getStance()
    {
        return this.stance;
    }
    public void setStance(int x)
    {
        this.stance = x;
    }
    public void doDamage(int dmg)//this is the damage!
    {
        if (dmg > 0 && cHp>0)
        {
            this.cHp = this.cHp - dmg;
        }
    }
}

