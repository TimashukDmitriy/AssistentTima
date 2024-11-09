using BdHelper;
using SQLitePCL;

namespace AssistantTima.Models;

public class AssistentModel
{
    public AssistentModel(Controller controller)
    {
        _controller = controller;
        _copy = this;
    }
    private Controller _controller;
    private AssistentModel _copy;

    public AssistentModel GetCopy()
    {
        return _copy;
    }
}