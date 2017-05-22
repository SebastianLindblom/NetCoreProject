using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CloudburryNet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace CloudburryNet.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private Data.ApplicationDbContext context { get; set; }
        public BlogController(Data.ApplicationDbContext _context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            context = _context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult UserBlog(string alias = "")
        {

            var SelectedUser = new Data.DataModels.User() { };

            if (alias == "" && User.Identity.IsAuthenticated)
            {
                SelectedUser = context.User.Include("UserPosts.Post.PostTags").FirstOrDefault(x => x.AspNetUsersId == _userManager.GetUserAsync(HttpContext.User).Result.Id);
            }
            else
            {
                SelectedUser = context.User.Include("UserPosts.Post.PostTags").FirstOrDefault(x => x.Alias == alias);
            }
            var Posts = SelectedUser?.UserPosts?.Select(x => x.Post).ToList();

            return View("Wall", new Models.BlogViewModels.Wall_ViewModel()
            {
                SelectedUser = SelectedUser,
                Posts = Posts,
            });
        }
        [AllowAnonymous]
        public async Task<IActionResult> ManageBlogPosts(string alias = "")
        {

            var identityuser = await _userManager.GetUserAsync(HttpContext.User);
            var UserCreatedPosts = context.User.Include("UserPost.Post").FirstOrDefault(x => x.AspNetUsersId == identityuser.Id)?.UserPosts.ToList();
            var UserRelatedPost = new List<Data.DataModels.UserRelatedPost>();

            return View("ManageBlogPosts", new Models.BlogViewModels.BlogOverviewViewModel()
            {
                 UserCreatedPosts = UserCreatedPosts.Select(x=> x.Post).ToList(),
                  UserRelatedPosts = UserRelatedPost
            });
        }

        public IActionResult CreateBlogPost()
        {
            var viewmodel = new Models.BlogViewModels.BlogPostFactoryViewModel()
            {

            };

            if (System.Diagnostics.Debugger.IsAttached)
            {
                viewmodel.Post = new Data.DataModels.Post()
                {
                    Title = "Test Title",
                    Content = "<h4>Here's the header</h4><p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur ? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur ?<p>",

                };
            }

            return View("CreateBlogPost", viewmodel);
        }
        [HttpPost]
        public IActionResult AppendTag(string tag, int count)
        {
            count++;
            var array = new string[count];
            array[count - 1] = tag;
            return PartialView("Tag", new Models.BlogViewModels.BlogPostFactoryViewModel() { Tags = array.ToList() });
        }
        [HttpPost]
        public IActionResult AppendAlias(string alias, int count)
        {
            var _alias = context.User.FirstOrDefault(x => x.Alias == alias);
            if (_alias == null)
            {
                count++;
                var array = new Data.DataModels.User[count];
                array[count - 1] = new Data.DataModels.User()
                {
                    Alias = alias,
                    AspNetUsersId = _userManager.GetUserAsync(HttpContext.User).Result?.Id
                };
                return PartialView("Alias", new Models.BlogViewModels.BlogAliasViewModel() { UserAliases = array.ToList() });
            }
            else
            {
                return new JsonResult(new
                {
                    success = false,
                    message = "This Alias is allready in use, try a different one."
                });
            }
        }

        [HttpPost]
        public IActionResult UpdateBlogPost(Models.BlogViewModels.BlogPostFactoryViewModel viewmodel)
        {
            return new JsonResult(new
            {
                success = true,
                message = "Created new blog post."
            });
        }


        [HttpPost]
        public async Task<IActionResult> NewBlogPostAsync(Models.BlogViewModels.BlogPostFactoryViewModel viewmodel)
        {
            try
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                var contentuser = context.User.FirstOrDefault(x => x.AspNetUsersId == user.Id);
                if (contentuser == null)
                {
                    return new JsonResult(new
                    {
                        success = false,
                        message = "Did not find the user for this form. "
                    });
                }
                var newpost = new Data.DataModels.Post()
                {
                    Title = viewmodel.Post.Title,
                    Content = viewmodel.Post.Content,
                    PostDate = viewmodel.Post.PostDate,
                };
                context.Post.Add(newpost);
                context.SaveChanges();

                context.UserPost.Add(new Data.DataModels.UserPost() { PostId = newpost.Id, UserId = contentuser?.Id });

                foreach (var tag in viewmodel.Tags)
                {
                    var thistag = context.Tag.FirstOrDefault(x => x.Name == tag) ?? new Data.DataModels.Tag()
                    {
                        Name = tag
                    };
                    if (thistag.Id == null)
                    {

                        context.Tag.Add(thistag);
                        context.SaveChanges();
                        context.UserTag.Add(new Data.DataModels.UserTag()
                        {
                            TagId = thistag.Id,
                            UserId = contentuser?.Id
                        });
                    }

                    context.PostTag.Add(new Data.DataModels.PostTag()
                    {
                        TagId = thistag.Id,
                        PostId = newpost.Id
                    });

                    context.SaveChanges();
                }



                return new JsonResult(new
                {
                    success = true,
                    message = "Created new blog post."
                });
            }
            catch (Exception e)
            {
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    throw e;
                }
                else
                {
                    return new JsonResult(new
                    {
                        success = false,
                        message = "Something went wrong, this is what I know: " + e.Message + ". " + e.InnerException
                    });
                }
            }

        }


        public async Task<IActionResult> ManageAlias()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User) ?? new ApplicationUser();
            var viewmodel = new Models.BlogViewModels.BlogAliasViewModel()
            {
                 UserAliases = await context.User.Where(x => x.AspNetUsersId == user.Id).ToListAsync()
            };

            return View("ManageAlias", viewmodel);
        }

        public IActionResult UpdateAliases(Models.BlogViewModels.BlogAliasViewModel viewmodel)
        {
            var c = 0;
            foreach (var item in viewmodel.UserAliases)
            {
                var user = context.User.FirstOrDefault(x => x.Id == item.Id);
                if (user.Alias != item.Alias)
                {
                    user.Alias = item.Alias;
                }
            }
            try
            {
                 c = context.SaveChanges();

            }
            catch (Exception e)
            {
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    throw e;
                }

                ViewData["StatusMessage"] = "Something hapend, this is what I know: " + e.Message;
            }

            ViewData["StatusMessage"] = string.Format("Updated {0}", c) + " Aliases. ";

            return View("ManageAlias", viewmodel);
        }
    }
}