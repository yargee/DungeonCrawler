using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class DungeonCreator : MonoBehaviour
{
    [SerializeField] private Room _startRoom;
    [SerializeField] private Room _roomTemplate;
    [SerializeField] private Chest _chestTemplate;
    [SerializeField] private ChestPanel _chestPanel;
    [SerializeField] private Enemy _enemyTemplate;
    [SerializeField] private DungeonExit _stairs;
    

    // 1 level - block 10/65;

    private List<Room> _dungeon = new List<Room>();

    private void Start()
    {
        _dungeon.Add(_startRoom);
        _startRoom.GenerateExits(10); // here
        StartCoroutine(MakeDungeon());        
    }

    private IEnumerator MakeDungeon()
    {
        for (int i = 0; i < _dungeon.Count; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                var exit = _dungeon[i].GetExit(j);

                if (!exit.IsConnected && exit.enabled)
                {
                    var newRoom = exit.AddRoom(_roomTemplate);
                    newRoom.gameObject.name = $"{_dungeon.Count}";
                    _dungeon.Add(newRoom);
                    exit.ConnectRooms(newRoom);
                    yield return new WaitForSeconds(0.01f);
                    newRoom.GenerateExits(65); // and here
                    //yield return new WaitForSeconds(0.1f);
                }
                else
                {
                    continue;
                }

                if (_dungeon.Count > 30)
                {
                    break;
                }
            }

            if (_dungeon.Count > 30)
            {
                break;
            }
        }
        Debug.Log(_dungeon.Count);
        SetDungeonExit();
        SetChests();
    }

    private void SetDungeonExit()
    {
        var exitPosition = _dungeon.Last().transform.position;
        Instantiate(_stairs, exitPosition, Quaternion.identity);
    }

    private void SetChests()
    {
        for(int i = 1; i < _dungeon.Count; i++)
        {
            if(Random.Range(0,100) < 30)
            {                
                var newChest = Instantiate(_chestTemplate, _dungeon[i].transform.position, Quaternion.identity);
                newChest.Init(_chestPanel);
            }
        }
    }

    private void SetEnemys()
    {

    }
}
