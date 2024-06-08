using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopKontrol : MonoBehaviour
{
    public UnityEngine.UI.Button btnExit;
    public UnityEngine.UI.Button btn;
    public UnityEngine.UI.Text zaman, can,durum;
    private Rigidbody rg;
    public float Hiz = 5000.0f;
    float zamanSayaci = 30;
    int canSayaci=3;
    bool oyunDevam = true;
    bool oyunTamam = false;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody> ();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (oyunDevam && !oyunTamam)
        {
            if (zamanSayaci >= 0)
            {
                zamanSayaci -= Time.deltaTime;
                zaman.text = (int)zamanSayaci + "";
                if (zamanSayaci < 0)
                {
                    oyunDevam = false;
                    durum.text = "GAME OVER";
                    btn.gameObject.SetActive(true);
                }
                    

            }
            
                
        }

    }
    void FixedUpdate() //her bir fizik hesaplamasýndan önce çaðrýlýr
    {
        if(oyunDevam && !oyunTamam)
        {
            float yatay = Input.GetAxis("Horizontal");
            float dikey = Input.GetAxis("Vertical");
            Vector3 kuvvet = new Vector3(-dikey, 0, yatay);
            rg.AddForce(kuvvet * Hiz);
        }
        else
        {
            rg.velocity = Vector3.zero;
            rg.angularVelocity = Vector3.zero;
        }
        
        
    }
    void OnCollisionEnter(Collision cls)
    {
        string objIsmi = cls.gameObject.name;
        int sayac=0;

        if (objIsmi=="bitis")
        {
            oyunTamam = true;
            durum.text = "TEBRÝKLER!!!";
            btn.gameObject.SetActive(true);
        }
        
        else if (objIsmi!="kucukZemin"&& objIsmi!="buyukZemin")
        {
            if(canSayaci>0)
            {
                canSayaci -= 1;
                can.text = canSayaci + "";
                if (canSayaci == 0)
                {
                    oyunDevam = false;
                    durum.text = "GAME OVER";
                    btn.gameObject.SetActive(true);
                }
                
            }
        }
            
    }
}
