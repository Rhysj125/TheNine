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

        private float fireRate = Player.GetInstance().FireRate;

        private float nextTimeToFire = 0f;

        public void Start()
        {
            Player.GetInstance().OnReload += Gun_OnReload;
        }

        private void Gun_OnReload(object sender, System.EventArgs e)
        {
            nextTimeToFire = Time.time + 1f / Player.GetInstance().ReloadSpeed;
        }

        public void Update()
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
            }
        }

        private void Shoot()
        {
            MuzzleFlash.Play();
            Player.GetInstance().Shoot();

            RaycastHit hit;
            if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                GameObject target = hit.transform.GetComponent<GameObject>();

                GameObject ImpactGameObject = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(ImpactGameObject, 0.5f);
            }


        }

    }
}
