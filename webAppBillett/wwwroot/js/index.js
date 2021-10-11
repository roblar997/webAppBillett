﻿
$(() => {

 

    //TODO
    hentFraHavner().then((x) => {

        hentTilHavner($("#fra").val()).catch((err) => {});


    }).catch((err) => { });



    $('#fra').change((x) => {
        
    });

    $('#til').change((x) => {
    });






    $("#prisMaks").change((x) => {
        let maksPrisSjekk = validerPrisMaks(x.target.value);
        if (!maksPrisSjekk) $("#maksprisFeil").html("<p> maks pris<p>");
        else $("#maksprisFeil").html("");
    });

    $("#prisMin").change((x) => {
        let minPrisSjekk = validerPrisMin(x.target.value);
        if (!minPrisSjekk) $("#minprisFeil").html("<p> min pris <p>");
        else $("#minprisFeil").html("");
    });
    $("#antall").change((x) => {
        let antallSjekk = validerAntall(x.target.value);
        if (!antallSjekk) $("#antallFeil").html("<p> ant barn <p>");
        else $("#antallFeil").html("");
    });




    $("#antBarn").change((x) => {
        let antBarnSjekk = validerAntBarn(x.target.value);
        if (!antBarnSjekk) $("#antbarnFeil").html("<p> ant barn <p>");
        else $("#antbarnFeil").html("");
    });

    $("#antVoksen").change((x) => {
        let antVoksenSjekkk = validerAntVoksen(x.target.value);
        if (!antVoksenSjekkk) $("#antvoksenFeil").html("<p> ant barn <p>");
        else $("#antvoksenFeil").html("");
    });


    $('#csv').change((x) => {
        let csvSjekk = validerCsv(x.target.value);
        if (!csvSjekk) $("#csvFeil").html("<p> csv <p>");
        else $("#csvFeil").html("");
    });

    $('#kortnummer').change((x) => {

        let kortnummerSjekk = validerKortnummer(x.target.value);
        if (!kortnummerSjekk) $("#kortnummerFeil").html("<p> kortnummer <p>");
        else $("#kortnummerFeil").html("");
    });

    $('#kortholderNavn').change((x) => {
        let kortholderNavnSjekk = validerKortholderNavn(x.target.value);
        if (!kortholderNavnSjekk) $("#kortholdernavnFeil").html("<p> kortholderNavn<p>");
        else $("#kortholdernavnFeil").html("");
     });

    $('#utloper').change((x) => {

        let utlopsTidSjekk = validerUltopsDato(x.target.value);
        if (!utlopsTidSjekk) $("#utloperFeil").html("<p> utlop <p>");
        else $("#utloperFeil").html("");


    });

    $("#postnr").change((x) => {
        
        //Betaling
        let postNrSjekk = validerPostNr(x.target.value);
        if (!postNrSjekk) $("#postnrFeil").html("<p> postnr <p>");
        else $("#postnrFeil").html("");

    });

    $("#poststed").change((x) => {

        let postStedSjekk = validerPoststed(x.target.value);
        if (!postStedSjekk) $("#poststedFeil").html("<p> postnr <p>");
        else $("#poststedFeil").html("");

     });

    $("#adresse").change((x) => {
        let adresseSjekk = validerAdresse(x.target.value);
        if (!adresseSjekk) $("#adresseFeil").html("<p> adresse <p>");
        else $("#adresseFeil").html("");
    });

    $("#telefon").change((x) => {
        let telefonSjekk = validerTelefonNummer(x.target.value);
        if (!telefonSjekk) $("#telefonFeil").html("<p> telefon <p>");
        else $("#telefonFeil").html("");

     });

    $("#email").change((x) => {
        let emailSjekk = validerEmail(x.target.value);
        if (!emailSjekk) $("#emailFeil").html("<p> email <p>");
        else $("#emailFeil").html("");
    });



   
 
    $("#reg0").click((e) => {
        const reiseInfo = {
            reiseId: -1,
            fra: $('#fra').val(),
            til: $('#til').val(),
            antBarn: $("#antBarn").val(),
            antVoksen: $("#antVoksen").val(),
            avgangsDato: $('#avgangsDato').val(),
            avgangsTid: $('#avgangsTid').val()
        };


        lagreReiseInformasjon(reiseInfo);
        
   

        
    });
    //Kjøp av billett
    $("#btnFerdig").click((e) => {
        if (GUIModuleSPA.erFerdig()) {
            beregnPris();

            $("#regform3").hide();

            $("#regform4").show();
         
        }
        else {
            alert("Du har ikke gitt tilstrekkelig riktig informasjon, for å kunne kjøpe en billett")
        }
    });
    $("#sokDato").click((e) => {
        hentForekomstDato();
    })

    $("#sokTid").click((e) => {
        hentForekomstDatoTid();
    })
    $("#fulfor").click((e) => {
        lagreBetaling();

    })

    $("#slettLugarer").click((e) => {

        slettLugarer();
    });


    $("#sok").click((e) => {
        $("#lugarerTilValg").html("");
        hentFiltrerteLugarer();
    });
    $("#fra").change((e) => {
        $("#til").html("");
        $("#avgangsDato").html("");
        $("#avgangsTid").html("");
        hentTilHavner($("#fra").val());
    });

    $("#avgangsDato").change((e) => {
        $("#avgangsTid").html("");
    });

    $("#til").change((e) => {

        $("#avgangsDato").html("");
        $("#avgangsTid").html("");

    });


    $("#endre0").click((e) => {
        let  reiseInfo = {
            fra: $('#fra').val(),
            til: $('#til').val(),
            avgangsDato: $('#avgangsDato').val(),
            avgangsTid: $('#avgangsTid').val(),
            antBarn: $("#antBarn").val(),
            antVoksen: $("#antVoksen").val(),
        };

        if (!validerReiseInfoSkjema(reiseInfo)) return;
        $("#personer").html("");
        personene = [];
        reiseInformasjonen = reiseInfo;
        genererPersonInfoSkjema(reiseInfo);
       
    });






});


// VARIABLER UTEN KLASSE ^^
let personene = [];
let lugarene = [];
let reiseInformasjonen;


//let reiseInformasjonen = [];


/**     ----- Alt i et løsning, men funker på backend. Nb reiseinformasjonen må da være liste ----
let registrering = {
personene: personene,
lugarene: lugarene,
reiseInformasjonen: reiseInformasjonen
}

*/

function lagreReiseInformasjon(reiseInfo) {
    // Reise info


    if (!validerReiseInfoSkjema(reiseInfo)) return;


    reiseInformasjonen = reiseInfo;

    GUIModuleSPA.addReiseInfo(1);
    $("#reg0").hide();
    $("#endre0").show();
    if (GUIModuleSPA.testReiseInformasjon()) {
        GUIModuleSPA.changeSchemaState(0, 1);
    }
    else {
        GUIModuleSPA.changeSchemaState(0, 4);
    }

    genererPersonInfoSkjema(reiseInfo);
}
//---------GUI
async function lagreReiseInfoServer() {


    await $.post("/billett/lagreBillett/", reiseInformasjonen).done((res) => {

    }).promise();
}

async function lagreBetaling() {
    const betalingsInfo = {
        betalingsId: -1,
        csv: $('#csv').val(),
        kortnummer: $('#kortnummer').val(),
        kortholderNavn: $('#kortholderNavn').val(),
        utloper: $('#utloper').val(),
        postnr: $("#postnr").val(),
        postSted: $("#poststed").val(),
        adresse: $("#adresse").val(),
        telefon: $("#telefon").val(),
        email: $("#email").val()
    };

    if (!validerBetalingSkjema(betalingsInfo)) return;
    let ant = GUIModuleSPA.hentAntallPersoner();
    let canContinue = true;

    await lagreReiseInfoServer().catch((err) => { canContinue = false; });
    if (!canContinue) return;

        //Send alle personer til server
        for (i = 1; i <= ant; i++) {
            
            await lagrePersonServer(i).catch((err) => { canContinue = false; });
            if (!canContinue) return;
        }

        //Send alle lugarene til server
        for (i = 0; i < lugarene.length; i++) {
            await velgLugar(lugarene[i]).catch((err) => { canContinue = false; });
            if (!canContinue) return;
        }

        $.post("/billett/utforBetaling/", betalingsInfo).done((res) => {

            //window.location.reload(true);
            hentBilletter();

        }).promise();

     


   
}


async function endrePerson(skjemaNr) {
    const person2 = {
        personId: $("#personId" + skjemaNr).val(),
        fornavn: $("#fornavn" + skjemaNr).val(),
        etternavn: $("#etternavn" + skjemaNr).val(),
        telefon: $("#telefon" + skjemaNr).val()
    };
    let ant = GUIModuleSPA.hentAntallPersoner();
    for (i =0; i <= ant; i++)
        if (JSON.stringify(personene[i]) === JSON.stringify(person2)) return;
    if (!validerPersonSkjema(person2, skjemaNr)) return;
    personene[skjemaNr] = person2;

}

async function lagrePerson(skjemaNr) {

    const person2 = {
        fornavn: $("#fornavn" + skjemaNr).val(),
        etternavn: $("#etternavn" + skjemaNr).val(),
        telefon: $("#telefon" + skjemaNr).val()
    };

    let val = skjemaNr;
    let ant = GUIModuleSPA.hentAntallPersoner();
    for (i = 0; i <= ant; i++)
        if (JSON.stringify(personene[i]) === JSON.stringify(person2)) return;

    if (!validerPersonSkjema(person2, skjemaNr)) return;
    personene[skjemaNr] = person2;
    $("#leggTilPerson" + val).hide();
    $("#endrePerson" + val).show();

    GUIModuleSPA.addPersoner(1);
    
    if (GUIModuleSPA.testAntallPersoner()) {
        GUIModuleSPA.changeSchemaState(2, 1);
    }
    else {
        GUIModuleSPA.changeSchemaState(2, 4);
    }


}

async function lagrePersonServer(skjemaNr) {



    await $.post("/billett/lagrePerson/", personene[skjemaNr]).done((res) => {


    }).promise();
}



function setPris(pris) {
    $("#pris").html('<p>' + pris + '</p>');
}
async function beregnPris() {


}



async function hentForekomstDato() {
    $("#avgangsDato").html("");
    $("#avgangsTid").html("");
    
    let rute = {
        fra: $("#fra").val(),
        til: $("#til").val()
    }
    if (!validerRute(rute)) return;

    await $.post("/billett/hentForekomsterDato/", rute).done((res) => {

        for (i = 0; i < res.length; i++) {
            setDato(res[i].avgangsDato);
        }

        $("#ruteValgt").val(res[0].ruteId);
    } )
    .promise();
}


async function hentForekomstDatoTid() {
    $("#avgangsTid").html("");
    let forekomstDato = {
        ruteId: $("#ruteValgt").val(),
        avgangsDato: $("#avgangsDato").val()
    }
    if (!validerRuteForekomst(forekomstDato)) return;

    await $.post("/billett/hentForekomsterDatoTid/", forekomstDato).done((res) => {
 
        for (i = 0; i < res.length; i++) {
            setTid(res[i].avgangsTid);
        }
    }) .promise();
}





async function hentFraHavner() {

    await $.get("/billett/hentHavner/").done((res) => {

        for (i = 0; i < res.length; i++) {
            setFraHavn(res[i]);
        }


    }).promise();
}

function setFraHavn(havn) {
    $("#fra").append('<option value = "' + havn.havnId + '">' + havn.navn + ' </option>');

}

async function hentTilHavner(id) {
    $("#til").html("");
    let val = id;
    await $.get("/billett/hentTilHavner/" + val).done((res) => {

        for (i = 0; i < res.length; i++) {
            setTilHavn(res[i]);
        }


    }).promise();
}

function setTilHavn(havn) {
    $("#til").append('<option value = "' + havn.havnId + '">' + havn.navn + ' </option>');

}
function setDato(dato) {
    $("#avgangsDato").append('<option value = "' + dato + '">' + dato + ' </option>');
}

function setTid(tid) {
    $("#avgangsTid").append('<option value = "' + tid + '">' + tid + ' </option>');
}

async function huskLugar(id, body, ant) {
    lugarene.push(id);
    GUIModuleSPA.leggTilMaksPlasser(parseInt(ant, 10));

    leggTilLugarOversikt(body);
    $("#lugarerTilValg").html("");

    if (GUIModuleSPA.testAntallLugarer()) {
        GUIModuleSPA.changeSchemaState(1, 1);
    }
    else {
        GUIModuleSPA.changeSchemaState(1, 4);
    }
}
async function velgLugar(id) {

    await $.get("/billett/velgLugar/" + id).done((res) => {

  

    }).promise();
}

async function hentBilletter() {

    await $.get("/billett/hentBillettFormatertListe/").done((res) => {

        html = '<div class="container">';

        for (i = 0; i < res.length; i++) {

            html += ' <div class="card" style="width: 18rem;">'

            html +=  '   <div class="card-body">'

            html +=   '      <h5 class="card-title">Billett </h5>'

            html +=     '  <p class="card-text">';

            html += "<p><strong> Navn: </strong> " + res[i].navn + "</p>";
            html += "<p><strong> Fra: </strong> " + res[i].fra + "</p>";
            html += "<p><strong> Til: </strong> " + res[i].til + "</p>";
            html += "<p><strong> Dato: </strong> " + res[i].avgangsDato + "</p > ";
            html += "<p><strong> Tid: </strong> " + res[i].avgangsTid + "</p > ";
            html += "<p><strong> RomNr: </strong> ";
            for (j = 0; j < res[i].listeRomNr.length; j++) {
                html += res[i].listeRomNr[j] + " ";
            }
            html += "</p> ";
            html +="    </div>"
            html += " </div>";
        }
        html += '</div>';

        $(html).appendTo("#billetter");
        $("#regform4").hide();

    }).promise();
}
async function hentFiltrerteLugarer() {
    let filterData = {
        prisMin: $("#prisMin").val(),
        prisMaks: $("#prisMaks").val(),
        antall: $("#antall").val(),
        harWc: $("#wc").prop("checked"),
        harDysj: $("#dysj").prop("checked"),
        harWifi: $("#wifi").prop("checked"),
        fra: reiseInformasjonen.fra,
        til: reiseInformasjonen.til,
        avgangsDato: reiseInformasjonen.avgangsDato,
        avgangsTid: reiseInformasjonen.avgangsTid

    }

    if (!validerFilterLugar(filterData)) return;

    $.post("/billett/hentFiltrerteLugarer",filterData).done((res) => {
    
        let typeValgt = [];

        for (i = 0; i < res.length; i++) {
            //Har allerede lugaren

            if (lugarene.includes(res[i].lugarId)) continue;

            //Kun en av hver type
            if (typeValgt.includes(res[i].lugarType)) continue;

            typeValgt.push(res[i].lugarType);

            let lugarHTML =
                ' <div class="card col-md-6"> <img class="card-img-top" src="' + res[i].bildeURL + '"></img> ' +
                ' <div class="card-body">' +
                ' <h5 class="card-title">' + res[i].tittel + '</h5>' +
                '    <p class="card-text"> <strong> Pris:</strong> ' + res[i].pris + ' </p>' +
                '    <p class="card-text"> <strong> Maks antall personer:</strong> ' + res[i].antall + ' </p>' +


                '    <p class="card-text"> ' + res[i].beskrivelse + '</p> ' +
                '        <div class="row"> ';

            if (res[i].harWc) {
                lugarHTML +=
                    '            <div class="col-sm-4"> ' +
                    '                    <i class="fas fa-toilet"> Wc</i> ' +

                    '            </div> ';
 
            
            }
            if (res[i].harDysj) {

                lugarHTML += '            <div class="col-sm-4"> ' +
                    '                    <i class="fa fa-shower" aria-hidden="true">    Dysj</i> ' +

                    '            </div> ';

            }
            if (res[i].harWifi) {
                lugarHTML += '            <div class="col-sm-4"> ' +

                    '                    <i class="fa fa-wifi" aria-hidden="true"> Wifi </i> ' +
                    '            </div> ';
            }

            lugarHTML += '        </div> ' +
                '    <a href="#" class="btn btn-primary" id = "listeValg' + res[i].lugarId + '">Velg lugar</a> </div>' +
                '    </div> ';
            leggTilLugarSokOversikt(lugarHTML);

            let lugarHTMLOversikt  =
                ' <div class="card col-md-6"> <img class="card-img-top" src="' + res[i].bildeURL + '"></img> ' +
                ' <div class="card-body">' +
                ' <h5 class="card-title">' + res[i].tittel + '</h5>' +
                '    <p class="card-text"> <strong> Pris:</strong> ' + res[i].pris + ' </p>' +
                '    <p class="card-text"> <strong> Maks antall personer:</strong> ' + res[i].antall + ' </p>' +
                '    <p class="card-text"> <strong> Rom nr:</strong> ' + res[i].romNr + ' </p>' +
                '    <p class="card-text"> ' + res[i].beskrivelse + '</p> ' +
                '        <div class="row"> ';

            if (res[i].harWc) {
                lugarHTMLOversikt +=
                    '            <div class="col-sm-4"> ' +
                    '                    <i class="fas fa-toilet"> Wc</i> ' +

                    '            </div> ';


            }
            if (res[i].harDysj) {

                lugarHTMLOversikt += '            <div class="col-sm-4"> ' +
                    '                    <i class="fa fa-shower" aria-hidden="true">    Dysj</i> ' +

                    '            </div> ';

            }
            if (res[i].harWifi) {
                lugarHTMLOversikt += '            <div class="col-sm-4"> ' +

                    '                    <i class="fa fa-wifi" aria-hidden="true"> Wifi </i> ' +
                    '            </div> ';
            }

            lugarHTMLOversikt +=  '    </div> ';


            let val = res[i].lugarId;
            let ant = res[i].antall;


            $("#listeValg" + res[i].lugarId).click((e) => {


                huskLugar(val, lugarHTMLOversikt, ant);
            });

        }





    }).promise();
}





async function slettLugarer() {

    GUIModuleSPA.fjernAlleLugarer();
    lugarene = [];
    if (GUIModuleSPA.testAntallLugarer()) {
        GUIModuleSPA.changeSchemaState(1, 1);
    }
    else {
        GUIModuleSPA.changeSchemaState(1, 2);
    }
    $("#lugarerTilValg").html("");
    $("#lugarOversikt").html("");


}





function genererPersonInfoSkjema(info) {

    let antBarn = parseInt(info.antBarn, 10);
    let antVoksen = parseInt(info.antVoksen, 10);

    let antPersoner = antBarn + antVoksen;

    GUIModuleSPA.settKravAntPersoner(antPersoner);
    //Legger til et nytt person registerings skjema i element med id personer
    for (let i = 1; i <= antPersoner; i++) {

        $('<div class="form-group">' +
            '<label for="person ' + i + ' class="col-sm-3 control-label"> ' +
            ' <h1>Person ' + i + ' </h1> ' +
            '</label>' +
            '<input type = "hidden" id="personId' + i + '"/>' +
            '<label for="fornavn ' + i + ' class="col-sm-3 control-label"> ' +
            '<b>  Fornavn ' + ' </b> ' +
            '</label>' +
            '<div class="col-sm-9">' +
            '   <input type="text" ' +
            '      id="fornavn' + i + '"' +
            '       placeholder="Fornavn"' +
            '       class="form-control"' +
            '       autofocus="" />' +
            ' <span id="fornavnFeil' + i + '"></span>' +
            ' </div>' +
            '<label for="etternavn ' + i + ' class="col-sm-3 control-label"> ' +
            '<b>  Etternavn ' + ' </b> ' +
            '</label>' +
            '<div class="col-sm-9">' +
            '   <input type="text" ' +
            '      id="etternavn' + i + '"' +
            '       placeholder="Etternavn"' +
            '       class="form-control"' +
            '       autofocus="" />' +
            ' </div>' +
            ' <span id="etternavnFeil' + i + '"></span>' +
            '<label for="telefon ' + i + ' class="col-sm-3 control-label"> ' +
            '<b>Telefon ' + ' </b> ' +
            ' </div>' +
            '</label>' +
            '<div class="col-sm-9">' +
            '   <input type="tlf" ' +
            '      id="telefon' + i + '"' +
            '       placeholder="Telefon"' +
            '       class="form-control"' +
            '       autofocus="" />' +
            ' </div>' +
            ' <span id="telefonFeil' + i + '"></span>' +
            ' <button type="button" class="btn btn-success" id="leggTilPerson' + i + '"' + ' > Legg til </button> ' +
            ' <button type="button" class="btn btn-warning" id="endrePerson' + i + '"' + ' > Endre </button> ' +
            ' </div>' +
            '</div>').appendTo("#personer");

 

        $("#endrePerson" + i).click((e) => {
            endrePerson( i);
        });

        $("#leggTilPerson" + i).click((e) => {
            lagrePerson(i)
        });
        $("#endrePerson" + i).hide();


        $('#fornavn' + i).change((x) => {

            let fornavnSjekk = validerFornavn(x.target.value);
            if (!fornavnSjekk) $("#fornavnFeil" + i).html("<p> fornavn <p>");
            else $("#fornavnFeil" + i).html("");

 

        });
        $('#etternavn' + i).change((x) => {
            let etternavnSjekk = validerEtternavn(x.target.value);
            if (!etternavnSjekk) $("#etternavnFeil" + i).html("<p> etternavn <p>");
            else $("#etternavnFeil" + i).html("");


        });
        $('#telefon' + i).change((x) => {
            let telefonSjekk = validerTelefonNummer(x.target.value);
            if (!telefonSjekk) $("#telefonFeil" + i).html("<p> telefon <p>");
            else $("#telefonFeil" + i).html("");
        });
    }
}





function leggTilLugarOversikt(html) {

    $(html).appendTo("#lugarOversikt");
}
function leggTilLugarSokOversikt(html) {

    $(html).appendTo("#lugarerTilValg");
}


function setPersonInfo(nummerPerson, personInfo) {


    $('#personId' + nummerPerson).val(personInfo.personId);

    $('#fornavn' + nummerPerson).val(personInfo.fornavn);
    $('#etternavn' + nummerPerson).val(personInfo.etternavn);
    $('#telefon' + nummerPerson).val(personInfo.telefon);



}