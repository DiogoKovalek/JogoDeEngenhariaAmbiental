using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMoveAtPoint : MonoBehaviour
{
    private Vector2 target;
    private float speed;
    private Animator anim;
    private SpawnerJabutiPath controlerPath;
    private int indexTarget;

    void Awake() {
        Enemy enemy = GetComponent<Enemy>();
        speed = enemy.GetSpeed();
        anim = enemy?.GetAnimator();
    }

    public void initAtributesForMove(Vector2 target, int indexTarget) {
        this.target = target;
        this.indexTarget = indexTarget;
        initAnimation();
    }
    private void initAnimation() {
        if(anim != null) {
            Vector2 diretion = (target - (Vector2) transform.position).normalized;
            anim.SetFloat("MoveX", diretion.x);
            anim.SetFloat("MoveY", diretion.y);
        }
        else {
            anim = GetComponent<Animator>();
            if(anim != null) initAnimation();
            else Debug.LogError("Nao encontrou o animator");
        }
    }

    void Update() {
        if(Vector2.Distance(transform.position, target) >= 0.01f) {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        else {
            transform.position = target;

            //Pedir outro caminho para seguir
            indexTarget++;
            target = controlerPath.GetTargetByIndex(ref indexTarget);
            initAnimation();
        }
    }
    public void AtributeControler(SpawnerJabutiPath controlerPath) {
        this.controlerPath = controlerPath;
    }

    public void SetSpeed(float speed) {
        this.speed = speed;
    }

}
