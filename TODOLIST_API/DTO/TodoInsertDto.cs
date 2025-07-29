namespace TODOLIST_API.DTO
{
    public class TodoInsertDto
    {
        public string Title { get; set; }
        public string DescriptionItem { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EndedDate { get; set; }
        public bool isCompleted { get; set; }
    }
}
