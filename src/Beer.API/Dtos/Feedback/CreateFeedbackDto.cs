namespace Beer.API.Dtos.Feedback
{
    public class CreateFeedbackDto
    {
        public int Rate { get; set; }
        
        public string Comment { get; set; }
    }
}