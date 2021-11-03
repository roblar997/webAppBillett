
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using webAppBillett.Contexts;
using webAppBillett.Models;

namespace webAppBillett.DAL {

    //Tilhører ikke database (derfor slik klasse) - kun som et view til klient.
    public class BillettFormatert
    {
        public string fra { get; set; }
        public string til { get; set; }
        public string navn { get; set; }



        public string avgangsDato { get; set; }


        public string avgangsTid { get; set; }

        public List<string> listeRomNr { get; set; }
    };

    public class KjoretoyToBeUnWrapped{

        [Required]
        public string typeKjoretoy { get; set; }
        [Required]
        public string hoydeKlasse { get; set; }
        [Required]
        public string lengdeKlasse { get; set; }
        [Required]
        public bool harVåpen { get; set; }
        [Required]
        public bool harElApparat { get; set; }
        [Required]
        public bool harSproyteBeholder { get; set; }
        [Required]
        public bool harGassBeholder { get; set; }
        [Required]
        public int antKjæledyr { get; set; }
        [Required]
        public string infoInnhold { get; set; }
        [Required]
        public int ruteId { get; set; }
        [Required]
        public string avgangsDato { get; set; }
        [Required]
        public string avgangsTid { get; set; }

    }
    public class PrisForRute
    {
        public double prisBarn { get; set; }
        public double prisVoksen { get; set; }
    }

    public class RuteForekomstConverted
    {
        public int ruteId { get; set; }
        public bool erUtsolgt {get;set;}
        public DateTime avgangsDato { get; set; }
        
        public DateTime avgangsTid { get; set; }
    }
    public interface IBillettRepository {
        public void lagreBagasje(int billettId, Bagasje bagasje);
        public Task<List<Lugar>> hentLugarer(int billettId);
        public  void velgLugar(int id, int billettId);
        public Task<double> beregnPris(int billettId);
        public Task<List<Havn>> hentHavner();
        public Task<PrisForRute> hentPrisForRute(Rute rute);
        public Task<List<Lugar>> hentFiltrerteLugarer(FilterLugar filterLugar);
        public  Task<List<Havn>> hentTilHavner(int id);
        public  Task<List<RuteForekomstConverted>> hentForekomsterDato(Rute rute);

        public  Task<List<RuteForekomstDatoTid>> hentForekomsterDatoTid(RuteForekomstDato ruteForekomstDato);
        public  Task<List<Kjoretoy>> hentKjoretoyInfo();

        public void lagreKjoretoy(int billettId, KjoretoyToBeUnWrapped kjoretoy);
        public  Task<int> lagrePerson(Person person, int billettId);

        public  void utforBetaling(Betaling betaling, int billettId);

        public Task<List<BillettFormatert>> hentBillettFormatert(int billettId);
        public  Task<int> lagreBillett(Billett billett);


        public Task<List<Person>> hentPersoner(int billettId);
        public  void slettBillett(int billettId);
        public  void slettLugarer(int billettId);

        public  void slettPersoner(int billettId);
        

    }   
    }

