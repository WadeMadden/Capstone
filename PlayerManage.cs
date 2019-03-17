using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManage : MonoBehaviour
{
    #region Singleton

    public static PlayerManage instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;


}
