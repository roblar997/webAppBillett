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
    public class BillettController : ControllerBase
    {



        private readonly IBillettRepository _lugDb;

 
        public BillettController(IBillettRepository db)
        {
            _lugDb = db;




        }

        public async void nyBillett()
        {
            int billettId = await _lugDb.nyBillett();
            HttpContext.Session.SetInt32("billettId", billettId);
        }



        public async Task slettBillettAsync()
        {
            await _lugDb.nyBillett();
        }

        [Route("{id}")]
        public async void velgLugar(int id)
        {
            int billettId = await _lugDb.nyBillett();
             _lugDb.velgLugar(id,billettId);


        }


        public async void slettLugarer()
        {
            int billettId = await _lugDb.nyBillett();
             _lugDb.slettLugarer(billettId);



        }

        public async Task slettPersonerAsync()
        {
            int billettId = await _lugDb.nyBillett();
             _lugDb.slettLugarer(billettId);



        }
    

        [HttpPost]
        public async Task<int> lagrePerson(Person person)
        {
            
                int billettId = await _lugDb.nyBillett();
                return await _lugDb.lagrePerson(person,billettId);

        }

        public async Task<List<Rute>> hentRuter()
        {
                return await _lugDb.hentRuter();
        }

        [HttpPost]
        public async void utforBetaling(Betaling betaling)
        {
            int billettId = HttpContext.Session.GetInt32("billettId").Value;
             _lugDb.utforBetaling(betaling,billettId);

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


        public async Task<List<Lugar>> hentLugarer()
        {
            int billettId = HttpContext.Session.GetInt32("billettId").Value;
            return await _lugDb.hentLugarer(billettId);

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
        public  void endrePerson(Person person)
        {

           _lugDb.endrePerson(person);

        }

        [HttpPost]
        public async Task<int> lagreReiseInformasjon(ReiseInformasjon reiseInformasjon)
        {

                int billettId = HttpContext.Session.GetInt32("billettId").Value;
                return await _lugDb.lagreReiseInformasjon(reiseInformasjon, billettId);

        }



        [HttpPost]
        public  void endreReiseInformasjon(ReiseInformasjon reiseInformasjon)
        {
            int billettId = HttpContext.Session.GetInt32("billettId").Value;
             _lugDb.endreReiseInformasjon(reiseInformasjon, billettId);
        }




        //Funksjon for debuging
        public async Task<List<Billett>> hentBilletter()
        {
            return await _lugDb.hentBilletter();
        }


    }
}