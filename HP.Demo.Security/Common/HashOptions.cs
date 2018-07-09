namespace HP.Demo.Security.Common
{
    public class HashOptions
    {
        public string StaticSalt { get; set; }
        public int SaltSize { get; set; }
        public int Cost { get; set; }
        public int BlockSize { get; set; }
        public int Parallel { get; set; }
        public int? MaxThreads { get; set; }
    }
}
