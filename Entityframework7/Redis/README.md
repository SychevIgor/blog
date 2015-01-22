Microsoft таки решили добавить в свой флагманский orm поддержку не реляционных хранилищ данных.
Лично я узнал об этом на teched europe 2014 (кто-то, возможно, знал и ранее).
В EF7 заявлена поддержка Redis и Azure Table Store.
<table><tr>
<td><img src="http://habrastorage.org/files/47b/b5a/338/47bb5a3384bf4e4abb141f64e6d268ae.png" alt="image"/></td>
<td><img src="http://habrastorage.org/files/d6a/3da/4dd/d6a3da4dd2ea4df3952c497aa0316729.png" alt="image"/></td>
</tr></table>

Table Store для тех, кто Azure не пользуется, не интересен в принципе.
А вот поддержка Redis - другое дело, т.к. in memory key-value store, которое можно держать на своих серверах - это уже интересно.
<habracut text="Давайте разбираться..." />

<b>Все что написано ниже, относится к текущему состоянию код, которое далеко от завершения.</b> Цитата из <a href="https://github.com/aspnet/EntityFramework/wiki/Getting-Started-with-Nightly-Builds">EF wiki</a>: 
"<i>As you try out EF7 please bear in mind that this is a very early stage in the development of the new EF codebase and there are many features that are partially implemented or not yet available.</i>"

<h4><b>Вообще про EF7</b></h4>
EF7 использует (на 10 ноября 2014 года) библиотеку работы с Redis от <a href="https://github.com/StackExchange/StackExchange.Redis">StackExchange </a> доступной на <a href="http://www.nuget.org/packages/StackExchange.Redis/">nuget.org </a>
Это приятно, что MS не стал писать свою собственную библиотеку, хотя они и могли это сделать.
Пока EF7 не доступен в nuget (на 10 ноября 2014 года), но на <a href="https://github.com/aspnet/EntityFramework/tree/dev/src/EntityFramework.Redis">github </a>уже можно смотреть 
(В видео с teched europe показывали ef7-pre, но на общем nuget его пока нет.)

EF7 пишется сразу, чтобы работать с VS2014(в vs2013 update2 тоже работает), с asp.net vnext (json файлы с зависимостями) и т.д.
У меня не получилось скомпилировать проект ни на vs2013, ни vs2014 т.к. не хватало части зависимостей сначала, а потом вылетела ошибка описанная <a href="https://github.com/aspnet/EntityFramework/issues/821">тут </a>до меня. Чтобы собрать проект, нужно прочитать <a href="https://github.com/aspnet/EntityFramework/wiki/Getting-and-Building-the-Code">инструкцию </a>, но мне пока это не помогло.

В EF появится Fluent Api, которое специфично для провайдера (для Relation или для Azure Table Store). Наверное, и для Redis что-то специфичное появится, но про это информации в wiki нет.

На Teched Europe говорилось, что EF7 станет более расширяемым. Я не знаю, что было первичным: "расширяемость" или "поддержка key-value store", но последнее без первого все равно не возможно. Т.к. Генератор sql в redis точно не нужен, к примеру, как и миграции от code first.

<h4><b>Что можно сказать про Redis сейчас:</b></h4>
На EF Wiki есть статья "<a href="https://github.com/aspnet/EntityFramework/wiki/Entity-Framework-Design-Meeting-Notes---July-17,-2014#ef7-redis-provider">EF7 Redis provider</a>" в которой есть хоть какая-то информация о работе с Redis, ограничениях по работе с ним.

Новых функций/методов/api для Redis учить особо не придется, если Вы ранее с EF уже работали.
Код выглядит примерно так же:

<spoiler title="Создаем контекст, выбираем из него типизированный DbSet.
Работая с DbSet, можем делать все CRUD операции."><img src="http://habrastorage.org/files/8d6/a2f/3bc/8d6a2f3bc2c84392b07c307ad7a00305.png" alt="image"/></spoiler>

<spoiler title="Для Redis также поддерживаются не только синхронные, но и асинхронные версии методов."><img src="http://habrastorage.org/files/e69/bca/aa7/e69bcaaa7eda4fd4807205b56fa10d05.png" alt="image"/></spoiler>

<spoiler title="Из DbSet (Реализует IQuariable) все так же можно получить все нужные нам выборки, агрегации и т.д. (правда, реализованы они, понятное дело, отлично, от sql версии.)"><img src="http://habrastorage.org/files/0b7/01e/19c/0b701e19c7f449ed94722ca301f7e1da.png" alt="image"/></spoiler>

Что самое приятное - многие тесты, общие для Redis версии и SQL server.
Например, тест на отключение ChangeTrackingManager 
<spoiler title="(способ ускорить работу, если нам не нужно отслеживать изменения в объектах)."><img src="http://habrastorage.org/files/8bd/3ca/718/8bd3ca718ba0454a824bf0b8ab6f2cce.png" alt="image"/></spoiler>

<h5><b>С запросами с фильтрацией(where) данных надо быть очень аккуратными.</b></h5>
Когда мы будем искать что-то по ключу - все просто, выборка по ключу быстрая операция. Когда делается условие where то в реляционную базу отправлялся запрос и where проводилась на базе данных. В бд могли быть индексы и можно было получить быстрый результат, даже на большом объеме данных. В случаи Redis, будет сканирование всех значений, без каких либо индексов. Думаю на клиент выноситься это не будет, но поиск сканирование всех данных, однозначно медленнее поиска по индексу.

<h4><b>Чего нет и не будет?</b></h4>
В EF можно было вызвать Include, чтобы загрузить NavigationPropery. На базе при этом делался join таблицы по внешнему ключу.
<spoiler title="В случаи Key-Value store никаких navigation property быть не может, т.к. relations отсутсвуют в key-value store и нет ни какогот join."><img src="http://habrastorage.org/files/fc6/f80/b7d/fc6f80b7d2014d59a18308f44c29e0ee.png" alt="image"/></spoiler>


<h5><b>Database/Model First подхода тоже не должно быть.</b></h5>
<ul>
	<li>Из InMemory Store вытащить модель данных и сгенерировать на основе классы не возможно т.к. в базе нет схемы или прочей метаинформации, по которой можно восстановить модель данных на C#. 
<img src="http://habrastorage.org/files/93a/72b/5a5/93a72b5a5d2c467ba71136f842073661.png" alt="image"/>
В Redis есть команда <a href="http://redis.io/commands/type">type</a>, но в списке значений которые она возвращает нет ни guid, ни int64... Только строки, list, set, zset, hash. Вопрос как при этом получить какие-то строготипизированные сущности в c#? - только очень странными и не очевидными способами. Можно конечно придумать какие-нибудь conventions, но не очевидно зачем огород городить.</li>
	<li>Model First ?- Model First может и хорошая идея, но базу из нее в нашем случаи не сгенерируешь т.к. генерация базы- это создание схемы, которой в Redis просто нет. А рисовать модель, которую можно просто описать в коде достаточно трудозатратно. Да и кто-то ее на самом деле использовал?</li>
</ul>

<h4><b>Интересные вопросы:</b></h4>
В EF можно через context на прямую вызвать хранимку или произвольный sql код выполнить на mssql server. 
	В Redis встроен <a href="http://redis.io/commands/EVAL">скриптовый движек</a> Lua , хочется понять можно ли его через EF использовать. 
	Можно ли на прямую будет вызвать <a href="http://redis.io/commands">команды</a>, если мы поймем, что генерируемый EF запрос не такой, как должен быть. 
Наверное есть случаи, когда вызов кода Lua через EF был бы разумен, как и команд на прямую. В текущих документах есть информация по этому поводу, но очень размыто в разделе <a href="https://github.com/aspnet/EntityFramework/wiki/Entity-Framework-Design-Meeting-Notes---July-17,-2014#ef7-redis-provider">Query Sorting</a> 
"You can also use the same command to store the result in another data structure that a LUA script could then analyze."
 
<h4><b>Что бы хотелось узнать:</b></h4>
Лично мне хотелось бы узнать 2 основные вещи: 
<ul>
	<li>Насколько % EF версия медленнее, чем обычная StackExchange версия. Понятно, что вопрос сложный и зависит от многих факторов, но хоть какие-то цифры увидеть бы.</li>
	<li>Насколько стабильно работает с кластерной конфигурацией? Т.к. именно работа кластера таких серверов и интересует.</li>
</ul>
Вряд ли мы узнаем это в ближайшее время, ибо до выхода EF еще времени немало. Пока на nuget нет версий даже пакетов от ef7, а раньше перед релизом всегда появлялись всякие alpha,beta,rc.
Да и в <a href="https://github.com/aspnet/EntityFramework/wiki/Entity-Framework-Design-Meeting-Notes">записках архитектурных комитетов</a> тоже не понятно 

Выводы: будем внимательно следить за успехами команды EntityFramework. Может, когда-нибудь появится возможность и другие nosql базы использовать.

P.S. 
В команде EF Иванов Иван Иванович не пользуется уважением.
<spoiler title="В качестве имен используется персонажи из my little ponny...">
<img src="http://habrastorage.org/files/708/5dd/262/7085dd2626004d8b956b418d91e568bb.png" alt="image"/>
<img src="http://habrastorage.org/files/a2a/e12/9f3/a2ae129f339f49f88632650df680680b.png" alt="image"/>
</spoiler>
Исходный текст статьи на <a href="https://github.com/SychevIgor/blog/tree/master/Entityframework7/Redis">github</a>
