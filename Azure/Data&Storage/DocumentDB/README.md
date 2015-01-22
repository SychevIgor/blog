Недавно Microsoft анонсировало Azure DocumentDB preview. 

Как следует из названия – это документно-ориентированная база данных. Даже на хабре в 2 строчках об этом написали в <a href="http://habrahabr.ru/post/234459/">этой</a> и <a href="http://habrahabr.ru/post/234233/">этой</a>. Я же хочу более детально рассказать, что скрывается под этим названием.
<habracut/>
<h4><b>Зачем Microsoft еще одна база данных, если есть Sql Azure, Sql Server на виртуалках, Tables, BLOBs!?</b> </h4>
Ни одна из этих фичей-баз не является документно-ориентированной базой данных. 
<ul>
	<li>Sql Azure, Sql Server на виртуалках — это реляционные база данных.</li>
	<li>Table — это KeyValue база, в которой есть всего 1 индекс по первичному ключу.</li>
	<li>Blob — это хранилище файлов.</li>
</ul>

Новый тип Microsoft не изобретала, а просто реализовала концепцию, которую каждый студент IT факультета слышит в курсе баз данных. 

<h5><b>На чем основана DocumentDB?</b> </h5>
Это самописный сервис, стоящий особняком от остальных сервисов Microsoft. Хотя, если честно, Blob Storage там применяется для хранения бинарных объектов. 

В одной из статей в комментариях спросили — а не на Table ли это построено? (Ребята сами написали обертку поверх Table). На что сотрудник MSFT ответил, что они сами написали. “DocumentDB is a new database engine built ground up for JSON documents.”  Более подробно введением в DocumentDB можно прочест в <a href="http://azure.microsoft.com/en-us/documentation/articles/documentdb-introduction/">этой статье</a>. Часть этой статьи я расскажу ниже.

<h5><b>JS/JS engine</b> </h5>
Разработчики сообщили, что они реализовали стандарт ECMA и что это не очередная нестандартная реализация. 
“<a href="http://azure.microsoft.com/en-us/documentation/articles/documentdb-interactions-with-resources/">DocumentDB JavaScript server side SDK provides support for the most of the mainstream JavaScript language features as standardized by ECMA-262</a>.”

Движок JavaScript встроен в систему. Я задал <a href="http://social.msdn.microsoft.com/Forums/windowshardware/en-US/001f4583-a0f1-419e-9b41-fe8a0f4607a2/is-documentdb-javascript-engine-is-based-on-existed-engine-or-its-a-absolytly-new?forum=AzureDocumentDB">вопрос</a>: какой у них движок внутри, т.к. непонятно. 

На форуме мне ответили примерно так: это не с нуля написанный движок — мы давно используем его на server side. Правда, я не понял где конкретно, даже прочитав ссылку, которую мне порекомендовали.

<h5><b>Протокол взаимодействия с DocumentDB</b> </h5>
На низком уровне взаимодействие идет через TCP, а сам API — это rest API. Т.е. get/post/put/delete. 
Обратно приходит ответ в виде json. 
Microsoft предоставляет SDK для .net, node.js, python. 
Всем остальным можно самим имплементировать работу с DocumentDB, т.к. API предоставляется через http протокол, и есть вот такое <a href="http://azure.microsoft.com/ru-ru/documentation/articles/documentdb-interactions-with-resources/ ">описание</a>.

<h5><b>Размеры и производительность базы данных </b></h5>
Пока есть только заявление Microsoft, что сервис очень хорошо и потенциально бесконечно масштабируемый. 
Цитата:
"A DocumentDB database is elastic by default – ranging from a few GB to petabytes of SSD backed document storage and provisioned throughput. Unlike a database in traditional RDBMS, a database in DocumentDB is not scoped to a single machine. With DocumentDB, as your application’s scale needs grow, you can create more collections or databases or both. Indeed, various first party applications within Microsoft have been using DocumentDB at a consumer scale by creating extremely large DocumentDB databases each containing thousands of collections with terabytes of document storage."

"There is no practical scale limit to the size of a database account – any number of capacity units can be added over time subject to the offer restrictions."

Как скейлятся разные коллекции очевидно. Т.к. отсутствуют <a href="http://social.msdn.microsoft.com/Forums/windowshardware/en-US/1bc35b3c-74aa-4081-aea6-19e88f4d3b20/documentdb-joins-between-collections?forum=AzureDocumentDB">join </a> между коллекциями, то и каждая коллекция может быть от другой независимой, а также может находиться на совершенно другом физическом железе. Скейлить же одну коллекцию уже сильно проще. 

<h5><b>Хранение </b></h5>
Я не нашел в публичном доступе информации о том, как данные хранятся внутри DocumentDB. В MongoDB мы знаем, что все хранится в BSON. Поэтому я задал <a href="http://social.msdn.microsoft.com/Forums/windowsazure/en-US/77c7b07f-e382-4ce6-a562-0e160b8dbf9d/inner-representation-of-data-in-documentdb?forum=AzureDocumentDB">вопрос </a>на форуме. 

В ответе было написано, что хранится именно json с небольшим числом дополнительных полей. 

Для бинарных файлов есть 2 варианта: хранить их в DocumentDB или на собственном внешнем ресурсе (назывался даже onedrive, dropbox, azure tables). Если хранить в DocumentDB, то, на самом деле, бинарные объекты будут лежать в Blob Storage. 

<h5><b>Запросы </b></h5>
Перед написание запросов, стоит глянуть картинку- что к чему привязано и что во что входит:

<img src="http://habrastorage.org/getpro/habr/post_images/3d7/8eb/4fb/3d78eb4fb070a112af971ead80e452aa.png" alt="image"/>

Способ написания запросов сочетает в себе sql-образный синтаксис и то, как пишут запросы в mongoDB для выбора результирующего набора данных. Глубже разобраться в вопросе можно <a href="http://azure.microsoft.com/en-us/documentation/articles/documentdb-sql-query/">здесь</a>, а я расскажу о концептуальном написании запросов.

В DocumentDB запросы мы можем писать либо на sql, либо воспользоваться LINQ для .net. 

Допустим у нас есть коллекция, в которой есть 2 документа:
<img src="http://habrastorage.org/files/d59/18c/62e/d5918c62e1f34eadb315d40a65ba97bc.png"/>
<img src="http://habrastorage.org/files/aea/2bf/574/aea2bf574c4849aab96a4cc76349e2fa.png"/>

Пишем простой select * с условием where и получаем только 1 запись. В целом очень даже sql.

<img src="http://habrastorage.org/files/4e6/d94/cfb/4e6d94cfb4144cd4b0be4585ab5e35f0.png"/>

Не стоит думать, что размер выходного потока бесконечен. В <a href="http://azure.microsoft.com/en-us/documentation/articles/documentdb-limits/">документе </a>по ограничениям указано, что на данный момент ограничение составляет 1 мб. 

Второй пример с выборкой только части исходного документа.
<img src="http://habrastorage.org/files/ab0/d75/f20/ab0d75f207a14ffd922d44b55302433d.png"/>

<h5><b>Программная модель  </b></h5>
Для DocumentDB можно писать триггеры, хранимые процедуры и UDF (user defined function). В отличии от mssql/oracle или других реляционных БД, здесь запросы мы будем писать на JavaScript. В принципе, на js можно накрутить любую логику, и за счет http-интерфейса общения с базой данных на этом можно написать хоть весь backend приложения... Но, судя по всему, разработчики DocumentDB позаботились о таких горячих головах и ввели ограничение на время исполнение любого клиентского кода в 5 секунд. 

В DocumentDb, как и в любой нормальной базе данных, есть транзакции, но на них останавливаться желания у меня не возникло. 

<h5><b>Индексы и политика индексирования</b></h5> 
Индексы по умолчанию строятся автоматически. Мы же, как разработчики, можем отключить эту настройку и указать шаблон, по которому будет собираться индекс (по каким полям). 

Индекс может быть синхронным(consistent) и асинхронным (lazy). Синхронный строится сразу после вставок в коллекцию, а асинхронный с задержкой. Задержка нужна для оптимизации скорости записи при массовой записи. 

Размер индекса вместе с самой коллекцией составляет полный объем потребляемой памяти. 

<h5><b>Программирование под DocumentDB</b></h5>
Моя рекомендация: прежде чем начать экспериментировать, прочесть <a href="http://azure.microsoft.com/en-us/documentation/articles/documentdb-limits/">статью </a>об ограничениях по использованию Чтобы не ломать голову, почему 2 UDF не работает в одном запросе. В документе это описано. 

Каждой хранимке-триггеру-UDF выделяется фиксированный квант ресурсов операционной системы, в течение которого она должна быть выполнена.(Each stored procedure, trigger or a UDF gets a fixed quantum of operating system resources to do its work) Т.к. в документации я нашел только о 5 секундах на исполнение и ничего про другие ограничения (например, про память), то задал <a href="http://social.msdn.microsoft.com/Forums/en-US/c2b94bc7-2c19-41dc-a12f-ce33dff992b4/is-limitation-exist-for-memory-consumption-during-stored-procedure-execution?forum=AzureDocumentDB">вопрос </a>на форуме. 

Further, stored procedures, triggers or UDFs cannot link against external JavaScript libraries and are blacklisted if they exceed the resource budgets allocated to them. Понять, как вытащить хранимку из blacklist. 

Сами хранимки и тп компилируются в байткод. Надо понять, хранятся они в обоих видах или только в бинарном - для меня это пока вопрос открытый.

Upon registration a stored procedure, trigger, or a UDF is pre-compiled and stored as byte code which gets executed later. 

<h5><b>Stored Procedure</b> </h5>
В хранимых процедурах ничего интересного нет. Но на них удобно показывать концепции написания кода на js для DocumentDB. 
<ul>
	<li>Создаем процедуру. <img src="http://habrastorage.org/files/3b7/bc6/31c/3b7bc631c0d74f16ab2db2e7bd3844c6.png"/></li>
	<li>Регистрируем ее в DocumentDB <img src="http://habrastorage.org/files/906/3f9/0ee/9063f90ee6364ff382491b9e0b153e98.png"/></li>
	<li>Вызываем <img src="http://habrastorage.org/files/0d5/592/850/0d559285026541c6839c4a6a83a04b42.png"/></li>
</ul>

<h5><b>Триггеры </b></h5>
Зачем нужны триггеры очевидно из того, как они вызываются. А вызываются они по событию. Триггеры бывают 2 типов: Pre и Post. Т.е. они работают до и после операции. Триггер может быть запущен по выбранному типу операции (Create, Replace, Delete or All/POST/PUT/DELETE). 

Pre-триггеры имеют доступ к данных входного запроса. 
Post-триггер имеет доступ к данным, которые будут отданы клиенту. 

<h5><b>UDF </b></h5>
Отличие UDF от Stored Procedure простое- UDF нельзя вызвать снаружи. Хранимую процедуру- можно. 
Цитата:
"User-defined functions, or UDFs are used to extend the DocumentDB SQL query language grammar and implement custom business logic. They can only be called from inside queries. They do not have access to the context object and are meant to be used as compute-only JavaScript. Therefore, UDFs can be run on secondary replicas of the DocumentDB service." А где запускаются by default мне не понятно.

<h5><b>Миграция данных</b></h5>
Пока никаких утилит миграции я не нашел, что логично, т.к. проект еще только в preview. Плюс есть проблема: переносить данные из реляционной базы требует переосмысления структуры хранения, схемы, денормализации, возможно. Наверное, пока таких утилит нету (и не факт что будут). 

<h5><b>Репликация </b></h5>
На <a href="http://azure.microsoft.com/en-us/services/documentdb/?mkt_tok=3RkMMJWWfF9wsRolvqvLZKXonjHpfsX56OsuXq6%2flMI%2f0ER3fOvrPUfGjI4ERMZqI%2bSLDwEYGJlv6SgFS7XCMadx37gOUxM%3d">странице  </a>, где анонсировали эту фичу, есть фраза: “Data is automatically replicated to provide high availability.” Но ничего более подробного я пока не нашел. Поэтому я <a href="http://social.msdn.microsoft.com/Forums/windowshardware/en-US/5d2d4d2a-c564-4f8a-b8cb-b412df42c14b/how-much-replicas-of-documentdb-collection-exists-in-the-same-time?forum=AzureDocumentDB">спросил </a>о репликах.

Краткий ответ был такой: есть алгоритм, который контролирует и т.п. По факту, есть 1 основная реплика, и, как минимум, 2 вторичных. Сейчас они все в одном датацентре, но разнесены по различному оборудованию (при падении одной железки, база останется жива.) Если нужна геораспределенность — <a href="http://feedback.azure.com/forums/263030-documentdb">напишите о вашем желании</a>.

<h5><b>Monitoring и Alerts </b></h5>
Как и у любого cloud service, у DocumentDB если система мониторинга. Вы можете собирать метрики среднее число запросов за период и общее количество запросов. Правда пока это доступно на preview портале Azure и недоступно на основном. Зачем эти метрики нужны, я думаю, очевидно. 

Также можно настроить оповещения на email о нарушении некоторых границ. Для этого надо настроить правило нотификации Alert Rule и указать кому отправить. <a href="http://azure.microsoft.com/en-us/documentation/articles/documentdb-monitor-accounts/ ">Статья</a> про настройку мониторинга и оповещений: 

Т.к. я знаю что к сопровождению постоянно приходят какие-то нотификации, то было бы интересно иметь возможность об особо критичных проблемах присылать не только email, но и sms. Это я <a href="http://social.msdn.microsoft.com/Forums/windowsazure/en-US/64ad92b0-3e05-4845-8ca4-91f3c3662264/alert-rule-with-sms-notification?forum=AzureDocumentDB">предложил </a>на форуме. 

<h5><b>Почему не MongoDB? </b></h5>
<u>Ее написали не они!</u> Мое мнение — компания уровня Microsoft может написать свою документно-ориентированную базу данных, чтобы не зависеть от внешних вендоров. У нее для этого есть время, деньги, компитенции, необходимость.

<h5><b>Чем DocumentDB лучше MongoDB?</b> </h5>
Пока она в preview, ее никто особо не ковырял, поэтому рассуждать сложно, особенно что касается сравнения производительности. 

Вопрос сравнения с mongo на сайте с feedback уже <a href="http://feedback.azure.com/forums/263030-documentdb/suggestions/6327750-please-provide-a-comparison-article-compare-betwe">подняли </a> до меня, я лишь поддержал.

В случае Azure от себя могу сказать, что DocumentDB сейчас настраивается в 2-3 клика мышкой (как и многие другие сервисы в Azure), а MongoDB надо себе ставить либо самому на виртуальную машину и разбираться с конфигурированием, либо запросить предварительно сконфигурированную виртуалку. <a href="http://azure.microsoft.com/en-us/documentation/articles/documentdb-introduction/">Цитата </a>от Microsoft 

“Fully managed: Eliminate the need to manage database and machine resources. As a fully-managed Microsoft Azure service, you do not need to manage virtual machines, deploy and configure software, or deal with complex data-tier upgrades. Every database is automatically backed up and protected against regional failures. You can easily add a DocumentDB account and provision capacity as you need it, allowing you to focus on your application vs. operating and managing your database”.

В DocumentDB вы будите писать sql подобные запросы, что сокращает порог вхождения для разрботка. В MongoDB вам придется освоить не такой привычный синтаксис операторов тк не sql base. 

<h5>Ссылки</h5>
<ul>
	<li><a href="http://blogs.msdn.com/b/documentdb/archive/2014/08/22/introducing-azure-documentdb-microsoft-s-fully-managed-nosql-document-database-service.aspx">Анонс в блоге msdn</a> </li>
	<li><a href="http://azure.microsoft.com/en-us/documentation/services/documentdb">Коллекция ресурсов для разработчика</a></li>
	<li><a href="http://azure.microsoft.com/en-us/documentation/articles/documentdb-resources/">Еще одна коллекция ресурсов</a></li>
<li> msdn <a href="http://msdn.microsoft.com/en-us/library/azure/dn781482.aspx">Документация</a></li>
	<li><a href="http://azure.microsoft.com/en-us/documentation/articles/documentdb-introduction/">Краткое описание для разработчика</a></li>
	<li><a href="http://azure.microsoft.com/en-us/documentation/articles/documentdb-get-started/">Как написать “hello word” Get started with a DocumentDB account</a></li>
	<li><a href="http://azure.microsoft.com/en-us/documentation/articles/documentdb-consistency-levels/">Консистентность данных</a> </li>
	<li><a href="http://www.documentdb.com/javascript/tutorial">Как писать на JavaScript хранимые процедуры, триггеры и UDF</a>  </li>
	<li><a href="http://azure.microsoft.com/en-us/documentation/articles/documentdb-dotnet-application/">Пример написание Asp.net MVC сайта с использованием DocumentDB</a>  </li>
	<li><a href="http://azure.microsoft.com/en-us/documentation/articles/documentdb-limits/">Ограничения preview-release</a> </li>
<li> <a href="http://azure.microsoft.com/en-us/documentation/articles/documentdb-faq/">FAQ</a></li>
</ul>

Если Вы хотите помочь улучшить статью- предлогайте ваши правки через <a href="https://github.com/SychevIgor/blog/blob/master/Azure/Data%26Storage/DocumentDB">github</a>
