using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using webAppBillett.Contexts;
using webAppBillett.Models;

namespace webAppBillett.Controllers
{
    [Route("[Controller]/[action]")]
    public class BillettController : ControllerBase
    {



        private readonly BillettContext _lugDb;



        public BillettController(BillettContext db)
        {
            _lugDb = db;


        }

        public int nyBillett()
        {
            Billett billett = new Billett();
            _lugDb.billetter.Add(billett);

            return billett.billettId;

        }



        public int slettBillett()
        {
            //  Billett billett = _lugDb.billetter.Find(billettId);
            //_lugDb.Remove(billett);
            //  _lugDb.SaveChanges();
            return nyBillett();
        }

        public void velgLugar(BillettLugar billettLugar)
        {
            Lugar lugar = _lugDb.lugarer.Find(billettLugar.lugarId);


            if (lugar != null)
            {

                _lugDb.billettLugar.Add(billettLugar);

            }



        }

        public void slettLugar(BillettLugar billettLugar)
        {

            Billett billett = _lugDb.billetter.Find(billettLugar.billettId);
            billett.billettLugar.RemoveAll((x) => { return x.lugarId == billettLugar.lugarId && x.billettId == billett.billettId; });




        }

        public void slettLugarer(int billettId)
        {

            Billett billett = _lugDb.billetter.Find(billettId);
            billett.billettLugar.RemoveAll((x) => { return x.billettId == billettId; });




        }

        public void slettPersoner(int billettId)
        {

            Billett billett = _lugDb.billetter.Find(billettId);
            billett.billettPerson.RemoveAll((x) => { return x.billettId == billettId; });
    


        }
      



        [HttpPost]
        public int lagrePerson(Person person)
        {
            _lugDb.personer.Add(person);
            _lugDb.SaveChanges();

            return person.personId;


        }
        public List<Rute> hentRuter()
        {
            return _lugDb.ruter.ToList();
        }
        [HttpPost]
        public void utforBetaling(Betaling betaling)
        {
            _lugDb.betaling.Add(betaling);
            _lugDb.SaveChanges();
            nyBillett();

        }

        public List<Person> hentPersoner(int billettId)
        {
            Billett billett = _lugDb.billetter.Find(billettId);

            List<Person> personer = billett.billettPerson.ConvertAll((x) =>
            {
                return _lugDb.personer.Find(x.personId);
            });

            return personer;

        }


        public List<Lugar> hentLugarer(int billettId)
        {
            Billett billett = _lugDb.billetter.Find(billettId);

            List<Lugar> lugarer = billett.billettLugar.ConvertAll((x) =>
            {
                return _lugDb.lugarer.Find(x.lugarId);
            });

            return lugarer;

        }


        public List<Lugar> hentAlleLugarer()
        {


            return _lugDb.lugarer.ToList();

        }

        public ReiseInformasjon hentReiseInformasjon(int billettId)
        {
            Billett billett = _lugDb.billetter.Find(billettId);
            return billett.ReiseInformasjon.ToList().First();

        }



        public void slettPerson(Person person)
        {




            Billett billett = _lugDb.billetter.Find(person.billettId);
            billett.billettPerson.RemoveAll((x) => { return x.personId == person.personId && x.billettId == billett.billettId; });



        }

        [HttpPost]
        public void endrePerson(Person person)
        {

            Person personGammel = _lugDb.personer.Find(person.personId);
            personGammel.fornavn = person.fornavn;
            personGammel.etternavn = person.etternavn;
            personGammel.addresse = person.addresse;


        }

        [HttpPost]
        public void lagreReiseInformasjon(ReiseInformasjon reiseInformasjon)
        {
            _lugDb.reiseInformasjon.Add(reiseInformasjon);




        }


        public void slettReiseInformasjon(int billettId)
        {
            Billett billett = _lugDb.billetter.Find(billettId);
            List<ReiseInformasjon> reiseInformasjon = billett.ReiseInformasjon;
            reiseInformasjon.ForEach((x) =>
            {
                _lugDb.reiseInformasjon.Remove(x);
            });


        }

        [HttpPost]
        public void endreReiseInformasjon(ReiseInformasjon reiseInformasjon)
        {

            ReiseInformasjon reiseInformasjonGammel = _lugDb.reiseInformasjon.Find(reiseInformasjon.billettId);
            if (reiseInformasjonGammel.antVoksen != reiseInformasjon.antVoksen || reiseInformasjonGammel.antBarn != reiseInformasjon.antBarn)
            {
                this.slettPersoner(reiseInformasjon.billettId);
            }
            reiseInformasjonGammel.antVoksen = reiseInformasjon.antVoksen;
            reiseInformasjonGammel.antBarn = reiseInformasjon.antBarn;
            reiseInformasjonGammel.fra = reiseInformasjon.fra;
            reiseInformasjonGammel.til = reiseInformasjon.til;
            reiseInformasjonGammel.reisetype = reiseInformasjon.reisetype;
            reiseInformasjonGammel.utreise = reiseInformasjon.utreise;
            reiseInformasjonGammel.hjemreiseDate = reiseInformasjon.hjemreiseDate;
           

        }




        //Funksjon for debuging
        public List<Billett> hentBilletter()
        {
            return _lugDb.billetter.ToList();
        }


    }
}