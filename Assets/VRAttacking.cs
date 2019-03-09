using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class VRAttacking : MonoBehaviour
{
    public SteamVR_Input_Sources input_Source;
    public SteamVR_Action_Boolean steam_action1;
    public SteamVR_Action_Boolean steam_action2;

    public Weapon weapon1;
    public Weapon weapon2;


    // Update is called once per frame
    void Update()
    {

        if (steam_action1.GetState(input_Source))
        {
            Debug.Log("111111");
           // weapon1.Attack();
        }

        if (steam_action2.GetState(input_Source))
        {
            Debug.Log("2222");

            //  weapon2.Attack();
        }



    }
}
