using KoulukantaMvc.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace KoulukantaMvc.Controllers
{
    public class TunnitController : Controller
    {
        // GET: Tunnit
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetList()
        {
            KoulukantaEntities entities = new KoulukantaEntities();

            CultureInfo fiFI = new CultureInfo("fi-FI");

            var model = (from t in entities.TUNNIT
                             select new
                             {
                                 TuntiID = t.TuntiID,
                                 ProjektiID = t.ProjektiID,
                                 HenkiloID = t.HenkiloID,
                                 Pvm = t.Pvm.Value,
                                 Projektitunnit = t.Projektitunnit
                             }).ToList();

                string json = JsonConvert.SerializeObject(model);
                entities.Dispose();

                Response.Expires = -1;
                Response.CacheControl = "no-cache";

                return Json(json, JsonRequestBehavior.AllowGet);

            }

            

        public JsonResult GetSingleTunnit(int id)
        {
            KoulukantaEntities entities = new KoulukantaEntities();
           // int iid = int.Parse(id);
            CultureInfo fiFI = new CultureInfo("fi-FI");

            var model = (from t in entities.TUNNIT
                         where t.TuntiID == id
                         select new
                         {
                             TuntiID = t.TuntiID,
                             ProjektiID = t.ProjektiID,
                             HenkiloID = t.HenkiloID,
                             Pvm = t.Pvm,
                             Projektitunnit = t.Projektitunnit
                         }).FirstOrDefault();


            string json = JsonConvert.SerializeObject(model);
            entities.Dispose();

            return Json(json, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Update(TUNNIT tunn)
        {

            KoulukantaEntities entities = new KoulukantaEntities();

            bool OK = false;

            // onko kyseessä muokkaus vai uuden lisääminen?
            if (tunn.TuntiID == 0)
            {
                // kyseessä on uuden asiakkaan lisääminen, kopioidaan kentät
                TUNNIT dbItem = new TUNNIT()
                {

                    ProjektiID = tunn.ProjektiID,
                    HenkiloID = tunn.HenkiloID,
                    Pvm = tunn.Pvm.Value,
                    Projektitunnit = tunn.Projektitunnit
                };

                // tallennus tietokantaan
                entities.TUNNIT.Add(dbItem);
                entities.SaveChanges();
                OK = true;
            }
            else
            {
                // muokkaus, haetaan id:n perusteella riviä tietokannasta
                TUNNIT dbItem = (from t in entities.TUNNIT
                                 where t.TuntiID == tunn.TuntiID
                                 select t).FirstOrDefault();



                if (dbItem != null)
                {
                    //dbItem.TuntiID = tunn.TuntiID;
                    dbItem.ProjektiID = tunn.ProjektiID;
                    dbItem.HenkiloID = tunn.HenkiloID;
                    dbItem.Pvm = tunn.Pvm.Value;
                    dbItem.Projektitunnit = tunn.Projektitunnit;


                    // tallennus tietokantaan
                    entities.SaveChanges();
                    OK = true;
                }
            }
            entities.Dispose();

            return Json(OK, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            KoulukantaEntities entities = new KoulukantaEntities();
            // etsitään id:n perusteella asiakasrivi kannasta
            bool OK = false;
            TUNNIT dbItem = (from t in entities.TUNNIT
                             where t.TuntiID == id
                             select t).FirstOrDefault();
            if (dbItem != null)
            {
                // tietokannasta poisto
                entities.TUNNIT.Remove(dbItem);
                entities.SaveChanges();
                OK = true;
            }
            entities.Dispose();

            return Json(OK, JsonRequestBehavior.AllowGet);
        }
    }
}