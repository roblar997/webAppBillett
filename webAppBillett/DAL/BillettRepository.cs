
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAppBillett.Contexts;
using webAppBillett.Models;

namespace webAppBillett.DAL {

        public class BillettRepository : IBillettRepository
        {
        private readonly BillettContext _lugDb;

        public BillettRepository(BillettContext db)
        {
            _lugDb = db;




        }

        public async Task<List<RuteForekomstDato>> hentForekomsterDato(Rute rute)
        {
           int ruteId = _lugDb.ruter.First((x) => x.fra == rute.fra && x.til == rute.til).ruteId;
           return await _lugDb.ruteForekomstDato.Where((x) => x.ruteId == ruteId).ToListAsync();
           

        }

        public async Task<List<RuteForekomstDatoTid>> hentForekomsterDatoTid(RuteForekomstDato ruteForekomstDato)
        {
            int forekomstDatoId = _lugDb.ruteForekomstDato.First((x) => x.ruteId == ruteForekomstDato.ruteId && x.avgangsDato == ruteForekomstDato.avgangsDato).ruteId;
            return await _lugDb.ruteForekomstDatoTid.Where((x) => x.forekomstDatoId == forekomstDatoId).ToListAsync();

        }
        public async Task<int> nyBillett() {
            Billett billett = new Billett();
            await _lugDb.billetter.AddAsync(billett);
            await _lugDb.SaveChangesAsync();
            return billett.billettId;
        }

            public async void slettBillett()
            {
                //  Billett billett = _lugDb.billetter.Find(billettId);
                //_lugDb.Remove(billett);
                //  _lugDb.SaveChanges();
               await nyBillett();
            }

   
            public async void velgLugar(int id,int billettId)
            {
                Lugar lugar = await _lugDb.lugarer.FindAsync(id);


                if (lugar != null)
                {
                    BillettLugar billettLugar = new BillettLugar();
                    Billett billett = await _lugDb.billetter.FindAsync(billettId);
                    billettLugar.billettId = billett.billettId;


                    billettLugar.lugarId = lugar.lugarId;



                   await _lugDb.billettLugar.AddAsync(billettLugar);
                   await _lugDb.SaveChangesAsync();
                }



            }

       

            public async void slettLugarer(int billettId)
            {

                Billett billett = await _lugDb.billetter.FindAsync(billettId);
                billett.billettLugar.RemoveAll((x) => { return x.billettId == billett.billettId; });
                await _lugDb.SaveChangesAsync();



            }

            public async void slettPersoner(int billettId) { 

                Billett billett = await _lugDb.billetter.FindAsync(billettId);
                billett.billettPerson.RemoveAll((x) => { return x.billettId == billett.billettId; });
                await _lugDb.SaveChangesAsync();



            }



            public async Task<int> lagrePerson(Person person,int billettId)
            {
                await _lugDb.personer.AddAsync(person);
                await _lugDb.SaveChangesAsync();
                //int billettId = HttpContext.Session.GetInt32("billettId").Value;

                BillettPerson billettPerson = new BillettPerson();
                Billett billett = _lugDb.billetter.Find(billettId);
                billettPerson.billettId = billett.billettId;


                billettPerson.personId = person.personId;

                await _lugDb.billettPerson.AddAsync(billettPerson);
                await _lugDb.SaveChangesAsync();
                return person.personId;


            }
            public async Task<List<Rute>> hentRuter()
            {
                return await _lugDb.ruter.ToListAsync();
            }

            public async void utforBetaling(Betaling betaling, int billettId)
            {
                //int billettId = HttpContext.Session.GetInt32("billettId").Value;
                betaling.betalingsId = billettId;
                await _lugDb.betaling.AddAsync(betaling);
                await _lugDb.SaveChangesAsync();
               await nyBillett();

            }

            public async Task<int> addBillettHelper()
            {
               Billett billetten = new Billett();
               await _lugDb.billetter.AddAsync(billetten);
               await _lugDb.SaveChangesAsync();
               return billetten.billettId;
             }
            public async Task<List<Person>> hentPersoner(int billettId)
            {

                
             
                Billett billett = await _lugDb.billetter.FindAsync(billettId);

                List<Person> personer = billett.billettPerson.ConvertAll((x) =>
                {
                    return  _lugDb.personer.Find(x.personId);
                });

                return personer;

            }


            public async Task<List<Lugar>> hentLugarer(int billettId)
            {

                Billett billett = await _lugDb.billetter.FindAsync(billettId);

                List<Lugar> lugarer = billett.billettLugar.ConvertAll((x) =>
                {
                    return  _lugDb.lugarer.Find(x.lugarId);
                });

                return lugarer;

            }


            public async Task<List<Lugar>> hentAlleLugarer()
            {


                return await _lugDb.lugarer.ToListAsync();

            }

            public async Task<ReiseInformasjon> hentReiseInformasjon(int billettId)
            {

                Billett billett = await _lugDb.billetter.FindAsync(billettId);
                return  billett.ReiseInformasjon.ToList().First();

            }


            public async Task slettPersonAsync(int id, int billettId)
            {



                Person person = await _lugDb.personer.FindAsync(id);
                Billett billett = _lugDb.billetter.Find(billettId);
                billett.billettPerson.RemoveAll((x) => { return x.personId == id && x.billettId == billett.billettId; });
                await _lugDb.SaveChangesAsync();

            }


            public void endrePerson(Person person)
            {

                Person personGammel = _lugDb.personer.Find(person.personId);
                personGammel.fornavn = person.fornavn;
                personGammel.etternavn = person.etternavn;
                personGammel.addresse = person.addresse;

                _lugDb.SaveChanges();

            }

            public async Task<int> lagreReiseInformasjon(ReiseInformasjon reiseInformasjon, int billettId)
            {

                reiseInformasjon.reiseId = billettId;
                _lugDb.reiseInformasjon.Add(reiseInformasjon);
                await _lugDb.SaveChangesAsync();


                return reiseInformasjon.reiseId;

            }


            public async void slettReiseInformasjon(int billettId)
            {

                Billett billett = await _lugDb.billetter.FindAsync(billettId);
                List<ReiseInformasjon> reiseInformasjon = billett.ReiseInformasjon;
                reiseInformasjon.ForEach((x) =>
                {
                    _lugDb.reiseInformasjon.Remove(x);
                });

                await _lugDb.SaveChangesAsync();
            }


            public async void endreReiseInformasjon(ReiseInformasjon reiseInformasjon, int billettId)
            {

                ReiseInformasjon reiseInformasjonGammel = await _lugDb.reiseInformasjon.FindAsync(billettId);
                if (reiseInformasjonGammel.antVoksen != reiseInformasjon.antVoksen || reiseInformasjonGammel.antBarn != reiseInformasjon.antBarn)
                {
                    slettPersoner(billettId);
                }
                reiseInformasjonGammel.antVoksen = reiseInformasjon.antVoksen;
                reiseInformasjonGammel.antBarn = reiseInformasjon.antBarn;
                reiseInformasjonGammel.fra = reiseInformasjon.fra;
                reiseInformasjonGammel.til = reiseInformasjon.til;
                reiseInformasjonGammel.reisetype = reiseInformasjon.reisetype;
                reiseInformasjonGammel.utreise = reiseInformasjon.utreise;
                reiseInformasjonGammel.hjemreiseDate = reiseInformasjon.hjemreiseDate;
                await _lugDb.SaveChangesAsync();

            }




            //Funksjon for debuging
            public async Task<List<Billett>> hentBilletter()
            {
                return await _lugDb.billetter.ToListAsync();
            }


        }
    }

