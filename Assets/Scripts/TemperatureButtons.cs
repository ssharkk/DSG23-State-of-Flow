using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureButtons : MonoBehaviour
{
    public void HeatUp()
    {
        Player[] allBulbs = FindObjectsOfType<Player>();
        foreach(Player bulb in allBulbs)
        {
            
            bulb.HeatUp();
        }
        Debug.Log("Heatin up");
    }

    public void CoolDown()
    {
        Player[] allBulbs = FindObjectsOfType<Player>();
        foreach (Player bulb in allBulbs)
        {
            bulb.CoolDown();
        }
        Debug.Log("Coolin down");
    }
}
