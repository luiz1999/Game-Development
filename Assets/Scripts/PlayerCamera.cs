using UnityEngine;


public class PlayerCamera : MonoBehaviour
{
    private GameObject player;

    void Start()
    {

        player = GameObject.Find("Player");
    
    } 

    void Update()
    {
        if (player.transform.position.x >= transform.position.x)
       {
           transform.position = new Vector3(player.transform.position.x, 0, -10);
       }
    }

}

