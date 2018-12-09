using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Standard_Assets.Scripts
{
    class UI : MonoBehaviour
    {
        public Text Health;
        public Text Ammo;
        public Text Reload;

        public void Start()
        {
            SetUITextPosition();
            SetUIText();
        }

        public void Update()
        {
      
        }

        public void FixedUpdate()
        {
            SetUITextPosition();
            SetUIText();
        }

        private void SetUITextPosition()
        {
            Health.rectTransform.SetPositionAndRotation(new Vector3(90, 480, 0), new Quaternion(0, 0, 0, 0));
            Ammo.rectTransform.SetPositionAndRotation(new Vector3(90, 450, 0), new Quaternion(0, 0, 0, 0));
            Reload.rectTransform.SetPositionAndRotation(new Vector3(700, 240, 0), new Quaternion(0, 0, 0, 0));
        }

        private void SetUIText()
        {
            Health.text = "Current Health: " + Player.GetInstance().CurrentHealth.ToString();
            Ammo.text = "Current Ammo: " + Player.GetInstance().AmmoCount.ToString();

            if (Player.GetInstance().AmmoCount <= Math.Floor(Player.GetInstance().AmmoCapacity / 0.5))
            {
                Reload.text = "(R) Reload";
            }
            else
            {
                Reload.text = "";
            }
        }

    }
}
