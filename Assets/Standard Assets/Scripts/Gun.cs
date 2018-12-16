using Assets.Standard_Assets.Classes;
using UnityEngine;

namespace Assets.Standard_Assets.Scripts
{
    class Gun : MonoBehaviour
    {

        public float damage = 10f;
        public float range = 100f;

        public Camera fpsCam;
        public ParticleSystem MuzzleFlash;
        public GameObject ImpactEffect;
        public AudioSource audioSourceGunShot;
        public AudioSource audioSourceReload;
        public AudioClip GunShotSound;

        private float fireRate = Player.GetInstance().FireRate;

        private float nextTimeToFire = 0f;
        private bool IsReloading;

        public void Start()
        {
            Player.GetInstance().OnReload += Gun_OnReload;
        }

        private void Gun_OnReload(object sender, System.EventArgs e)
        {
            nextTimeToFire = Time.time + 1f / Player.GetInstance().ReloadSpeed;

            audioSourceReload.PlayDelayed(0.5f);
            IsReloading = true;
        }

        public void Update()
        {
            if (Time.time >= nextTimeToFire)
            {
                if (IsReloading)
                {
                    audioSourceReload.Stop();
                    IsReloading = false;
                }

                if (Input.GetButton("Fire1"))
                {
                    nextTimeToFire = Time.time + 1f / fireRate;
                    Shoot();

                    audioSourceGunShot.PlayOneShot(GunShotSound);
                }
            }
        }

        private void Shoot()
        {
            MuzzleFlash.Play();
            Player.GetInstance().Shoot();

            Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward, Color.green, 10);

            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                GameObject target = hit.transform.GetComponent<GameObject>();

                Enemy enemy = hit.transform.GetComponent<Enemy>();

                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }

                GameObject ImpactGameObject = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(ImpactGameObject, 0.5f);
            }


        }

    }
}
