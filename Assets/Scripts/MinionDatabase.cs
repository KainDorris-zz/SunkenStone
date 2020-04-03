using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

[CreateAssetMenu(fileName = "MinionDatabase", menuName = "SunkenStone/MinionDatabase", order = 0)]
public class MinionDatabase : ScriptableObject {
    [SerializeField] List<ScriptableObject> minionDatabase;
}
