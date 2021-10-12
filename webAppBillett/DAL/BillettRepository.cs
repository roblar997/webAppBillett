using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using webAppBillett.Contexts;
using webAppBillett.Models;

namespace webAppBillett.DAL
{

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

        public async Task<List<BillettFormatert>> hentBillettFormatert(int billettId)
        {

            List<BillettFormatert> billettFormatertListe = new List<BillettFormatert>();

            Billett billett = await _lugDb.billetter.FindAsync(billettId);

            List<Person> personer = await hentPersoner(billettId);
            List<Lugar> lugarer = await hentLugarer(billettId);
            List<String> listeRomNr = new List<String>();

            String fraNavn = _lugDb.havn.First((x) => x.havnId == billett.fra).navn;
            String tilNavn = _lugDb.havn.First((x) => x.havnId == billett.til).navn;

            lugarer.ForEach((x) =>
            {
                listeRomNr.Add(x.romNr);
            });

     
            for(int i = 0; i < personer.Count; i++)
            {
                BillettFormatert billettFormatert = new BillettFormatert();
                billettFormatert.listeRomNr = listeRomNr;
                billettFormatert.navn = personer.ElementAt(i).fornavn + " " + personer.ElementAt(i).etternavn;
                billettFormatert.fra = fraNavn;
                billettFormatert.til = tilNavn;
                billettFormatert.avgangsDato = billett.avgangsDato.Date.ToString();
                billettFormatert.avgangsTid = billett.avgangsTid.TimeOfDay.ToString();

                billettFormatertListe.Add(billettFormatert);
            }

            return billettFormatertListe;
            

        }
        public async Task<List<Lugar>> hentLugarer(int billettId)
        {

            Billett billett = await _lugDb.billetter.FindAsync(billettId);

            List<Lugar> lugarer = billett.reservasjoner.ConvertAll((x) =>
            {
                return _lugDb.lugarer.Find(x.lugarId);
            });

            return lugarer;

        }
        public async Task<List<Person>> hentPersoner(int billettId)
        {



            Billett billett = await _lugDb.billetter.FindAsync(billettId);

            List<Person> personer = billett.billettPerson.ConvertAll((x) =>
            {
                return _lugDb.personer.Find(x.personId);
            });

            return personer;

        }
        public async Task<List<Havn>> hentTilHavner(int id)
        {
            List<Rute> ruter = await _lugDb.ruter.Where((x) => x.fra == id).ToListAsync();
            List<Havn> havner = ruter.ConvertAll((x) => _lugDb.havn.First((y) => x.til == y.havnId)).ToList();
            return havner;

        }
        public async Task<List<RuteForekomstDato>> hentForekomsterDato(Rute rute)
        {
            DateTime datetime = DateTime.Now;
            DateTime datetimein4month = DateTime.Now.AddMonths(4);




            int ruteId = _lugDb.ruter.First((x) => x.fra == rute.fra && x.til == rute.til).ruteId;
            return await _lugDb.ruteForekomstDato.Where((x) => x.ruteId == ruteId && !x.erUtsolgt && (datetime.Date.CompareTo(x.avgangsDato.Date) <= 0) && (datetimein4month.Date.CompareTo(x.avgangsDato.Date) >= 0)).ToListAsync();
               
        }

        public async Task<PrisForRute> hentPrisForRute(Rute rute)
        {
            Rute ruten = _lugDb.ruter.Where((x) => x.fra == rute.fra && x.til == rute.til).First();
            PrisForRute prisforrute = new PrisForRute();
            prisforrute.prisBarn = ruten.prisBarn;
            prisforrute.prisVoksen = ruten.prisVoksen;
            return prisforrute;
        }
        public async Task<List<Lugar>> hentFiltrerteLugarer(FilterLugar filterLugar)
        {

            int ruteId = _lugDb.ruter.Where((x) => x.fra == filterLugar.fra && x.til == filterLugar.til).First().ruteId;
            List<Reservasjon> billettLugarer = _lugDb.reservasjon.Where((x) => x.ruteId == ruteId && x.avgangsDato.Date == filterLugar.avgangsDato.Date ).ToList();
            List<int> lugarReservert = billettLugarer.ConvertAll((x) => x.lugarId).ToList();

           List<Lugar> sjekkUtsolgt = await _lugDb.lugarer.Where((x) =>
           //Skal ikke være reservert
           !lugarReservert.Contains(x.lugarId)

            ).ToListAsync();

            if (sjekkUtsolgt.Count == 0)
            {
                RuteForekomstDato forekomst = _lugDb.ruteForekomstDato.First((x) => x.ruteId == ruteId && x.avgangsDato.Date == filterLugar.avgangsDato.Date);
                forekomst.erUtsolgt = true;
                _lugDb.SaveChanges();
                //tom liste
                return new List<Lugar>();
            }

            List<Lugar> lugarer = sjekkUtsolgt.Where((x) =>
         
           filterLugar.antall <= x.antall &&
           (!filterLugar.harDysj || (filterLugar.harDysj && x.harDysj)) &&
           (!filterLugar.harWifi || (filterLugar.harWifi && x.harWifi)) &&
           (!filterLugar.harWc || (filterLugar.harWc && x.harWc)) &&
           x.pris >= filterLugar.prisMin &&
           x.pris <= filterLugar.prisMaks

            ).ToList();

            return lugarer;

        }

        public async Task<List<RuteForekomstDatoTid>> hentForekomsterDatoTid(RuteForekomstDato ruteForekomstDato)
        {
            DateTime dateTime = DateTime.Now;

            RuteForekomstDato forekomst = _lugDb.ruteForekomstDato.First((x) => x.ruteId == ruteForekomstDato.ruteId && x.avgangsDato.Date.CompareTo(ruteForekomstDato.avgangsDato.Date)==0 && !x.erUtsolgt );
            int forekomstDatoId = forekomst.forekomstDatoId;
            List<RuteForekomstDatoTid> forekomster = await _lugDb.ruteForekomstDatoTid.Where((x) => x.forekomstDatoId == forekomstDatoId && !x.erUtsolgt && ((dateTime.Date.CompareTo(x.avgangsDato.Date) != 0) || ((dateTime.TimeOfDay.CompareTo(x.avgangsTid.TimeOfDay) <= 0)))).ToListAsync();
            if(forekomster.Count == 0)
            {
                forekomst.erUtsolgt = true;
                _lugDb.SaveChanges();
            }
            return forekomster;

        }

        public async void velgLugar(int id, int billettId)
        {
            try
            {
                Lugar lugar = await _lugDb.lugarer.FindAsync(id);

                if (lugar != null)
                {
                    Reservasjon billettLugar = new Reservasjon();
                    Billett billett = await _lugDb.billetter.FindAsync(billettId);


                    int ruteId = _lugDb.ruter.Where((x) => x.fra == billett.fra && x.til == billett.til).First().ruteId;

                    billettLugar.billettId = billett.billettId;

                    billettLugar.lugarId = lugar.lugarId;
                    billettLugar.ruteId = ruteId;
                    billettLugar.avgangsTid =  billett.avgangsTid;
                    billettLugar.avgangsDato = billett.avgangsDato;

                    await _lugDb.reservasjon.AddAsync(billettLugar);
                    await _lugDb.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                slettBillett(billettId);
                throw;
            }

        }

        public async void slettBillett(int billettId)
        {
            Billett billett = await _lugDb.billetter.FindAsync(billettId);

            slettLugarer(billettId);
            slettPersoner(billettId);

            _lugDb.billetter.Remove(billett);
            _lugDb.SaveChanges();

        }

        public async void slettLugarer(int billettId)
        {

            Billett billett = await _lugDb.billetter.FindAsync(billettId);
            billett.reservasjoner.RemoveAll((x) => {
                return x.billettId == billett.billettId;
            });
            await _lugDb.SaveChangesAsync();

        }

        public async void slettPersoner(int billettId)
        {

            Billett billett = await _lugDb.billetter.FindAsync(billettId);
            billett.billettPerson.RemoveAll((x) => {
                return x.billettId == billett.billettId;
            });
            await _lugDb.SaveChangesAsync();

            //Fjern personer som ikke er i BillettPerson.

            List<int> personIdVerdier = _lugDb.billettPerson.ToList().ConvertAll((x) => x.personId).ToList();

            //Å fjerne
            List<Person> personer = _lugDb.personer.Where((x) => !personIdVerdier.Contains(x.personId)).ToList();
            _lugDb.personer.RemoveRange(personer);
            _lugDb.SaveChanges();

        }


        public async Task<int> lagrePerson(Person person, int billettId)
        {

            Person personen = null;
            try
            {
                personen = _lugDb.personer.Where((x) => x.fornavn == person.fornavn && x.etternavn == person.etternavn && x.telefon == person.telefon).First();
            }

            //finnes ikke
            catch
            {

            }

            try
            {

                if (personen == null)
                {
                    await _lugDb.personer.AddAsync(person);
                    await _lugDb.SaveChangesAsync();
                }
                else
                {
                    person = personen;
                }

                //int billettId = HttpContext.Session.GetInt32("billettId").Value;

                BillettPerson billettPerson = new BillettPerson();
                Billett billett = _lugDb.billetter.Find(billettId);
                billettPerson.billettId = billett.billettId;

                billettPerson.personId = person.personId;

                await _lugDb.billettPerson.AddAsync(billettPerson);
                await _lugDb.SaveChangesAsync();
                return person.personId;
            }
            catch (Exception ex)
            {
                slettBillett(billettId);
                throw;
            }

        }

        public async void utforBetaling(Betaling betaling, int billettId)
        {

            try
            {
                Billett billett = _lugDb.billetter.Find(billettId);

                betaling.betalingsId = billettId;
                double pris = await beregnPris(billettId);
                billett.pris = pris;
                betaling.pris = pris;
                await _lugDb.betaling.AddAsync(betaling);
                await _lugDb.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                slettBillett(billettId);
                throw;
            }

        }


        public async Task<double> beregnPris(int billettId)
        {
            Billett billett = await _lugDb.billetter.FindAsync(billettId);


            Rute rute = _lugDb.ruter.Where((x) => x.fra == billett.fra && x.til == billett.til).First();

            double barnPris = rute.prisBarn;
            double voksenPris = rute.prisVoksen;

            double totPrisRute = barnPris * billett.antBarn + billett.antVoksen * rute.prisVoksen;

            List<Lugar> lugarer = billett.reservasjoner.ConvertAll((x) => {
                return _lugDb.lugarer.Find(x.lugarId);
            });

            double totLugarPris = lugarer.Aggregate<Lugar, double>(0, (pris, lug) => pris += lug.pris);
            double totPris = totPrisRute + totLugarPris;

            return totPris;

        }

        public async Task<int> lagreBillett(Billett billett)
        {

                await _lugDb.billetter.AddAsync(billett);
                await _lugDb.SaveChangesAsync();
                return billett.billettId;

      

        }

    }

}