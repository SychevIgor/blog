using System;
using Microsoft.ComplexEventProcessing;
using Microsoft.ComplexEventProcessing.Linq;
using Sychev.Monitoring.StreamInsight.Contract;
using Sychev.Monitoring.StreamInsight.Contract.Observables;
using Sychev.Monitoring.StreamInsight.Contract.Observers;
using Sychev.Monitoring.StreamInsightServer.Models;

namespace Sychev.Monitoring.StreamInsight.Plugin
{
    public class QStremableSourceValueEventQueue : IQStremableSourcePlugin
    {
        public IQStreamable<DiagramModelCollection> Get(Application app, string wcfSourceUrl)
        {
            //���������� �������� ������.
            var observableAppFabricEventWcfSource = app.DefineObservable(() => new WCFObservable<ValueEvent>(wcfSourceUrl + "AppFabricEventService", "AppFabricEventService"));

            //���������� ��� �� ����� ������� ��� ����� ������� ������ �� ����� � �������� �� ��� �������� ������.
            //����� �� �������� ����� �������� NonValueEvent, ����� �� �� ���� �� 1�������.
            var appFabricEventQueue = from x in observableAppFabricEventWcfSource
                .ToPointStreamable(i => PointEvent.CreateInsert<StreamInsightServer.Models.ValueEvent>(i.Time, i), AdvanceTimeSettings.IncreasingStartTime)
                .CountWindow(2)
                select x.MapEventOnDiagrams();

            return appFabricEventQueue;
        }
    }
}