using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BallController : MonoBehaviour
{
    public static event Action OnScore;
    public static event Action OnFail;
    public static event Action<GameObject> OnCoinCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.CompareTo("ScoreLine") == 0)
        {
            OnScore.Invoke();
        }
        else if (other.gameObject.name.CompareTo("DeathLine") == 0)
        {
            OnFail.Invoke();
        }
        else if (other.gameObject.CompareTag("Collectable"))
        {
            OnCoinCollected.Invoke(other.gameObject);
            return;
        }

        GameObject.Destroy(this.gameObject);
    }
}
