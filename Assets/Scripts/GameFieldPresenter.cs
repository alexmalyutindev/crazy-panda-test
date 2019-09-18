using UnityEngine;

public class GameFieldPresenter
{
    public GameFieldPresenter(GameFieldModel model, GameFieldView view)
    {
        view.OnGroundTouch += position =>
        {
            view.Dig(position);
            if (model.TryGetDiamond())
                view.PlaceDiamond(position);
        };
    }
}