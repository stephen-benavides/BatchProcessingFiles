namespace source.Model;
public class DeserializedFile
{
    public string DirectoryName { get; set; }
    public string FileName { get; set; }

    public DeserializedFile(string directoryName, string fileName)
    {
        this.DirectoryName = directoryName;
        this.FileName = fileName;
    }
}
