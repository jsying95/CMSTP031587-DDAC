using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ScheduleController : Controller
    {
        // GET: Schedule
        public ActionResult addContainer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addContainer(addScheduleViewModel asvmn)
        {
            var con = new Container();


            using (Model1Container container = new Model1Container())
            {
                con.ContainerID = asvmn.containerid;
                con.ContainerOutDate = asvmn.containeroutdate;
                con.Destination = asvmn.destination;
                con.Weight = asvmn.weight;
                con.Status = "Waiting for Ship";

                container.Containers.Add(con);
                container.SaveChanges();
            }

            return RedirectToAction("../Schedule/Index");
        }

        public ActionResult Index()
        {
            List<Container> container = new List<Container>();

            using (Model1Container con = new Model1Container())
            {
                container = con.Containers.ToList();
            }

            return View(container);
        }

        [HttpPost]
        public ActionResult editContainer(Container obj)
        {
            var con = new Container();

            using (Model1Container container = new Model1Container())
            {
                con = container.Containers.Single(a => a.ContainerID == obj.ContainerID);  
                con.ContainerOutDate = obj.ContainerOutDate;
                con.Destination = obj.Destination;
                con.Weight = obj.Weight;

                container.SaveChanges();
            }

            return RedirectToAction("../Schedule/Index");

        }
        public ActionResult editContainer(int id)
        {
            var container = new Container();

            using (Model1Container con = new Model1Container())
            {
                container = con.Containers.Where(a => a.Id == id).FirstOrDefault();
            }

            return View(container);
        }

        public ActionResult removeContainer()
        {
            List<Container> container = new List<Container>();

            using (Model1Container con = new Model1Container())
            {
                container = con.Containers.ToList();
            }

            return View(container);
        }

        public ActionResult Delete(int id)
        {
            var container = new Container();

            using (Model1Container con = new Model1Container())
            {
                container = con.Containers.Where(a => a.Id == id).FirstOrDefault();
                con.Containers.Remove(container);
                con.SaveChanges();
            }
            return RedirectToAction("../Schedule/Index");
        }

    }
}