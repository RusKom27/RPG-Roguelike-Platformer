using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public float dumping = 5f;
	public Vector2 offset = new Vector2(2f, 2f);

	private bool isLeft;
	private GameObject player;
	private Transform PlayerTransform;

	private void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		PlayerTransform = player.GetComponent<Transform>();
	}
	private void Start()
	{
		offset = new Vector2(Mathf.Abs(offset.x), offset.y);
		FindPlayer(isLeft);
	}

	public void FindPlayer(bool playerIsLeft)
	{
		if (playerIsLeft)
		{
			transform.position = new Vector2(PlayerTransform.position.x - offset.x, PlayerTransform.position.y - offset.y);
		}
		else
		{
			transform.position = new Vector2(PlayerTransform.position.x + offset.x, PlayerTransform.position.y + offset.y);
		}
	}
	private void Update()
	{
		if (PlayerTransform)
		{
			
			int currentX = Mathf.RoundToInt(PlayerTransform.position.x);
			if (Screen.width / 2 <= Input.mousePosition.x)
				isLeft = false;
			else if (Screen.width / 2 >= Input.mousePosition.x)
				isLeft = true;

			Vector2 target;
			if (isLeft)
				target = new Vector2(PlayerTransform.position.x - offset.x, PlayerTransform.position.y + offset.y);
			else
				target = new Vector2(PlayerTransform.position.x + offset.x, PlayerTransform.position.y + offset.y);

			Vector2 currentPosition = Vector2.Lerp(transform.position, target, dumping * Time.deltaTime);
			transform.position = new Vector3(currentPosition.x, currentPosition.y, PlayerTransform.position.z - 4);
		}
	}
}