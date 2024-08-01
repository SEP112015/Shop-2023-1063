namespace Shop.WebUI.Results.Base
{
    public class BaseResult<TModel>
    {
        public bool success { get; set; }
        public string? message { get; set; }
        public TModel? data { get; set; }
    }
}
