using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.CommentComponents
{
    public class _AddCommentComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
