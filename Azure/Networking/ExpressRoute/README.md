В Azure есть технологии, которые хорошо известны и доступны нам в России. Однако, не все. Одной из таких технологий Microsoft Azure является Express Route, и именно поэтому эта статья является общепознавательной. 

<b>Azure ExpressRoute</b>, как следует из названия -<b> это ваше прямое подключение к Azure в обход интернета.</b>
Как мы подключаемся к Azure: подключаем компьютер к модему, тот соединяется с местным провайдером, тот соединяется с крупным провайдером на уровне города, и далее идем в интернет до интересующего нас ресурса, в частности Azure. 
А что делать, если мы не хотим подключаться к интернету, но использовать Azure хотим?!

<b>При использовании Express Route трафик не идет через Internet, при этом передача данных будет более защищенная, с меньшими задержками (low latency), как правило, и в определенных случаях дешевле. </b>

Как мы понимаем, основным ограничением является то, что Azure Data Centers находится в достаточно ограниченном числе точек на планете. У нас в России, например, нет (Есть только CDN).  
Ранее были 3 минианонса на хабре, но я хочу чуть более подробно рассказать <a href="http://habrahabr.ru/company/microsoft/blog/214611/">1</a>, <a href="http://habrahabr.ru/company/microsoft/blog/241925/">2</a>, <a href="http://habrahabr.ru/company/microsoft/blog/223467/">3</a>.
<habracut>
<h5><b>Подключение</b></h5>
Есть 2 способа подключения: через Network Provider и через Exchange Provider.
<ul>
	<li><b>Network Provider</b> предоставляет доступ к сети. Пример: AT&T, Verizon, British Telecom.</li>
	<li><b>Exchange Provider</b> предоставляет доступ до <a href="https://en.wikipedia.org/wiki/Internet_exchange_point">точки обмена трафиком</a>.  <a href="https://en.wikipedia.org/wiki/List_of_Internet_exchange_points">Список таких точек в мире</a>. Т.е. провайдер предоставляет (возможно даже прокладывает) канал до точки обмена трафиком, а оттуда уже идет доступ до Azure. Этот вариант потенциально быстрее, но и сложнее технически.</li>
</ul>
<spoiler title="Мы можем использовать одну из этих точек обмена трафиком"><img src="http://habrastorage.org/files/c8f/055/814/c8f0558149fc4e719ade4314c98d468f.png" alt="image"/></spoiler>
Как мы видим, точек доступно не много, хотя в будущем может быть и больше. Дата центры открывали сначала тоже 2 в США, 2 в Европе, 2 в Азии. А теперь их сильно больше.
<spoiler title="Network Provider доступны в тех же регионах"><img src="http://habrastorage.org/files/3c3/b47/6c0/3c3b476c0a5d4fcf9fd7b9741f41f8df.png" alt="image"/></spoiler>

<b>Ограничение скорости</b>
<spoiler title="В зависимости от выбранного типа подключения мы можем выбрать скорость подключения и сопоставить ее с ценой за подключение.">
<img src="http://habrastorage.org/files/829/565/00e/82956500e62645ffb377d729389c9c16.png" alt="image"/></spoiler>

<b>Цены</b>
Вопрос цены для нас чисто теоретический, но было бы интересно знать. Есть 2 разные цены, в зависимости от того, как вы подключились - через Network Service provider или Exchange Provider.
<spoiler title="В случаи с Exchange Provider мы платим за исходящий трафик, в зависимости от зон в Azure."><img src="http://habrastorage.org/files/1d3/5f1/c28/1d35f1c28ff1497085fe361a90126f93.png" alt="image"/></spoiler>
<spoiler title="В случае Network Service Provider мы платим фиксированную цену за ширину канала, без ограничения на входящий/исходящий трафик."><img src="http://habrastorage.org/files/a0b/791/20f/a0b79120f0324814b516cdb5ef7f84d7.png" alt="image"/></spoiler>

А вот настройка этих соединений - это уже совсем теоретическая вещь для нас в СНГ, и кому интересно, может прочесть в документации.
<ul>
	<li><a href="http://msdn.microsoft.com/en-us/library/azure/dn643736.aspx">Network Provider</a> </li>
	<li><a href="http://msdn.microsoft.com/en-us/library/azure/dn606306.aspx">Exchange Provider</a></li>
</ul>

<h5><b>Какие сервисы Azure могут использовать возможности ExpressRoute</b></h5>
Многие сервисы Azure могут использовать (WebSites, CloudServices, HDInsigth и т.д.), но есть и группа, которой от использования ExpressRoute ни горячо, ни холодно. Это надо понимать.
<ul>
	<li>Service Bus</li>
	<li>CDN</li>
	<li>RemoteApp</li>
	<li>VisualStudioOnline</li>
	<li>Notification Hubs</li>
	<li>Automation</li>
	<li>Application Insights</li>
	<li>Multi-factor Authentication</li>
	<li>API Management</li>
	<li>Push Notifications</li>
</ul>
Использование одного Express Route между несколькими подписками http://msdn.microsoft.com/en-us/library/azure/dn835110.aspx. Если коротко, то нужны действия со стороны владельца ExpressRoute и владельца подписки, с которой он шарится. Всего 3 действия: Circuit владелец дает права на доступ владельцу подписки, владелец подписки получает Service Key и дальше может, используя этот ключ, создать ссылку.

<h5><b>Проложите кабель сами до точки обмена трафиком</b></h5>
Лично мне понравился ответ на вопрос в разделе FAQ: «Что делать, если мы хотим использовать Express Route, но у нас нет партнёрства с этими компаниями?»
Microsoft предлагает Вам самим проложить кабель до Exchange Point.
<i>«You can select a regional carrier and land Ethernet connections to one of the supported exchange provider locations. You can then peer with Azure at the exchange providers’ location».</i>

<b>Оказывается, что есть и такие экзотические технологии у Microsoft.</b>

<h5><b>Ссылки</b></h5>
<ul>
	<li><a href="http://azure.microsoft.com/en-us/services/expressroute/">Стартовая</a></li>
	<li><a href="http://azure.microsoft.com/en-us/documentation/services/expressroute/">Стартовая техническая</a></li>
	<li><a href="http://azure.microsoft.com/en-us/pricing/details/expressroute/">Цены</a></li>
	<li><a href="http://msdn.microsoft.com/library/azure/dn606310.aspx">Работа с API</a></li>
	<li><a href="http://msdn.microsoft.com/library/azure/dn606292.aspx">FAQ</a></li>
	<li><a href="http://azure.microsoft.com/blog/2014/06/02/expressroute-an-overview/">Блог авторов</a></li>
</ul>