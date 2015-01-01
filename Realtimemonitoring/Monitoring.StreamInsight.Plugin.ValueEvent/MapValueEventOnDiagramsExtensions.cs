using Microsoft.ComplexEventProcessing.Linq;
using Sychev.Monitoring.StreamInsight.Contract.Observers;

namespace Sychev.Monitoring.StreamInsight.Plugin
{
    public static class MapValueEventOnDiagramsExtensions
    {
        //extension method ������ �� ����� ������ CepOperator
        [CepUserDefinedOperator(typeof(MapValueEventOnDiagramsUDO))]
        public static DiagramModelCollection MapEventOnDiagrams(this CepWindow<StreamInsightServer.Models.ValueEvent> window)
        {
            throw CepUtility.DoNotCall();
        }
    }
}