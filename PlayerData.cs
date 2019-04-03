using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int health;
    public int gems;
    public float[] position;
    public int actScene;

    public PlayerData (Vector3 player, int mortHealth, int activeScene)
    {
        health = 3;
        gems = 0;
        position = new float[3];
        position[0] = player.x;
        position[1] = player.y;
        position[2] = player.z;
        actScene = activeScene;
    }
}
