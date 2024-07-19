using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class TileLoader : MonoBehaviour
{
    public GameObject[] tilePrefab;
    public TextAsset csvFile;      // 인스펙터에서 할당할 수 있도록 TextAsset 타입으로 선언
    public GameObject player;

    public Camera mainCamera;
    public float size = 5.0f; // 기본 값

    void Start()
    {
        LoadTilesFromCSV();
        if (mainCamera != null)
        {
            mainCamera.orthographicSize = size;
            mainCamera.transform.position = new Vector3(size - 4f, 0, -10);
        }
    }

    void LoadTilesFromCSV()
    {
        if (csvFile == null)
        {
            Debug.LogError("CSV 파일이 할당되지 않았습니다.");
            return;
        }

        // CSV 파일 읽기
        string[] lines = csvFile.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

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
                Instantiate(tilePrefab[typeNumber-1], pos, Quaternion.identity, transform);
                break;
            case 8:
                player.transform.position = pos;
                break;
        }
    }
}
