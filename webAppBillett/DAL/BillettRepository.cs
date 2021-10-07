
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

        public async Task<List<Havn>> hentHavner()
        {
            return await _lugDb.havn.ToListAsync();


        }

        public async Task<List<Havn>> hentTilHavner(int id)
        {
           List<Rute> ruter =  await _lugDb.ruter.Where((x) => x.fra == id).ToListAsync();
           List<Havn> havner = ruter.ConvertAll( (x) =>  _lugDb.havn.First((y) => x.til == y.havnId)).ToList();
            return havner;


        }
        public async Task<List<RuteForekomstDato>> hentForekomsterDato(Rute rute)
        {
           int ruteId = _lugDb.ruter.First((x) => x.fra == rute.fra && x.til == rute.til).ruteId;
           return await _lugDb.ruteForekomstDato.Where((x) => x.ruteId == ruteId).ToListAsync();
           

        }
        public async Task<List<Lugar>> hentFiltrerteLugarer(FilterLugar filterLugar, int billettId)
        {
            Billett billett = await _lugDb.billetter.FindAsync(billettId);
            ReiseInformasjon reiseInformasjon = await hentReiseInformasjon(billettId);
            int ruteId = _lugDb.ruter.Where((x) => x.fra == reiseInformasjon.fra && x.til == reiseInformasjon.til).First().ruteId;
            List<Reservasjon> billettLugarer = billett.reservasjoner.Where((x) => x.ruteId == ruteId && x.avgangsDato == reiseInformasjon.avgangsDato && x.avgangsTid == reiseInformasjon.avgangsTid).ToList();
            List<int> lugarReservert = billettLugarer.ConvertAll((x) => x.lugarId).ToList();

            return await _lugDb.lugarer.Where((x)=>
                //Skal ikke være reservert
                !lugarReservert.Contains(x.lugarId) &&
                filterLugar.antall <= x.antall &&
                (!filterLugar.harDysj || filterLugar.harDysj == x.harDysj) &&
               (!filterLugar.harWifi || filterLugar.harDysj == x.harWifi)  &&
               (!filterLugar.harWc || filterLugar.harDysj == x.harWc) &&
                x.pris >= filterLugar.prisMin &&
                x.pris <= filterLugar.prisMaks
            
                
            ).ToListAsync();
        }

        public async Task<List<RuteForekomstDatoTid>> hentForekomsterDatoTid(RuteForekomstDato ruteForekomstDato)
        {
            int forekomstDatoId = _lugDb.ruteForekomstDato.First((x) => x.ruteId == ruteForekomstDato.ruteId && x.avgangsDato == ruteForekomstDato.avgangsDato).forekomstDatoId;
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
                    Reservasjon billettLugar = new Reservasjon();
                    Billett billett = await _lugDb.billetter.FindAsync(billettId);
                    ReiseInformasjon reiseInformasjon = billett.ReiseInformasjon.First();
                    int ruteId = _lugDb.ruter.Where((x) => x.fra == reiseInformasjon.fra && x.til == reiseInformasjon.til).First().ruteId;

                    billettLugar.billettId = billett.billettId;


                    billettLugar.lugarId      = lugar.lugarId;
                    billettLugar.ruteId       = ruteId;
                    billettLugar.avgangsTid   = reiseInformasjon.avgangsTid;
                    billettLugar.avgangsDato  = reiseInformasjon.avgangsDato;



                   await _lugDb.reservasjon.AddAsync(billettLugar);
                   await _lugDb.SaveChangesAsync();
                }



            }

       

            public async void slettLugarer(int billettId)
            {

                Billett billett = await _lugDb.billetter.FindAsync(billettId);
                billett.reservasjoner.RemoveAll((x) => { return x.billettId == billett.billettId; });
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
                 Billett billett = _lugDb.billetter.Find(billettId);
                 betaling.betalingsId = billettId;
                 double pris = await beregnPris(billettId);
                 billett.pris = pris;
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

                List<Lugar> lugarer = billett.reservasjoner.ConvertAll((x) =>
                {
                    return  _lugDb.lugarer.Find(x.lugarId);
                });

                return lugarer;

            }


            public async Task<List<Lugar>> hentAlleLugarer()
            {


                return await _lugDb.lugarer.ToListAsync();

            }

            public async Task<double> beregnPris(int billettId)
           {
                Billett billett = await _lugDb.billetter.FindAsync(billettId);
                ReiseInformasjon reiseInformasjon = billett.ReiseInformasjon.First();
                Rute rute = _lugDb.ruter.Where((x) => x.fra == reiseInformasjon.fra && x.til == reiseInformasjon.til).First();

               double barnPris = rute.prisBarn;
               double voksenPris = rute.prisVoksen;
             
               double totPrisRute = barnPris * reiseInformasjon.antBarn + voksenPris * rute.prisVoksen;

               List<Lugar> lugarer = await hentLugarer(billettId);
               double totLugarPris = lugarer.Aggregate<Lugar, double>(0, (pris, lug) => pris += lug.pris);

               return totPrisRute + totLugarPris;

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
                reiseInformasjonGammel.avgangsDato = reiseInformasjon.avgangsDato;
                reiseInformasjonGammel.avgangsTid = reiseInformasjon.avgangsTid;
                await _lugDb.SaveChangesAsync();

            }




            //Funksjon for debuging
            public async Task<List<Billett>> hentBilletter()
            {
                return await _lugDb.billetter.ToListAsync();
            }


        }
    }

