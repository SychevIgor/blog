Пару месяцев назад в preview в Microsoft Azure появился новый сервис- Operation Insight и у меня наконец-то дошли руки с ним разобраться.

<b>Суть сервиса в том, что он собирает, хранит данные и дает возможность по ним искать, визуализировать их и автоматически анализировать данные, генерируемые вашей инфраструктурой. </b>Такая возможность не нужна, пока вы не наберете критическую массу единиц для мониторинга (виртуальных машин, почтовых серверов, баз данных) и/или не появится по крайней мере 2 человека, которые занимаются администрированием этого «зверинца».
Инфраструктура генерирует логи (к примеру, Windows Events, IIS logs и т.п.), пишет информацию об изменении конфигурации машины (поставили обновление, драйверы, софт, перезагрузили машину), а вы в веб интерфейсе видите это, через поиск можете найти инциденты определенного типа и т.д. и т.п.
<img src="http://habrastorage.org/files/407/f5e/c1d/407f5ec1d5104da9b3046f01f2ffb4db.png" alt="image"/>
<habracut>
<img src="http://habrastorage.org/files/c34/099/b08/c34099b0815c4b08955541cd21d1e370.png" alt="image"/>

Одной из самых важных возможностей является добавление наиболее важных графиков и отчетов с помощью запросов на этот же экран. Сегодня нужно последить за одним - добавили, завтра за другими параметрами - удалили, добавили новый запрос. Как это может выглядеть хорошо описано в <a href="http://blogs.technet.com/b/momteam/archive/2014/10/16/custom-dashboard-in-advisor.aspx">статье</a>.

<a href="http://msdn.microsoft.com/en-us/library/azure/dn884641.aspx">Данные </a>можно собирать с: 
<ul>
	<li>Windows Server 2012 and Microsoft Hyper-V Server 2012</li>
	<li>Windows Server 2008 and Windows Server 2008 R2, including:
<ul>
	<li>Active Directory</li>
	<li>Hyper-V host</li>
	<li>General operating system</li>
</ul></li>
	<li>SQL Server 2012, SQL Server 2008 R2, SQL Server 2008
	<ul><li>SQL Server Database Engine</li></ul> </li>
	<li>Microsoft SharePoint 2010</li>
	<li>Microsoft Exchange Server 2010</li>
	<li>Microsoft Lync Server 2013 and Lync Server 2010 </li>
	<li>System Center 2012 SP1 – Virtual Machine Manager</li>
</ul>
Можно собирать данные не только с машин в облаке, но и с локальных (OnPremise).

<h4><b>Из личного опыта:</b></h4>
Каждый разработчик в своей жизни не раз сталкивался с ситуацией: возникает проблема с .net/iis приложением, читаешь в чем причина и понимаешь, что чтобы исправить проблему достаточно поставить патч на windows 2-летней давности. Ты спрашиваешь админов поставлен ли он (доступа на боевые сервера у разработчиков конечно-же нет), админы полдня занимаются другими важными делами, затем по RDP лезут на машину, сначала у них тоже нет прав, ищут кто может дать еще полдня, затем, получив, видят, что обновления нет и говорят, что 2 года обновления не ставились т.к. никто не просил. В итоге время ожидания информации - сутки.

Затем обновление ставится в план на следующие выходные (или другое технологическое окно). Проходит неделя, ты спрашиваешь: «ну что поставили?» Тебе еще через день отвечают да или нет. Как разработчику, мне бы хотелось видеть какие обновления поставлены и куда, а не ждать сутками ответа (опять же в большой конторе не всегда можно прийти ногами к людям и спросить или по телефону позвонить… поэтому приходится ждать).

Другой вариант: была с машиной проблема, вроде исправлена, но надо понаблюдать за ней несколько дней-неделю. Если у системы есть сопровождение, просишь сопровождение понаблюдать.  Ну не будут же они сидеть и смотреть на машину сутками, повесят стикер, задачку в outlook сделают, по RDP откроют, метрики собирать поставят. Но у сопровождения не только эти задачи, всегда еще куча другой работы…. А через Operation Insight – повесишь выборку на экран и поглядываешь периодически, поставил нотификацию/alert и чуть-что узнаешь о проблеме. 

Понятно, что проблемы мониторинга были и до Azure и никуда не денутся после нее. Есть решение на <a href="http://www.zabbix.com/">zabbix</a> или <a href="http://en.wikipedia.org/wiki/HP_OpenView">hp open view</a>. У Microsoft есть system Center Operation Manager, и дополнительно к нему специально для Azure написан Operation Insight.

<h5><b>Operation Insight и Operation Manager</b></h5>
OpIn может использовать данные, собранные в том числе через Operation Manager. Общая схема ниже.
<img src="http://habrastorage.org/files/249/aeb/362/249aeb362bd3469ea78f8e4b1d0b660e.png" alt="image"/>

<h5><b>Operation Insight и system center advisor </b></h5>
Нет больше advisor как такового: он полностью <a href="https://go.microsoft.com/fwlink/?LinkId=517580#why-op-insights">вошел</a> в состав Operation Insight.  
Поэтому вопрос  «Чем одно отличается от другого?» - это вопрос «Чем целое отличается от его части?»

<h5><b>Как это работает. Настройка</b></h5>
На машину, за которой производится мониторинг, ставится агент, который собирает с нее данные. Инсталлятор можно прямо с портала <a href="http://msdn.microsoft.com/en-us/library/azure/dn884659.aspx">выкачать</a>, затем ставится на целевую машину и <a href="http://msdn.microsoft.com/en-us/library/azure/dn873959.aspx">конфигурируется</a>. Вся настройка агента - это буквально пара опций- нужно указать Workspace ID и Primary Workspace Key.
После того, как агент на машину поставлен, нужно <a href="http://msdn.microsoft.com/en-us/library/azure/dn873948.aspx">включить </a>компьютер в OpInsight для мониторинга.
По необходимости прорубается настройка в <a href="http://msdn.microsoft.com/library/azure/08fcfe25-2f90-4b17-aea0-5514833d8812">firewall</a>.

<h4><b>Intelligent Pack</b></h4>
Intelligent Pack - это набор правил визуализации данных, которые вы можете скачать для расширения функциональности OpIn. Существующие пакеты представлены в <a href="http://msdn.microsoft.com/en-us/library/azure/dn873980.aspx">галерее  </a>. Вот 2 примера таких пакетов:
<ul>
<li><a href="http://blogs.technet.com/b/momteam/archive/2014/11/12/manage-your-operations-manager-alerts-from-azure-operational-insight-with-the-new-alert-management-intelligence-pack.aspx">Alert Intelligent Pack</a> -  сколько, когда и каких нотификаций о проблемах или потенциальных проблемах было, очень помогает обнаруживать грядущий апокалипсис и начать действовать до его наступления.
<img src="http://habrastorage.org/files/d54/9fe/9cf/d549fe9cfedb45b5b078a0a3dfb49355.PNG" alt="image"/>
<img src="http://habrastorage.org/files/90d/2c4/f05/90d2c4f05a4f4239ae905f19cbe32a0d.png" alt="image"/>
</li>
<li> <a href="http://blogs.technet.com/b/momteam/archive/2014/10/23/new-sql-server-assessment-intelligence-pack-in-advisor.aspx">SQL Server Intelligent Pack</a> - Как не трудно догадаться, это пакет для анализа и планирования мероприятий по SQL Server для его поддержки и снижения риска с ним связанного. 
<i>“Recommendations are categorized across six focus areas which helps your quickly understand the risk and health of your infrastructure and to help you easily take action to decrease risk and improve health.
The recommendations made are based on the knowledge and experiences gained by Microsoft engineers from based on thousands of customer visits.” </i>
<spoiler title="Общая страница">
<img src="http://habrastorage.org/files/3da/2ca/525/3da2ca5252ac47fabaead6e8aff15c0a.png" alt="image"/></spoiler>
<spoiler title="Детальная информация"><img src="http://habrastorage.org/files/83d/9f4/e2b/83d9f4e2b9054f48a11d677cd8b43f77.png" alt="image"/></spoiler>
Более подробно можно почитать на пример <a href="http://msdn.microsoft.com/en-us/library/azure/dn873958.aspx">тут</a> или в блогах <a href="http://www.concurrency.com/infrastructure/new-intelligence-pack-for-sql-server-assessment-is-available-in-system-center-advisor/">тут</a> и <a href="http://sqldbawithabeard.com/2014/11/24/a-look-at-the-sql-assessment-intelligence-pack-in-operational-insights/">тут</a>.
</li>
</ul>

<h5><b>Заметки</b></h5>
<ul>
	<li>Есть клиент для просмотра на <a href="http://www.windowsphone.com/en-us/store/app/operational-insights/4823b935-83ce-466c-82bb-bd0a3f58d865">windows phone</a>.
<img src="http://habrastorage.org/files/e4f/783/b30/e4f783b308c44512aa0b24e280855092.png" alt="image"/>
<a href="http://blogs.technet.com/b/momteam/archive/2014/11/24/access-your-operational-insights-on-the-go.aspx">Описание </a>есть в блоге. 
Если хотите клиент для IOS, Android просят проголосовать за такие клиенты (хотят понять нужно ли оно вообще)</li>
	<li>Сейчас, во время preview, сервис хостится в США, но доступ мы можем получить откуда угодно. http://msdn.microsoft.com/en-us/library/azure/dn873945.aspx </li>
	<li>Microsoft в статье про безопасность долго объясняет, что ваши данные даже в облаке останутся только вашими. Что используется https, что ваши данные хранятся отдельно от данных других аккаунтов и т.д. и т.п. https://go.microsoft.com/fwlink/?LinkId=517154 http://azure.microsoft.com/en-us/documentation/articles/operational-insights-security/ </li>
	<li>Я смотрел многие сервисы azure, и <a href="http://feedback.azure.com/forums/267889-azure-operational-insights/">обсуждение </a>новых фичей идет очень активно , в отличии от большинства других сервисов.</li>
</ul>

<h5><b>Цены:</b></h5>
Есть 3 различных тарифных плана (Tier).
Free, Standard, Premium. Все различия в этих планах - это объем собираемых за день данных и время хранения этих данных. 
<img src="http://habrastorage.org/files/509/da4/9d6/509da49d6a7d46f0839a6896630fbeae.png" alt="image"/>
Лично мне не понятно, почему бы не сделать бессрочное хранение данных и возможность почистить старые данные по кнопке?! Т.к. не хочется потерять знания о серьезных инцидентах старше 12 месяц. 

<h5><b>Ссылки:</b></h5>
<ul>
	<li><a href="http://azure.microsoft.com/en-us/services/preview">Preview 1</a> <a href="https://preview.opinsights.azure.com/" >Preview 2</a></li>
	<li><a href="http://azure.microsoft.com/en-us/services/operational-insights/">Стартовая</a></li>
	<li><a href="http://azure.microsoft.com/en-us/pricing/details/operational-insights/">Цены</a></li>
	<li><a href="http://blogs.technet.com/b/momteam/">Блог команды System Center</a></li>
	<li><a href="https://preview.opinsights.azure.com/FAQ">FAQ</a></li>
	<li>Предложить свои фичи и проголосовать за предложенные ранее можно <a href="http://feedback.azure.com/forums/267889-azure-operational-insights/">здесь</a>.</li>
</ul>

Если Вы хотите помочь улучшить статью- предлогайте ваши правки через <a href="https://github.com/SychevIgor/blog/tree/master/Azure/Management/OperationInsight">github</a>
