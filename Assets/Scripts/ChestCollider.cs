using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.name == "Player")
        {
            Debug.Log("±¶œ‰≈ˆµΩ¡ÀÕÊº“");
            GameManager.instance.NextLevel();
        }
    }
}
