namespace School.Data.Result
{
    public class RefreshToken
    {
        public string UserName { get; set; }
        public string RefreshTokenString { get; set; }
        public DateTime ExpiredAt { get; set; }
    }
}
