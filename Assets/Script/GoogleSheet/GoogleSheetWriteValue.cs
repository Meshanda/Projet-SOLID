using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using UnityEngine;

[CreateAssetMenu (menuName = "GoogleSheet/Writer")]
public class GoogleSheetWriteValue : ScriptableObject
{
    private GoogleSheetClient userConnection;
    
    [SerializeField] private string spreadSheetID;
    [SerializeField] private string sheetName;
    [SerializeField] private string rangeData;
    
    
    [SerializeField] private PlayerNames playerNames;
    [SerializeField] private PlayerClasses playerClasses;

    
    
    public async void WriteValueExe()
    {
        userConnection = GoogleSheetClient.Instance;
        if(userConnection.Connected)
        {
            var result = CreateTab();
            await WriteValue(result);
        }
    }
    
    //todo try to make this usable in GoogleSheetUtilities
    private string[][] CreateTab()
    {
        string[][] playerNameClass = new string[playerNames.GetPlayerCount()][];

        for (int i = 0; i < Mathf.Min(playerNames.GetPlayerCount(), playerClasses.PlayerClassesList.Count); i++)
        {
            playerNameClass[i] = new []{ playerNames.Names[i], playerClasses.PlayerClassesList[i].name };
        }

        return playerNameClass;
    }
    
    private async Task<bool> WriteValue(params object[][] data)
    {
        if (!await userConnection.AwaitForConnection(2000))
        {
            return false;
        }

        var clearResult = await ClearSheet();

        if (clearResult)
        {
            ValueRange valueRange = new ValueRange();
            IList<IList<object>> values = new List<IList<object>>();
            foreach (var row in data)
            {
                values.Add(row.ToArray());
            }
        
            valueRange.Values = values;

            var valueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
            var request =
                userConnection.Service.Spreadsheets.Values.Update(valueRange, spreadSheetID, $"{sheetName}!{rangeData}");

            request.ValueInputOption = valueInputOption;

            var result = await request.ExecuteAsync();
        
            return true;
        }

        return false;
    }

    private async Task<bool> ClearSheet()
    {
        if (!await userConnection.AwaitForConnection(2000))
        {
            return false;
        }

        ClearValuesRequest clearValuesRequest = new ClearValuesRequest();

        var request =
            userConnection.Service.Spreadsheets.Values.Clear(clearValuesRequest, spreadSheetID, $"{sheetName}!{rangeData}");


        var result = await request.ExecuteAsync();
        
        return true;
    }
}
