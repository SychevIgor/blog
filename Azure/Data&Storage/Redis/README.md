<table><tr>
<td><img width="359" height="300" src="http://habrastorage.org/files/679/357/ddc/679357ddcc224abeb2bb76bb33dc8ed1.jpg" alt="image"/></td>
<td><img width="359" height="300" src="http://habrastorage.org/files/401/866/749/40186674993442e097c1946da04da92f.png" alt="image"/></td></tr></table>

С 2014 года .net стал совсем другим (не тем, каким мы его знаем). Открытие части .net framework, новый компилятор C#, новый jit компилятор, .net native, активное использование нетипичных для windows технологий в Azure (из-за чего даже переименовали Windows Azure в Microsoft Azure), все большее движение Asp.net в сторону не только windows. 

На DevCon в 2012 году мы (я) с непониманием, слушал доклады по использованию Redis в .net приложениях. <b>В нынешнем 2015 году не обращать внимания на Redis невозможно, даже живя на другой планете.</b>

Я для себя точкой смены вех вижу 7 октября 2014 года, когда Скотт Гаттри анонсировал общую доступность <a href="http://weblogs.asp.net/scottgu/azure-redis-cache-disaster-recovery-to-azure-tagging-support-elastic-scale-for-sqldb-docdb">Redis Cache в Azure</a>.

<b>И последним ударом стало - <a href="http://msdn.microsoft.com/en-us/library/azure/dn766201.aspx">Microsoft теперь официально рекомендует использовать Redis для кэша -  "We recommend all new developments use Azure Redis Cache." 
</a></b> Всю жизнь говорили SQL Server (либо распределенный AppFabric Caching), а теперь Redis.
<habracut text="А дальше стали обнаруживаться места, где в платформе Microsoft торчит Redis" />
В Asp.Net5 (до декабря 2014 - vnext) появятся возможности:
<ul>
	<li>Команда Entity Framework анонсировала поддержку NoSQL хранилищ в Entity Framework 7 (правда в первом релизе 7.0 будет по старинке только SQL Server). Моя <a href="http://habrahabr.ru/post/111542/">статья</a> об этом.</li>
	<li>Xранить Session в Redis <a href="http://msdn.microsoft.com/en-us/library/azure/dn690522.aspx ">1</a> и <a href="http://blogs.msdn.com/b/webdev/archive/2014/05/12/announcing-asp-net-session-state-provider-for-redis-preview-release.aspx">2</a>.</li>
	<li>И <a href="https://github.com/aspnet/Caching/tree/dev/src/Microsoft.Framework.Cache.Redis">кэшировать</a> данные в Redis.</li>
	<li>Для SignalR можно использовать Redis в качестве scaleout backplane. <a href="http://habrahabr.ru/post/108929/">Моя статья</a> и <a href="http://www.asp.net/signalr/overview/performance/scaleout-with-redis">официальная </a></li>
</ul>
А когда-то не так давно, во времена .net 4.0- 4.5, был только <a href="http://msdn.microsoft.com/en-us/library/azure/dn798898.aspx">Output cache</a> и умельцы прикручивали Redis сами - автор на хабре недавно <a href="http://habrahabr.ru/post/240269/">писал</a> про использование Redis вместе с CacheDependency.

<h4><b>Краткая справка про Redis для .net разработчиков, не следивших за Redis ранее</b></h4>
Изначально Redis писался под nix системы. Через какое-то время Microsoft занялся поддержкой Redis для Windows через Microsoft Open Technologies. И уже потом, от проекта под Windows, Azure форкнула свою версию.
Чтобы понимать разницу между проектами:
<ul>
	<li><a href="https://github.com/antirez/redis">antirez/redis</a> – 4836 комитов</li>
	<li><a href="https://github.com/MSOpenTech/redis">MSOpenTech/redis</a> – 4399 комитов</li>
	<li><a href="https://github.com/Azure/redis">Azure/redis</a> – 3813 комитов </li>
</ul>
<b>Основную работу по поддержке Windows версии несет команда MS Open Technologies.</b>
<spoiler title="Она пишет Win32_Interop, для работы Redis под Windows,"><img src="http://habrastorage.org/files/009/68c/478/00968c478a3c4d289ad26e7537d4ee5b.png" alt="image"/></spoiler> сохраняя все интерфейсы/header файлы для совместимости с не windows версией; при этом ответственность на себя за windows версию берет только в Azure варианте. На локальном сервере/кластере – это на ваш страх и риск. 
<b>Команде Azure проще всего, т.к.</b>
<ul>
	<li>Они не тащат кучу старых веток типа 2.2, 2.4. У них есть prod версия 2.8 и на этом все. </li>
	<li><spoiler title="Они не используют 32-битную версию сборки - только 64."><img src="http://habrastorage.org/files/b7b/be8/46e/b7bbe846ed2f45a7afbb4e5a35ef016d.png" alt="image"/></spoiler></li>
	<li>Им не нужны инструкции инсталляции, т.к. в Azure ты просто берешь инстанс, а не занимаешься сам его настройкой.</li>
</ul>

<h4><b>Часто задаваемые вопросы</b></h4>
Коллеги, которые очень хорошо/плотно разбирались/ковырялись с SQL Server лет по 10, но вообще не ковырялись с Redis спрашивали:

<h5><b>А насколько он быстрый? А выдержит ли он нашу нагрузку, причем с запасом, мы ведь все-таки enterprise, а не детская площадка?</b></h5>
<b>Простой ответ - Redis очень быстрый.</b> На бытовом уровне я бы объяснил так:
<ul>
	<li>Использовать данные в памяти сильно быстрее, чем сначала читать их с диска.</li>
	<li><a href="http://stackoverflow.com/questions/9625246/what-are-the-underlying-data-structures-used-for-redis?answertab=votes#tab-top">Внутри</a> себя Redis хранит данные в разных структурах данных в зависимости от типа. Быстрее чем поиск по hash таблице, тяжело что-то придумать (без углубления в вопросы распределения hash и качества hash функций) => если вы храните данные в ней, у вас все очень хорошо. Если храните данные в списках, то могут быть проблемы.</li>
	<li>Т.к. в Redis нет такого сложного конвейера обработки запроса, как в SQL, накладные расходы ниже (план запроса, к примеру, надо составить, если его нет. Он составляется на основе статистики, статистика может быть некорректной и т.д., и т.п.). </li>
</ul>
В документации есть <a href="http://redis.io/topics/benchmarks">статья</a> про производительность  (очень рекомендую потратить время и прочесть), и <a href="http://oldblog.antirez.com/post/redis-memcached-benchmark.html">сравнение производительности с memcache</a>/ <a href="http://dormando.livejournal.com/525147.html http://oldblog.antirez.com/post/update-on-memcached-redis-benchmark.html">вариант 2</a>. На своих тестах Redis обошел Memcache, что очень хороший критерий производительности.

Если коротко, то 100 тысяч запросов в секунду на одном узле - это абсолютно нормальный результат, без какого-то фантастического железа или плясок с бубном при настройке. Мне нравится вот этот график, 
<img src="http://habrastorage.org/files/938/5b1/a5e/9385b1a5e99c45f1adeee5d1ea1b5d3b.png" alt="image"/>
который объясняет большую часть моментов, а именно: что при росте объема данных сеть становится узким местом, а не процессор или память. Сеть - это уже вопрос не к производительности самого Redis.

<h4><b>Второй вопрос был: кластерную конфигурацию поддерживает?</b></h4>
Ответ: да, причем из коробки, и кластер - это практически базовая конфигурация (design for cluster).
В этих статьях это описано подробно <a href="http://redis.io/topics/cluster-spec">1</a> и <a href="http://redis.io/topics/cluster-tutorial">2</a>, и пусть Вас не смущает фразы про альфа/бета - тут как с gmail (которая была beta когда уже сотни миллионов ящиков на ней были по 5-6 лет в эксплуатации). Люди годами работают и не жалуются.
Кластеры поддерживают и распределение нагрузки, и отказоустойчивость. Master-узлы разделяют между собой нагрузку (диапазон ключей) + у каждого узла может быть любое число shard-ов (на которых хранится реплика мастера, готовая его заменить в случае недоступности.)

<h4><b>А какие хорошие библиотеки доступа из .net есть?</b></h4>
Года 2 назад, на devcon 2012, ребята показывали библиотеку, написанную на коленках за неделю. С тех пор мир изменился кардинально. Есть <a href="http://redis.io/clients">множество </a>библиотек, но для .net де факто стандартом стала <a href="https://github.com/StackExchange/StackExchange.Redis">stackexchane</a> (те, кто использовал другие библиотеки в своих проектах, все чаще выпиливают и заменяют на эту версию).
Чтобы начать пользоваться этой библиотекой, долго вникать в нее не нужно. Принцип ее работы можно разобрать, открыв всего 3 класса.
<ul>
	<li>https://github.com/StackExchange/StackExchange.Redis/blob/master/StackExchange.Redis/StackExchange/Redis/RedisCommand.cs </li>
	<li>https://github.com/StackExchange/StackExchange.Redis/blob/master/StackExchange.Redis/StackExchange/Redis/ConnectionMultiplexer.cs</li>
	<li>https://github.com/StackExchange/StackExchange.Redis/blob/master/StackExchange.Redis/StackExchange/Redis/RedisDatabase.cs </li>
</ul>
<h4><b>Если данные хранятся в памяти, то как долговременно хранить их? Сервер же перегружается иногда!</b></h4>
В определении что такое Redis есть слово, которое всех сбивает с толку – InMemory, но оно не означает In Memory Only. В Redis есть механизм сброса данных на диск, точнее 2 механизма. Инкрементальный - это когда каждые n секунд (можно сделать каждые 5, 30, 600 секунд) идет сброс данных, и Полный - это когда сбрасывается все содержимое на диск. (Как с бэкапами баз данных - инкрементальный и полный бэкап). Эти варианты друг другу не противоречат, можно оба включить. Это не бесплатно в плане производительности, как и любая запись на диск.

<h5><b>Вместо заключения</b></h5>
<b>.Net сильно меняется, и придется меняться .net разработчикам. Использование Redis – это очередной шаг эволюции платформы, и его надо принять. Это не страшно. </b>

<h4><b>Ссылки</b></h4>
<ul>
	<li><a href="http://redis.io">redis</a></li>
	<li>http://msdn.microsoft.com/en-us/library/azure/dn690523.aspx </li>
	<li><a href="http://azure.microsoft.com/en-us/services/cache/">Azure Redis</a></li>
</ul>

Если Вы хотите помочь улучшить статью- предлогайте ваши правки через <a href="https://github.com/SychevIgor/blog/tree/master/Azure/Data%26Storage/Redis">github</a>
