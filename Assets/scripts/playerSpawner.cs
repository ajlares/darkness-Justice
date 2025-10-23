using UnityEngine;
using Fusion;

public class playerSpawner : SimulationBehaviour, IPlayerJoined
{
    public GameObject playerPrefab;

    public void PlayerJoined(PlayerRef player)
    {
        if(player == Runner.LocalPlayer)
        {
            Runner.Spawn(playerPrefab,Vector3.zero,Quaternion.identity,player);
        }
    }
}