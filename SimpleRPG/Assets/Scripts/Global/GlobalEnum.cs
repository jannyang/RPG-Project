/// <summary>
/// Enum Á¤¸®
/// </summary>


// BaseObject
public enum eBaseObjectState
{
    State_Normal,
    State_Die,
}

// Living Entity
public enum eTeamType
{
    TEAM_1,
    TEAM_2,

    MAX,
}

public enum eStateType
{
    STATE_NONE = 0,
    STATE_IDLE,
    STATE_ATTACK,
    STATE_WALK,
    STATE_DEAD,
}

public enum eAIType
{
    Controll,
    NormalAI,
}