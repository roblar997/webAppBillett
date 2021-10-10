function validerFornavn(input, nummerPerson) {
    if (input == undefined || input == null) return false;
    let regexp = /^[a-zA-Z]+$/;
    let minLen = 4;
    let maxLen = 10;
    if (input.length < minLen || input.length > maxLen) return false;
    if (!regexp.test(input)) return false;

    return true;
}

function validerEtternavn(input, nummerPerson) {
    if (input == undefined || input == null) return false;
    let regexp = /^[a-zA-Z]+$/;
    let minLen = 4;
    let maxLen = 10;
    if (input.length < minLen || input.length > maxLen) return false;
    if (!regexp.test(input)) return false;

    return true;
}

function validerTelefonNummer(input, nummerPerson) {
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
    let regexp = /^[0-9]*$/;

    let minLen =10;
    let maxLen = 15;
    if (input.length < minLen || input.length > maxLen) return false;
    if (!regexp.test(input)) return false;

    return true;
}
function validerKortnummer(input) {
    if (input == undefined || input == null) return false;
    return true;
}
function validerCsv(input) {
    if (input == undefined || input == null) return false;
    let regexp = /^[0-9]{3,3}$/;
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
    let fornavnSjekk    = validerFornavn(data.fornavn);
    let etternavnSjekk = validerEtternavn(data.etternavn);
    let telefonSjekk = validerTelefonNummer(data.telefon);

    return fornavnSjekk && etternavnSjekk && telefonSjekk;
}

function validerBetalingSkjema(data) {
    let postNrSjekk = validerPostNr(data.postnr);
    let postStedSjekk = validerPoststed(data.postSted);
    let emailSjekk = validerEmail(data.email);
    let adresseSjekk = validerAdresse(data.adresse);

    let csvSjekk = validerCsv(data.csv);
    let kortholderNavnSjekk = validerKortholderNavn(data.kortholderNavn);
    let utlopsTidSjekk = validerUltopsDato(data.utloper);
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