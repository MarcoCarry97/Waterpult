using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GridView : MonoBehaviour
{
    [SerializeField]
    private GameObject tilePrefab;

    [SerializeField]
    private List<LevelAsset> data;

    private GridLayoutGroup viewport;

    private void Start()
    {
        viewport=this.GetComponentInChildren<GridLayoutGroup>();
        View();
    }

    public void View()
    {
        DeleteTiles();
        foreach(LevelAsset asset in data)
        {
            DrawTile(asset);
        }

    }

    private void DeleteTiles()
    {
        Transform content = viewport.transform;
        for(int i=0;i<content.childCount;i++)
        {
            Transform child = content.GetChild(i);
            Destroy(child.gameObject);
        }
    }

    private void DrawTile(LevelAsset asset)
    {
        GameObject tile=Instantiate(tilePrefab);
        LevelButton button=tile.GetComponent<LevelButton>();
        button.SetLevelAsset(asset);
        tile.transform.SetParent(viewport.transform);
    }
}
