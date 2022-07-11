namespace RapidPay.Service.Identity.Models.Dto
{
    public class RespondeDto
    {
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public List<string> ErrorMessages { get; set; }
        public int StatusCode { get; set; }
    }
}
