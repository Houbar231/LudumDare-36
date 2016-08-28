using UnityEngine.UI;
using UnityEngine;
using System.Collections;

    public class BuildingButton : MonoBehaviour
    {
        public Button button;
        public Sprite sprite;
        public string bmode_Text;
        public bool buildingMode = false;
        public static BuildingButton Instance;
        public Text Bmode_text;
        public Button Bmode;
        public string BuildingName;
        public void Awake()
        {
            Instance = this;
        }

        public void Bmode_Click()
        {
            Debug.Log("Button Pressed");
            HideOnStart.Instance.BHider.SetActive(false);
            buildingMode = false;
        }

        public void OnClick()
        {
            BuildingShop.Instance.CloseShop();
            buildingMode = true;

            HideOnStart.Instance.BHider.SetActive(false);
            Bmode_text.text = bmode_Text;
            HideOnStart.Instance.BHider.SetActive(true);
        }

        void FixedUpdate()
        {
            if (Input.GetMouseButton(1) && buildingMode == true)
            {
                Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                int MouseX = Mathf.FloorToInt(MousePosition.x);
                int MouseY = Mathf.FloorToInt(MousePosition.y);
                MapTile SelectedTile = Map.Instance.Tiles[MouseX, MouseY];
                GameObject GO = new GameObject(BuildingName);
                GO.AddComponent<SpriteRenderer>().sprite = sprite;
                GO.transform.position = new Vector3(SelectedTile.Data.x, SelectedTile.Data.y, 0);
            }

        }
    }