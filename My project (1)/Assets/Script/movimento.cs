using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class movimento : MonoBehaviour
{
    private CharacterController controller;
    [Header("Movimento Player")]
    public float speed;


    [Header("Gravidade Player")]
    public float fatorMultiplicativo;
    public float gravidade;
    private Vector3 velocidadePulo;
    public float jumpForce;



    [Header("Jump")]
    private bool sensor;
    public LayerMask layerPulo;
    public Transform posicaoSensor;



    [Header("Player Run")]
    public float baseSpeed;
    public float addSpeed;

    private int pontuacao;
    public Text txtPontuacao;

    [Header("player Slow")]
    public float lowSpeed;


    [Header("Anim")]
    public GameObject animMonstro;
    public bool colidir;

    [Header("Pegar Cristal")]
    public GameObject cristal1;
    public GameObject cristal2;
    
    public TextMeshProUGUI perguntasRespondidas, numeroDeCristais;
    public float contarCristais;
    

    [Header("Pause")]
    public GameObject painelPause;
    public bool pausado;

    [Header("Tiro")]
    public GameObject projetil;
    public Transform posTiro;

    [Header("Cursor")]
    public Texture2D cursorTexture;
    Vector2 cursorHotspot;

    [Header("Perguntas")]
    public GameObject painelPergunta, painelPergunta2, painelPergunta3;
    bool colidindoPergunta;
    Perguntas perg;
    public SpriteRenderer srPergunta1, srPergunta2, srPergunta3;

    [Header("Fade In")]
    public GameObject fadeInImage;

    [Header("Som")]
    public AudioClip somTiro;
    public  AudioSource audioTiro;

    public float vidaInicial, vidaAtual, porcentagemDeVida;

    public Image barraVermelha;

    private void Awake()
    {

        fadeInImage.SetActive(true);
        cristal1.SetActive(false);
      //  cristal2.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioTiro = GetComponent<AudioSource>();
        vidaAtual = vidaInicial;
        controller = GetComponent<CharacterController>();  //controle
        gravidade = Physics.gravity.y;
        speed = baseSpeed;
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
        Cursor.visible = false;
        perg = FindObjectOfType(typeof(Perguntas))  as Perguntas;
      
    }

    // Update is called once per frame


   

    // Update is called once per frame
    void Update()
    {
        MovimentacaoPlayer();

        GravidadePlayer();

        JumpPlayer();

        RunPlayer();

        sensor = Physics.CheckSphere(posicaoSensor.position, 0.5f, layerPulo);

        if (Input.GetKeyDown(KeyCode.E))
        {
            
            Destroy(cristal1.gameObject);
            contarCristais += 1;
            numeroDeCristais.text = contarCristais.ToString();

        }
        

        if (Input.GetKeyDown(KeyCode.J) && contarCristais >= 3)
        {
            SceneManager.LoadScene("fim");
        }

        if (Input.GetButtonDown("Fire1"))
        {
            
            Atirar();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausado == false)
            {
                painelPause.SetActive(true);
                Cursor.visible = true;                            
                Time.timeScale = 0;
                pausado = true;
            }
            else if(pausado == true )
            {
                painelPause.SetActive(false);
                Cursor.visible = false;                            
                Time.timeScale = 1;
                pausado = false;
            }

        }

        if(perg.contResp == 3)
        {
            cristal1.SetActive(true);
            cristal2.SetActive(true);

        }
       

        if(vidaAtual <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }   
    public void MovimentacaoPlayer()
    {
        float x = Input.GetAxis("Horizontal"); //controle horizontal

        float z = Input.GetAxis("Vertical"); //contorle vertical

        Vector3 move = transform.right * x + transform.forward * z; //movimentação
        controller.Move(move * speed * Time.deltaTime); //velocidade
    }

    public void JumpPlayer()  //JumpPlayer
    {
        if (Input.GetButtonDown("Jump") && sensor == true)
        {
            velocidadePulo.y = jumpForce;
        }
    }
    public void GravidadePlayer() //gravidade Player
    {
        velocidadePulo.y += gravidade * fatorMultiplicativo * Time.deltaTime;

        controller.Move(velocidadePulo * Time.deltaTime);
    }

    public void RunPlayer()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            speed = baseSpeed + addSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            speed = baseSpeed;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = baseSpeed - lowSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = baseSpeed;
        }


    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Nave")
        {
            SceneManager.LoadScene("CenaFinal");
        }
        if(coll.gameObject.tag == "Portao")
        {
            animMonstro.GetComponent<Animator>().SetBool("playerPerto", true);
            
        }
       
        if (coll.gameObject.tag == "Pergunta1")
        {
            if (colidindoPergunta == false)
            {
                painelPergunta.SetActive(true);
                colidindoPergunta = true;
                Time.timeScale = 0;
                Cursor.visible = true;
                
            }

        }
        if (coll.gameObject.tag == "dois")
        {
            if (colidindoPergunta == false)
            {
                painelPergunta2.SetActive(true);
                colidindoPergunta = true;
                Time.timeScale = 0;
                Cursor.visible = true;
            }

        }
        if (coll.gameObject.tag == "tres")
        {
            if (colidindoPergunta == false)
            {
                painelPergunta3.SetActive(true);
                colidindoPergunta = true;
                Time.timeScale = 0;
                Cursor.visible = true;
                
            }

        }
        if(coll.gameObject.tag == "Aranha")
        {
            vidaAtual -= 1;
            porcentagemDeVida = vidaAtual / vidaInicial;

            barraVermelha.fillAmount = porcentagemDeVida;
        }

    }

    private void OnTriggerExit(Collider coll)
    {
       if(coll.gameObject.tag == "Portao")
        {
            animMonstro.GetComponent<Animator>().SetBool("playerPerto", false);
        } 
      
       
       
    }

    public void FecharPainelPerguntas()
    {
        if(colidindoPergunta == true)
        {
            painelPause.SetActive(false);
            Cursor.visible = false;
            colidindoPergunta = false;
            Time.timeScale = 1;
            
        }
       
    }

    void Atirar()
    {

        Instantiate(projetil,posTiro.transform.position, posTiro.transform.rotation);
        audioTiro.Play();
        projetil.GetComponent<Rigidbody>().AddForce(Vector3.forward, ForceMode.Impulse);
    }
}

