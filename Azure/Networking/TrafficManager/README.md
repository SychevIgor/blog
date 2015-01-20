<img src="http://habrastorage.org/files/258/ca9/529/258ca95294574e0ba455c8736f5d2506.png" alt="image"/>
<b>Traffic Manager</b>- Это балансировщик нагрузки as a Service, работающий как с Azure, так и с сервисами вне его. 
Нагрузка может быть поделена между узлами как равномерно, так и пропорционально заданным весам [1-1000], там же поддерживаются проверки работоспособности узлов (Health Check). 
В случае, если в балансировщике несколько групп серверов, один, например, в регионе US, второй в EU, то клиент будет перенаправляться к той группе серверов, до которой ближе к клиенту (ping меньше).

На хабре были <a href="http://habrahabr.ru/company/epam_systems/blog/226763/">1</a>, <a href="http://habrahabr.ru/company/microsoft/blog/204758/">2</a> статьи про использование Traffic Manager, я же, как всегда, чуть более подробно попытаюсь рассказать. 
<habracut/>
<h5><b>Термины</b></h5>
Чтобы при дальнейшем обсуждении говорить на одном языке, нужно дать определения 2 терминам. 
<ul>
	<li><b>EndPoint</b> - URL, по которому отвечает каждый конкретный сервис/сервер/сайт. Таких точек может быть в profile много, и уж точно более 1, т.к. иначе зачем вообще TM!</li>
	<li><b>Profile</b> – объединение Endpoints и содержит в себе стратегию распределения нагрузки и внешний балансируемый URL.</li>
</ul>

<h5><b>Настройка</b></h5>
В примере настройки, используемом ниже, считается, что наши сервисы отвечают по адресам myapp-eu.cloudaupp.net, myapp-us.cloudapp.net 

Настройку TM можно провести либо через Management Portal, либо используя <a href="http://www.nuget.org/packages/Microsoft.WindowsAzure.Management.TrafficManager/0.16.0-preview">.net sdk</a> (до сих пор в версии preview), либо через <a href="https://msdn.microsoft.com/library/dn690250.aspx">powershell командлеты</a>. В любом случае, это работает через один и тот же <a href="http://msdn.microsoft.com/library/hh758255.aspx">API</a>. SDK для java, node пока не готовы.

Минимальная настройка состоит из 2 шагов. 
<ul>
	<li>Создание Profile 
<img src="http://habrastorage.org/files/5d8/fea/160/5d8fea160bb74093819460c1236b1c83.png" alt="image"/>
</li>
	<li>Добавление EndPoint к Profile 
<img src="http://habrastorage.org/files/ab5/b36/569/ab5b36569d9848828d7bc08bf7b4c2a6.png" alt="image"/>
</li>
</ul>
А дальше уже действуем по обстоятельствам. 

<h5><b>API</b></h5>
Весь API - это <a href="https://msdn.microsoft.com/library/dn690250.aspx">десяток операций</a> 
<ul>
	<li>Получить весь список, создание, обновление, удаление, блокирование Profile.</li>
	<li>Добавление/Удаление/Изменение свойств EndPoint в Profile.</li>
	<li>Проверка свободен ли DomainName, который будет балансировать.</li>
</ul>

<h5><b>Мониторинг состояния узлов/EndPoint</b></h5>
В плане мониторинга состояния узлов TM не предлагает <a href="http://msdn.microsoft.com/en-us/library/azure/dn339014.aspx">ничего сверхъестественного</a>. Он просто проверяет 200 код ответа по определенному URL (+если необходимо относительный путь до ресурса типа /index.html). Из настроек есть <b>порт</b> (80-443) и <b>протокол</b> (http/https). Никакого умного анализа контента - только базовые фичи. Хотя для многих и этого будет достаточно. 

<h6><b><a href="https://msdn.microsoft.com/en-us/library/azure/dn339013.aspx">Как работает проверка работоспособности узла</a></b></h6>
Traffic Manager каждые 3<b>0 секунд отправляет Get запрос к EndPoint и ждет не более 10 секунд</b>. Если EndPoint <b>ответил 200 кодом в течение 10 секунд</b>, то сервис считается рабочим. Между этими 30 секундами состояние EndPoint не проверяется.

<img src="http://habrastorage.org/files/d3e/b99/9a5/d3eb999a594d483cb81b5a71f675887c.jpg" alt="image"/>

Если EndPoint не ответил или код не 200, или ответил после 10 секунд, то сама endpoint считается неработоспособной. Как только 1 endpoint был признан не работоспособным, будет еще 3 попытки проверить статус с интервалом 5 секунд (суммарно 4 попытки), до того, как endpoint будет показан как неработоспособный. Если из этих 3 раз хотя бы 1 раз сервис ответил кодом 200 в заданный интервал, EndPoint считается рабочим, и счетчик попыток сбрасывается. Если же EndPoint продолжает не отвечать, то он продолжает проверяться, но уже отмечен как неработоспособный, и нагрузка на него подаваться не будет.

Трафик все еще может остаточно приходить на EndPoint, т.к. в DNS может быть еще закэширована запись. Как только TTL (Time To Live) истекает, трафик полностью прекращает идти на Endpoint.  Это не Traffic Manager такой глупый, что продолжает какой-то период времени подавать нагрузку на сбойный узел, а устройство и оптимизация нагрузки на DNS.
 
В документации от MSFT можно прочесть даже советы, как проверять работоспособность сервиса, используя dns-lookup, не забыть при этом сбросить dns кэш, через команду flushdns.

<h5><b>Режимы работы балансировщика</b></h5>
Есть всего 3 режима работы балансировщика:
<ul>
	<li>Performance. В этом случае для клиента будет определяться ближайший сервер, и он будет работать именно с ним.
<img src="http://habrastorage.org/files/da0/bc5/a1a/da0bc5a1a0a64205a98b062c6318cbc0.jpg" alt="image"/>
</li>
	<li>Failover - это не балансировка, я бы даже сказал. Допустим, у вас есть 4 узла, один из них основной, а остальные – это Replica Set с него. Все узлы (кроме основного) - это резерв. Вся нагрузка будет на основной узел, пока он живой. Как только он будет недоступен, будет выбран следующий в очереди по приоритету сервер, и вся нагрузка уйдет на него, до восстановления сервера.  
<img src="http://habrastorage.org/files/5e8/0e4/8c1/5e80e48c11014282a1bac17a449b6c98.jpg" alt="image"/>
</li>
	<li>Round Robin - запросы в соответствии с заданными весами распределяются между EndPoint</li>
</ul>

<h5><b>Traffic Manager не DNS</b></h5>
Если зайти на голосовалку за фичи в Azure, то на первой странице можно найти много запросов про «дайте нам DNS в облаке, дайте возможность задавать кастомные доменные имена, а не *.cloudapp.net» и таких на первой-же странице 3 разных запроса: <a href="http://feedback.azure.com/forums/217313-networking-dns-traffic-manager-vpn-vnet/suggestions/397428-create-elastic-ips-so-we-can-actually-create-web-a">1</a>,<a href="http://feedback.azure.com/forums/217313-networking-dns-traffic-manager-vpn-vnet/suggestions/397156-provide-dns-services-for-my-domains-and-sub-domain">2</a>,<a href="http://feedback.azure.com/forums/217313-networking-dns-traffic-manager-vpn-vnet/suggestions/4996615-azure-should-be-its-own-domain-registrar">3</a>.
<b>Надо отдавать себе отчет, что Traffic Manager - это не DNS. </b>Его внешний адрес будет именно MyProfileName.trafficmanager.net, и вы можете выбрать только имя профиля балансировки. А уже в своем dns надо будет прописать, что MyProfileName.trafficmanager.net это mydomain.com 
Я не знаю, почему до сих пор не сделали dns as a service, но уже года 2 просят.

<h6><b>Логирование изменений в profile</b></h6>
Поскольку балансировка нагрузки - это точка входа в ваше приложение, то любые изменения его конфигурации должны фиксироваться. Именно поэтому все изменения в profile можно просмотреть в <a href="http://msdn.microsoft.com/en-us/library/azure/dn509488.aspx">истории</a>.

<h5><b><a href="http://azure.microsoft.com/en-us/pricing/details/traffic-manager/">Цены</a></b></h5>
Деньги в TM платятся за 2 фичи: запросы к DNS и проверка работоспособности узла. При этом сюда, понятно дело, не включен трафик из Azure, т.к. это оплачивается отдельно.
Каждый узел при проверке здоровья оплачивается отдельно, ну и, понятное дело, если узел не в azure, то он в 1.5 раза дороже.
 

<h5><b>Ссылки</b></h5>
<ul>
	<li><a href="http://azure.microsoft.com/en-us/services/traffic-manager/">Стартовая</a></li>
	<li><a href="http://azure.microsoft.com/en-us/documentation/services/traffic-manager/">Стартовая документации</a></li>
	<li><a href="http://msdn.microsoft.com/library/azure/hh744830.aspx">Стартовая страница для конфигурации</a></li>
	<li><a href="http://feedback.azure.com/forums/217313-traffic-manager">Предложить и проголосовать за фичи</a></li>
</ul>
P.S. Если Вы хотите помочь улучшить статью- можно предлогать ваши правки через <a href="https://github.com/SychevIgor/blog/blob/master/Azure/Networking/TrafficManager">github</a>