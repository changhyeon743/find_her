using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterDB
{
    //[System.Serializable]
    public class Marfia_Base : MonoBehaviour
    {
        public enum MonsterState
        {
            Plowl,
            Trace,
            Attack
        }
        public MonsterState monsterState;
        protected GameObject player;
        public Vector2 targetPos;
        public SpriteRenderer srenderer;
        public Animator animator;

        public float direction = 1.0f;
        //private bool isIdle = true;
        //private float idleTime = 0.0f;

        public float attackDist = 1.2f; //공격 거리
        public float traceDist = 5.0f; //추적 거리

        public float stime = 0.0f;

        public virtual void SetState(){
            float dist = Vector2.Distance(transform.position, player.transform.position);
            if(dist < attackDist){
                monsterState = MonsterState.Attack;
                animator.SetInteger("State", 3);
            }
            else if(dist < traceDist){
                monsterState = MonsterState.Trace;
                animator.SetInteger("State", 2);
            }
            else{
                monsterState = MonsterState.Plowl;
                animator.SetInteger("State", 1);
            }
        }
        public virtual void SetBehaviour(){
            switch(monsterState){
                case MonsterState.Plowl:
                    Plowl();
                    break;
                case MonsterState.Trace:
                    Trace();
                    break;
                case MonsterState.Attack:
                    //Attack();
                    break;
            } 
        }
        //plowl
        private void Plowl(){
            transform.Translate(Vector2.right * direction * 2.0f * Time.deltaTime);
            SetDir();
        }
        public void SetDir(){
            if(direction > 0){
                srenderer.flipX = false;
            }
            else{
                srenderer.flipX = true;
            }
            if(transform.position.x > 7.5f){
                direction *= -1;
                transform.position = new Vector3(7.2f, transform.position.y, transform.position.z);
            }
            if(transform.position.x < -7.5f){
                direction *= -1;
                transform.position = new Vector3(-7.2f, transform.position.y, transform.position.z);
            }
        }
        public IEnumerator RandDir(){
            int randir = Random.Range(0, 2);
            float time = Random.Range(1.0f, 3.0f);
            direction = randir == 1 ? 1 : -1;
            yield return new WaitForSeconds(time);
            StartCoroutine(RandDir());
        }
        //trace
        private void Trace(){
            transform.Translate(targetPos * 2.0f * Time.deltaTime);
            SetFlip();
        }
        private void SetFlip(){
            if(player.transform.position.x - transform.position.x > 0){
                srenderer.flipX = false;
                direction = 1.0f;
            }
            else{
                srenderer.flipX = true;
                direction = -1.0f;
            }
        }
        public IEnumerator SetTarget(){
            targetPos = (player.transform.position - transform.position).normalized;
            yield return new WaitForSeconds(1.0f);
            StartCoroutine(SetTarget());
        }
        //attack
        public virtual void Attack() {
            Debug.Log("Virtual Func"); 
        } //추상 메서드, 재정의 필수
    }
}
