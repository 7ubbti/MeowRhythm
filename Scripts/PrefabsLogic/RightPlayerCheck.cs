using System;
using System.Collections;
using DG.Tweening;
using SweetCandy.Basic;
using SweetCandy.Event;
using SweetCandy.Managers;
using UnityEngine;

namespace SweetCandy.PrefabsLogic
{
    public class RightPlayerCheck : MonoBehaviour
    {
        private ComboTimeEvent _comboEvent;
        [SerializeField] private float maxPerfectPosAbs;
        [SerializeField] private float minMissPosAbs;
        private void Awake()
        {
            _comboEvent = FindObjectOfType<ComboTimeEvent>();
        }
        
        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("up"))
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    JudgeTrigger(this.gameObject.transform.position.x, other.gameObject.transform.position.x,other.transform.localPosition);
                    GameObjectPool.Instance.CollectObject(other.gameObject);
                }
            }
            if (other.CompareTag("down"))
            {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    JudgeTrigger(this.gameObject.transform.position.x, other.gameObject.transform.position.x,other.transform.localPosition);
                    GameObjectPool.Instance.CollectObject(other.gameObject);
                }
            }
            if (other.CompareTag("left"))
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    JudgeTrigger(this.gameObject.transform.position.x, other.gameObject.transform.position.x,other.transform.localPosition);
                    GameObjectPool.Instance.CollectObject(other.gameObject);
                }
            }
            if (other.CompareTag("right"))
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    JudgeTrigger(this.gameObject.transform.position.x, other.gameObject.transform.position.x,other.transform.localPosition);
                    GameObjectPool.Instance.CollectObject(other.gameObject);
                }
            }
           
        }

        private void JudgeTrigger(float thisX, float otherX,Vector2 pos)
        {
            if (Math.Abs(thisX - otherX) < maxPerfectPosAbs)
            {
                PerfectTrigger(pos);
            }
            else if(Math.Abs(thisX-otherX)>minMissPosAbs)
            {
                MissTrigger(pos);
            }
            else
            {
                NormalTrigger(pos);
            }
        }

        private void MissTrigger(Vector2 pos)
        {
            _comboEvent.DoComboEffect(ComboEffect.Miss,pos);
            ScoreManager.Instance.ComBoHit(ComboEffect.Miss);
            this.gameObject.transform.DOPunchScale(new Vector3(0.8f,0.8f,1f),0.4f,2,0);
            AudioManager.Instance.PlaySound("拾取音效3");
        }

        private void PerfectTrigger(Vector2 pos)
        {
            _comboEvent.DoComboEffect(ComboEffect.Perfect,pos);
            ScoreManager.Instance.ComBoHit(ComboEffect.Perfect);
            this.gameObject.transform.DOPunchScale(new Vector3(0.8f,0.8f,1f),0.4f,2,0);
            AudioManager.Instance.PlaySound("拾取音效2");
        }

        private void NormalTrigger(Vector2 pos)
        {
            _comboEvent.DoComboEffect(ComboEffect.Good,pos);
            ScoreManager.Instance.ComBoHit(ComboEffect.Good);
            this.gameObject.transform.DOPunchScale(new Vector3(0.8f,0.8f,1f),0.4f,2,0);
            AudioManager.Instance.PlaySound("拾取音效1");
        }

        private void OnTriggerExit2D(Collider2D other)
        {
          
            /*
            isTrueDirection = false;
               isStartCheck = false;
            */
            
        }

        /*void Inspection()
        {
            if (this.gameObject.CompareTag("player1"))
            {
                switch (pickNum)
                {
                    case 0:
                        if (Input.GetKeyDown(KeyCode.W))
                        {
 
                            isTrueDirection = true;
                            isStartCheck = false;
                        }
                        else
                        {
                            isTrueDirection = false;
 
                        }
 
                        break;
                    case 1:
                        if (Input.GetKeyDown(KeyCode.A))
                        {
 
                            isTrueDirection = true;
                            isStartCheck = false;
                        }
                        else
                        {
                            isTrueDirection = false;
 
                        }
 
                        break;
                    case 2:
                        if (Input.GetKeyDown(KeyCode.S))
                        {
 
                            isTrueDirection = true;
                            isStartCheck = false;
                        }
                        else
                        {
                            isTrueDirection = false;
 
                        }
 
                        break;
                    case 3:
                        if (Input.GetKeyDown(KeyCode.D))
                        {
 
                            isTrueDirection = true;
                            isStartCheck = false;
                        }
                        else
                        {
 
                            isTrueDirection = false;
 
                        }
 
 
                        break;
                }
            }
 
            if (this.gameObject.CompareTag("player2"))
            {
                switch (pickNum)
                {
                    case 0:
                        if (Input.GetKeyDown(KeyCode.UpArrow))
                        {
 
                            isTrueDirection = true;
                            isStartCheck = false;
                        }
                        else
                        {
                            isTrueDirection = false;
 
                        }
 
                        break;
                    case 1:
                        if (Input.GetKeyDown(KeyCode.LeftArrow))
                        {
 
                            isTrueDirection = true;
                            isStartCheck = false;
                        }
                        else
                        {
                            isTrueDirection = false;
 
                        }
 
                        break;
                    case 2:
                        if (Input.GetKeyDown(KeyCode.DownArrow))
                        {
 
                            isTrueDirection = true;
                            isStartCheck = false;
                        }
                        else
                        {
                            isTrueDirection = false;
 
                        }
 
                        break;
                    case 3:
                        if (Input.GetKeyDown(KeyCode.RightArrow))
                        {
 
                            isTrueDirection = true;
                            isStartCheck = false;
                        }
                        else
                        {
 
                            isTrueDirection = false;
 
                        }
 
 
                        break;
                }
            }
 
        }*/
    }
}