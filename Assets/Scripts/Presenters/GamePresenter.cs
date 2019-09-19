using UnityEngine;

public class GamePresenter
{
    public GamePresenter(
        GameModel model,
        DiggableFieldView gameField,
        CounterView shovelConter,
        CounterView diamondCounter,
        BackpackView backpack
    )
    {
        shovelConter.SetCount(model.ShovelCount);

        gameField.OnGroundTouch += fieldCell =>
        {
            if (model.CanDig(fieldCell.Position))
            {
                gameField.Dig(fieldCell.Position);
                if (model.TryDigDiamond(fieldCell.Position))
                    gameField.PlaceDiamond(fieldCell.Position);
            }
        };
        gameField.OnItemGrabed += cell =>
        {
            Debug.Log(cell);
        };

        backpack.OnItemGrabed += position => model.CollectDiamond(position);

        model.OnShavelCountChanged += count => shovelConter.SetCount(count);
        model.OnDiamondCountChanged += count => diamondCounter.SetCount(count);
    }
}