public class HorizontalSelectionController : SelectionController
{
    protected override void VerifyInputs()
    {
        if (InputManager.GetHorizontalDown())
        {
            if (InputManager.GetHorizontalAxisRaw() > 0)
                Increase();
            else if (InputManager.GetHorizontalAxisRaw() < 0)
                Decrease();

            UpdateValues();
        }
    }
}
