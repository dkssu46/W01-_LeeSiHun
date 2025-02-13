using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class TileLoader : MonoBehaviour
{
    public GameObject[] tilePrefab;
    public TextAsset[] csvFile;
    public GameObject player;
    [SerializeField]
    GameObject boundPrefab;
    public int boundDistance = 3;

    public Camera mainCamera;
    public float size = 5.0f; // 기본 값

    void Start()
    {
        LoadTilesFromCSV(PlayerPrefs.GetInt("Now",0));
        AddBounds(PlayerPrefs.GetInt("Now", 0));
        Debug.Log("Stage Loading: "+PlayerPrefs.GetInt("Now", 0));
        if (mainCamera != null)
        {
            mainCamera.orthographicSize = size;
            mainCamera.transform.position = new Vector3(size - 4f, 0, -10);
        }
    }

    //New Map Load
    public void LoadTilesFromCSV(int code)
    {
        if (csvFile == null)
        {
            Debug.LogError("CSV 파일이 할당되지 않았습니다.");
            return;
        }
        ClearTile();
        // CSV 파일 읽기
        string[] lines = csvFile[code].text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

        // 중앙 좌표 계산
        int rows = lines.Length;
        int cols = lines[0].Split(',').Length;
        size = lines.Length / 2 + 2;
        float startX = -cols / 2.0f + 0.5f;
        float startY = rows / 2.0f - 0.5f;

        // CSV 데이터를 파싱하여 타일 배치
        for (int y = 0; y < rows; y++)
        {
            string[] values = lines[y].Split(',');

            for (int x = 0; x < values.Length; x++)
            {
                string tileType = values[x];
                Vector2 position = new Vector2(startX + x, startY - y);

                GenerateTile(tileType, position);
            }
        }
    }
    void GenerateTile(string tileType, Vector2 pos)
    {
        int typeNumber = int.Parse(tileType);

        switch (typeNumber)
        {
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
                Instantiate(tilePrefab[typeNumber - 1], pos, Quaternion.identity, transform);
                break;
            case 52:
                GameObject wall = Instantiate(tilePrefab[4], pos, Quaternion.identity, transform);
                wall.SetActive(false);
                break;
            case 8:
                player.transform.position = pos;
                break;
        }
    }
    public void ClearTile()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
    void AddBounds(int code)
    {
        if (boundPrefab == null)
        {
            Debug.LogError("Bound 프리팹이 할당되지 않았습니다.");
            return;
        }

        // CSV 파일 읽기
        string[] lines = csvFile[code].text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

        // 중앙 좌표 계산
        int rows = lines.Length;
        int cols = lines[0].Split(',').Length;
        float startX = -cols / 2.0f + 0.5f;
        float startY = rows / 2.0f - 0.5f;

        // 테두리 추가
        for (int x = -boundDistance; x <= cols + boundDistance - 1; x++)
        {
            // 상단 테두리
            Vector2 topPosition = new Vector2(startX + x, startY + boundDistance);
            Instantiate(boundPrefab, topPosition, Quaternion.identity, transform);

            // 하단 테두리
            Vector2 bottomPosition = new Vector2(startX + x, startY - rows - boundDistance + 1);
            Instantiate(boundPrefab, bottomPosition, Quaternion.identity, transform);
        }

        for (int y = -boundDistance; y < rows + boundDistance; y++)
        {
            // 좌측 테두리
            Vector2 leftPosition = new Vector2(startX - boundDistance, startY - y);
            Instantiate(boundPrefab, leftPosition, Quaternion.identity, transform);

            // 우측 테두리
            Vector2 rightPosition = new Vector2(startX + cols + boundDistance - 1, startY - y);
            Instantiate(boundPrefab, rightPosition, Quaternion.identity, transform);
        }
    }
    //end
}
