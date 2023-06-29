using System;
using Commands;
using Controllers;
using Managers;
using UnityEngine;
using Strategy;

namespace Entities
{
    public class Boy : MonoBehaviour
    {

        private Animator anim;

        float lastTimeOfStandUp = 0;

        void Start()
        {
            anim = GetComponent<Animator>();
            lastTimeOfStandUp = Time.unscaledTime;
        }

        void Update()
        {
            if (Time.unscaledTime - lastTimeOfStandUp > 10) {
                anim.Play("standup_faint");
                lastTimeOfStandUp = Time.unscaledTime;
            }
        }

        private void OnTriggerEnter(Collider other) {
            String currentState = anim.GetCurrentAnimatorClipInfo(0)[0].clip.name;            
            if (other.gameObject.name.Contains("Bullet") && !other.gameObject.name.Contains("Enemy")){
                if ((currentState == "boy_standup_faint" || currentState == "boy_idle" || currentState == "boy_idle0")) {
                    anim.Play("damage");
                }
            }
        }
    }
}