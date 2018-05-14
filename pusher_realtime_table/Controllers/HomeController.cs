using pusher_realtime_table.Models;
using System.Linq;
using System.Web.Mvc;
using PusherServer;
using System.Threading.Tasks;

namespace pusher_realtime_table.Controllers
{
    public class HomeController : Controller

    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult index()
        {
            return View();
        }

        public ActionResult about()
        {
            return View();
        }

        public ActionResult Menu()
        {
            return View();
        }

        public ActionResult contact()
        {
            return View();
        }

        public ActionResult ordenar()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(RealtimeTable data)
        {
            RealtimeTable setdata = new RealtimeTable();
            setdata.title = data.title;
            setdata.Nombre_Foodtruck = data.Nombre_Foodtruck;
            setdata.year = data.year;
            setdata.Desc_Orden = data.Desc_Orden;
            setdata.Metodo_Pago = data.Metodo_Pago;
            db.realtime.Add(setdata);
            db.SaveChanges();
            var options = new PusherOptions();
            options.Cluster = "mt1";
            var pusher = new Pusher("524125", "62428177916ab25dc80b", "d6305f36761dc62dbf23", options);
            ITriggerResult result = await pusher.TriggerAsync("asp_channel", "asp_event", data);
            return RedirectToAction("view", "Home");
        }

        public ActionResult seen()
        {
            return Json(db.realtime.ToArray(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult view()
        {
            return View();
        }

       
       
    }
}
