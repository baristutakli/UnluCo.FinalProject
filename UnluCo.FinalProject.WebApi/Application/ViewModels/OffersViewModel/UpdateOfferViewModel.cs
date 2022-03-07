namespace UnluCo.FinalProject.WebApi.Application.ViewModels.OffersViewModel
{
    public class UpdateOfferViewModel
    {
        public int Id { get; set; }
        public int? Amount { get; set; }
        public int? Percentage { get; set; }
        public int ProductId { get; set; }
        public bool IsActive { get; set; }
    }
}
