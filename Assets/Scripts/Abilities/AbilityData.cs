using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAbilityData", menuName = "Battle/Ability")]
public class abilityData : ScriptableObject
{
    public string abilityName;
    public AbilityTargetType target;
    public AbilityType type;
    public AbilityStatType stat;
    public uint AbilityTime;
}

public enum AbilityTargetType
{
    SingleTarget,
    MultiTarget,
}

public enum AbilityType
{
   // HOT, // heal over time
   // DOT, // damage over time
   incremental,
   decremental,
}

public enum AbilityStatType
{
    health,
    attack,
    defense,
    revival,
}
