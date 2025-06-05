namespace BODYTRANINGAPI.Models
{
    public class MealItemImage
    {
        public int Id { get; set; }
        public int MealItemId { get; set; }
        public string ImageUrl { get; set; }
        public MealItem MealItem { get; set; }
    }

}
