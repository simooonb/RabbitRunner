using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Light))]
public class LightController : MonoBehaviour
{

    Light lt;
    public GameObject player;
    PlayerController playerController;

    void Awake()
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        lt = GetComponent<Light>();
    }

    public void setColor(Color color)
    {
        lt.color = color;
    }

}