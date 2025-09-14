using System;
using System.Collections.Generic;

namespace BlazorApp4.Models
{
    public class FormResponseModel
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public DateTime SubmittedAt { get; set; }
        public List<FieldResponseModel> FieldResponses { get; set; } = new List<FieldResponseModel>();
    }

}
