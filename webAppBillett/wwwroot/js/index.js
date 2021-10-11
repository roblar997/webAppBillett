
$(() => {

    //TODO
    hentFraHavner().then((x) => {

        hentTilHavner($("#fra").val());


    })
    $('#fra').change((x) => {
    });

    $('#til').change((x) => {
    });

    $("#antBarn").change((x) => {

    });

    $("#antVoksen").change((x) => {

    });

    $('#avgangsDato').change((x) => {
    });

    $('#avgangsTid').change((x) => {

    });

    //Betaling

    $('#csv').change((x) => {
        validerCsv(this.value);
    });

    $('#kortnummer').change((x) => {
        validerKortnummer(x.target.nodeValue);
    });

    $('#kortholderNavn').change((x) => {
        validerKortholderNavn(x.target.nodeValue);
     });

    $('#utloper').change((x) => {
        validerUltopsDato(x.target.nodeValue);
    });

    $("#postnr").change((x) => {
        validerPostNr(x.target.nodeValue);
    });

    $("#poststed").change((x) => {
        validerPoststed(x.target.nodeValue);
     });

    $("#adresse").change((x) => {
        validerAdresse(x.target.nodeValue);
    });

    $("#telefon").change((x) => {
        validerTelefonNummer(x.target.nodeValue);
     });

    $("#email").change((x) => {
        validerEmail(x.target.nodeValue);
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


    await $.post("/billett/lagreReiseInformasjon/", reiseInformasjonen).done((res) => {

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

        await lagreReiseInfoServer();
        //Send alle personer til server
        for (i = 1; i <= ant; i++) {
            await lagrePersonServer(i);
        }

        //Send alle lugarene til server
        for (i = 0; i < lugarene.length; i++) {
            await velgLugar(lugarene[i]);
        }

        $.post("/billett/utforBetaling/", betalingsInfo).done((res) => {

            window.location.reload(true);

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

        $('#personId' + i).change((x) => {
        });

        $('#fornavn' + i).change((x) => {
            validerFornavn(this.value, i);
        });
        $('#etternavn' + i).change((x) => {
            validerEtternavn(this.value, i);
        });
        $('#telefon' + i).change((x) => {
            validerTelefonNummer(this.value, i);
        });
    }
}





function leggTilLugarOversikt(html) {

    $(html).appendTo("#lugarOversikt");
}
function leggTilLugarSokOversikt(html) {

    $(html).appendTo("#lugarerTilValg");
}fe


function setPersonInfo(nummerPerson, personInfo) {


    $('#personId' + nummerPerson).val(personInfo.personId);

    $('#fornavn' + nummerPerson).val(personInfo.fornavn);
    $('#etternavn' + nummerPerson).val(personInfo.etternavn);
    $('#telefon' + nummerPerson).val(personInfo.telefon);



}