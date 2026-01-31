using UnityEngine;
using UnityEngine.UI;

public class KarakterOzellikleri : MonoBehaviour
{
    [Header("Character Creation UI Root")]
    public GameObject CharacterCreationUI;

    [Header("Prefab Listeleri")]
    public GameObject[] Saclar;
    public GameObject[] Burunlar;
    public GameObject[] Tenler;
    public GameObject[] Agizlar;

    [Header("Parentlar")]
    public Transform SacParent;
    public Transform BurunParent;
    public Transform TenParent;
    public Transform AgizParent;

    // UIManager bunlarý kullanýyor
    public static GameObject SacPrefab;
    public static GameObject BurunPrefab;
    public static GameObject TenPrefab;
    public static GameObject AgizPrefab;

    public static Color SacRenk = Color.white;
    public static Color TenRenk = Color.white;
    public static Color AgizRenk = Color.white;
    public static Color GozRenk = Color.white;

    public static bool IsChanged;

    public static GameObject SagGoz;
    public static GameObject SolGoz;


    GameObject aktifSac, aktifBurun, aktifTen, aktifAgiz;

    const string CREATED = "CharacterCreated";
    const string SAC_ID = "SacID";
    const string BURUN_ID = "BurunID";
    const string TEN_ID = "TenID";
    const string AGIZ_ID = "AgizID";

    void Start()
    {
        if (PlayerPrefs.GetInt(CREATED, 0) == 1)
        {
            Yukle();
            IsChanged = true;
            CharacterCreationUI.SetActive(false);
        }
        else
        {
            CharacterCreationUI.SetActive(true);
        }
    }

    void Update()
    {
        if (!IsChanged) return;

        // === HER PARÇA BAÐIMSIZ ===
        if (TenPrefab != null)
            Degistir(ref aktifTen, TenPrefab, TenParent, TenRenk);

        if (BurunPrefab != null)
            Degistir(ref aktifBurun, BurunPrefab, BurunParent, TenRenk);

        if (SacPrefab != null)
            Degistir(ref aktifSac, SacPrefab, SacParent, SacRenk);

        if (AgizPrefab != null)
            Degistir(ref aktifAgiz, AgizPrefab, AgizParent, AgizRenk);

        // === TÜM PARÇALAR VARSA KAYDET ===
        if (KarakterTamam())
        {
            Kaydet();
            CharacterCreationUI.SetActive(false);
        }

        IsChanged = false;
    }

    void Degistir(ref GameObject aktif, GameObject prefab, Transform parent, Color renk)
    {
        if (aktif != null)
            Destroy(aktif);

        aktif = Instantiate(prefab, parent);

        // ?? PREFAB AYARLARINI BOZMA
        aktif.transform.localPosition = prefab.transform.localPosition;
        aktif.transform.localRotation = prefab.transform.localRotation;
        aktif.transform.localScale = prefab.transform.localScale;

        Image img = aktif.GetComponent<Image>();
        if (img != null)
            img.color = renk;
    }

    bool KarakterTamam()
    {
        return SacPrefab != null
            && BurunPrefab != null
            && TenPrefab != null
            && AgizPrefab != null;
    }

    void Kaydet()
    {
        PlayerPrefs.SetInt(CREATED, 1);
        PlayerPrefs.SetInt(SAC_ID, IndexBul(Saclar, SacPrefab));
        PlayerPrefs.SetInt(BURUN_ID, IndexBul(Burunlar, BurunPrefab));
        PlayerPrefs.SetInt(TEN_ID, IndexBul(Tenler, TenPrefab));
        PlayerPrefs.SetInt(AGIZ_ID, IndexBul(Agizlar, AgizPrefab));
        PlayerPrefs.Save();
    }

    void Yukle()
    {
        SacPrefab = Saclar[PlayerPrefs.GetInt(SAC_ID)];
        BurunPrefab = Burunlar[PlayerPrefs.GetInt(BURUN_ID)];
        TenPrefab = Tenler[PlayerPrefs.GetInt(TEN_ID)];
        AgizPrefab = Agizlar[PlayerPrefs.GetInt(AGIZ_ID)];
    }

    int IndexBul(GameObject[] liste, GameObject obj)
    {
        for (int i = 0; i < liste.Length; i++)
            if (liste[i] == obj)
                return i;
        return 0;
    }
}
