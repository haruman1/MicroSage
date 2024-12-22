using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMainManager : MonoBehaviour
{
    public int currentIndexTutorial = 0;
    public FieldTutorial fieldTutorial;

    [SerializeField]
    private TutorialManager _tutorialManager;

    [Header("Tile")]
    public GameObject[] tileAwal;
    public GameObject[] tileTujuan;

    [Header("Penutup Tutorial")]
    public GameObject tutupBawah;
    public RectTransform penutupBawah;

    public Vector2[] positionsBawah;

    public void Start()
    {
        currentIndexTutorial = 0;
        tutupBawah.SetActive(false);
    }

    public void DisableTile()
    {
        foreach (GameObject tileawal in tileAwal)
        {
            tileawal.SetActive(false);
        }
        foreach (GameObject tiletujuan in tileTujuan)
        {
            tiletujuan.SetActive(false);
        }
    }

    public void EnableTile()
    {
        foreach (GameObject tileawal in tileAwal)
        {
            tileawal.SetActive(true);
        }
        foreach (GameObject tiletujuan in tileTujuan)
        {
            tiletujuan.SetActive(true);
        }
    }

    public void UpdateTutorial()
    {
        tutupBawah.SetActive(true);
        List<int> solvedConnectionIds = fieldTutorial.GetSolvedConnections();

        if (solvedConnectionIds.Count > 0)
        {
            foreach (int connectionId in solvedConnectionIds)
            {
                switch (connectionId)
                {
                    case 1:
                        currentIndexTutorial = (currentIndexTutorial == 1) ? 1 : 0;
                        break;
                    case 2:
                        currentIndexTutorial = (currentIndexTutorial == 2) ? 2 : 1;
                        break;
                    case 3:
                        currentIndexTutorial = (currentIndexTutorial == 3) ? 3 : 2;
                        break;
                    case 4:
                        currentIndexTutorial = (currentIndexTutorial == 4) ? 4 : 3;
                        break;
                    case 5:
                        currentIndexTutorial = (currentIndexTutorial == 5) ? 5 : 4;
                        break;
                    case 6:
                        currentIndexTutorial = (currentIndexTutorial == 6) ? 6 : 5;
                        break;
                    default:
                        Debug.Log($"Unknown Solved Connection: {connectionId}");
                        break;
                }

                Debug.Log("Mengulang index di foreach ke " + currentIndexTutorial);
                MovePanel(positionsBawah[currentIndexTutorial]); // Perbarui posisi
            }
        }
        else
        {
            Debug.Log("Mengulang index ke " + currentIndexTutorial);
            if (currentIndexTutorial == 0) // Jika indeks kembali ke 0
            {
                ResetPositions(); // Reset posisi atau atribut lainnya
            }
            else
            {
                MovePanel(positionsBawah[currentIndexTutorial]); // Perbarui posisi
            }
        }
    }

    public void MovePanel(Vector2 positions)
    {
        Debug.Log("Move Panel to: " + positions);
        penutupBawah.anchoredPosition = positions;
    }

    private void ResetPositions()
    {
        Debug.Log("Mereset posisi bawah ke kondisi awal.");

        // Atur ulang posisi awal sesuai kebutuhan
        if (positionsBawah.Length > 0)
        {
            MovePanel(positionsBawah[0]); // Reset ke posisi awal
        }

        // Tambahkan logika lain jika perlu untuk mengatur ulang elemen UI atau atribut
    }
}
