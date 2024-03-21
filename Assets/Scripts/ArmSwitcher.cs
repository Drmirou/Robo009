using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSwitcher : MonoBehaviour
{
    int totalArms = 1;
    public int currentArmsIndex;

    public GameObject[] arms;
    public GameObject armHolder;
    public GameObject currentArm;

    private void Start()
    {
        totalArms = armHolder.transform.childCount;
        arms = new GameObject[totalArms];

        for(int i = 0; i < totalArms; i++)
        {
            arms[i] = armHolder.transform.GetChild(i).gameObject;
            arms[i].SetActive(false);
        }
       
        arms[0].SetActive(true);
        currentArm = arms[0];
        currentArmsIndex = 0;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            if(currentArmsIndex <totalArms -1)
            {

            }
        }
    }
}
