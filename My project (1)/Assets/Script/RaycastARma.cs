using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GERAL
{
    [RequireComponent(typeof(LineRenderer))]
    public class RaycastARma : MonoBehaviour
    {
        public Camera playerCamera;
        public Transform laserOrigin;
        public float gunRange = 50f;
        public float fireRate = 0.2f;
        public float laserDuration = 0.05f;
        public LayerMask hitcast;

        LineRenderer laserLine;
        float fireTimer;

        private int pontuacao;
        public Text txtPontuacao;
        public inimigo inimigo;
        public GameObject infoCristal;



        void Awake()
        {
            laserLine = GetComponent<LineRenderer>();
            inimigo = GetComponent<inimigo>();
        }

        void Update()
        {
            fireTimer += Time.deltaTime;
            if (Input.GetMouseButtonDown(0) && fireTimer > fireRate)
            {
                fireTimer = 0;
                laserLine.SetPosition(0, laserOrigin.position);
                Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit;

                if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange, hitcast))
                {

                   /* if(){

                    }
                    laserLine.SetPosition(1, hit.point);
                    inimigo.vida -= 10;
                    */

                }
                else
                {
                    laserLine.SetPosition(1, rayOrigin + (playerCamera.transform.forward * gunRange));
                }

                StartCoroutine(ShootLaser());
            }


        }

        IEnumerator ShootLaser()
        {
            laserLine.enabled = true;
            yield return new WaitForSeconds(laserDuration);
            laserLine.enabled = false;
        }
    }
}