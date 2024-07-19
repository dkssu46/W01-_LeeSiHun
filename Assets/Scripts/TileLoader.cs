using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class TileLoader : MonoBehaviour
{
    public GameObject[] tilePrefab;
    public TextAsset csvFile;      // �ν����Ϳ��� �Ҵ��� �� �ֵ��� TextAsset Ÿ������ ����
    public GameObject player;

    public Camera mainCamera;
    public float size = 5.0f; // �⺻ ��

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
            Debug.LogError("CSV ������ �Ҵ���� �ʾҽ��ϴ�.");
            return;
        }

        // CSV ���� �б�
        string[] lines = csvFile.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

        // �߾� ��ǥ ���
        int rows = lines.Length;
        int cols = lines[0].Split(',').Length;
        size = lines.Length / 2 + 2;
        float startX = -cols / 2.0f + 0.5f;
        float startY = rows / 2.0f - 0.5f;

        // CSV �����͸� �Ľ��Ͽ� Ÿ�� ��ġ
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
