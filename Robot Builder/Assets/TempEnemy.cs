using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempEnemy : MonoBehaviour
{
    TempStats tStats;

    // Start is called before the first frame update
    void Start()
    {
        
        tStats = new TempStats("ENEMY", 18, 6, 7, 6, 7, 6, 3);
    }
    public int getStance()
    {
        return this.tStats.getStance();
    }
    public void setStance(int x)
    {
        this.tStats.setStance(x);
    }
    public void PrintStats()
    {
        Debug.Log(tStats.getName() + " HP: " + tStats.getHP());
    }
    public TempStats getTemptStats()
    {
        return this.tStats;
    }
    public bool getStatus()//this defines if the subject is alive or dead;
    {
        return this.tStats.getDead();
    }
    public void getNewEnemy()
    {
        tStats = new TempStats("ENEMY", 18, 6, 7, 6, 7, 6, 3);
    }
    public void getNewEnemey(int a, int b)
    {
        tStats = new TempStats("ENEMY", 18, 6, 7, 6, 7, 6, 3);
    }
}
