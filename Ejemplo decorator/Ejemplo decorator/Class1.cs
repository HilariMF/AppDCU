namespace Ejemplo_decorator
{
    //Haremos un ejemplo basado en un videojuego
    // Interfaz para definir el comportamiento del jugador base y de los decoradores
    public interface IPlayer
    {
        int Health { get; }
        int Damage { get; }
        int Jump { get; }
        int Run { get; }
    }

    // Clase base del jugador
    public class Player : IPlayer
    {
        public int Health { get; set; } = 70;
        public int Damage { get; set; } = 20;
        public int Jump { get; set; } = 10;
        public int Run { get; set; } = 7;
    }

    // Decorador base
    public abstract class PlayerDecorator : IPlayer
    {
        protected IPlayer decoratedPlayer;

        public PlayerDecorator(IPlayer player)
        {
            decoratedPlayer = player;
        }

        public virtual int Health => decoratedPlayer.Health;
        public virtual int Damage => decoratedPlayer.Damage;
        public virtual int Jump => decoratedPlayer.Jump;
        public virtual int Run => decoratedPlayer.Run;
    }

    // Decorador para agregar una habilidad de ataque adicional
    public class AttackBoostDecorator : PlayerDecorator
    {
        public AttackBoostDecorator(IPlayer player) : base(player)
        {
        }

        public override int Damage => decoratedPlayer.Damage + 10;
    }

    // Decorador para agregar una habilidad de salto adicional
    public class JumpBoostDecorator : PlayerDecorator
    {
        public JumpBoostDecorator(IPlayer player) : base(player)
        {
        }

        public override int Jump => decoratedPlayer.Jump + 5;
    }

    // Decorador para agregar una habilidad de velocidad adicional
    public class SpeedBoostDecorator : PlayerDecorator
    {
        public SpeedBoostDecorator(IPlayer player) : base(player)
        {
        }

        public override int Run => decoratedPlayer.Run + 3;
    }



}