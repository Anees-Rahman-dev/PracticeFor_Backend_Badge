namespace PracticeFor_B_Review.Setting
{
    public class JwtSettings
    {
        public string key { get; set; } = string.Empty; //for siginig
        public string issuer { get; set; } = string.Empty;//who created the token
        public string audience { get; set;} = string.Empty; //who is allowed to use the token
        public int durationInMinutes { get; set; } //how long the token is valid
    }
}
