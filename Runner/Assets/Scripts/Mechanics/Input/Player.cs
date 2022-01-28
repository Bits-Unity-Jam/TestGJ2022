
using Mechanics.Interfaces;
using Mechanics.Management;
using Mechanics.Movement;
using Mechanics.Movement.Human;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Mechanics.Input
{
    //—крипт, €кий керуватиме персонажем через д≥њ користувача.
    //якщо ми зробимо скрипт дл€ бот≥в штучного ≥нтелекту, в≥н взаЇмод≥€тиме з персонажем так само, т≥льки зам≥сть прийому вже готових значень з клав≥атури гравц€, сам скрипт буде њх розраховувати
    public class Player : MonoBehaviour
    {

        public GameObject congratulations;
        [SerializeField] GameObject diePanel;
        public TextMeshProUGUI countText;
        public TextMeshProUGUI congratText;
        public TextMeshProUGUI bestScore;
        public TextMeshProUGUI endCountText;
        private int count;
        private IMovementController movementController;
        IDying dying;

        [SerializeField]
        float replayDelay;



        private void Start()
        {
            count = 0;

            movementController = gameObject.GetComponent<IMovementController>();
            dying = gameObject.GetComponent<IDying>();
            if (dying != null)
            {
                dying.NotifyAboutDeath(OnDied);
            }
        }

        private void OnDestroy()
        {
            dying.DontNotifyAboutDeath(OnDied);
        }

        public void OnDied(object sender, EventArgs args)
        {
            //diePanel.SetActive(true);
            //SceneLoader.Instance.Replay(replayDelay);
            //ScoreManager.Instance.CheckNewBestScore(count);

            //endCountText.text = "Your score: " + count.ToString();
            //bestScore.text = "Best score: " + ScoreManager.Instance.BestScore;

            //diePanel.SetActive(true);
            Invoke("EndGame", replayDelay);





        }

        private void EndGame()
        {
            if (count > ScoreManager.Instance.BestScore)
                congratulations.SetActive(true);
            congratText.text = "Congratilations!\nYour new\nbest score: " + count.ToString();
            ScoreManager.Instance.CheckNewBestScore(count);

            CoinManager.Instance.CoinCount = count;

            endCountText.text = "Your score: " + count.ToString();
            bestScore.text = "Best score: " + ScoreManager.Instance.BestScore;
           
            

            diePanel.SetActive(true);
        }

        private void Update()
        {
            //float direction = UnityEngine.Input.GetAxis("Horizontal");
            float direction;
            float jump = 0; ;
            if (SimpleJoystick.instance.Direction.x > 0.5 )
                direction = 1;
            else if (SimpleJoystick.instance.Direction.x < -0.5)
                direction = -1;
            else
                direction = 0;
            if (SimpleJoystick.instance.Direction.x < 0.5 && SimpleJoystick.instance.Direction.x > -0.5 && SimpleJoystick.instance.Direction.y > 0)
            jump = 1;

            if (jump > 0.01f) movementController.Jump();
            movementController.Direction = direction;

            if (UnityEngine.Input.GetKey(KeyCode.LeftShift))
            {
                movementController.Slide();
            }

        }
        void OnTriggerEnter(Collider other)
        {
            // ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
            if (other.gameObject.CompareTag("PickUp"))
            {
                other.gameObject.SetActive(false);

                // Add one to the score variable 'count'
                count = count + 1;

                // Run the 'SetCountText()' function (see below)
                SetCountText();
            }
            if (other.gameObject.CompareTag("BoostMode"))
            {
                other.gameObject.SetActive(false);
                
                var humancontroller = GetComponent<HumanController>();
                humancontroller.ActivateBoostMode();
            }


            void SetCountText()
            {
                countText.text = "Score: " + count.ToString();
            }
             
        }
    }
}