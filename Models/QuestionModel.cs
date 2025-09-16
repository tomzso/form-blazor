namespace BlazorApp4.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public string Label { get; set; } = string.Empty;   
        public string FieldType { get; set; } = string.Empty; // e.g., "radiobox", "checkbox", "textbox"
        public bool Required { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int Order { get; set; }

        public List<OptionModel> Options { get; set; } = new();

        // Placeholder for future responses
        public string? RadioResponse { get; set; } = string.Empty;
        public List<string> CheckboxResponse { get; set; } = new List<string>();
        public string? TextResponse { get; set; } = string.Empty;

    }
}
