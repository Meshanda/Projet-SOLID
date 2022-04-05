using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using UnityEngine;


[CreateAssetMenu (menuName = "GoogleSheet/Reader")]
public class GoogleSheetReadValue : ScriptableObject
{
    [SerializeField] private string spreadSheetID;
    [SerializeField] private string rangeData;
    [SerializeField] private string sheetName;


    [SerializeField] private TupleSheetData sheetData;
    private GoogleSheetClient userConnection;
    
    public async Task<bool> ReadValueExe()
    {
        userConnection = GoogleSheetClient.Instance;
        if(userConnection.Connected)
        {
            return await ReadValue(sheetName, rangeData);
        }
        return false;
    }
    
    
    private async Task<bool> ReadValue(string sheetNameSheet, string rangeDataSheet)
    {
        if (!await userConnection.AwaitForConnection(2000))
        {
            return false;
        }
        
        // Define request parameters.
        var request = userConnection.Service.Spreadsheets.Values.Get(spreadSheetID, $"{sheetNameSheet}!{rangeDataSheet}");
        
        // Prints the names and majors of students in a sample spreadsheet
        ValueRange response = await request.ExecuteAsync();
        
        IList<IList<object>> values = response.Values;
        if (values != null && values.Count > 0)
        {
            GoogleSheetUtilities.StoreValue(values, sheetData);
        }
        else
        {
            Debug.Log("No Data found");
        }

        return true;
    }
}
