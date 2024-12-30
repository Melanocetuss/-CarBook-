using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.CommentComponents
{
    public class _CommentListByBlogComponentPartail : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}