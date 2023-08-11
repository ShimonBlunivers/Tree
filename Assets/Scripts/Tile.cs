using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

	[SerializeField] private Color baseColor, highlightColor;

	private SpriteRenderer renderer;

	private Vector2 position;

	private bool root = false;

	[SerializeField] private GameObject rootCenter;
	[SerializeField] private GameObject rootLeft;
	[SerializeField] private GameObject rootRight;
	[SerializeField] private GameObject rootTop;
	[SerializeField] private GameObject rootBottom;

	private void Start()
	{
		renderer = GetComponent<SpriteRenderer>();
		renderer.color = baseColor;
	}

	public void Init(int x, int y)
	{
		position = new Vector2(x, y);
	}

	void OnMouseEnter()
	{
		renderer.color = highlightColor;
	}

	private void OnMouseDown()
	{
		growRoot();
	}
	void OnMouseExit()
	{
		renderer.color = baseColor;
	}

	public void growRoot()
	{
		root = true;
		rootCenter.SetActive(true);
		updateRootConnections();
	}

	private void updateRootConnections()
	{


		if (GridManager.tiles.ContainsKey(new Vector2(position.x - 1, position.y)) && GridManager.tiles[new Vector2(position.x - 1, position.y)].root == true)
		{
			rootLeft.SetActive(true);
			GridManager.tiles[new Vector2(position.x - 1, position.y)].setRootConnection(1);
		}
		else rootLeft.SetActive(false);
		if (GridManager.tiles.ContainsKey(new Vector2(position.x + 1, position.y)) && GridManager.tiles[new Vector2(position.x + 1, position.y)].root == true)
		{
			rootRight.SetActive(true);
			GridManager.tiles[new Vector2(position.x + 1, position.y)].setRootConnection(0);
		}
		else rootRight.SetActive(false);
		if (GridManager.tiles.ContainsKey(new Vector2(position.x, position.y - 1)) && GridManager.tiles[new Vector2(position.x, position.y - 1)].root == true)
		{
			rootTop.SetActive(true);
			GridManager.tiles[new Vector2(position.x, position.y - 1)].setRootConnection(3);
		}
		else rootTop.SetActive(false);
		if (GridManager.tiles.ContainsKey(new Vector2(position.x, position.y + 1)) && GridManager.tiles[new Vector2(position.x, position.y + 1)].root == true)
		{
			rootBottom.SetActive(true);
			GridManager.tiles[new Vector2(position.x, position.y + 1)].setRootConnection(2);
		}
		else rootBottom.SetActive(false);
	}

	public void setRootConnection(int direction) // Left Rright Top Bot
	{
		switch (direction)
		{
			case 0:
				rootLeft.SetActive(true);
				break;
			case 1:
				rootRight.SetActive(true);
				break;
			case 2:	
				rootTop.SetActive(true);
				break;
			case 3:
				rootBottom.SetActive(true);
				break;
		}
	}
}
