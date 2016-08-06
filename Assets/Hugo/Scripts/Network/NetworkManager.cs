﻿using UnityEngine;
using System.Collections;
using NDream.AirConsole;
using System;
using Newtonsoft.Json.Linq;

public class NetworkManager : MonoBehaviour
{
    void Start()
    {
        AirConsole.instance.onConnect += OnPlayerConnect;
        AirConsole.instance.onDisconnect += OnPlayerDisconnect;
		AirConsole.instance.onMessage += OnMessage;
    }

    private void OnMessage(int from, JToken data)
    {
		Debug.Log("message from player " + from + " data: " + data.ToString());
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
