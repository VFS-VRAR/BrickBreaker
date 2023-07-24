using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseZone : MonoBehaviour
{
    [SerializeField] private BrickBreakerManager bbm;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bbm.LooseGame();
    }
}
