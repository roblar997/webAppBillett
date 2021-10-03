
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAppBillett.Contexts;
using webAppBillett.Models;

namespace webAppBillett.DAL {

        public interface IBillettRepository {
        public Task<int> nyBillett();
        public  void slettBillett();
        public  void velgLugar(int id, int billettId);


        public  Task<List<RuteForekomstDato>> hentForekomsterDato(Rute rute);

        public  Task<List<RuteForekomstDato>> hentForekomsterDatoTid(RuteForekomstDato ruteForekomstDato);
        public   void slettLugarer(int billettId);
        public  void slettPersoner(int billettId);

        public  Task<int> lagrePerson(Person person, int billettId);
        public  Task<List<Rute>> hentRuter();
        public  void utforBetaling(Betaling betaling, int billettId);

        public  Task<int> addBillettHelper();
        public  Task<List<Person>> hentPersoner(int billettId);

        public  Task<List<Lugar>> hentLugarer(int billettId);


        public  Task<List<Lugar>> hentAlleLugarer();

        public  Task<ReiseInformasjon> hentReiseInformasjon(int billettId);



        public void endrePerson(Person person);

        public  Task<int> lagreReiseInformasjon(ReiseInformasjon reiseInformasjon, int billettId);

        public  void slettReiseInformasjon(int billettId);

        public  void endreReiseInformasjon(ReiseInformasjon reiseInformasjon, int billettId);





        //Funksjon for debuging
        public  Task<List<Billett>> hentBilletter();


    }   
    }

