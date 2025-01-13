using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEngine;

public class MineSkill : BasicSkill
{
    private List<GameObject> _mines = new List<GameObject>();
    private Coroutine _mineSpawnTimer;

    private int minesAmount;
    public override void OnDisable()
    {
        DestroyMines();
        CoroutineServices.instance.StopCoroutine(_mineSpawnTimer);

        base.OnDisable();
    }
    public override void ActivateSkill()
    {
        _mineSpawnTimer = CoroutineServices.instance.StartCoroutine(MinesCreator());
    }

    private IEnumerator MinesCreator()
    {
        while (minesAmount < _skillConfig.GetParameter(SkillParameterType.Count))
        {     
            MineController mine = PoolObjectManager.instant.Mines.GetComponent();
            mine.gameObject.transform.position = _characterPos.position;
            _mines.Add(mine.gameObject);
            minesAmount++;
            yield return new WaitForSeconds(_skillConfig.GetParameter(SkillParameterType.Delay));
        }
        minesAmount = 0;
    }
    private void DestroyMines()
    {
        if (!_mines.IsNullOrEmpty())
        {
            foreach (var mine in _mines)
            {
                Object.Destroy(mine);
            }
            _mines.Clear();
        }
    }
}