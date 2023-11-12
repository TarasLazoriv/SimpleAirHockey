using System.Threading.Tasks;

namespace SimpleAirHockey.Runtime
{
    public interface IGoalCommand
    {
        Task Execute(bool userGate);
    }
}