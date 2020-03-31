using UnityEngine;
using System.Collections.Generic;
using Colyseus;
using UnityEngine.Events;

class Message
{
    public int fieldId;
}

public class FieldChangeEvent : UnityEvent<string, int>
{
}

public class ColyseusClient : MonoBehaviour
{
    private Client _client;
    private Room<MyState> _room;

    public FieldChangeEvent changeField = new FieldChangeEvent();

    public string playerId;

    public void Start()
    {
        ConnectToServer();
        JoinOrCreateRoom();
    }
    private void ConnectToServer()
    {
        string endpoint = "ws://127.0.0.1:3000";
        _client = ColyseusManager.Instance.CreateClient(endpoint);
    }

    private async void JoinOrCreateRoom()
    {
        _room = await _client.JoinOrCreate<MyState>("myRoom", new Dictionary<string, object>() { });

        _room.State.field.OnChange += OnFieldChange;
        
        playerId = _room.SessionId;
    }

    public void SendMessage(int field)
    {
        if (_room != null)
        {
            _room.Send(new Message()
            {
                fieldId = field
            });
        }
    }
    private void OnFieldChange(string owner, int index)
    {
        changeField.Invoke(owner, index);
    }
}