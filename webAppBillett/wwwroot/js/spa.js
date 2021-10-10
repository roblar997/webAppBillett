




//Etter dokumentet er lastet inn
$(() => {




    let state = {
        warning: 0,
        success: 1,
        notFinished: 2,
        locked: 3,
        active: 4
    }

    GUIModuleSPA.changeSchemaState(0, state.active);
    $('#regform2').hide();
    $("#regform3").hide();
    $("#regform4").hide();
    $("#endre0").hide();

    $("#btnNeste").click(function () {

        if (GUIModuleSPA.testReiseInformasjon()) {
            $("#regform").hide();
            $("#regform2").show();
            GUIModuleSPA.changeSchemaState(1, state.active);
        }
        else {
            alert("Ikke ferdig med skjemaet");
        }

    });
    $("#btnTilbake1").click(function () {
        $("#regform2").hide();
        $("#regform").show();
        GUIModuleSPA.changeSchemaState(0, state.active);
    });
    $("#btnTilbake2").click(function () {
        $("#regform3").hide();
        $("#regform2").show();
        GUIModuleSPA.changeSchemaState(1, state.active);
    });
    $("#btnNeste2").click(function () {
        if (GUIModuleSPA.testAntallLugarer()) {
            $("#regform2").hide();
            $("#regform3").show();

            GUIModuleSPA.changeSchemaState(2, state.active);
        }
        else {
            alert("Ikke ferdig med skjemaet");
        }

    });
    






});



var GUIModuleSPA = (function () {

    let state = {
        warning: 0,
        success: 1,
        notFinished: 2,
        locked: 3,
        active: 4
    }

    let kravPersonAntall = 1;
    let kravReiseInfoAntall = 1;
    let personerRegistrert = 0;
    let reiseInfoReigstrert = 0;
    let antPlasserRegistrert = 0;

    function leggTilMaksPPlasser(antall) {
        antPlasserRegistrert += antall;
    }
    function hentPPersonAntall() {
        return kravPersonAntall;
    }
    function addPPersoner(antall) {
        personerRegistrert += antall;
    }
    function settPKravAntPersoner(antall) {
        kravPersonAntall = antall;
    }
    function fjernPPersoner(antall) {
        personerRegistrert -= antall;
    }
    function addPReiseInfo(antall) {
        reiseInfoReigstrert += antall;
    }

    function fjernPReiseInfo(antall) {
        reiseInfoReigstrert -= antall;
    }


    function testPAntallLugarer() {
        return antPlasserRegistrert >= kravPersonAntall;
    }
    function testPAntallPersoner() {

        return personerRegistrert == kravPersonAntall;
    }
    function testPReiseInformasjon() {
        return reiseInfoReigstrert == kravReiseInfoAntall;
    }

    function fjernPAllePersoner() {
        personerRegistrert = 0;
    }
    function fjernPAlleReiseInformasjon() {
        reiseInformasjonRegistrert = 0;
    }
    function fjernPAlleLugarer() {
        antPlasserRegistrert = 0;
    }
    //CSS klasser assosiert med ulike states
    let warningClasses = ["bg-warning", "text-black-50"];
    let successClasses = ["bg-success", "text-white"];
    let notFinishedClasses = ["text-white"];
    let lockedClasses = ["text-black-50"];
    let activeClasses = ["text-white", "bg-primary"];

    //Tilstanden skjemaet hadde før
    let preSchemaState = [state.notFinished, state.notFinished, state.notFinished];

    //Tilstanden skjemaet har nå
    let schemaState = [state.active, state.notFinished, state.notFinished];
    let currentActive = 0;


    //Endrer tilstand til skjema gitt id, til tilstand myState
    function changePschemaState(id, myState) {
        //For å unngå at en går til active 2 ganger, ettersom en da ikke vil
        //kunne gå tilbake til orginal tilstand når en gjør en annen knapp active.
        if (schemaState[id] == state.active && myState == state.active) return;

        //Fjern CSS Klasser assosiert med staten en har nå,fra skjema med følgende id
        removeAndRemClasses(id, schemaState[id]);
        //Tilstanden en har nå, er ønsket tilstand
        schemaState[id] = myState;

        //Velger ny tilstand basert på ønske.

        if (myState == state.warning) {
            warningClasses.forEach((x) => { $("#nav" + id).addClass(x) });
            document.getElementById("warning" + id).style.visibility = "visible";

        }

        else if (myState == state.success) {
            successClasses.forEach((x) => { $("#nav" + id).addClass(x) });
            document.getElementById("success" + id).style.visibility = "visible";

        }
        else if (myState == state.notFinished) {
            notFinishedClasses.forEach((x) => { $("#nav" + id).addClass(x) });
        }
        else if (myState == state.locked) {
            lockedClasses.forEach((x) => { $("#nav" + id).addClass(x) });
            document.getElementById("locked" + id).style.visibility = "visible";
        }

        else if (myState == state.active) {
            activeClasses.forEach((x) => { $("#nav" + id).addClass(x) });
            changePschemaState(currentActive, preSchemaState[currentActive]);
            currentActive = id;
        }


    }

    //Fjerner CSS klasser assoisert med klassen myState, med følgende id.
    function removeAndRemClasses(id, myState) {
        preSchemaState[id] = myState;
        if (myState == state.warning) {
            warningClasses.forEach((x) => { $("#nav" + id).removeClass(x) });
            document.getElementById("warning" + id).style.visibility = "hidden";

        }
        else if (myState == state.success) {
            successClasses.forEach((x) => { $("#nav" + id).removeClass(x) });
            document.getElementById("success" + id).style.visibility = "hidden";

        }
        else if (myState == state.notFinished) {
            successClasses.forEach((x) => { $("#nav" + id).removeClass(x) });
        }
        else if (myState == state.locked) {
            lockedClasses.forEach((x) => { $("#nav" + id).removeClass(x) });
            document.getElementById("locked" + id).style.visibility = "hidden";
        }

        else if (myState == state.active) {
            activeClasses.forEach((x) => { $("#nav" + id).removeClass(x) });
        }


    }
    //Sjekker om alle skjemaene har status state.success. 
    //Er ok at et skjema er active, så lenge forrige tilstand var state.success.
    function erPFerdig() {
        return GUIModuleSPA.testAntallLugarer() && GUIModuleSPA.testAntallLugarer() && GUIModuleSPA.testReiseInformasjon();
    }

    return {
        changeSchemaState: function (id, state) {

            changePschemaState(id, state);

        },
        erFerdig: function () {
            return erPFerdig();
        },
        addPersoner: function (antall) {
            addPPersoner(antall);
        },
        fjernPersoner: function (antall) {
            fjernPPersoner(antall);
        },
        addReiseInfo: function (antall) {
            addPReiseInfo(antall);
        },

        fjernReiseInfo: function (antall) {
            fjernPReiseInfo(antall);
        },

        addLugarer: function (antall) {
            addPLugarer(antall);
        },

        fjernLugarer: function (antall) {
            fjernPLugarer(antall);
        },

        testReiseInformasjon: function () {
            return testPReiseInformasjon();
        },//

        testAntallLugarer: function () {

            return testPAntallLugarer();
        },

        testAntallPersoner: function () {
            return testPAntallPersoner();
        },

        fjernAlleLugarer: function () {
            fjernPAlleLugarer();
        },

        fjernAlleReiseInformasjon: function () {
            fjernPReiseInfo();
        },

        fjernAllePersoner: function () {
            fjernPAllePersoner();
        },
        settKravAntPersoner: function (antall) {
            settPKravAntPersoner(antall);
        },
        leggTilMaksPlasser: function (antall) {
            leggTilMaksPPlasser(antall);
        },
        hentAntallPersoner: function () {
            return hentPPersonAntall();
        }
    }

})();