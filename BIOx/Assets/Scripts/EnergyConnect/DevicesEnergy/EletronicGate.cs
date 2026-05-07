using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EletronicGate : ReceivesEnergy
{
    [SerializeField] private Transform gate;
    [SerializeField] private Transform pointOn;

    private Vector2 positionOff;
    private Vector2 positionOn;

    private Coroutine coroutine;
    private float speedMovement = 2.0f;

    void Start() {
        positionOff = gate.position;
        positionOn = pointOn.position;
    }
    protected override void deciveOFF() {
        base.deciveOFF();
        
        if(coroutine == null) {
            coroutine = StartCoroutine(GateToPoint(positionOff));
        }
        else {
            StopCoroutine(coroutine);
            coroutine = StartCoroutine(GateToPoint(positionOff));
        }
    }
    protected override void deciveON() {
        base.deciveON();

        if(coroutine == null) {
            coroutine = StartCoroutine(GateToPoint(positionOn));
        }
        else {
            StopCoroutine(coroutine);
            coroutine = StartCoroutine(GateToPoint(positionOn));
        }
    }

    private IEnumerator GateToPoint(Vector2 destino) {
        while(Vector2.Distance(gate.position, destino) > 0.01f) {
            gate.position = Vector2.MoveTowards(gate.position, destino, speedMovement*Time.deltaTime);

            yield return null;
        }
        gate.position = destino;
        coroutine = null;
    }
}
