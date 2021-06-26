public class VerticalSelectionController : SelectionController
{
    protected override void VerifyInputs()
    {
        if (InputManager.GetVerticalDown())
        {
            if (InputManager.GetVerticalAxisRaw() < 0)
                Increase();
            else if (InputManager.GetVerticalAxisRaw() > 0)
                Decrease();

            UpdateValues();
        }
    }
}