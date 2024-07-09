using Hamsell.Data.Repositories.Post;
using Hamsell.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hamsell.Controllers;

public class PostController : Controller
{
    private readonly PostRepository _postRepository;

    public PostController(PostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    [HttpGet]
    public IActionResult NewPost()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(PostViewModel model)
    {
        if (ModelState.IsValid)
        {
            _postRepository.AddPost(model);
            return RedirectToAction("Index", "Home");
        }

        return View("NewPost", model);
    }
}