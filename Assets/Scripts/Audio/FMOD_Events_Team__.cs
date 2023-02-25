using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity; 

public class FMOD_Events : MonoBehaviour
{
    ///Player///

    // Gas

    [field: Header("GasTransition")]

    [field: SerializeField] public EventReference GasTransition { get; private set; }

    [field: Header("ContinousGas")]

    [field: SerializeField] public EventReference ContinousGas  { get; private set; }

    [field: Header("Gas_Hit")]

    [field: SerializeField] public EventReference Gas_Hit { get; private set; }

    //Ice 

    [field: Header("IceContinous")]

    [field: SerializeField] public EventReference IceContinous  { get; private set; }

    [field: Header("FreezeTransition")]

    [field: SerializeField] public EventReference  { get; private set; }

    //Liquid

    [field: Header("Liquid_Continous")]

    [field: SerializeField] public EventReference Liquid_Continous  { get; private set; }

    [field: Header("Liquid_Hit")]

    [field: SerializeField] public EventReference Liquid_Hit { get; private set; }

//Ambience 

    [field: Header("Vending_Machine_Ambi")]

    [field: SerializeField] public EventReference Vending_Machine { get; private set; }

//Bruce Oldman LEE

[field: Header("Grunts")]

[field: SerializeField] public EventReference Grunts { get; private set; }

[field: Header("Laugh")]

[field: SerializeField] public EventReference Vending_Machine { get; private set; }

[field: Header("Attacking")]

[field: SerializeField] public EventReference Attacking { get; private set; }

//Music

[field: Header("GasTransition")]

    [field: SerializeField] public EventReference GasTransition { get; private set; }

    [field: Header("")]

    [field: SerializeField] public EventReference acornDropped { get; private set; }

    [field: Header("Ambience")]

    [field: SerializeField] public EventReference ambience { get; private set; }

    [field: Header("Root SFX")]

    [field: SerializeField] public EventReference RootMovement { get; private set; }

    [field: Header("Object SFX")]

    [field: SerializeField] public EventReference ObjectInteracted { get; private set; }

    [field: SerializeField] public EventReference ObjectIdle { get; private set; }

    public static FMOD_Events instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Fmod Events instancein the Scene.");
        }
        instance = this;
    }
}
