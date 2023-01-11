using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variables;

[CreateAssetMenu(fileName = "new GameDataSO", menuName = "GameData", order = 1)]
public class GameData : ScriptableObject
{
    [Header("Ship Stats")]
    public IntVariable HullHealth;
    [Space]
    [Header("Engine Stats")]
    public FloatVariable ThrottlePower;
    public FloatVariable RotationPower;

}
