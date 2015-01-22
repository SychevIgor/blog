Несколько месяцев назад в виде preview появился сервис Azure Data Factory, и наконец-то у меня дошли руки с ним разобраться.

<b>Основной смысл этого проекта в том, чтобы дать возможность брать различные источники данных, связывать их с обработчиками и получать очищенные данные на выходе.</b>

Такой своеобразный аналог SQL Server Integration Service. Построил pipeline (конвейер обработки) и на выходе получил результат.  При этом в качестве источника данных можно использовать SQL Azure, SQL Server (в том числе и не в Azure), а также Blob, Table, Queue из Storage Account.
Конечно с SSIS на порядок более мощный инструмент, но это самое близкое сравнение приходящее на ум.
<habracut text="Далее расскажу подробнее результаты своего разбирательства" />
<h4><b>Термины</b></h4>
Чтобы понять что такое ADF надо разобраться с его <a href="http://azure.microsoft.com/en-us/documentation/articles/data-factory-introduction/">терминологий</a>.
<ul>
	<li><b>Linked Service</b> – фактически, это указатель-запись-строка на ресурс, который затем будет использован при работе. Он бывает 2 типов: хранение данных и обработка.
<ul>
<li><b>Storage</b> - SQL Azure, Azure Storage Account, SQL Server.</li>
	<li><b>Compute</b> сейчас поддерживается только Hadoop. На мой взгляд, Hadoop может быть излишне мощным инструментом, и для задач обработки будет достаточно менее мощных ресурсов. Надеюсь, в будущем добавят и worker role, и виртуальные машины, и batch. Но на данный момент в стадии preview.</li>
</ul></li>
	<li><b>Data Set</b> - именованный набор данных. В теории, может быть как просто набором байт, так и структурированной таблицей со схемой. В реальности на данный момент поддерживается только один тип.
<ul><li><b>Table</b> - это набор плоских данных со схемой.</li></ul></li>	
	<li><b>Activity</b> – это непосредственные обработчики данных. Они бывают 3 типов: написанные на C#, написанные на Hive/Pig для Hadoop и copy-активности, для копирования данных с локальных серверов в облако.</li>
	<li><b>Pipeline</b> - это процесс, который объединяет linked service-источники данных, linked service-обработчики и activity и на выходе создает Data Set.</li>
	<li><b>Data Hub</b> - логическая группировка Linked Service. Pipeline стартует в рамках одного Data Hub.  (Судя по всему сейчас переименовали в Resource Group т.к. я только в одной статье видел этот термин, а на портале и в остальных статьях resource group. По этому даже pull request сделал, с правкой стать.)</li>
	<li><b>Slice</b> - это часть Dataset, полученная в рамках одного запуска. Каждый последующий запуск процесса порождает новый slice. </li>
	<li><b><a href="http://azure.microsoft.com/en-us/documentation/articles/data-factory-use-onpremises-datasources/">Data Management Gateway</a></b> - это ПО, которое позволяет соединить локальный sql server ADF. Мы должны его установить в своей сети, зарегистрировать через  Azure Portal.</li>
</ul>

<h4><b>Создаем Azure Data factory</b></h4>
<a href="http://azure.microsoft.com/en-us/documentation/articles/data-factory-get-started/">Как это выглядит пошагово</a>:
<spoiler title="Открываем Management Portal Preview."><img src="http://habrastorage.org/files/50e/bb3/c3c/50ebb3c3c2924909bd0e0846f4d5caf8.png" alt="image"/></spoiler>
<spoiler title="Нажимаем создать"><img src="http://habrastorage.org/files/9eb/164/c7e/9eb164c7e2154a0b9eb1869664aded3a.png" alt="image"/></spoiler>
<spoiler title="Добавляем Linked Service"><img src="http://habrastorage.org/files/d7c/87b/0c6/d7c87b0c6c7f4640bd44be7db818d8d0.png" alt="image"/></spoiler>
<spoiler title="Выбирав тип Storage для LS, выбираем тип Azure Table storage"><img src="http://habrastorage.org/files/5b1/345/646/5b1345646b884a4d90b272f11520847c.png" alt="image"/></spoiler>
<spoiler title="Wizard для Storage Account"><img src="http://habrastorage.org/files/f3a/29d/9de/f3a29d9dedf34cf28233f5f2a7837202.png" alt="image"/></spoiler>
<spoiler title="Wizard для базы данных"><img src="http://habrastorage.org/files/5c8/470/e0e/5c8470e0e8ee40aa91a5813a79d3a999.png" alt="image"/></spoiler>

<h5><b>Следующим шагом будет создание Pipeline</b>.</h5>
Особенность на текущий момент в том, что мы не можем сделать это через интерфейс. Придется использовать Powershell командлеты.
<h6>Входящая таблица</h6>
 <spoiler title="В Json описываем структуру нашего источника данных."><img src="http://habrastorage.org/files/ad8/cae/9e7/ad8cae9e745345b7bd14ee1c8ac4ed96.png" alt="image"/></spoiler>
Надеюсь, в будущем команда сделает экспорт какой-нибудь или графический wizard, но пока так.
<spoiler title="После чего создаем таблицу через powershell команду:"><img src="http://habrastorage.org/files/61e/e7e/366/61ee7e366fe84c768ab83301b8c651dc.png" alt="image"/></spoiler>
Точно таким же образом создается выходная таблица. Т.к. если есть вход, значит должен быть и выход.

<h6>Создаем сам Pipeline</h6>
<spoiler title="Мы это делаем в json-формате."><img src="http://habrastorage.org/files/db4/22f/eb5/db422feb59dd4f58b8041ab103790dab.png" alt="image"/></spoiler>
Самое важное я выделил - это имена входящих и исходящих таблиц, их типы указаны в трансформации. 
<spoiler title="Затем исполняем скрипт создания pipeline через powershell."><img src="http://habrastorage.org/files/f15/aa2/38e/f15aa238ec8b4bc781754ccbc73d66fc.png" alt="image"/></spoiler>
<spoiler title="После чего через интерфейс портала мы можем посмотреть на созданную активность, статистику ее вызовов и т.п.">
<img src="http://habrastorage.org/files/def/e8b/819/defe8b81970a43ea999c76741cc7b887.png" alt="image"/><img src="http://habrastorage.org/files/b0d/166/d93/b0d166d93d2d432f999f2195a00786d3.png" alt="image"/></spoiler>

Это достаточно простой пример.
Ничто нам не мешает выход одной активности передавать на вход другой или сделать несколько источников данных для активности. Все упирается в ваши потребности.
 <spoiler title="Вот пример более сложной схемы:"><img src="http://habrastorage.org/files/625/e89/efb/625e89efb85b4993ac3836cac7b24744.png" alt="image"/></spoiler>

<h5><b>Источники и приемники для Copy Activity</b></h5>
Команда разработчиков предоставила нам табличку, показывающую, что и куда можно переливать. 
<img src="http://habrastorage.org/files/47d/559/2df/47d5592df94f4b6294e94a5561a509c5.png" alt="image"/>
Понятно, что внутри Azure все и везде.  А вот если мы подключаем либо свой локальный SQL Server, либо созданный на виртуальной машине (что по сути одно и тоже, с точностью до Data Management Gateway), то мы уже ограничены в направлениях. Хотя если мы переливаем данные с одного локального SQL Server на другой, то не очень понятно, зачем тут Data Factory вообще: берем SQL Integration Service и поехали! 
В <a href="http://azure.microsoft.com/en-us/documentation/articles/data-factory-copy-activity/">этой же статье</a> и набор свойств для каждого источника/приемника данных перечислен.

<b><a href="http://azure.microsoft.com/en-us/documentation/articles/data-factory-use-custom-activities/">.Net code activity</a></b>
Но это были всего лишь Copy Activity. Если мы хотим написать что-то более разумное, чем переливку данных из одного источника в другой, нам придется написать на C# code activity и подключать его в процесс обработки. Хостится .Net activity внутри Hadoop кластера.

<spoiler title="Чтобы созданный нами класс был вызван, мы должны всего-то на всего имплементировать интерфейс."><img src="http://habrastorage.org/files/2fd/a33/5e9/2fda335e97284da78bff1bfd3974a089.png" alt="image"/>
</spoiler>
У нас есть входные и выходные таблицы, свойства, а какую логику с помощью этого реализовать - это на усмотрение разработчика.

После того, как мы написали код, мы должны его опубликовать в blob в виде zip-архива. 
<spoiler title="Затем мы можем сослаться на него при создании pipeline,как это показано ниже."><img src="http://habrastorage.org/files/97d/3c2/3c5/97d3c23c51e844d9aa1ee3b566c9fd5f.png" alt="image"/></spoiler>

<h5><b>.net SDK - Создание всех настроек из C#</b></h5>
В принципе, мы можем создавать и linked resource и pipeline из C#, а не только из powershell через json. Все объекты в JSON один в один мапятся в C# классы. Кому интересно можно прочесть в <a href="http://azure.microsoft.com/en-us/documentation/articles/data-factory-create-data-factories-programmatically/">статье</a>

С ADF можно и нужно работать через PowerShell-<a href=" http://msdn.microsoft.com/en-us/library/dn820234.aspx">коммандлеты</a>, полное  их описание можно прочитать тут.


<h5><b>Использования Hive на Hadoop</b></h5>
Мы можем написать скрипт на hive или pig и встроить его в pipeline обработки. Более подробно можно прочитать в <a href="http://azure.microsoft.com/en-us/documentation/articles/data-factory-map-reduce/">этой</a> и <a href="http://azure.microsoft.com/en-us/documentation/articles/data-factory-pig-hive-activities/">этой</a> статье.
По большому счету ничего особенно отличающегося от остальных вариантов. Просто в качестве актвности указывается hive скрипт, грузится в blob и затем на него ссылается в декларации pipeline.
Я правда везде вижу Hive/Pig, но про Pig почему-то только заявления, что можно, ни статьи нет на эту тему.

<h5><b>Мониторинг, запуски, данные.</b></h5>
В интерфейсе портала можно посмотреть информацию по всем источникам данных, запускам, их состоянию, по  slice-ам, образовавшимся в результате работы. 
<spoiler title="Тут все вроде очевидно.">
<img src="http://habrastorage.org/files/ffb/59a/aad/ffb59aaad2e646d9b0da3d3ea89a890a.png" alt="image"/>
<img src="http://habrastorage.org/files/d89/2f5/74f/d892f574f93b48cb8f1be4291eb5a373.png" alt="image"/>
<img src="http://habrastorage.org/files/4b5/3b0/c50/4b53b0c505844de481306bfb90a46e88.png" alt="image"/>
<img src="http://habrastorage.org/files/ac4/435/63a/ac443563a5e7458eb52eb2b5a5ded3ff.png" alt="image"/>
</spoiler>

<h5><b>On Premise data source</b></h5>
Как заявляют авторы, мы можем использовать стоящий в нашем datacenter sql server.
Для этого нам надо поставить Data Management Gateway (это ПО, которое ставится на ваш сервер и обеспечивает связь azure с ним), а затем так же, как и раньше, зарегистрировать наш sql как linked service.
Более подробно рекомендую прочитать <a href="http://azure.microsoft.com/en-us/documentation/articles/data-factory-use-onpremises-datasources/">статью</a>. Ни каких рокетных технологий тут нет.

<h5><b>Разбирательства с ошибками и проблемами</b></h5>
Более <a href="http://azure.microsoft.com/en-us/documentation/articles/data-factory-troubleshoot/">подробно </a>
Как и любой проект по переливке данных (SQL Integration Service и т.п.) с логированием все могло бы быть лучше. 
<spoiler title="Из выводимой информации можно понять про факт наличия проблемы, некоторые сообщения пробрасываются и в проблему с авторизацией."><img src="http://habrastorage.org/files/5aa/15e/e73/5aa15ee73a0149478bf064b5a8e91ffe.png" alt="image"/>
<img src="http://habrastorage.org/files/5fc/668/acd/5fc668acdd9a41f28f3b53d0972b9aa6.png" alt="image"/>
<img src="http://habrastorage.org/files/0cd/11a/13b/0cd11a13b89842dda73b90e0abd422ad.png" alt="image"/>
<img src="http://habrastorage.org/files/da5/f82/8b4/da5f828b4fe046fd9a47db17ead62415.png" alt="image"/></spoiler>

На мой субъективный взгляд, было бы полезно встроиться в шаг процесса и понять что там происходит и залогировать это, а то что есть сейчас немного не достаточно. Хотя это еще preview, а не релиз.

<spoiler title="У pig/hive можно выгрузить логи stderr"><img src="http://habrastorage.org/files/0ed/fb5/f5c/0edfb5f5c3184029bd23f0541980cb5c.png" alt="image"/></spoiler>

<h5><b><a href="http://azure.microsoft.com/en-us/pricing/details/data-factory/">Цены</a>:</b></h5>
Есть 2 возможности запуска, т.к. есть 2 тарификации: в облаке и локально. 
Под локально понимается не возможность развернуть ADF под столом, а использование локального sql. 
<img src="http://habrastorage.org/files/cee/22a/831/cee22a831d0b4a72a7fc334dced0ffd4.png" alt="image"/>
Тут как всегда: запуск активности - это одни деньги. Если  используете HD Insight(Hadoop), то за него отдельно, трафик, исходящий из azure - тоже отдельно. Мне лично непонятно, зависит ли время работы активности и стоимость ее запуска, т.к. в информации этого не нашел. 

<h5><b>Ссылки</b></h5>
<ul>
	<li><a href="http://azure.microsoft.com/en-us/services/preview/">Data Factory на страничке preview</a></li>
	<li><a href="http://azure.microsoft.com/en-us/services/data-factory/">Стартовая</a></li>
	<li><a href="http://channel9.msdn.com/Blogs/Windows-Azure/Azure-Data-Factory-Overview/">Видео Overview</a></li>
	<li><a href="http://azure.microsoft.com/en-us/documentation/services/data-factory/">Техническая документация</a></li>
	<li><a href="http://msdn.microsoft.com/en-us/library/dn834987.aspx">Техническая документация2</a></li>
	<li><a href="https://github.com/Azure/Azure-DataFactory">Примеры на github</a></li>
	<li><a href="http://msdn.microsoft.com/en-us/library/dn883654.aspx">.NetSDK документация</a></li>
	<li><a href="https://social.msdn.microsoft.com/forums/azure/en-US/home?forum=AzureDataFactory">Форум</a></li>
	<li><a href="http://azure.microsoft.com/en-us/pricing/details/data-factory/">Цены</a></li>
	<li><a href="http://azure.microsoft.com/en-us/documentation/articles/data-factory-faq/">FAQ</a></li>
	<li><a href="http://aws.amazon.com/datapipeline/">Datapipeline от AWS</a></li>
</ul>

Мое личное мнение, что проекто родился из внутренней разработки внутри одной из команд azure и был представлен публике... Он решал свою специфичную задачу, а потом был выкачен в public. Как по мне так не хватает библиотеки активностей, чтобы не все писать руками (в SSIS есть ведь такая), не будет хватать возможности написать свой провайдер к источнику данных и т.п. В целом над SQL Server Integration Service есть 1 преимущество- можно испольовать не SQL источники и приемники данных, в остальном-же сервис сильно проще, если не сказать примитивнее.

P.S. статья доступна на <a href="https://github.com/SychevIgor/blog/tree/master/Azure/DataFactory">github</a>
