function validerFornavn(input,nummerPerson) {
    let regexp = /^[a-zA-Z]+$/;
    let minLen = 4;
    let maxLen = 10;
    if (input.length < minLen || input.length > maxLen) return false;
    if (regexp.test(input)) return false;

    return true;
}

function validerEtternavn(input,nummerPerson) {
    let regexp = /^[a-zA-Z]+$/;
    let minLen = 4;
    let maxLen = 10;
    if (input.length < minLen || input.length > maxLen) return false;
    if (regexp.test(input)) return false;

    return true;
}

function validerTelefonNummer(input,nummerPerson) {
    let regexp = /^(\+[0-9]+)?[0-9]+$/;
    let minLen = 4;
    let maxLen = 10;
    if (input.length < minLen || input.length > maxLen) return false;
    if (regexp.test(input)) return false;
    return true;
}


function validerPoststed(input) {
    let regexp = /^[a-zA-Z]+$/;
    let minLen = 4;
    let maxLen = 10;
    if (input.length < minLen || input.length > maxLen) return false;
    if (regexp.test(input)) return false;

    return true;
}
function validerPostNr(input) {
    let regexp = /^[0-9]{4,4}$/;
    if (regexp.test(input)) return false;

    return true;
}
function validerAdresse(input) {
    let regexp = /^[a-zA-Z0-9/s]+$/;
    let minLen = 4;
    let maxLen = 10;
    if (input.length < minLen || input.length > maxLen) return false;
    if (regexp.test(input)) return false;

    return true;
}
function validerEmail(input) {
    let regexp = /^[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(([a-zA-Z]+)|([a-zA-z0-9]+[a-zA-z]+)|([a-zA-z]+[a-zA-Z0-9]+))((.|[a-zA-Z0-9-]+)([a-zA-Z0-9])+)*$/;
    let minLen = 4;
    let maxLen = 10;
    if (input.length < minLen || input.length > maxLen) return false;
    if (regexp.test(input)) return false;

    return true;
}


function validerKortholderNavn(input) {
    let regexp = /^[a-zA-Z\s]+ $/;
    let minLen = 4;
    let maxLen = 10;
    if (input.length < minLen || input.length > maxLen) return false;
    if (regexp.test(input)) return false;

    return true;
}
function validerKortnummer(input) {
    return true;
}
function validerCsv(input) {

    return true;
}
function validerUltopsDato(input) {
    return true;
}



function validerAntVoksen(input) {

    return true;
}
function validerAntBarn(input) {

    return true;
}


function validerFra(input) {

    return true;
}
function validerTil(input) {

    return true;
}

function validerAvgangsDato(input) {
    return true;
}
function validerAvgangsTid(input) {
    return true;
}


function validerPrisMin(input) {

    return true;
}

function validerPrisMaks(input) {

    return true;
}
function validerPrisAntall(input) {

    return true;
}
function validerCheckBox(input) {
    return input === false || input === true;
}
function validerAntall(input) {

    return true;
}

function validerRuteId(input) {

    return true;
}

// Skjema validering

function validerPersonSkjema(data, nummerPerson) {
    let fornavnSjekk    = validerFornavn(data.fornavn);
    let etternavnSjekk = validerEtternavn(data.etternavn);
    let telefonSjekk = validerTelefonNummer(data.telefon);

    return fornavnSjekk && etternavnSjekk && telefonSjekk;
}

function validerBetalingSkjema(data) {
    let postNrSjekk = validerPostNr(data.postnr);
    let postStedSjekk = validerPoststed(data.poststed);
    let emailSjekk = validerEmail(data.email);
    let adresseSjekk = validerAdresse(data.adresse);

    let csvSjekk = validerCsv(data.csv);
    let kortholderNavnSjekk = validerKortholderNavn(data.kortholderNavn);
    let utlopsTidSjekk = validerUltopsDato(data.utlopsTid);
    let kortnummerSjekk = validerKortnummer(data.kortnummer);

    return postNrSjekk && postStedSjekk && emailSjekk && adresseSjekk && csvSjekk && kortholderNavnSjekk && utlopsTidSjekk && kortnummerSjekk;
}

function validerReiseInfoSkjema(data) {
    let fraSjekk = validerFra(data.fra);
    let tilSjekk = validerTil(data.til);
    let avgangsDatoSjekk = validerAvgangsDato(data.avgangsDato);
    let avgangsTidSjekk = validerAvgangsTid(data.avgangsTid);
    let antVoksenSjekkk = validerAntVoksen(data.antVoksen);
    let antBarnSjekk = validerAntBarn(data.antBarn);

    return fraSjekk && tilSjekk && avgangsDatoSjekk && avgangsTidSjekk && antVoksenSjekkk && antBarnSjekk;

}

function validerFilterLugar(data) {
    let antallSjekk = validerAntall(data.antall);
    let minPrisSjekk = validerPrisMin(data.prisMin);
    let maksPrisSjekk = validerPrisMaks(data.prisMaks);
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