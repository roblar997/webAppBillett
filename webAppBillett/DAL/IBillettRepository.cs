
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAppBillett.Contexts;
using webAppBillett.Models;

namespace webAppBillett.DAL {

        public interface IBillettRepository {

        public  void velgLugar(int id, int billettId);
        public Task<double> beregnPris(int billettId);
        public Task<List<Havn>> hentHavner();
        public Task<List<Lugar>> hentFiltrerteLugarer(FilterLugar filterLugar);
        public  Task<List<Havn>> hentTilHavner(int id);
        public  Task<List<RuteForekomstDato>> hentForekomsterDato(Rute rute);

        public  Task<List<RuteForekomstDatoTid>> hentForekomsterDatoTid(RuteForekomstDato ruteForekomstDato);

        public  Task<int> lagrePerson(Person person, int billettId);

        public  void utforBetaling(Betaling betaling, int billettId);

        public  Task<int> addBillettHelper();


        public  Task<int> lagreReiseInformasjon(ReiseInformasjon reiseInformasjon, int billettId);



        public  void slettBillett(int billettId);
        public  void slettLugarer(int billettId);

        public  void slettPersoner(int billettId);
        

       public  void slettReiseInformasjon(int billettId);
    }   
    }

