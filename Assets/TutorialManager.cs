using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] tutorialPages; // Array untuk menyimpan halaman tutorial
    private int currentPageIndex = 0; // Indeks halaman aktif

    [Header("Header dan Tutorial Text")]
    public string[] headerTexts; // Text untuk header tutorial
    public string[] tutorialTexts; // Text untuk deskripsi tutorial

    [Header("UI NYA")]
    public TextMeshProUGUI textKontainerTutorial; //textTutorialPage
    public GameObject triggerSkipTutorial; //panelSkipTutorial
    public GameObject kontainerTutorial; //kontainerPanelTutorial
    public Button tidakTriggerButton; //skiptutorialbutton
    public Button iyaTriggerButton; //nexttutorialbutton
    public GameObject endTutorial; //SelesaiTutorial

    [Header("Object Tutorial")]
    public GameObject[] tutorialObjects; // Array untuk objek tutorial

    [Header("Text simpan tutorial")]
    public TextMeshProUGUI[] textTutorial;

    [Header("Prev / Next Button")]
    public Button nextButton;
    public Button prevButton;

    [Header("Pindah tempat")]
    public RectTransform kontainerTutorialUI;
    public Vector2[] positions;

    private void Start()
    {
        currentPageIndex = 0; // Mulai dari halaman pertama

        // Nonaktifkan semua halaman terlebih dahulu
        for (int i = 0; i < tutorialPages.Length; i++)
        {
            tutorialPages[i].SetActive(false);
        }

        UpdatePage();
        nextButton.onClick.AddListener(NextPage);
        prevButton.onClick.AddListener(PrevPage);
        tidakTriggerButton.onClick.AddListener(SkipTutorial);
        iyaTriggerButton.onClick.AddListener(NextTutorial);
    }

    //



    public void OnEnable()
    {
        triggerSkipTutorial.SetActive(true);
        endTutorial.SetActive(false);
        kontainerTutorial.SetActive(false);
    }

    private void NextTutorial()
    {
        ResetTutorial();
    }

    private void ResetTutorial()
    {
        currentPageIndex = 0; // Set index ke 0

        UpdatePage();
    }

    public void SkipTutorial()
    {
        triggerSkipTutorial.SetActive(false);
        kontainerTutorial.SetActive(false);
        endTutorial.SetActive(false);
        // Aktifkan semua tutorialObjects
        foreach (GameObject obj in tutorialObjects)
        {
            obj.SetActive(true);
        }

        Debug.Log("Semua objek tutorial diaktifkan.");
    }

    private void UpdatePage()
    {
        Debug.Log("Page aktif: " + currentPageIndex); // Debug
        kontainerTutorial.SetActive(true);
        triggerSkipTutorial.SetActive(false);

        // Perbarui halaman aktif
        for (int i = 0; i < tutorialPages.Length; i++)
        {
            tutorialPages[i].SetActive(i == currentPageIndex);
        }

        // Validasi teks dan objek sebelum dipanggil
        if (currentPageIndex < textTutorial.Length)
        {
            SetTextForPageIndex(currentPageIndex);
        }

        if (currentPageIndex < tutorialObjects.Length)
        {
            SetObjectsForPageIndex(currentPageIndex);
        }

        endTutorial.SetActive(currentPageIndex == tutorialPages.Length - 1);

        prevButton.interactable = currentPageIndex > 0;
        nextButton.interactable = currentPageIndex < tutorialPages.Length - 1;

        // Validasi positions array sebelum MoveUI
        if (currentPageIndex < positions.Length)
        {
            MoveUI(positions[currentPageIndex]);
        }
    }

    private void SetObjectsForPageIndex(int index)
    {
        for (int i = 0; i < tutorialObjects.Length; i++)
        {
            if (i == index)
            {
                tutorialObjects[i].SetActive(true); // Aktifkan jika indeks sesuai
            }
            else
            {
                tutorialObjects[i].SetActive(false); // Nonaktifkan jika indeks tidak sesuai
            }
        }
    }

    private void SetTextForPageIndex(int index)
    {
        if (index >= 0 && index < textTutorial.Length)
        {
            // Mengatur teks header dan deskripsi ke UI yang berbeda
            textKontainerTutorial.text = GetHeaderTextForPageIndex(index);
            textTutorial[index].text = GetTutorialTextForPageIndex(index);
        }
    }

    // Fungsi untuk mendapatkan teks header
    // private string GetHeaderTextForPageIndex(int index)
    // {
    //     // Array untuk header teks
    //     string[] headerTexts =
    //     {
    //         "Generator",
    //         "Lamp Dioda",
    //         "Timer",
    //         "Logic Gate",
    //         "Kabel Tersisa",
    //         "Switch Lampu",
    //         "Positif dan Ground",
    //     };

    //     // Validasi index agar tidak keluar dari batas array
    //     if (index >= 0 && index < headerTexts.Length)
    //     {
    //         return headerTexts[index];
    //     }
    //     else
    //     {
    //         return "Header tidak ditemukan.";
    //     }
    // }
    private string GetHeaderTextForPageIndex(int index)
    {
        if (index >= 0 && index < headerTexts.Length)
        {
            return headerTexts[index];
        }
        else
        {
            return "Header tidak ditemukan.";
        }
    }

    // Fungsi untuk mendapatkan teks deskripsi tutorial
    private string GetTutorialTextForPageIndex(int index)
    {
        if (index >= 0 && index < tutorialTexts.Length)
        {
            return tutorialTexts[index];
        }
        else
        {
            return "Deskripsi tidak ditemukan.";
        }
    }

    // Fungsi untuk mendapatkan teks deskripsi tutorial
    // private string GetTutorialTextForPageIndex(int index)
    // {
    //     // Array untuk detail teks tutorial
    //     string[] tutorialTexts =
    //     {
    //         "Generator digunakan untuk menghasilkan energi listrik.",
    //         "Lamp Dioda merupakan fungsi utama untuk menyalakan lampu.",
    //         "Waktu tersisa untuk menyelesaikan level.",
    //         "Logic Gate digunakan untuk mengatur alur logika listrik.",
    //         "Jumlah kabel yang tersisa untuk digunakan.",
    //         "Switch digunakan untuk menyalakan lampu.",
    //         "+ atau positif  digunakan untuk mengalirkan listrik bertengangan positif, - atau ground untuk mengeluarkan tegangan negatif",
    //     };

    //     // Validasi index agar tidak keluar dari batas array
    //     if (index >= 0 && index < tutorialTexts.Length)
    //     {
    //         return tutorialTexts[index];
    //     }
    //     else
    //     {
    //         return "Deskripsi tidak ditemukan.";
    //     }
    // }

    private void NextPage()
    {
        if (currentPageIndex < tutorialPages.Length - 1)
        {
            currentPageIndex++;
            Debug.Log("Page selanjutnya: " + currentPageIndex); // Debug
            UpdatePage();
        }
    }

    private void PrevPage()
    {
        if (currentPageIndex > 0)
        {
            currentPageIndex--;
            Debug.Log("Page sebelumnya: " + currentPageIndex); // Debug
            UpdatePage();
        }
    }

    private void MoveUI(Vector2 targetPosition)
    {
        kontainerTutorialUI.anchoredPosition = targetPosition;
    }
}
