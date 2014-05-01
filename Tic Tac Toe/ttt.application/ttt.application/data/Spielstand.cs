namespace ttt.application.data
{
    public class Spielstand
    {
        public string Hinweis;
        public Spielstein[] Spielbrett;
    }

    public enum Spielstein
    {
        Leer,
        X,
        O
    }
}