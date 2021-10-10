using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using webAppBillett.Models;
using webAppBillett.DAL;
using System.Threading.Tasks;

namespace webAppBillett.Controllers
{
    [Route("[Controller]/[action]")]
    public class BillettController : Controller
    {



        private readonly IBillettRepository _lugDb;

 
        public BillettController(IBillettRepository db)
        {

                _lugDb = db;




        }


        public async Task<List<Havn>> hentHavner()
        {
            //For oppstart
            if (!HttpContext.Session.GetInt32("billettId").HasValue)
            {
                int billettId = await _lugDb.addBillettHelper();

                HttpContext.Session.SetInt32("billettId", billettId);
            }



            return await _lugDb.hentHavner();
        }
        [Route("{id}")]
        public async Task<List<Havn>> hentTilHavner(int id)
        {
            return await _lugDb.hentTilHavner(id);



        }

        [Route("{id}")]
        public  void velgLugar(int id)
        {
            
                int billettId = HttpContext.Session.GetInt32("billettId").Value;
                _lugDb.velgLugar(id,billettId);


        }


    

        [HttpPost]
        public async Task<ActionResult> lagrePerson(Person person)
        {
            if (!ModelState.IsValid) return BadRequest("Ugyldig input");
            int billettId = HttpContext.Session.GetInt32("billettId").Value;
            return Ok(await _lugDb.lagrePerson(person,billettId));

        }

        [HttpPost]
        public  async Task<ActionResult> utforBetaling(Betaling betaling)
        {
            if (!ModelState.IsValid) return BadRequest("Ugyldig input");
            int billettId = HttpContext.Session.GetInt32("billettId").Value;
            

              _lugDb.utforBetaling(betaling,billettId);
            HttpContext.Session.Remove("billettId");
            int billettNyId = await _lugDb.addBillettHelper();

            HttpContext.Session.SetInt32("billettId", billettNyId);
            return Ok();

        }




        public async Task<ActionResult> hentForekomsterDato(Rute rute)
        {
            if (!ModelState.IsValid) return BadRequest("Ugyldig input");
            return Ok(await _lugDb.hentForekomsterDato(rute));

        }

        public async Task<ActionResult> hentForekomsterDatoTid(RuteForekomstDato ruteForekomstDato)
        {
            if (!ModelState.IsValid) return BadRequest("Ugyldig input");
            return Ok(await _lugDb.hentForekomsterDatoTid(ruteForekomstDato));

        }


        public async Task<ActionResult> hentFiltrerteLugarer(FilterLugar filterLugar)
        {
            if (!ModelState.IsValid) return BadRequest("Ugyldig input");
            int billettId = HttpContext.Session.GetInt32("billettId").Value;
            return Ok(await _lugDb.hentFiltrerteLugarer(filterLugar, billettId));
        }



    
        [HttpPost]
        public async Task<ActionResult> lagreReiseInformasjon(ReiseInformasjon reiseInformasjon)
        {
            if (!ModelState.IsValid) return BadRequest("Ugyldig input");
            int billettId = HttpContext.Session.GetInt32("billettId").Value;
            return Ok(await _lugDb.lagreReiseInformasjon(reiseInformasjon, billettId));

        }








    }
}