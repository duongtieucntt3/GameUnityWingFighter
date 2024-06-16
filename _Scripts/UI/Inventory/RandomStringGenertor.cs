
public class RandomStringGenertor
{
    private const string chars = "abcdefghjkkmnopqrstuvwxyz0123456789";
    
    public static string Generate(int length)
    {
        string randomString = "";
        for(int i=0;i<length;i++)
        {
            randomString += chars[UnityEngine.Random.Range(0, chars.Length)];
        }
        return randomString;
    }
}