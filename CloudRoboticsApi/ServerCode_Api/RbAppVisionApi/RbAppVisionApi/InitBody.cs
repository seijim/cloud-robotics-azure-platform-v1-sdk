namespace RbAppVisionApi
{
    public class InitBody
    {
        public string storageAccount { set; get; }
        public string storageKey { set; get; }
        public string storageContainer { set; get; }
        public InitBody()
        {
            this.storageAccount = string.Empty;
            this.storageKey = string.Empty;
            this.storageContainer = string.Empty;

        }
    }
}