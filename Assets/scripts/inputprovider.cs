using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class inputprovider : SimulationBehaviour,INetworkRunnerCallbacks
{
    private InputSystem_Actions inputActions;
    private bool done;

    private void Start()
    {
        if(Runner != null) 
        {
            Inicialize();
        }
    }

    private void Update()
    {
        if (done == false && Runner != null)
        {
            Inicialize();
        }
    }
    private void Inicialize()
    {
        inputActions = new InputSystem_Actions();
        inputActions.playermovement.Enable();
        Runner.AddCallbacks(this);
        done = true;
    }

    private void OnDisable()
    {
        Runner.RemoveCallbacks(this);
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        var myInput = new MyInput();
        var actions = inputActions.playermovement;
        InputSystem.Update();
        myInput.buttons.Set(MyButtons.forward, actions.move.ReadValue<Vector2>().y > 0);
        myInput.buttons.Set(MyButtons.backward, actions.move.ReadValue<Vector2>().y < 0);
        myInput.buttons.Set(MyButtons.left, actions.move.ReadValue<Vector2>().x > 0);
        myInput.buttons.Set(MyButtons.right, actions.move.ReadValue<Vector2>().x < 0);
        input.Set(myInput);
    }

    public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
    }

    public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
    }

    public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
    {
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
    {
    }

    public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
    {
    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
    }

    public void OnConnectedToServer(NetworkRunner runner)
    {
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
    }
}
public struct MyInput: INetworkInput
{
    public NetworkButtons buttons;
    public Vector3 vector;
}

enum MyButtons
{
    forward = 0,
    backward =1,
    left = 2,
    right = 3,
}
