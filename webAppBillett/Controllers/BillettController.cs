using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using webAppBillett.Contexts;

namespace webAppBillett.Controllers
{
    [Route("[Controller]/[action]")]
    public class BillettContext : ControllerBase
    {



        private readonly BillettContext _lugDb;

        static int billettId = -1;

        public BillettContext(BillettContext db)
        {
            _lugDb = db;
            if (billettId == -1)
            {
                nyBillett();
            }




        }

        public void nyBillett()
        {
            Billett billett = new Billett();
            _lugDb.billetter.Add(billett);
            _lugDb.SaveChanges();
            billettId = billett.billettId;

        }



        public void slettBillett()
        {
            //  Billett billett = _lugDb.billetter.Find(billettId);
            //_lugDb.Remove(billett);
            //  _lugDb.SaveChanges();
            nyBillett();
        }

        [Route("{id}")]
        public void velgLugar(int id)
        {
            Lugar lugar = _lugDb.lugarer.Find(id);


            if (lugar != null)
            {
                BillettLugar billettLugar = new BillettLugar();
                Billett billett = _lugDb.billetter.Find(billettId);
                billettLugar.billettId = billett.billettId;


                billettLugar.lugarId = lugar.lugarId;



                _lugDb.billettLugar.Add(billettLugar);
                _lugDb.SaveChanges();
            }



        }

        [Route("{id}")]
        public void slettLugar(int id)
        {

            Billett billett = _lugDb.billetter.Find(billettId);
            billett.billettLugar.RemoveAll((x) => { return x.lugarId == id && x.billettId == billett.billettId; });
            _lugDb.SaveChanges();



        }

        public void slettLugarer()
        {

            Billett billett = _lugDb.billetter.Find(billettId);
            billett.billettLugar.RemoveAll((x) => { return x.billettId == billett.billettId; });
            _lugDb.SaveChanges();



        }

        public void slettPersoner()
        {

            Billett billett = _lugDb.billetter.Find(billettId);
            billett.billettPerson.RemoveAll((x) => { return x.billettId == billett.billettId; });
            _lugDb.SaveChanges();



        }
        [HttpPost]

        [Route("{id}/{nyId}")]
        public void endreLugar(int id, int nyId)
        {
            Billett billett = _lugDb.billetter.Find(billettId);
            billett.billettLugar.RemoveAll((x) => { return x.lugarId == id && x.billettId == billett.billettId; });
            _lugDb.SaveChanges();

            Lugar lugar = _lugDb.lugarer.Find(nyId);

            if (lugar != null)
            {
                BillettLugar billettLugar = new BillettLugar();

                billettLugar.billettId = billett.billettId;


                billettLugar.lugarId = lugar.lugarId;



                _lugDb.billettLugar.Add(billettLugar);
                _lugDb.SaveChanges();
            }



        }



        [HttpPost]
        public int lagrePerson(Person person)
        {
            _lugDb.personer.Add(person);
            _lugDb.SaveChanges();


            BillettPerson billettPerson = new BillettPerson();
            Billett billett = _lugDb.billetter.Find(billettId);
            billettPerson.billettId = billett.billettId;


            billettPerson.personId = person.personId;

            _lugDb.billettPerson.Add(billettPerson);
            _lugDb.SaveChanges();
            return person.personId;


        }
        public List<Rute> hentRuter()
        {
            return _lugDb.ruter.ToList();
        }
        public List<Person> hentPersoner()
        {
            Billett billett = _lugDb.billetter.Find(billettId);

            List<Person> personer = billett.billettPerson.ConvertAll((x) =>
            {
                return _lugDb.personer.Find(x.personId);
            });

            return personer;

        }


        public List<Lugar> hentLugarer()
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

        public ReiseInformasjon hentReiseInformasjon()
        {
            Billett billett = _lugDb.billetter.Find(billettId);
            return billett.ReiseInformasjon.ToList().First();

        }


        [Route("{id}")]
        public void slettPerson(int id)
        {



            Person person = _lugDb.personer.Find(id);
            Billett billett = _lugDb.billetter.Find(billettId);
            billett.billettPerson.RemoveAll((x) => { return x.personId == id && x.billettId == billett.billettId; });
            _lugDb.SaveChanges();


        }

        [HttpPost]
        public void endrePerson(Person person)
        {

            Person personGammel = _lugDb.personer.Find(person.personId);
            personGammel.fornavn = person.fornavn;
            personGammel.etternavn = person.etternavn;
            personGammel.addresse = person.addresse;

            _lugDb.SaveChanges();

        }

        [HttpPost]
        public int lagreReiseInformasjon(ReiseInformasjon reiseInformasjon)
        {
            reiseInformasjon.reiseId = billettId;
            _lugDb.reiseInformasjon.Add(reiseInformasjon);
            _lugDb.SaveChanges();


            return reiseInformasjon.reiseId;

        }


        public void slettReiseInformasjon()
        {
            Billett billett = _lugDb.billetter.Find(billettId);
            List<ReiseInformasjon> reiseInformasjon = billett.ReiseInformasjon;
            reiseInformasjon.ForEach((x) =>
            {
                _lugDb.reiseInformasjon.Remove(x);
            });

            _lugDb.SaveChanges();
        }

        [HttpPost]
        public void endreReiseInformasjon(ReiseInformasjon reiseInformasjon)
        {

            ReiseInformasjon reiseInformasjonGammel = _lugDb.reiseInformasjon.Find(billettId);
            if (reiseInformasjonGammel.antVoksen != reiseInformasjon.antVoksen || reiseInformasjonGammel.antBarn != reiseInformasjon.antBarn)
            {
                this.slettPersoner();
            }
            reiseInformasjonGammel.antVoksen = reiseInformasjon.antVoksen;
            reiseInformasjonGammel.antBarn = reiseInformasjon.antBarn;
            reiseInformasjonGammel.fra = reiseInformasjon.fra;
            reiseInformasjonGammel.til = reiseInformasjon.til;
            reiseInformasjonGammel.reisetype = reiseInformasjon.reisetype;
            reiseInformasjonGammel.utreise = reiseInformasjon.utreise;
            reiseInformasjonGammel.hjemreiseDate = reiseInformasjon.hjemreiseDate;
            _lugDb.SaveChanges();

        }




        //Funksjon for debuging
        public List<Billett> hentBilletter()
        {
            return _lugDb.billetter.ToList();
        }


    }
}