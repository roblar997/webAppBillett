
$(() => {

    // Reise info


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
        validerKortnummer(this.value);
    });

    $('#kortholderNavn').change((x) => {
        validerKortholderNavn(this.value);
     });

    $('#utloper').change((x) => {
        validerUltopsDato(this.value);
    });

    $("#postnr").change((x) => {
        validerPostNr(this.value);
    });

    $("#poststed").change((x) => {
        validerPoststed(this.value);
     });

    $("#adresse").change((x) => {
        validerAdresse(this.value);
    });

    $("#telefon").change((x) => {
        validerTelefonNummer(this.value);
     });

    $("#email").change((x) => {
        validerEmail(this.value);
    });

    //TODO
    hentFraHavner().then((x) => {

        hentTilHavner($("#fra").val());
        hentReiseInfoServer().then((ok) => {
            hentPersonInfoServer();
            hentLugarInfoServer();

           
           
            
         
          
        }, (err) => {
            hentPersonInfoServer();
            hentLugarInfoServer(); });

    })
 
    $("#reg0").click((e) => {
        let info = {
            fra: $('#fra').val(),
            til: $('#til').val(),
            avgangsDato: $('#avgangsDato').val(),
            avgangsTid: $('#avgangsTid').val(),
            antBarn: $("#antBarn").val(),
            antVoksen: $("#antVoksen").val(),
        };

        if (!validerReiseInfoSkjema(info)) return;

        lagreReiseInfoServer();
        sendReiseInformasjon(info);

        
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
    $("#slettBillett").click((e) => {
        slettBillettServer();
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

  //  $("#til").change((e) => {
 //   
 //       $("#fra")[0].selectedIndex = index;
  //  });


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

        if (erGyldig) {
            endreReiseInfoServer(info);

        }
    });



    $("#slettLugarer").click((e) => {
        resetLugarOversikt();
    });


});

//---------GUI
async function endreReiseInfoServer(reiseInfo) {
    const reiseInfo2 = {
        reiseId: 1,
        fra: $('#fra').val(),
        til: $('#til').val(),
        antBarn: $("#antBarn").val(),
        antVoksen: $("#antVoksen").val(),
        avgangsDato: $('#avgangsDato').val(),
        avgangsTid: $('#avgangsTid').val()
    };




    $.post("/billett/endreReiseInformasjon/", reiseInfo2).done((res) => {
        $("#personer").html("");
        //Ny reiseInfo, så fjern lugarene.
        slettLugarer();
        genererPersonInfoSkjema(reiseInfo2);
    }).promise();
}


//---------GUI
async function lagreReiseInfoServer() {
    const reiseInfo = {
        reiseId: -1,
        fra: $('#fra').val(),
        til: $('#til').val(),
        antBarn: $("#antBarn").val(),
        antVoksen: $("#antVoksen").val(),
        avgangsDato: $('#avgangsDato').val(),
        avgangsTid: $('#avgangsTid').val()
    };

    if (!validerReiseInfoSkjema(reiseInfo)) return;



    $.post("/billett/lagreReiseInformasjon/", reiseInfo).done((res) => {
        GUIModuleSPA.addReiseInfo(1);
        $("#reg0").hide();
        $("#endre0").show();
        if (GUIModuleSPA.testReiseInformasjon()) {
            GUIModuleSPA.changeSchemaState(0, 1);
        }
        else {
            GUIModuleSPA.changeSchemaState(0, 2);
        }
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


    $.post("/billett/utforBetaling/", betalingsInfo).done((res) => {

    document.getElementById("regform").reset();
    $("#avgangsDato").html("");
    $("#avgangsTid").html("");
    $("#lugarOversikt").html("");
    GUIModuleSPA.fjernAlleLugarer();
    GUIModuleSPA.fjernAllePersoner();
    GUIModuleSPA.fjernAlleReiseInformasjon();
    GUIModuleSPA.changeSchemaState(0, 4);
    GUIModuleSPA.changeSchemaState(1, 2);
    GUIModuleSPA.changeSchemaState(2, 2);
    $("#regform").show();
    $("#regform2").hide();
    $("#regform3").hide();

    $("#regform4").hide();

    $("#reg0").show();
    $("#endre0").hide();

    hentFraHavner().then((x) => {

        hentTilHavner($("#fra").val());
        hentReiseInfoServer().then((ok) => {
            hentPersonInfoServer();
            hentLugarInfoServer();






        }, (err) => {
            hentPersonInfoServer();
            hentLugarInfoServer();
        });

    })

    }).promise();
}


async function endrePersonServer(id, skjemaNr) {
    const person2 = {
        personId: $("#personId" + skjemaNr).val(),
        fornavn: $("#fornavn" + skjemaNr).val(),
        etternavn: $("#etternavn" + skjemaNr).val(),
        telefon: $("#telefon" + skjemaNr).val()
    };
    if (!validerPersonSkjema(person2, skjemaNr)) return;

    $.post("/billett/endrePerson/", person2).done((res) => {

    }).promise();
}

async function lagrePersonServer(skjemaNr) {


    const person2 = {
        fornavn: $("#fornavn" + skjemaNr).val(),
        etternavn: $("#etternavn" + skjemaNr).val(),
        telefon: $("#telefon" + skjemaNr).val()
    };

    if (!validerPersonSkjema(person2, skjemaNr)) return;
    let val = skjemaNr;

    $.post("/billett/lagrePerson/", person2).done((res) => {

        $("#leggTilPerson" + val).hide();
        $("#endrePerson" + val).show();

        GUIModuleSPA.addPersoner(1);
        $("#personId" + val).val(res);
        if (GUIModuleSPA.testAntallPersoner()) {
            GUIModuleSPA.changeSchemaState(2, 1);
        }
        else {
            GUIModuleSPA.changeSchemaState(2, 2);
        }
    }).promise();
}



function setPris(pris) {
    $("#pris").html('<p>' + pris + '</p>');
}
async function beregnPris() {

    await $.get("/billett/beregnPris/").done((res) => {
        setPris(res);
    }).promise();
}

async function hentReiseInfoServer() {

    await $.get("/billett/hentReiseInformasjon/").done((res) => {
        setReiseInfo(res);
        $("#reg0").hide();
        $("#endre0").show();
        GUIModuleSPA.addReiseInfo(1);

        if (GUIModuleSPA.testReiseInformasjon()) {
            GUIModuleSPA.changeSchemaState(0, 1);
        }
        else {
            GUIModuleSPA.changeSchemaState(0, 2);
        }



    }).promise();
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
async function velgLugar(id, body,ant) {

    $.get("/billett/velgLugar/" + id).done((res) => {
        GUIModuleSPA.leggTilMaksPlasser(parseInt(ant,10));

        leggTilLugarOversikt(body);
        $("#lugarerTilValg").html("");

        if (GUIModuleSPA.testAntallLugarer()) {
            GUIModuleSPA.changeSchemaState(1, 1);
        }
        else {
            GUIModuleSPA.changeSchemaState(1, 2);
        }

    }).promise();
}

async function hentLugarInfoServer() {



    $.get("/billett/hentLugarer").done((res) => {

        for (i = 0; i < res.length; i++) {
            let lugarHTMLOversikt =
                ' <div class="card col-md-6"> <img class="card-img-top" src="' + res[i].bildeURL + '"></img> ' +
                ' <div class="card-body">' +
                ' <h5 class="card-title">' + res[i].tittel + '</h5>' +
                '    <p class="card-text"> <strong> Pris:</strong> ' + res[i].pris + ' </p>' +
                '    <p class="card-text"> <strong> Maks antall personer:</strong> ' + res[i].antall + ' </p>' +
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

            lugarHTMLOversikt += '    </div> ';


            leggTilLugarOversikt(lugarHTMLOversikt);
            GUIModuleSPA.leggTilMaksPlasser(res[i].antall);
        }


        if (GUIModuleSPA.testAntallLugarer()) {
            GUIModuleSPA.changeSchemaState(1, 1);
        }
        else {
            GUIModuleSPA.changeSchemaState(1, 2);
        }

    }).promise();
}
async function hentFiltrerteLugarer() {
    let filterData = {
        prisMin: $("#prisMin").val(),
        prisMaks: $("#prisMaks").val(),
        antall: $("#antall").val(),
        harWc: $("#wc").prop("checked"),
        harDysj: $("#dysj").prop("checked"),
        harWifi: $("#wifi").prop("checked")

    }

    if (!validerFilterLugar(filterData)) return;

    $.post("/billett/hentFiltrerteLugarer",filterData).done((res) => {
    

        for (i = 0; i < res.length; i++) {
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


                velgLugar(val, lugarHTMLOversikt,ant);
            });

        }





    }).promise();
}





async function slettLugarer() {

    $.get("/billett/slettLugarer").done((res) => {


        GUIModuleSPA.fjernAlleLugarer();

        if (GUIModuleSPA.testAntallLugarer()) {
            GUIModuleSPA.changeSchemaState(1, 1);
        }
        else {
            GUIModuleSPA.changeSchemaState(1, 2);
        }
        $("#lugarerTilValg").html("");
        $("#lugarOversikt").html("");
    }).promise();
}
async function slettBillettServer() {

    await $.get("/billett/slettBillett").done((res) => {
       
    }).promise();

    document.getElementById("regform").reset();

    $("#avgangsDato").html("");
    $("#avgangsTid").html("");
    $("#lugarOversikt").html("");
    GUIModuleSPA.fjernAlleLugarer();
    GUIModuleSPA.fjernAllePersoner();
    GUIModuleSPA.fjernAlleReiseInformasjon();
    GUIModuleSPA.changeSchemaState(0, 4);
    GUIModuleSPA.changeSchemaState(1, 2);
    GUIModuleSPA.changeSchemaState(2, 2);
    $("#regform").show();
    $("#regform2").hide();
    $("#regform3").hide();

    $("#regform4").hide();

    $("#reg0").show();
    $("#endre0").hide();

    hentFraHavner().then((x) => {

        hentTilHavner($("#fra").val());
        hentReiseInfoServer().then((ok) => {
            hentPersonInfoServer();
            hentLugarInfoServer();






        }, (err) => {
            hentPersonInfoServer();
            hentLugarInfoServer();
        });

    })


}

async function hentPersonInfoServer() {

    GUIModuleSPA.fjernAllePersoner();
    $.get("/billett/hentPersoner/").done((res) => {

        if (res.length == 0) return;
       GUIModuleSPA.addPersoner(res.length);
        for (i = 0; i < res.length; i++) {
            setPersonInfo(i + 1, res[i]);
            
            $("#endrePerson" + (i + 1)).show();
            $("#leggTilPerson" + (i + 1)).hide();
        }

        if ($("#fornavn1").val() == undefined) {
            setTimeout(hentPersonInfoServer(), 1000);
        }

        if (GUIModuleSPA.testAntallPersoner()) {
            GUIModuleSPA.changeSchemaState(2, 1);
        }
        else {
            GUIModuleSPA.changeSchemaState(2, 2);
        }
    }).promise();


}





function genererPersonInfoSkjema(info) {

    let antBarn = parseInt(info.antBarn, 10);
    let antVoksen = parseInt(info.antVoksen, 10);

    let antPersoner = antBarn + antVoksen;


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
            ' <button type="button" class="btn btn-success" id="leggTilPerson' + i + '"' + ' > Legg til </button> ' +
            ' <button type="button" class="btn btn-warning" id="endrePerson' + i + '"' + ' > Endre </button> ' +
            ' </div>' +
            '</div>').appendTo("#personer");

        GUIModuleSPA.settKravAntPersoner(antPersoner);

        $("#endrePerson" + i).click((e) => {
            endrePersonServer(i, i);
        });

        $("#leggTilPerson" + i).click((e) => {
            lagrePersonServer(i)
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
function sendReiseInformasjon(info) {

    genererPersonInfoSkjema(info);

}




function leggTilLugarOversikt(html) {

    $(html).appendTo("#lugarOversikt");
}
function leggTilLugarSokOversikt(html) {

    $(html).appendTo("#lugarerTilValg");
}
async function setReiseInfo(reiseInfo) {

    $('#antBarn').val(reiseInfo.antBarn);
    $('#antVoksen').val(reiseInfo.antVoksen);
    $('#fra').val(reiseInfo.fra);

    await hentTilHavner(reiseInfo.fra);
    $("#til").val(reiseInfo.til);
     await hentForekomstDato();
   
    $('#avgangsDato').val(reiseInfo.avgangsDato);
    
     hentForekomstDatoTid();
    $('#avgangsTid').val(reiseInfo.avgangsTid);
    genererPersonInfoSkjema(reiseInfo);
}


function setPersonInfo(nummerPerson, personInfo) {
   
    $('#personId' + nummerPerson).val(personInfo.personId);

    $('#fornavn' + nummerPerson).val(personInfo.fornavn);
    $('#etternavn' + nummerPerson).val(personInfo.etternavn);
    $('#telefon' + nummerPerson).val(personInfo.telefon);



}