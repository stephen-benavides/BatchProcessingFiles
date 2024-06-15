namespace source.Model;
public class ExcelCell
{
    public string Value { get; set; }
    public int Row { get; set; }
    public int Column { get; set; }
    public bool IsMatch { get; set; } = false; //Set to false by default as we do not know if it is a match yet

}
