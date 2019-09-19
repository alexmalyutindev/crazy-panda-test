using UnityEngine;

public class GamePresenter
{
    public GamePresenter(
        GameModel model,
        DiggableFieldView gameField,
        CounterView shovelConter,
        CounterView diamondCounter)
    {
        shovelConter.SetCount(model.ShovelCount);

        gameField.OnGroundTouch += fieldCell =>
        {
            if (model.CanDig())
            {
                gameField.Dig(fieldCell.Position);
                if (model.TryDigDiamond())
                    gameField.PlaceDiamond(fieldCell.Position);
            }
        };

        model.OnShavelCountChanged += count => shovelConter.SetCount(count);
        model.OnDiamondCountChanged += count => shovelConter.SetCount(count);
    }
}