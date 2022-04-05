using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu (menuName = "GoogleSheet/LinkData")]
public class LinkSheetFloatData : ScriptableObject
{
    [SerializeField] private TupleSheetData _data;
    
    [SerializeField] private List<string> keyName;
    [SerializeField] private List<FloatVariable> value;

    private Dictionary<string, FloatVariable> dataToLink;

    public void Init()
    {
        dataToLink = new Dictionary<string, FloatVariable>();
        for (int i = 0; i < keyName.Count; i++)
        {
            dataToLink.Add(keyName[i], value[i]);
        }
    }

    public void LinkData()
    {
        foreach (var tuple in _data.Value)
        {
            if (dataToLink.ContainsKey(tuple.Name))
            {
                dataToLink[tuple.Name].Value = tuple.Value;
            }
        }
    }
}
