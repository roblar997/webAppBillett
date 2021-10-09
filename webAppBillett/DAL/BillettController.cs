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
   

            return await _lugDb.hentHavner();
        }
        [Route("{id}")]
        public async Task<List<Havn>> hentTilHavner(int id)
        {
            return await _lugDb.hentTilHavner(id);



        }
        public  void slettBillett()
        {
            try
            {
                int billettId = HttpContext.Session.GetInt32("billettId").Value;

                _lugDb.slettBillett(billettId);
                HttpContext.Session.Remove("billettId");
            }
            catch
            {
                return;
            }

        }

        [Route("{id}")]
        public  void velgLugar(int id)
        {
            
                int billettId = HttpContext.Session.GetInt32("billettId").Value;
                _lugDb.velgLugar(id,billettId);


        }


        public  void slettLugarer()
        {
            
                int billettId = HttpContext.Session.GetInt32("billettId").Value;
                _lugDb.slettLugarer(billettId);



        }

        public  void slettPersoner()
        {
            int billettId = HttpContext.Session.GetInt32("billettId").Value;
            _lugDb.slettPersoner(billettId);



        }
    

        [HttpPost]
        public async Task<ActionResult> lagrePerson(Person person)
        {
            if (!ModelState.IsValid) return BadRequest("Ugyldig input");
            int billettId = HttpContext.Session.GetInt32("billettId").Value;

            return Ok(await _lugDb.lagrePerson(person,billettId));

        }

        public async Task<List<Rute>> hentRuter()
        {
                return await _lugDb.hentRuter();
        }

        [HttpPost]
        public  async Task<ActionResult> utforBetaling(Betaling betaling)
        {
            if (!ModelState.IsValid) return BadRequest("Ugyldig input");
            int billettId = HttpContext.Session.GetInt32("billettId").Value;
            

              _lugDb.utforBetaling(betaling,billettId);
            HttpContext.Session.Remove("billettId");
            return Ok();

        }

        public async Task<List<Person>> hentPersoner()
        {

            //For oppstart
            if (!HttpContext.Session.GetInt32("billettId").HasValue)
            {
                int billettId = await _lugDb.addBillettHelper();

                HttpContext.Session.SetInt32("billettId", billettId);

            }
            int billettId2 = HttpContext.Session.GetInt32("billettId").Value;

     
            return await _lugDb.hentPersoner(billettId2);

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
        public async Task<List<Lugar>> hentLugarer()
        {
            int billettId = HttpContext.Session.GetInt32("billettId").Value;
            return await _lugDb.hentLugarer(billettId);

        }


        public async Task<ActionResult> hentFiltrerteLugarer(FilterLugar filterLugar)
        {
            if (!ModelState.IsValid) return BadRequest("Ugyldig input");
            int billettId = HttpContext.Session.GetInt32("billettId").Value;
            return Ok(await _lugDb.hentFiltrerteLugarer(filterLugar,billettId));
        }
        public async Task<List<Lugar>> hentAlleLugarer()
        {


            return await _lugDb.hentAlleLugarer();

        }

        public async Task<ReiseInformasjon> hentReiseInformasjon()
        {
            int billettId = HttpContext.Session.GetInt32("billettId").Value;
            return await _lugDb.hentReiseInformasjon(billettId);

        }



        [HttpPost]
        public async Task<ActionResult> endrePerson(Person person)
        {
            if (!ModelState.IsValid) return BadRequest("Ugyldig input");
            _lugDb.endrePerson(person);
            return Ok();

        }
        public async Task<double> beregnPris()
        {
            int billettId = HttpContext.Session.GetInt32("billettId").Value;
            return await _lugDb.beregnPris(billettId);
        }

        [HttpPost]
        public async Task<ActionResult> lagreReiseInformasjon(ReiseInformasjon reiseInformasjon)
        {
            if (!ModelState.IsValid) return BadRequest("Ugyldig input");
            int billettId = HttpContext.Session.GetInt32("billettId").Value;
            return Ok(await _lugDb.lagreReiseInformasjon(reiseInformasjon, billettId));

        }



        [HttpPost]
        public async Task<ActionResult> endreReiseInformasjon(ReiseInformasjon reiseInformasjon)
        {
            if (!ModelState.IsValid) return BadRequest("Ugyldig input");
            int billettId = HttpContext.Session.GetInt32("billettId").Value;
             _lugDb.endreReiseInformasjon(reiseInformasjon, billettId);

            return Ok();
        }




        //Funksjon for debuging
        public async Task<List<Billett>> hentBilletter()
        {
            return await _lugDb.hentBilletter();
        }


    }
}