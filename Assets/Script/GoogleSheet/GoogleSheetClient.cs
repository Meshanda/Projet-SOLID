using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Util.Store;
using UnityEngine;

public class GoogleSheetClient : MySingleton<GoogleSheetClient>
{
    protected override bool DoDestroyOnLoad => true;
    
    [SerializeField] private string[] _scopes = { SheetsService.Scope.Spreadsheets };
    [SerializeField] private string _credentialsPath;
    [SerializeField] private string _fileName;
    
    public SheetsService Service;
    private bool _connected;
    
    public bool Connected
    {
        get => _connected;
    }

    public async  Task<bool> Connect()
    {
        if(!_connected)
        {
            _connected = await ConnectToSheet();
        }
        return _connected;
    }
    
    private async Task<bool> ConnectToSheet()
    {
        string directoryPath = Path.Combine(Application.streamingAssetsPath, _credentialsPath);
        string credentialsPath = Path.Combine(directoryPath, _fileName);
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        UserCredential userCredential;
        GoogleClientSecrets clientSecrets;
        using (var stream =
            new FileStream(credentialsPath, FileMode.Open, FileAccess.Read))
        {
            clientSecrets = await GoogleClientSecrets.FromStreamAsync(stream);
        }
        
        // The file token.json stores the user's access and refresh tokens, and is created
        // automatically when the authorization flow completes for the first time.
        string credPath = Path.Combine(Application.persistentDataPath, _credentialsPath);
        userCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(
            clientSecrets.Secrets,
            _scopes,
            "user",
            CancellationToken.None,
            new FileDataStore(credPath, true)).Result;
        Debug.Log("Credential file saved to: " + credPath);
        
        // Create Google Sheets API service.
        Service = new SheetsService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = userCredential
        });

        return true;
    }

    public async Task<bool> AwaitForConnection(int timeout)
    {
        CancellationTokenSource source = new CancellationTokenSource(timeout);

        while (!_connected)
        {
            await Task.Delay(16);
            if (source.Token.IsCancellationRequested)
            {
                return false;
            }
        }

        return true;
    }
}
