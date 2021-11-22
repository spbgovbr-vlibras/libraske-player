using UnityEngine;

public class TextOverflowHandler : TextUIEffect
{
    [SerializeField, Range(0, 18)] private int _maxCharacters = 15;
    [SerializeField] private bool _addEllipsis = true;

    public string CutText(string input)
    {
        var output = input;

        if (input.Length >= _maxCharacters)
        {
            output = output.Remove(_maxCharacters - 1);

            if (_addEllipsis)
                output += "...";
        }

        return output;
    }

    public override string HandleText(string value)
    {
        if (value.Length >= _maxCharacters)
        {
            value = value.Remove(_maxCharacters - 1);

            if (_addEllipsis)
                value += "...";
        }

        return value;
    }
}
