using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayer : MonoBehaviour
{
    TempStats tStats;
    //int stance;
    // Start is called before the first frame update
    void Start()
    {
        //stance = 0;
        tStats = new TempStats("Player", 20, 7, 5, 6, 7, 5, 6);
    }

    public void PrintStats()
    {
        Debug.Log(tStats.getName() + " HP: " + tStats.getHP());
    }
    public int getStance()
    {
        return this.tStats.getStance();
    }
    public void setStance(int x)
    {
        this.tStats.setStance(x);
    }
    public TempStats getTemptStats()
    {
        return this.tStats;
    }
    public bool getStatus()//this defines if the subject is alive or dead;
    {
        return this.tStats.getDead();
    }
    public void PlayerRet()
    {
        tStats = new TempStats("Player", 20, 7, 5, 6, 7, 5, 6);
    }
    public void PlayerRet(int a, int b)
    {
        tStats = new TempStats("Player", 20, 7, 5, 6, 7, 5, 6);
    }
}
