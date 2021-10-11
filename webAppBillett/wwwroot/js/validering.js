function validerFornavn(input) {
    if (input == undefined || input == null) return false;
    let regexp = /^[a-zA-Z]+$/;
    let minLen = 4;
    let maxLen = 10;
    if (input.length < minLen || input.length > maxLen) return false;
    if (!regexp.test(input)) return false;

    return true;
}

function validerEtternavn(input) {
    if (input == undefined || input == null) return false;
    let regexp = /^[a-zA-Z]+$/;
    let minLen = 4;
    let maxLen = 10;
    if (input.length < minLen || input.length > maxLen) return false;
    if (!regexp.test(input)) return false;

    return true;
}

function validerTelefonNummer(input) {
    if (input == undefined || input == null) return false;
    let regexp = /^(\+[0-9]+)?[0-9]+$/;
    let minLen = 8;
    let maxLen = 15;
    if (input.length < minLen || input.length > maxLen) return false;
    if (!regexp.test(input)) return false;
    return true;
}


function validerPoststed(input) {
    if (input == undefined || input == null) return false;
    let regexp = /^[a-zA-Z]+$/;
    let minLen = 4;
    let maxLen = 10;
    if (input.length < minLen || input.length > maxLen) return false;
    if (!regexp.test(input)) return false;

    return true;
}
function validerPostNr(input) {
    if (input == undefined || input == null) return false;
    let regexp = /^[0-9]{4,4}$/;
    if (!regexp.test(input)) return false;

    return true;
}
function validerAdresse(input) {
    if (input == undefined || input == null) return false;
    let regexp = /^[a-zA-Z0-9/s]+$/;
    let minLen = 4;
    let maxLen = 10;
    if (input.length < minLen || input.length > maxLen) return false;
    if (!regexp.test(input)) return false;

    return true;
}
function validerEmail(input) {
    if (input == undefined || input == null) return false;
    let regexp = /^[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(([a-zA-Z]+)|([a-zA-z0-9]+[a-zA-z]+)|([a-zA-z]+[a-zA-Z0-9]+))((.|[a-zA-Z0-9-]+)([a-zA-Z0-9])+)*$/;
    let minLen = 4;
    let maxLen = 10;
    if (input.length < minLen || input.length > maxLen) return false;
    if (!regexp.test(input)) return false;

    return true;
}


function validerKortholderNavn(input) {
    if (input == undefined || input == null) return false;
    let regexp = /^[a-zA-Z0-9/s]+$/;

    let minLen =4;
    let maxLen = 15;
    if (input.length < minLen || input.length > maxLen) return false;
    if (!regexp.test(input)) return false;

    return true;
}
function validerKortnummer(input) {

    if (input == undefined || input == null) return false;
    let regexp = /^[0-9]+$/;

    let minLen = 10;
    let maxLen = 15;
    if (input.length < minLen || input.length > maxLen) return false;
    if (!regexp.test(input)) return false;

    return true;
}
function validerCsv(input) {
    if (input == undefined || input == null) return false;
    alert(typeof input);
    let regexp = /^[0-9]{3,3}$/;
    if (!regexp.test(input)) return false;
    return true;
}
function validerUltopsDato(input) {
    if (input == undefined || input == null) return false;
    return true;
}



function validerAntVoksen(input) {
    if (input == undefined || input == null) return false;
    let regexp = /^(0|([1-9][0-9]*))$/;
    let minLen = 1;
    let maxLen = 3;
    if (input.length < minLen || input.length > maxLen) return false;
    if (!regexp.test(input)) return false;
    return true;
}
function validerAntBarn(input) {
    if (input == undefined || input == null) return false;
    let regexp = /^(0|([1-9][0-9]*))$/;
    let minLen = 1;
    let maxLen = 3;
    if (input.length < minLen || input.length > maxLen) return false;
    if (!regexp.test(input)) return false;
    return true;
}


function validerFra(input) {
    if (input == undefined || input == null) return false;
    let regexp = /^(0|([1-9]*))$/;
    let minLen = 1;
    let maxLen = 3;
    if (input.length < minLen || input.length > maxLen) return false;
    if (!regexp.test(input)) return false;
    return true;
}
function validerTil(input) {
    if (input == undefined || input == null) return false;
    let regexp = /^(0|([1-9]*))$/;
    let minLen = 1;
    let maxLen = 3;
    if (input.length < minLen || input.length > maxLen) return false;
    if (!regexp.test(input)) return false;
    return true;
}

function validerAvgangsDato(input) {
    if (input == undefined || input == null) return false;
    return true;
}
function validerAvgangsTid(input) {
    if (input == undefined || input == null) return false;
    return true;
}


function validerPrisMin(input) {
    if (input == undefined || input == null) return false;
    let regexp = /^(0|([1-9][0-9]*))$/;
    let minLen = 1;
    let maxLen = 3;
    if (input.length < minLen || input.length > maxLen) return false;
    if (!regexp.test(input)) return false;
    return true;
}

function validerPrisMaks(input) {
    if (input == undefined || input == null) return false;
    let regexp = /^(0|([1-9][0-9]*))$/;
    let minLen = 1;
    let maxLen = 3;
    if (input.length < minLen || input.length > maxLen) return false;
    if (!regexp.test(input)) return false;
    return true;
}
function validerPrisAntall(input) {
    if (input == undefined || input == null) return false;
    let regexp = /^(0|([1-9][0-9]*))$/;
    let minLen = 1;
    let maxLen = 3;
    if (input.length < minLen || input.length > maxLen) return false;
    if (!regexp.test(input)) return false;
    return true;
}
function validerCheckBox(input) {
    if (input == undefined || input == null) return false;
    return input === false || input === true;
}
function validerAntall(input) {
    if (input == undefined || input == null) return false;
    let regexp = /^(0|([1-9][0-9]*))$/;
    let minLen = 1;
    let maxLen = 3;
    if (input.length < minLen || input.length > maxLen) return false;
    if (!regexp.test(input)) return false;
    return true;
}

function validerRuteId(input) {
    if (input == undefined || input == null) return false;
    let regexp = /^(0|([1-9][0-9]*))$/;
    let minLen = 1;
    let maxLen = 3;
    if (input.length < minLen || input.length > maxLen) return false;
    if (!regexp.test(input)) return false;
    return true;
}

// Skjema validering

function validerPersonSkjema(data, nummerPerson) {

    let fornavnSjekk = validerFornavn(data.fornavn);
    if (!fornavnSjekk) $("#fornavnFeil" + nummerPerson).html("<p> fornavn <p>");
    else $("#fornavnFeil" + nummerPerson).html("");

    let etternavnSjekk = validerEtternavn(data.etternavn);
    if (!etternavnSjekk) $("#etternavnFeil" + nummerPerson).html("<p> etternavn <p>");
    else $("#etternavnFeil" + nummerPerson).html("");

    let telefonSjekk = validerTelefonNummer(data.telefon);
    if (!telefonSjekk) $("#telefonFeil" + nummerPerson).html("<p> telefon <p>");
    else $("#telefonFeil" + nummerPerson).html("");

    return fornavnSjekk && etternavnSjekk && telefonSjekk;
}

function validerBetalingSkjema(data) {

    let postNrSjekk = validerPostNr(data.postnr);
    if (!postNrSjekk) $("#postnrFeil").html("<p> postnr <p>");
    else $("#postnrFeil").html("");

    let postStedSjekk = validerPoststed(data.postSted);
    if (!postStedSjekk) $("#poststedFeil").html("<p> postnr <p>");
    else $("#poststedFeil").html("");

    let emailSjekk = validerEmail(data.email);
    if (!emailSjekk) $("#emailFeil").html("<p> email <p>");
    else $("#emailFeil").html("");

    let adresseSjekk = validerAdresse(data.adresse);
    if (!adresseSjekk) $("#adresseFeil").html("<p> adresse <p>");
    else $("#adresseFeil").html("");

    let telefonSjekk = validerTelefonNummer(data.telefon);
    if (!telefonSjekk) $("#telefonFeil").html("<p> telefon <p>");
    else $("#telefonFeil").html("");

    let csvSjekk = validerCsv(data.csv);
    if (!csvSjekk) $("#csvFeil").html("<p> csv <p>");
    else $("#csvFeil").html("");

    let kortholderNavnSjekk = validerKortholderNavn(data.kortholderNavn);
    if (!kortholderNavnSjekk) $("#kortholdernavnFeil").html("<p> kortholderNavn<p>");
    else $("#kortholdernavnFeil").html("");


    let utlopsTidSjekk = validerUltopsDato(data.utloper);
    if (!utlopsTidSjekk) $("#utloperFeil").html("<p> utlop <p>");
    else $("#utloperFeil").html("");

    let kortnummerSjekk = validerKortnummer(data.kortnummer);
    if (!kortnummerSjekk) $("#kortnummerFeil").html("<p> kortnummer <p>");
    else $("#kortnummerFeil").html("");

    return telefonSjekk && postNrSjekk && postStedSjekk && emailSjekk && adresseSjekk && csvSjekk && kortholderNavnSjekk && utlopsTidSjekk && kortnummerSjekk;
}

function validerReiseInfoSkjema(data) {
    let fraSjekk = validerFra(data.fra);
    let tilSjekk = validerTil(data.til);
    let avgangsDatoSjekk = validerAvgangsDato(data.avgangsDato);
    let avgangsTidSjekk = validerAvgangsTid(data.avgangsTid);

    let antVoksenSjekkk = validerAntVoksen(data.antVoksen);
    if (!antVoksenSjekkk) $("#antvoksenFeil").html("<p> ant barn <p>");
    else $("#antvoksenFeil").html("");

    let antBarnSjekk = validerAntBarn(data.antBarn);
    if (!antBarnSjekk) $("#antbarnFeil").html("<p> ant barn <p>");
    else $("#antbarnFeil").html("");


  return fraSjekk && tilSjekk && avgangsDatoSjekk && avgangsTidSjekk && antVoksenSjekkk && antBarnSjekk;

}

function validerFilterLugar(data) {

    let antallSjekk = validerAntall(data.antall);
    if (!antallSjekk) $("#antallFeil").html("<p> ant barn <p>");
    else $("#antallFeil").html("");

    let minPrisSjekk = validerPrisMin(data.prisMin);
    if (!minPrisSjekk) $("#minprisFeil").html("<p> min pris <p>");
    else $("#minprisFeil").html("");

    let maksPrisSjekk = validerPrisMaks(data.prisMaks);
    if (!maksPrisSjekk) $("#maksprisFeil").html("<p> maks pris<p>");
    else $("#maksprisFeil").html("");

    let wcSjekk = validerCheckBox(data.harWc);
    let dysjSjekk = validerCheckBox(data.harDysj);
    let wifiSjekk = validerCheckBox(data.harWifi);

    return antallSjekk && minPrisSjekk && maksPrisSjekk && wcSjekk && dysjSjekk && wifiSjekk;

}

// Sub skjema validering

function validerRute(data) {
    let fraSjekk = validerFra(data.fra);

    let tilSjekk = validerTil(data.til);

    return fraSjekk && tilSjekk;
}

function validerRuteForekomst(data) {
    let avgangsDatoSjekk = validerAvgangsDato(data.avgangsDato);
    let ruteIdSjekk = validerRuteId(data.ruteId);

    return avgangsDatoSjekk && ruteIdSjekk;
}