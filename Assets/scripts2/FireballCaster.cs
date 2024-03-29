using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public FireBall fireBallPrefab;
    public Transform FireBallSourceTransform;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(fireBallPrefab, FireBallSourceTransform.position, FireBallSourceTransform.rotation);
        }
    }
}
