    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Geral
{
    public class MovPlayer : MonoBehaviour
    {
        
        //public Transform target;

        private Rigidbody gravity;
        private float Fgravity;

        public float AdfS;
        private float velBase = 1000f;

        public float forwardSpeed, strafeSpeed = 7.5f, hoverSpeed = 5f;
        private float activeForwardSpeed, activeStrafeSpeed, activeHoverSpeed;
        private float forwardAcceleration = 2.5f, strafeAcceleration = 2f, hoverAcceleration = 2f;

        public float lookRotateSpeed = 90f;
        private Vector2 lookInput, screeCenter, mouseDistance;
            
        private float rollInput;
        public float rollSpeed = 90f, rollAccleration = 3.5f;

        
        public GameObject Part1;

       
        public GameObject Part2;

        public GameObject Part3;

        [Header("Cursor")]
        public Texture2D cursorTex;
        Vector2 cursorHotspot;

        [Header("Info")]
        public GameObject imagem;
        bool informando;

        public GameObject fade;
        public GameObject fadeOut;
        bool parado;
        public GameObject fadeCanvas;
        private void Awake()
        {
            Cursor.visible = false;
            fade.SetActive(true);
        }
        void Start()
        {
            Cursor.visible = true;

            gravity = GetComponent<Rigidbody>();

            gravity.useGravity = false;

            screeCenter.x = Screen.width * 0.5f;
            screeCenter.y = Screen.height * 0.5f;

            //Cursor.lockState = CursorLockMode.Confined;
            forwardSpeed = velBase;
            
            cursorHotspot = new Vector2(cursorTex.width / 2, cursorTex.height / 2);
            Cursor.SetCursor(cursorTex, cursorHotspot, CursorMode.Auto);

        }

        
        private void OnTriggerEnter(Collider coll)
        {
            if (coll.gameObject.CompareTag("planeta"))
            {
                StartCoroutine(fadeOutSair());
              
                
            }
        }


        void Update()
        {
            
            MovePlayer();
            lightSpeed();

            if (Input.anyKeyDown)
            {
                Cursor.visible = true;
            }
         
            if (Input.GetKeyDown(KeyCode.G))
            {
                if (informando == false)
                {
                    imagem.SetActive(true);
                    informando = true;
                }
                else if (informando == true)
                {
                    imagem.SetActive(false);
                    informando = false;
                }
            }
        }
        IEnumerator fadeOutSair()
        {
            forwardSpeed = 0;
            hoverSpeed = 0;
            strafeSpeed = 0;
            fadeCanvas.SetActive(true);
            fadeOut.SetActive(true);
            yield return new WaitForSeconds(4);
            SceneManager.LoadScene("SampleScene 1");
            Cursor.visible = false;
        }
        #region
        void MovePlayer()
        {
            lookInput.x = Input.mousePosition.x;
            lookInput.y = Input.mousePosition.y;

            mouseDistance.x = (lookInput.x - screeCenter.x) / screeCenter.y;
            mouseDistance.y = (lookInput.y - screeCenter.y) / screeCenter.y;

            mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

            rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAccleration * Time.deltaTime);

            transform.Rotate(-mouseDistance.y * lookRotateSpeed * Time.deltaTime, mouseDistance.x * lookRotateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);


            activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAcceleration * Time.deltaTime);
            activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAcceleration * Time.deltaTime);
            activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAcceleration * Time.deltaTime);

            transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
            transform.position += transform.right * (activeStrafeSpeed * Time.deltaTime) + (transform.up * activeHoverSpeed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                forwardSpeed += 600;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                forwardSpeed -= 600;
            }
         /*   if(Input.GetAxisRaw("Vertical") != 0)
            {              
                Part3.SetActive(true);                               
            }
            else
            {
                Part3.SetActive(false);
            }*/
            if (Input.GetKeyDown(KeyCode.W))
            {
                Part3.SetActive(true);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                Part3.SetActive(false);
            }
        }

        void lightSpeed()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                StartCoroutine("SL");
                

                forwardSpeed = AdfS;

                Part1.SetActive(true);
                Part2.SetActive(true);
            }
            if (Input.GetKeyUp(KeyCode.C))
            {
                forwardSpeed = velBase;
                Part1.SetActive(false);
                Part2.SetActive(false);
            }

        }

        IEnumerator SL()
        {
            yield return new WaitForSeconds(5f);


        }
        #endregion
    }
}

