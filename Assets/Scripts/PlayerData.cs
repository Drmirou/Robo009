using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    public float HP = 1.0f;
    public float Points = 1.0f;
}
// jag kommer anv�nda textmeshpro men om ni g�r custom testmesh so kan jag �ndra p� det
