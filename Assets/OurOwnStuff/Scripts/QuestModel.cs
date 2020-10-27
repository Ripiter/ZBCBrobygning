using System.Collections;
using System.Collections.Generic;

public class QuestModel
{
    string name;
    string objective;
    bool complete;

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public string Objective
    {
        get
        {
            return objective;
        }

        set
        {
            objective = value;
        }
    }

    public bool Complete
    {
        get
        {
            return complete;
        }

        set
        {
            complete = value;
        }
    }
}
