namespace MyShop.WebUI.Settings
{
    public class ClientSettings
    {
        public Client MyShopVisitorClient { get; set; }
        public Client MyShopManagerClient { get; set; }
        public Client MyShopAdminClient { get; set; }

    }

    public class Client
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
