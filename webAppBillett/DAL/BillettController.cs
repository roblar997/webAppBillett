using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using webAppBillett.Models;
using webAppBillett.DAL;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;

namespace webAppBillett.Controllers
{
    [Route("[Controller]/[action]")]
    public class BillettController : Controller
    {

        private readonly IBillettRepository _lugDb;
        private ILogger<BillettController> _log;

        public BillettController(IBillettRepository db, ILogger<BillettController> log)
        {

            _lugDb = db;
            _log = log;

        }

        /**     ----- Alt i et løsning, men funker ikke ----
        public Registrering registrer(string input)
        {
            Registrering toReturn = JsonConvert.DeserializeObject<Registrering>(input);
            return toReturn;
        }
        **/

        public async Task<ActionResult> hentHavner()
        {

            try
            {
                return Ok(await _lugDb.hentHavner());
            }
            catch
            {
                _log.LogInformation("hentHavner fant ikke det som ble etterspurt");
                return NotFound("Fant ikke det som ble spurt om");
            }

        }
        [Route("{id}")]
        public async Task<ActionResult> hentTilHavner(int id)
        {
            if (id < 0 || id > 999999)
            {

                return BadRequest("Ugyldig input");
            }
            try
            {
                return Ok(await _lugDb.hentTilHavner(id));
            }
            catch
            {
                _log.LogInformation("hentForekomsterDato fant ikke det som ble etterspurt");
                return NotFound("Fant ikke det som ble spurt om");
            }

        }

        [Route("{id}")]
        public async Task<ActionResult> velgLugar(int id)
        {

            if (id < 0 || id > 999999)
            {
                int billettId = HttpContext.Session.GetInt32("billettId").Value;
                _lugDb.slettBillett(billettId);
                return BadRequest("Ugyldig input");
            }

            try
            {
                int billettId = HttpContext.Session.GetInt32("billettId").Value;
                _lugDb.velgLugar(id, billettId);
                return Ok();

            }
            catch
            {
                _log.LogInformation("hentForekomsterDato fant ikke det som ble etterspurt");

                return NotFound("Fant ikke det som ble spurt om");
            }
        }
        public async Task<List<BillettFormatert>> hentBillettFormatertListe()
        {
            int billettId = HttpContext.Session.GetInt32("billettId").Value;
            HttpContext.Session.Remove("billettId");
            return await _lugDb.hentBillettFormatert(billettId);
        }
       
        [HttpPost]
        public async Task<ActionResult> lagrePerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                int billettId = HttpContext.Session.GetInt32("billettId").Value;
                _lugDb.slettBillett(billettId);
                return BadRequest("Ugyldig input");
            }

            try
            {
                int billettId = HttpContext.Session.GetInt32("billettId").Value;
                return Ok(await _lugDb.lagrePerson(person, billettId));
            }
            catch
            {
                _log.LogError("lagrePerson fikk ufylding input");

                return BadRequest("Ugyldig input");

            }

        }

        [HttpPost]
        public async Task<ActionResult> utforBetaling(Betaling betaling)
        {
            if (!ModelState.IsValid)
            {
                int billettId = HttpContext.Session.GetInt32("billettId").Value;
                _lugDb.slettBillett(billettId);
                return BadRequest("Ugyldig input");
            }
            try
            {

                int billettId = HttpContext.Session.GetInt32("billettId").Value;
                _lugDb.utforBetaling(betaling, billettId);
       
                return Ok();
            }
            catch
            {
                _log.LogError("UtforBetaling fikk ufylding input");

                return BadRequest("Ugyldig input");

            }

        }
        public async Task<PrisForRute> hentPrisForRute(Rute rute)
        {
            return await _lugDb.hentPrisForRute(rute);
        }
        public async Task<ActionResult> hentForekomsterDato(Rute rute)
        {
            if (!ModelState.IsValid) return BadRequest("Ugyldig input");

            try
            {
                return Ok(await _lugDb.hentForekomsterDato(rute));
            }
            catch
            {
                _log.LogInformation("hentForekomsterDato fant ikke det som ble etterspurt");
                return NotFound("Fant ikke det som ble spurt om");
            }

        }

        public async Task<ActionResult> hentForekomsterDatoTid(RuteForekomstDato ruteForekomstDato)
        {
            if (!ModelState.IsValid) return BadRequest("Ugyldig input");
            try
            {
                return Ok(await _lugDb.hentForekomsterDatoTid(ruteForekomstDato));
            }
            catch
            {
                _log.LogInformation(" hentForekomsterDatoTid fant ikke det som ble etterspurt");
                return NotFound("Fant ikke det som ble spurt om");
            }
        }

        public ActionResult lagreBagasje(Bagasje bagasje)
        {
            if (!ModelState.IsValid) return BadRequest("Ugyldig input");
            try
            {

                int billettId = HttpContext.Session.GetInt32("billettId").Value;
                _lugDb.lagreBagasje(billettId, bagasje);
                return Ok();
            }
            catch
            {
                _log.LogError("  bagasje klarte ikke å lagre");
                return BadRequest("Kunne ikke lagre");
            }
        }

        public ActionResult lagreKjoretoy(KjoretoyToBeUnWrapped kjoretoy)
        {
            if (!ModelState.IsValid) return BadRequest("Ugyldig input");
            try
            {

                int billettId = HttpContext.Session.GetInt32("billettId").Value;
            //    _lugDb.lagreKjoretoy(billettId, kjoretoy);
                return Ok();
            }
            catch
            {
                _log.LogError("  kjoretoy klarte ikke å lagre");
                return BadRequest("Kunne ikke lagre");
            }
        }

        public async Task<List<Kjoretoy>> hentKjoretoyInfo()
        {
            return await _lugDb.hentKjoretoyInfo();
        }
        public async Task<ActionResult> hentFiltrerteLugarer(FilterLugar filterLugar)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest("Ugyldig input");
            }
            try
            {

                return Ok(await _lugDb.hentFiltrerteLugarer(filterLugar));
            }
            catch
            {
                _log.LogError("  hentFiltrerteLugarer klarte ikke å lagre");
                return BadRequest("Kunne ikke lagre");
            }
        }

        [HttpPost]
        public async Task<ActionResult> lagreBillett(Billett billett)
        {

            if (!ModelState.IsValid) return BadRequest("Ugyldig input");

            try
            {

                int billettId = await _lugDb.lagreBillett(billett);

                HttpContext.Session.SetInt32("billettId", billettId);
                return Ok();
            }
            catch
            {
                _log.LogError("  billett klarte ikke å lagre");
                return BadRequest("Kunne ikke lagre");
            }

        }

    }
}