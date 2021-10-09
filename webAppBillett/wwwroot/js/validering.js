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


// Skjema validering

function validerPersonSkjema(data) {
    let fornavnSjekk    = validerFornavn(data.fornavn);
    let etternavnSjekk = validerEtternavn(data.etternavn);
    let telefonSjekk = validerTelefonNummer(data.telefon);

    return fornavnSjekk && etternavnSjekk && telefonSjekk;
}