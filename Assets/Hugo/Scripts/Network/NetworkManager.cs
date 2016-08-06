using UnityEngine;
using System.Collections;
using NDream.AirConsole;
using System;

public class NetworkManager : MonoBehaviour
{
    void Start()
    {
        AirConsole.instance.onConnect += OnPlayerConnect;
        AirConsole.instance.onDisconnect += OnPlayerDisconnect;
    }

    private void OnPlayerConnect(int device_id)
    {
        Debug.Log("Player connected id: " + device_id);
    }

    private void OnPlayerDisconnect(int device_id)
    {
        Debug.Log("Player disconnected id: " + device_id);
    }
}
