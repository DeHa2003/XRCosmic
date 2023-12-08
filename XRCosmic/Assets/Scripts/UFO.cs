using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UFO : MonoBehaviour
{
    public float speed;
    public GameObject bullet;
    private Rigidbody rb;
    private GameObject player;
    private AudioSource audioSource;
    private GameObject effect;

    public AudioClip clip;
    public AudioClip clipBabah;

    [Header("Panel")]
    private GameObject panel;

    private TextMeshProUGUI textCoins;
    private int coins = 0;

    private bool go = true;
    private bool delete = false;
    private bool bull = true;
    // Start is called before the first frame update
    void Start()
    {
        //--------------------------UI----------------------------//
        
        panel = GameObject.Find("HeadCanvas").gameObject;
        textCoins = panel.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();

        //--------------------------------------------------------//

        effect = gameObject.transform.GetChild(3).gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = gameObject.transform.GetChild(0).gameObject.GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        GoUFO();
    }

    private void GoUFO()
    {
        Vistrel();
        if (go)
        {
            Vector3 vector = new Vector3(Random.Range(0, 200), 30, Random.Range(0, 200)) - transform.position;
            rb.AddForce(vector);
            go = false;
            Invoke(nameof(ReGoUFO), 20);
        }
        Invoke(nameof(GoUFO), Random.Range(5, 10));
    }

    private void ReGoUFO()
    {
        go = true;
    }

    private void Vistrel()
    {
        audioSource.clip = clip;
        audioSource.Play();


        Vector3 vector = player.transform.GetChild(0).transform.GetChild(0).transform.position;
        Vector3 vectorWorld = vector - gameObject.transform.position;
        GameObject spawnBullet = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        Rigidbody rb = spawnBullet.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.AddForce(vectorWorld * 1000);

        Destroy(spawnBullet, 3);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (bull)
            {
                coins = int.Parse(textCoins.text);
                coins += 1;
                textCoins.text = coins.ToString();
                bull = false;
            }

            delete = true;
            rb.useGravity = true;
            gameObject.transform.GetChild(3).gameObject.SetActive(true);
            effect.SetActive(true);
            Destroy(gameObject, 10);
        }

        if (other.CompareTag("Moon"))
        {
            if (delete)
            {
                effect.transform.localScale = new Vector3(20, 20, 20);


                audioSource.clip = clipBabah;
                audioSource.spatialBlend = 1f;
                audioSource.Play();

                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    gameObject.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().enabled = false;
                    Destroy(gameObject, 2);
                }
            }
        }
    }
}
