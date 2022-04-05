using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GoogleSheetUtilities
{
    public static void StoreValue(IList<IList<object>> sheetData, TupleSheetData storing)
    {
        storing.Value.Clear();
        foreach (var data in sheetData)
        {
            if(data.Count == 2)
                storing.Value.Add((data[0].ToString(), float.Parse(data[1].ToString())));
        }
    }
}
