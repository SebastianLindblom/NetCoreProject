using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Gwenzig.Models;
using Microsoft.EntityFrameworkCore;
using Gwenzig.Data.DataModels;
using System.Collections.Generic;

namespace Gwenzig.Controllers
{
 

    public class HomeController : Controller
    {
        private Data.ApplicationDbContext dbcontext { get; set; }
        private SessionViewModel _datamodel_instance { get; set; }
        private SessionViewModel datamodel { get { if (_datamodel_instance == null) _datamodel_instance = new SessionViewModel(); return _datamodel_instance; } }
        public HomeController(Data.ApplicationDbContext _dbcontext)
        {
            dbcontext = _dbcontext;
            Set_SessionViewModel();
        }
        private void Set_SessionViewModel()
        {
            
            if (datamodel.Prices == null) _datamodel_instance.Prices = dbcontext.Prices.Include(x=> x.Priceattributes).ToList();
            if (datamodel.Businessareas == null) _datamodel_instance.Businessareas = dbcontext.Businessareas.ToList();
            if (datamodel.FeaturedItems == null) _datamodel_instance.FeaturedItems = dbcontext.FeaturedItems.ToList();
            if (datamodel.Serviceareas == null) _datamodel_instance.Serviceareas = dbcontext.Serviceareas.ToList();
            if (datamodel.Serviceoffers == null) _datamodel_instance.Serviceoffers = dbcontext.Serviceoffers.ToList();
            if (datamodel.ShowcaseItems == null) _datamodel_instance.ShowcaseItems = dbcontext.ShowcaseItems.ToList();
        }
        public async Task<IActionResult> Index()
        {
            return View(new System.Tuple<SessionViewModel,List<Banners>, List<Sections>>(datamodel, await Render_Banner(), new List<Sections>(){
                
               await Render_Section(1),
               await Render_Section(2),
               await Render_Section(3),
               await Render_Section(4),
               await Render_Section(5),
               await Render_Section(6),
               await Render_Section(7),
               await Render_Section(8),
            }));
        }


        public async Task<Sections> Render_Section(int id = 0)
        {
            return await dbcontext.Sections.FirstOrDefaultAsync(x=> x.PositionNumber == id);
        }
        public async Task<List<Banners>> Render_Banner()
        {
            return  await dbcontext.Banners.ToListAsync();
        }
        public async Task<IActionResult>  Render_List(string ModelName)
        {
            string templateurl = "~/Views/Home/Lists/" + ModelName + "_List.cshtml";

            if (ModelName.ToLower() == "businessareas") return await Task.FromResult(PartialView(templateurl, datamodel.Businessareas));
            else if (ModelName.ToLower() == "featureditems") return await Task.FromResult(PartialView(templateurl, datamodel.FeaturedItems));
            else if (ModelName.ToLower() == "prices") return await Task.FromResult(PartialView(templateurl, datamodel.Prices));
            else if (ModelName.ToLower() == "serviceareas") return await Task.FromResult(PartialView(templateurl, datamodel.Serviceareas));
            else if (ModelName.ToLower() == "serviceoffers") return await Task.FromResult(PartialView(templateurl, datamodel.Serviceoffers));
            else if (ModelName.ToLower() == "showcaseitems") return await Task.FromResult(PartialView(templateurl, datamodel.ShowcaseItems));
            else return PartialView("~/Views/Home/List/Default_List.cshtml");
        }



        // GET: FeaturedItems/FeaturedItem_Modal
        public async Task<IActionResult> Featured_Modal(string Name = "")
        {
            if (Name == null || Name == string.Empty)
            {
                return await Task.FromResult(BadRequest());
            }

            FeaturedItems featuredItems = await dbcontext.FeaturedItems.FirstOrDefaultAsync(x=> x.FeaturedName == Name);
            if (featuredItems == null)
            {
                return NotFound();
            }
            return await Task.FromResult(PartialView("/Views/FeaturedItems/Featured_Modal.cshtml", featuredItems));

        }
        // GET: ShowcaseItems/ShowcaseItem_Modal
        public async Task<IActionResult> ShowcaseItem_Modal(string Name = "")
        {
            if (Name == null || Name == string.Empty)
            {
                return BadRequest();
            }

            ShowcaseItems showcaseItems = await dbcontext.ShowcaseItems.FirstOrDefaultAsync(x=> x.ItemName == Name);
            if (showcaseItems == null)
            {
                return NotFound();
            }
            return await Task.FromResult(PartialView("/Views/ShowcaseItems/ShowcaseItem_Modal.cshtml", showcaseItems));

        }


        public IActionResult Error()
        {
            return View();
        }
    }
}
