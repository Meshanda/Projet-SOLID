using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GoogleSheetManager : MonoBehaviour
{
    private GoogleSheetClient _clientToConnect;
    [SerializeField] private List<GoogleSheetReadValue> dataToCatch;
    [SerializeField] private List<LinkSheetFloatData> linkData;
    [SerializeField] private GoogleSheetWriteValue writerSheet;
    private bool connected;
    
    // Start is called before the first frame update
    void Start()
    {
        _clientToConnect = GoogleSheetClient.Instance;
        ConnectClient();
    }

    private async void ConnectClient()
    {
        
        connected = await _clientToConnect.Connect();
    }


    public async void StartReadingValue()
    {
        if (connected)
        {
            for ( int i = 0; i < dataToCatch.Count; i++)
            {
                var reader = dataToCatch[i];
                bool valueReaded = await reader.ReadValueExe();

                if (valueReaded)
                {
                    linkData[i].Init();
                    linkData[i].LinkData();
                }
            }
        }
    }
}
