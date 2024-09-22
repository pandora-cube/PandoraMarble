public abstract class CellAction
{
    public Pawn pawn;
    public string param1;
    public string param2;

    public abstract void Invoke();

    public static CellAction GetAction(string action)
    {
        switch (action)
        {
            case "Move":
                return new MoveAction();
            case "Star":
                return new StarAction();
            default:
                return null;
        }
    }
}

public class MoveAction : CellAction
{
    public override void Invoke()
    {
        pawn.MovePoint(int.Parse(param2), int.Parse(param1));
    }
}

public class StarAction : CellAction
{
    public override void Invoke()
    {
        pawn.AddStar();
        StarManager.Instance.SetStar();
    }
}
