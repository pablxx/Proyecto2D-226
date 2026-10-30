using UnityEngine;

public interface IDamageable
{
    public void AplicarDanoInstantaneo(float daño);

    public void AplicarDOT(float duracion, float daño, float frecuencia);


}
