using System.Collections.Generic;

public class SelectorFinales
{
    public static List<bool> minijuegosSuperados;
    
    public static bool finalActivado()
    {
        bool activo = true;
        foreach (var superado in minijuegosSuperados)
        {
            if (!superado)
                activo = false;
        }

        return activo;
    }
}
