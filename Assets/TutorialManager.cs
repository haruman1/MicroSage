using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public TutorialMainManager tutorialMainManager;
    public FieldTutorial fieldTutorial;
    public GameObject[] tutorialPages; // Array untuk menyimpan halaman tutorial
    private int currentPageIndex = 0; // Indeks halaman aktif

    [Header("Header dan Tutorial Text")]
    public string[] headerTexts; // Text untuk header tutorial
    public string[] tutorialTexts; // Text untuk deskripsi tutorial

    [Header("UI NYA")]
    public TextMeshProUGUI textKontainerTutorial; //textTutorialPage
    public GameObject triggerSkipTutorial; //panelSkipTutorial
    public GameObject kontainerTutorial; //kontainerPanelTutorial
    public GameObject endTutorial; //SelesaiTutorial

    [Header("Object Tutorial")]
    public GameObject[] tutorialObjects; // Array untuk objek tutorial
    private bool objectsActivated = false;

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
        OnEnable();
    }

    //



    public void OnEnable()
    {
        triggerSkipTutorial.SetActive(true);
        tutorialMainManager.DisableTile();
        endTutorial.SetActive(false);
        kontainerTutorial.SetActive(false);
    }

    public void NextTutorial()
    {
        UpdatePage();
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
        tutorialMainManager.EnableTile();
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

        // Atur teks dan objek untuk halaman aktif
        if (currentPageIndex < textTutorial.Length)
        {
            SetTextForPageIndex(currentPageIndex);
        }

        if (currentPageIndex < tutorialObjects.Length)
        {
            SetObjectsForPageIndex(currentPageIndex);
        }
        prevButton.interactable = currentPageIndex > 0;
        nextButton.interactable = currentPageIndex < tutorialPages.Length - 1;
        // Jika currentPageIndex >= 8, panggil UpdateTutorial
        if (currentPageIndex >= 8)
        {
            prevButton.interactable = false;
            tutorialMainManager.EnableTile();

            // Aktifkan semua tutorialObjects
            foreach (GameObject obj in tutorialObjects)
            {
                obj.SetActive(true);
            }
            objectsActivated = true; // Tandai objek sebagai aktif

            // Sesuaikan currentIndexTutorial berdasarkan currentPageIndex
            tutorialMainManager.currentIndexTutorial = currentPageIndex - 8;

            // Pastikan posisi diatur ulang berdasarkan currentIndexTutorial
            tutorialMainManager.UpdateTutorial();
        }
        else
        {
            tutorialMainManager.DisableTile();
            fieldTutorial.OnRestart();
            tutorialMainManager.tutupBawah.SetActive(false);

            objectsActivated = false;

            Debug.Log("UpdateTutorial tidak dipanggil karena currentPageIndex < 8.");
        }

        // Tampilkan atau sembunyikan end tutorial
        endTutorial.SetActive(currentPageIndex == tutorialPages.Length - 1);

        // Atur tombol navigasi


        // Perbarui posisi UI hanya jika posisi valid
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

    public void NextPage()
    {
        if (currentPageIndex < tutorialPages.Length - 1)
        {
            currentPageIndex++;
            Debug.Log("Page selanjutnya: " + currentPageIndex); // Debug
            UpdatePage();
        }
    }

    public void PrevPage()
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
