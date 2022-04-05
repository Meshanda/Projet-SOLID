using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Variables/TupleSheetData", fileName = "New TupleSheetData")]
public class TupleSheetData : ScriptableObject
{
    public List<(string Name, float Value)> Value = new List<(string, float)>();
}
