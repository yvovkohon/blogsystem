namespace BlogSystem.Models.Common
{
    public enum DeletePostResult
    {
        Unknown = 0,
        Succeed = 1,
        NotFound = 2,
        HasComments = 3
    }
}