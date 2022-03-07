using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class DragAndShoot : MonoBehaviour
{
    /* TODO: Firstly I need to use github. After that I need to open the assets I want to use in an empty project.
     Always add gitignore.
     */
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;
    private AudioSource audioSource;
    public AudioClip shootSound;
    public AudioClip stickSound;
    public AudioClip stickSoundCylinder;



    private Rigidbody rb;

    private bool isShooted;

    public float forceMultiplier = 7;

    // Impact yarış oyunu, çok geliştirici oldu. Gameplayde her detayı düşünmek değil.
    // Gameplay kısmındaki şeyleri kodlamak daha çok hoşuma gitti.
    // Impact dönemi unity, üniversite, udemyler youtube'lar.
    // Kesinlikle GameJam'lere katıl. Network çok önemli.
    /// <summary>
    /// Global Game Jam
    /// Her katıldığında farklı insanlarla katılmak. Farklı insanlar tanımak.
    /// Motorlar yaklaşık olarak birbirine benzer.
    /// Birini öğrenip uzmanlaşırsanız diğer motora geçmeniz zor olmaz.
    /// ----
    /// Sinematik bir oyun.
    /// Lineer bir oyun.
    /// *** 
    /// Gameplay programmer gamer'dır yoksa ne işi var.
    /// Kesinlikle oyun geliştirme içinde çalışan herkesin gamer olması gerekiyor bence dedi.
    /// Üzerine düşünür nasıl olmuş, nasıl daha iyi olabilir.
    /// ---
    /// Gamer oynar, gameplay programmer oynamak için kodlar.
    /// ---
    /// Ben nasıl başladım. Herşeyinizi deli gibi arşivleyin. Sizden çıkan her şeyi deli gibi arşivleyin. Videosu, kodu vs olsun.
    /// Bunların hepsini portfolyonuza arşivleyin.
    /// Zaten seviyorsanız portfolyonuz dolu olur.
    /// Halihazırda olan arşivinizi güzelce sunduğunuzda artık sizi almıyorlarsa kendileri bilir. Kendinizi rahat hissedebilirsiniz.
    /// Gameplay prog ise gameplay öncelikle olduğu ürünler paylaşın.
    /// Gameplay prog ama ne shader yapıyorum üf demek saçma olur.
    /// Bir projeye başlayınca bitirin.
    /// Bitir, arşivle.
    /// ---
    /// OOP biliyor olmanız lazım iyice.
    /// 
    /// Direk YouTube.
    /// OOP'nin içinden geçiyor olmanız lazım.
    /// Pattern'ları da öğrenmek için youtube'a başvurabiliriniz.
    /// 
    /// motordan motora çok farketmez. Ama gerçekten program yazdığınız bir motor olduğunuz bir motor old varsayıyorum.
    /// 
    /// base'inde ne yapıyor. Atamızdan böyle gördükten ziyade Nasıl çalıştığını anla. 
    /// unitydfe şunu yapıyorduk unrealda da ha şöyleymiş.
    /// 
    /// ---
    /// 
    /// Önerdiği kitap YouTube : )
    /// 
    /// Gazi bilgisayar mezunu, yüksek lisans grafik...
    /// 
    /// 
    /// Algoritma kurma becerini geliştirmesi çok önemli temel programlama derslerinin
    /// günün sonunda yaptığın iş bir sorunu çözmek.
    /// 
    /// Algoritmalar...
    /// 
    /// // Companionları 
    /// 
    /// ***
    /// Rutin işlerin yok olacağını ileri sürdü Oğuz hoca.
    /// Hukuk programcılığı kanun programcılığı gibi şimdi bize garip gelen meslekler...
    /// 
    /// En iyi arkadaşımın yapay zeka olduğunü düşünmek...
    /// 
    /// </summary>

    // Start is called before the first frame update
    void Start()
    {

        audioSource = GameObject.Find("Game Manager").GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        mouseReleasePos = Input.mousePosition;
        Shoot(mousePressDownPos - mouseReleasePos);
        audioSource.PlayOneShot(shootSound, 1f);
    }

    void Shoot(Vector3 force)
    {
        forceMultiplier = 7;
        if (isShooted)
        {
            return;
        }

        rb.AddForce(new Vector3(force.x, force.y, force.y) * forceMultiplier);
        isShooted = true;
    }

    // Küçük firmalar biz indieler, onları eksik yönlerinden vurmalıyız.
    // Senaryo. Küçük bir şirketken orasına zaman ayırıp orasından rekabet edebilirsiniz, dediler.

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            audioSource.PlayOneShot(stickSound, 1);
        }
        else if (collision.gameObject.CompareTag("Wall Cylinder"))
        {
            audioSource.PlayOneShot(stickSoundCylinder, 1);
        }
    }

}
