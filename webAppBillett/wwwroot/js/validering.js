function validerFornavn(input,nummerPerson) {
    return true;
}

function validerEtternavn(input,nummerPerson) {
    return true;
}

function validerTelefonNummer(input,nummerPerson) {
    return true;
}


function validerPoststed(input) {
    return true;
}
function validerPostNr(input) {
    return true;
}
function validerAdresse(input) {
    return true;
}
function validerEmail(input) {
    return true;
}


function validerKortholderNavn(input) {
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


// Skjema validering

function validerPersonSkjema(data) {
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
    let antBarnSjekk = validerAntBarn(dat.antBarn);

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

