namespace Caterer_DB.MVCServices
{
    public enum LoginSuccessLevel
    {
        Erfolgreich = 1,
        BenutzerNichtGefunden = 2,
        PasswortFalsch = 3,
        DatenbankFehler = 4,
        Unbekannt = 5
    }
}