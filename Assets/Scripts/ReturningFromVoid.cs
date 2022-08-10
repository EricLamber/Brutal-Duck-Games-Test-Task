using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturningFromVoid : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerControl>().Returning();
    }
}
