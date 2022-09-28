namespace Store_Application.Services.Users.Queries.GetUsers
{
    public class ResultGetUserDto
    {
        public List<GetUserDto> users { get; set; }
        public int Rows { get; set; }
    }
}