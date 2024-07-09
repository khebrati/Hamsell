namespace Hamsell.ViewModels
{
    public class PostViewModel
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public int? Price { get; set; }
        public string PostDescription { get; set; }
        public int PostCategoryId { get; set; }
        public int CityId { get; set; } 
    }
}