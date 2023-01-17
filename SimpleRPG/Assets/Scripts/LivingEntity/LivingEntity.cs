using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class LivingEntity : BaseObject
{
    private bool _isPlayer = false;
    public bool IsPlayer
    {
        // get; set;
        get { return _isPlayer; }
        set { _isPlayer = value; }
    }

    [SerializeField]
    private eTeamType _teamType = eTeamType.TEAM_1;
    public eTeamType TEAM_TYPE
    {
        get { return _teamType; }
    }

    [SerializeField]
    private eAIType aiType = eAIType.NormalAI;
    BaseAI _ai = null;
    public BaseAI AI
    { get { return _ai; } }

    private void Awake()
    {
        GameObject aiObject = new GameObject();
        aiObject.name = aiType.ToString();
        switch (aiType)
        {
            case eAIType.NormalAI:
                _ai = aiObject.AddComponent<NormalAI>();
                break;
        }
        aiObject.transform.SetParent(this.transform);
        if (_ai != null)
            _ai.Target = this;  // 없으면 동작 X
    }

    protected virtual void Update()
    {
        AI.UpdateAI();
        if (AI.IsEnd)
            Destroy(SelfObject);
    }


}
