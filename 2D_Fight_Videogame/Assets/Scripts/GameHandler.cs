using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public int HP;
    private void Start() {
        HealthSystem healthSystem = new HealthSystem(HP);

        //Debug.Log("Health: " + healthSystem.GetHealt());
    }
}
