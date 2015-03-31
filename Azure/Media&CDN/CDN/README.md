Из названия CDN (Content Delivery Network) следует и смысл - это сервис, обеспечивающий кэширование контента, находящегося в blob на узлах, которые ближе к потребителю, чем основные дата центры Azure. <a href="https://msdn.microsoft.com/en-us/library/azure/gg680301.aspx">Как только мы включили CDN для Storage Account, любой объект в нем может быть закэширован в CDN</a>. 
<habracut>
<h5><b>Где находятся CND</b></h5>
Список точек присутствия (<a href="https://msdn.microsoft.com/en-us/library/azure/gg680302.aspx">Point of presence</a>), где есть CDN.  
<img src="http://habrastorage.org/files/60e/920/975/60e9209753404092ba1c2b02134b3327.png" alt="image"/>
<a href="http://azure.microsoft.com/blog/2011/02/01/new-moscow-node-of-the-windows-azure-cdn-brings-total-number-of-nodes-available-globally-to-23/">Когда-то был CDN и в России</a>, но сейчас его нет. Я не заметил, когда он исчез, да и анонсов публичных не помню. 

<h5><b>Скорость доступа </b></h5>
до самого CDN скорость доступа может быть сильно выше, чем до ресурса в Azure Storage.
<img src="http://habrastorage.org/files/cfb/67f/d6b/cfb67fd6bfc34928a80b20e54c204eed.jpg" alt="image"/>
<spoiler title="Ping"><img src="http://habrastorage.org/files/1c8/633/1a9/1c86331a93ed4cb39c9ab2f99148e9f1.png" alt="image"/></spoiler> 

<h5><b>Создание CDN</b></h5>
<img src="http://habrastorage.org/files/9ea/5e9/44a/9ea5e944ae994c599e3fa1bb262690fd.png" alt="image"/>
По умолчанию URL кэшируется без параметров. Т.е. эти 2 файла, были бы идентичные.
<img src="http://habrastorage.org/files/e0c/459/2f3/e0c4592f37bc4242898f953ac1d3c577.png" alt="image"/>

<spoiler title="Если от этих параметров, должен быть разный ответ, то необходимо включить настройку Enable Query String."><img src="http://habrastorage.org/files/274/fc3/497/274fc349726d4585801d6d176fdc0806.png" alt="image"/></spoiler>
<spoiler title="Кэшировать мы можем не только объекты из blob, но и веб сайты."><img src="http://habrastorage.org/files/f25/84a/147/f2584a147e7b4553879f7c5f787047f5.png" alt="image"/></spoiler>

<h5><b>Время кэширования</b></h5>
<a href="https://msdn.microsoft.com/en-us/library/azure/gg680306.aspx">По умолчанию время кэширования (Time To Live) – 7 дней</a>, но мы можем задать время кэширования, выставив свойство у blob. Рекомендованного времени кэширования нет, все зависит от скорости изменений необходимый для Вас.
<spoiler title="Настройка для выбранного blob"><img src="http://habrastorage.org/files/824/f68/e7b/824f68e7b4b5449892d93199049516b2.png" alt="image"/></spoiler>
<spoiler title="Настройка TTL из C#"><img src="http://habrastorage.org/files/ca8/698/d7c/ca8698d7c5c74f46af5171da6ad4c553.png" alt="image"/></spoiler>

<h5><b>Удаление объектов</b></h5>
<a href="https://msdn.microsoft.com/library/azure/gg680303.aspx">Удалить объект из CDN, можно несколькими способами</a>: 
<ul>
	<li>Удалить объект из public container</li>
	<li>Сделать container не публичный.</li>
	<li>Отключить CDN</li>
	<li>Отключить сервис, который содержит объект, закэшированный в CDN.</li>
</ul>
Правда, уже после одного из этих действий (не считая отключения CDN), какое-то время контент еще будет доступен, пока не истечет время жизни.
После нажатия создания CDN может пройти до 60 минут, прежде чем CDN будет доступен.

Можно использовать свой <a href="https://msdn.microsoft.com/library/azure/gg680307.aspx">собственный домен для кэширования данных в CDN вместо дефолтного домена CDN</a>. 

<h5><b>Отображение объектов в BLOB на CDN</b></h5>
Когда мы подключаем CDN, то мы должны использовать не URL, от нашего Storage Account, а уже UDL от CDN. Пример:
<img src="http://habrastorage.org/files/8f0/06f/029/8f006f029a314b419d46583870709745.png" alt="image"/>
Вместо домена blob.core.windows.net будет использовать vo.mscend.net . В случае blob у нас идет имя storage account, а в случае CND будет идти идентификатор нашего CDN. Остальные же часть URL, в том числе и параметры, строки останутся неизменными.

<h5><b>HTTPS</b></h5>
Вы можете использовать и HTTPS, но для этого надо включить эту опцию и иметь ввиду <a href="http://azure.microsoft.com/en-us/documentation/articles/cdn-overview/">2 ограничения</a>: 
<ul>
	<li>Использовать сертификат, выданный CDN</li>
	<li>Использовать домен CDN, а не ваш собственный domain.</li>
</ul>

<h5><b>Цены</b></h5>
В Azure принято платить за исходящий трафик, CDN не исключение. Стоимость зависит от выходного потока и зоны, где расположен CDN.
<img src="http://habrastorage.org/files/05f/a19/940/05fa1994004e43308c8509d7b90caad8.png" alt="image"/>
Градацию цен надо понимать так: первые 10 тб в месяц будет по цене 1, с 10 тб по 50 тб по следующей цене, после превышения лимита в 50тб и до 150 цена будет уже третья. Т.е. после пересечения каждой границы интервала, следующий объем будет уже по новому тарифу. 
<spoiler title="Для разных сервисов разные точки земного шара входят в разные зоны. Где-то 1, где-то 2.">
<img src="http://habrastorage.org/files/ea9/3fc/015/ea93fc015afd441b842f56c784ee355d.png" alt="image"/></spoiler>
<b>Цена на CDN - это не вся цена, которые вы платите. Отдельно вы платите за хранение данных в blob</b>, но это так, напоминание.

<h5><b>Ссылки</b></h5>
<ul>
	<li>Стартовая <a href="http://azure.microsoft.com/en-us/services/cdn/">1</a>, <a href="http://azure.microsoft.com/en-us/documentation/services/cdn/">2</a>.</li>
	<li><a href="http://azure.microsoft.com/en-us/pricing/details/cdn/">Цены</a></li>
	<li><a href="https://social.msdn.microsoft.com/Search/en-US/?query=CDN&rq=meta:Search.MSForums.GroupID(cce86a2c-2881-4856-8ff0-3528d44cf49c)%20site:microsoft.com&rn=All%20Windows%20Azure%20Platform%20Forums">Форум</a></li>
</ul>
P.S. Если Вы хотите помочь улучшить статью- можно предлогать ваши правки через <a href="https://github.com/SychevIgor/blog/tree/master/Azure/Media&CDN/CDN">github</a>
