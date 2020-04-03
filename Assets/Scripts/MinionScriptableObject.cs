using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

[CreateAssetMenu(fileName = "MinionScriptableObject", menuName = "SunkenStone/MinionScriptableObject", order = 0)]
public class MinionScriptableObject : ScriptableObject {
    
    [SerializeField] public string minionName;
    [SerializeField] public string minionDescription;
    
    [SerializeField] public int health;
    [SerializeField] public float damage;
}
