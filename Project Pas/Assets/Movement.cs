using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
    
{
    [Header("config")]
    Rigidbody _rigidbody;
    [SerializeField] private float speed = 3000f;
    [SerializeField] private float jumpPower;
    bool jump;
    
    float hInput;
    float vInput;
    public Text countText;
    public Text winText;
    public int hitung;
    public Button exit, exitHome;
    public Image winImage;
    // Start is called before the first frame update
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        jump = Input.GetKeyDown(KeyCode.Space);
        Vector3 move = new Vector3(Vertical, 0f, -Horizontal);
        if (_rigidbody)
            _rigidbody.AddForce((move * speed) * Time.deltaTime);
        winText.enabled = false;
        exit.gameObject.SetActive(false);
        exitHome.gameObject.SetActive(false);
        setHitungText();
    }
    void Jump()
    {
        _rigidbody.AddForce(Vector3.up * jumpPower * Time.fixedDeltaTime, ForceMode.Impulse);
    }
     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin") 
        {
            other.gameObject.SetActive(false);
            hitung++;
           
        }
    }
    void setHitungText()
    {
        countText.text = "Kotak Apel : " + hitung.ToString();
  
          
        if(hitung >= 9)
        {
            exit.gameObject.SetActive(true);
            exitHome.gameObject.SetActive(true);
            winText.enabled = true;
            
            winText.text = "Your Win !!!";
            

        }
    }
}
