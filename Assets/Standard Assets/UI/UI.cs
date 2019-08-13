using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Standard_Assets.Scripts
{
    class UI : MonoBehaviour
    {
        public TextMeshProUGUI Health = null;
        public TextMeshProUGUI Ammo = null;
        public TextMeshProUGUI Reload = null;
        public TextMeshProUGUI PickUp = null;
        private bool showPickUpText;

        public void Start()
        {
            SetUIText();
            showPickUpText = false;
        }

        public void Update()
        {
      
        }

        public void FixedUpdate()
        {
            SetUIText();
            ShowPickUpText();
        }

        private void ShowPickUpText()
        {
            if (showPickUpText)
            {
                PickUp.color = Color.white;
            }
            else
            {
                PickUp.color = Color.clear;
            }
        }

        private void SetUIText()
        {
            Health.text = "Current Health: " + Player.GetInstance().CurrentHealth.ToString();
            Ammo.text = "Current Ammo: " + Player.GetInstance().AmmoCount.ToString();

            if (Player.GetInstance().AmmoCount <= Math.Floor(Player.GetInstance().AmmoCapacity * 0.2))
            {
                Reload.color = Color.white;
            }
            else
            {
                Reload.color = Color.clear;
            }
        }

        public void DisplayPickUpText() => showPickUpText = true;

        public void HidePickUpText() => showPickUpText = false;
    }
}
