using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class puzzle2 : MonoBehaviour
{
    GridLayoutGroup gridLayoutGroup;
    public GameObject buttonPrefab;
    public RectTransform grid;
    Text[,] buttons;
    public int size = 3;
    public Text winCheck;
    public Button nextLevel;
    void Start()
    {
        gridLayoutGroup = grid.GetComponent<GridLayoutGroup>();
        Vector2 gridSize = grid.sizeDelta;

        float buttonSize = (gridSize.x * .85f) / size;
        gridLayoutGroup.cellSize = new Vector2(buttonSize, buttonSize);

        float spacingSize = (gridSize.x * .125f) / size;
        gridLayoutGroup.spacing = new Vector2(spacingSize, spacingSize);

        buttons = new Text[size, size];

        string[] List = getRandomNumbers();

        var count = 0;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                var clone = Instantiate(buttonPrefab, grid);
                var b = clone.GetComponent<Button>();
                var t = b.GetComponentInChildren<Text>();
                buttons[i, j] = t;

                int ROWS = i;
                int COLS = j;

                t.text = List[count++];

                b.onClick.AddListener(() => { Move(ROWS, COLS); });
            }
        }
    }
    private string[] getRandomNumbers()
    {

        int s = size * size;
        string[] List = new string[s];
        var i = 0;
        while (i < s)
        {
            int number = Random.Range(0, s);
            if (!List.Contains(number.ToString()))
            {
                List[i++] = number.ToString();
            }
        }
        for (int j = 0; j < List.Length; j++)
        {
            if (List[j] == "0")
            {
                List[j] = "";
                break;
            }
        }
        return List;
    }
    void Move(int i, int j)
    {
        if (j + 1 < size && buttons[i, j + 1].text == "")
        {
            buttons[i, j + 1].text = buttons[i, j].text;
            buttons[i, j].text = "";
        }
        else if (j - 1 >= 0 && buttons[i, j - 1].text == "")
        {
            buttons[i, j - 1].text = buttons[i, j].text;
            buttons[i, j].text = "";
        }
        else if (i + 1 < size && buttons[i + 1, j].text == "")
        {
            buttons[i + 1, j].text = buttons[i, j].text;
            buttons[i, j].text = "";
        }
        else if (i - 1 >= 0 && buttons[i - 1, j].text == "")
        {
            buttons[i - 1, j].text = buttons[i, j].text;
            buttons[i, j].text = "";
        }
        wincheck();
    }
    public void Reset_bt()
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                buttons[i, j].text = "";
            }
        }
        string[] List = getRandomNumbers();
        var count = 0;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                buttons[i, j].text = List[count++];
            }
        }
        winCheck.text = "";
    }
    public void wincheck()
    {
        //int a = 1;
        //for (int i = 0; i < size; i++)
        //{
        //    for (int j = 0; j < size; j++)
        //    {
        //        //print("i : " + i + " j : " + j);

        //        string index = buttons[i, j].text;

        //        if (index != "")
        //        {
        //            if (index != a.ToString())
        //            {
        //                winCheck.text = "";
        //                return;
        //            }
        //            a++;
        //            //print("a : " + a);
        //        }
        //    }
        //    winCheck.text = "You Win!";
        //    nextLevel.gameObject.SetActive(true);

        //}
        int a = 1;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                // Skip the last button (bottom-right), it should be blank
                if (i == size - 1 && j == size - 1)
                {
                    if (buttons[i, j].text != "")
                    {
                        winCheck.text = "";
                        return;
                    }
                }
                else
                {
                    if (buttons[i, j].text != a.ToString())
                    {
                        winCheck.text = "";
                        return;
                    }
                    a++;
                }
            }
        }

        // If all checks pass
        winCheck.text = "You Win!";
        nextLevel.gameObject.SetActive(true);
    }


    public void NextLevel()
    {
        int nextLevel = screenManager.instance.levelIndex + 1;

        // Unlock next level

        int currentUnlocked = PlayerPrefs.GetInt("LevelUnlocked", 1);
        if (nextLevel > currentUnlocked)
        {
            PlayerPrefs.SetInt("LevelUnlocked", nextLevel);
            PlayerPrefs.Save();
        }

        SceneManager.LoadScene("Level-" + nextLevel);

    }
}
