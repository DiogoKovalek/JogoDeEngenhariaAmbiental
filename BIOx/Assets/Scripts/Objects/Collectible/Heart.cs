using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour, ICollectible {
    [SerializeField] private int quantLife = 1;
    [SerializeField] private int quantPoints = 50;
    public void communicateWithPlayer(PlayerCommunicateCollectible playerCC) {
        playerCC.UpdLife(quantLife);
        playerCC.UpdPoint(quantPoints);
    }
}
