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
    }

    public void CoolDown()
    {
        Player[] allBulbs = FindObjectsOfType<Player>();
        foreach (Player bulb in allBulbs)
        {
            bulb.CoolDown();
        }
    }
}
