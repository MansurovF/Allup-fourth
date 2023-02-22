using Microsoft.AspNetCore.Mvc;

namespace AllupTask.ViewComponents
{
    public class NewsLetterViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
