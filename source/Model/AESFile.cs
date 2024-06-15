namespace source.Model;
public class AESFile
{
    public string DirectoryName { get; set; }
    //public string DestinationDirectoryName { get; set; }
    public string OriginalFileName { get; set; }
    public string NewFileName { get; set; }
    public string OriginalFileNameWithNoAes { get; set; }
    public string NewFileNameWithNoAes { get; set; }

    //Break down the name of the file here, seprated by . 
    public string[] NameKeywords { get; set; }

    public string AbsoluteName { get; set; }
    public string AbsoluteNameWithNoAes { get; set; }

    public bool IsAesFile(string directoryName, string originalFileName){
        NameKeywords = originalFileName.Split('.');
        OriginalFileName = originalFileName;

        //Check if the file has AES
        if(!OriginalFileName.ToUpperInvariant().Contains("_AES")){
            return false;
        }
        //Check if the file has 'old'
        if(OriginalFileName.ToUpperInvariant().Contains("_OLD")){
            return false;
        }

        DirectoryName = directoryName;
        OriginalFileNameWithNoAes = string.Join(".", new[]{NameKeywords[0], RemoveAesKeyword(NameKeywords[1]), NameKeywords[2], NameKeywords[3]});
        NewFileNameWithNoAes = string.Join(".", new[]{NameKeywords[0], RemoveAesKeyword(NameKeywords[1]), NameKeywords[3]});

        AbsoluteName = NameKeywords[1];
        AbsoluteNameWithNoAes = RemoveAesKeyword(NameKeywords[1]);
        return true;
    }

    private string RemoveAesKeyword(string keyword){
        return keyword.Remove(NameKeywords[1].Length - "_aes".Length);
    }
}
