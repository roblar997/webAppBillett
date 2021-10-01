using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAppBillett.wwwroot.DAL
{
    public interface IBillettRepository
    {
        using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using webAppBillett.Contexts;
using webAppBillett.Models;

namespace webAppBillett.DAL {

        public interface IBillettRepository { 

            public void nyBillett();


            public void slettBillett();
            public void velgLugar(int id);
            public void slettLugar(int id);
            

            public void slettLugarer();

            public void slettPersoner();
            public void endreLugar(int id, int nyId);
            public Task<int> lagrePerson(Person person;
            public Task<List<Rute>> hentRuter();
            public void utforBetaling(Betaling betaling);

            public Task<List<Person>> hentPersoner();


            public Task<List<Lugar>> hentLugarer();

            public Task<List<Lugar>> hentAlleLugarer();

            public Task<ReiseInformasjon> hentReiseInformasjon();
            public void slettPerson(int id);
            public void endrePerson(Person person);
            public Task<int> lagreReiseInformasjon(ReiseInformasjon reiseInformasjon);

            public void slettReiseInformasjon();
            public void endreReiseInformasjon(ReiseInformasjon reiseInformasjon);

            public Task<List<Billett>> hentBilletter();


        }
    }
}
}
