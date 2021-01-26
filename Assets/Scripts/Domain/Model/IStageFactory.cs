using Application;

namespace Domain.Model
{
    public interface IStageFactory
    {
        Stage Create(StageInfo stageInfo);
    }
}