Не так давно в Microsoft Azure появилась новая фича - WebJob, правда, пока в стадии alpha 2.
Основная идея WebJob - дать возможность запускать в Azure задачи по расписанию. Плюс, для .NET кода предоставляется простой API для event driven обработки.
<habracut text="Подробнее зачем это, и чем отличается от уже существующих вариантов..." />
<h4>Решения до WebJob</h4>
Если было действие, которое нужно запускать раз в день то раньше это решалось несколько странно для Cloud Platform:

<h5>Вариант 1:</h5> 
Создать виртуалку, и в Windows Scheduler поставить новую задачу. Этот вариант отлично работает, но в рамках виртуальной машины. Если нужно, например, логи сайта  с WebSite Role сжимать и отправлять куда-нибудь, то виртуалка абсолютно бесполезна. Есть конечно и плюс - нет привязки к Azure.

<h5>Вариант 2: </h5> 
Планировщик <a href="http://www.Windowsazure.com/en-us/services/scheduler/">Windows Azure Scheduler</a>. <a href="http://habrahabr.ru/post/201840/">Пример по русски </a>. Проблема в том, что для его использования надо написать код, который, в общем-то, лично мне кажется не обязательным: все должно быть проще. 
Таким образом, можно запустить  .NET код, но что делать, если логика написана на батниках или на powershell?
Ну и самое важное: сервис предполагается использовать для: 
<ul>
	<li>Invoking a Web Service over HTTP/s</li>
	<li>Post a message to a Windows Azure Storage Queue</li>
</ul>
Такой набор мне кажется очень ограниченным. 

<h5>Вариант 3:</h5> 
Worker Role, которая в активном режиме будет жить и по заложенному вами алгоритму, выполнять действия.  Есть один момент: такой подход совсем не Event Driven. Так, можно запустить .NET код, но что делать, если код опять же на батниках или на powershell? Ну и еще один момент: т.к. Worker Role - это инстанс, за который надо платить, а не отдельно стоящий .exe файл к вашему WebSite Role.


<h4>Что же может предложить WebJob, чего не предлагают все выше перечисленные варианты?</h4>

Запуск exe, bat, sh, <a href="http://blogs.msdn.com/b/nicktrog/archive/2014/01/22/running-powershell-web-jobs-on-azure-websites.aspx ">ps </a>файлов по расписанию или прямо из web-интерфейса. 
<spoiler title="Расписание можно установить достаточно сложное"><img src="http://habrastorage.org/getpro/habr/post_images/374/9aa/96e/3749aa96e693e0af3e2577f5458c2db5.png"/></spoiler>

Для .NET WebJob дополнительно дает API, связывающий ваш код, с внешними источниками событий (очередями, таблицами, блобами). Это Api является не обязательным, но дает плюшку в виде - окна во внешний мир, позволяющее реагировать на события.
 
<spoiler title="Сам список job будет доступен на вкладке сайта:">
<img src="http://habrastorage.org/getpro/habr/post_images/696/102/7fb/6961027fb7e8ba8069a0699c604269bf.jpg"/>
</spoiler>

<h5>Предварительные настройки:</h5>
Запустить все это можно и локально, без деплоя на Azure, но давайте это сделаем по-честному - загрузим в Azure. Для этого нам понадобится:
<ul>
	<li>Создать аккаунт в Azure. Я взял Trial на 30 дней;</li>
	<li>Создать Web Site;</li>
	<li>Создать Storage.</li>
</ul>

<h4>Типы Web Job</h4>
WebJob можно разделить на 3 типа:
<ul>
	<li>On Demand Task — по требованию (ручной запуск: после загрузки появляется кнопка «Запустить»);</li>
	<li>Continuously Running Task — постоянно работающие задачи (после загрузки zip архива стартует автоматически и живет вечно, а .NET код реагирует на появление новых файлов в очереди);</li>
	<li>Scheduled Task — запускаемые по расписанию</li>
</ul>
<spoiler title="Для варианта Scheduled придется сделать дополнительный шаг, а именно согласиться на использование фичи.">
<img src="http://habrastorage.org/getpro/habr/post_images/1a2/9c9/c64/1a29c9c642c946615e8be62a0eabd714.jpg"/>
</spoiler>
Я этого делать не буду, об этом более подробно можно прочесть <a href=" http://www.Windowsazure.com/en-us/documentation/articles/web-sites-create-web-jobs/">тут</a>.

<spoiler title="Загрузим простой powershell скрипт, запакованый в обычный zip архив.">
<img src="http://habrastorage.org/getpro/habr/post_images/de3/e55/9fd/de3e559fd212a3f33e2bceb4e94b0cbf.jpg"/>
</spoiler> 
<spoiler title="Загрузили, запустили. Теперь хочется понять, что этот скрипт сделал-то.">
<img src="http://habrastorage.org/getpro/habr/post_images/d9e/9ce/424/d9e9ce42426642f9342e1d582b4a94e0.jpg"/>
</spoiler>
<spoiler title="Ну, тут уже играет свою роль особенность запуска powershell. Скрипт хоть и упал внутри, но сам powershell.exe завершился вполне корректно.">
<img src="http://habrastorage.org/getpro/habr/post_images/145/c98/2c7/145c982c7a70df3f80ecc0c430512184.jpg"/>
</spoiler>

<h4>Мониторинг</h4>
Типичные решения на Windows, как то: Windows service или задача в Windows scheduler имеют одну общую проблему - никогда не знаешь работают они или нет, пока не глянешь на список процессов. Не раз натыкался на ситуацию, когда сервис умирал, но т.к. его через WebUi не видно, то узнаешь о его падении по косвенным признакам (как всегда - логи, крики пользователей, отвалился функционал в UI). Написание WatchDog - это конечно решение, но надо писать код и проверять, что Watchdog сам по себе работает.

Еще одной проблемой является- а запускался ли он по расписанию? Это можно понять из логов, но их же читать надо.

<spoiler title="WebJob, как и все остальные сервисы Azure, предоставляет какой-никакой, но интерфейс просмотра состояния вашего Webjob и статуса запусков.">
<img src="http://habrastorage.org/getpro/habr/post_images/3ef/125/c15/3ef125c1571c551d80ed44cc620bea9d.jpg"/>
</spoiler>
На этом базовая фича- запуск исполняемого файла по расписанию закончена.

<h4>Привязки через Queue (очереди), Blobs (блобы)</h4>
Рассмотрим самый тривиальный пример:

Через nuget установлены 2 пакета:
<ul>
	<li>Install-Package Microsoft.WindowsAzure.Jobs -Pre;</li>
	<li>Install-Package Microsoft.WindowsAzure.Jobs.Host -Pre.</li>
</ul>
Они за собой еще потянули  Newtonsoft.Json  и Microsoft.WindowsAzure.ConfigurationManager, но это мелочи.
<spoiler title="Перед нами консольное приложение, ничего специфичного в нем нет.">
<img src="http://habrastorage.org/getpro/habr/post_images/0d9/d4f/c73/0d9d4fc73575d2476872c85ba8a6765d.jpg"/>
</spoiler>
В методе main создаем объект JobHost и вызываем метод RunAndBlock().
Больше никакой логики при запуске можно не создавать. Как мы видим, из Main никаких других вызовов, кроме  RunAndBlock нет.
При загрузке в Azure система сама распознает методы, у которых входные параметры размечены атрибутами типа *Input (например, QueueInput) и вызывает эти методы. Т.е. окно во внешний мир за нас уже прорубили. Наша задача — отработать входное сообщение. 

<h5>Как и когда Azure понимает, что нужно вызвать метод?</h5>
Azure дергает метод, когда в соответствующую очередь/таблицу/блоб добавляется новое значение. Получается такой Event Driven стиль. При этом нам не надо заморачиваться с API чтением объектов из blob, queue, table: за нас инфраструктура WebJob сделает это сама. 

Я специально сделал этот пример с одной неточностью, чтобы показать что мы увидим в логах. Выходная строка должна быть out string output – такова специфика.
<spoiler title="Вот так эта ошибка будет видна.">
<img src="http://habrastorage.org/getpro/habr/post_images/7c2/7bd/8a0/7c27bd8a0219dfcbdb9df41473634a85.jpg"/>
</spoiler>
<spoiler title="Теперь исправим код:">
<img src="http://habrastorage.org/getpro/habr/post_images/963/5e6/788/9635e6788a832b25f710fe9109a1c54a.jpg"/>
</spoiler>

Чтобы показать, как он работает:
<ul>
	<li>я установил Azure Storage Explorer. </li>
	<li>Создал 2 очереди: myqueye и myqueuecopy.</li>
</ul>
<spoiler title="Добавим новое сообщение.">
<img src="http://habrastorage.org/getpro/habr/post_images/eec/50b/527/eec50b527d9f2b55cc9b7d3c960d5ea1.jpg"/>
</spoiler>
<spoiler title="И на выходе получим сообщение уже в другой очереди:">
<img src="http://habrastorage.org/getpro/habr/post_images/d00/d54/a83/d00d54a830c4e3f3b17083640b51ba3c.jpg"/>
</spoiler>
<spoiler title="Вот так, будет выглядеть результат корректной отработки ">
<img src="http://habrastorage.org/getpro/habr/post_images/d7a/be7/e38/d7abe7e38c4ff2eba87cd640fe784982.jpg"/>
</spoiler>

<h4>Binding (привязка) параметров</h4>
Хорошая <a href="http://blogs.msdn.com/b/jmstall/archive/2014/01/28/trigger-bindings-and-route-parameters-in-azurejobs.aspx">статья </a>про Binding (привязка) параметров, где подробно рассказано об Input параметрах.

<h5>Из интересного: </h5>
1. Если у метода есть 2 *Input аргумента, то он будет вызван по добавлению нового объекта в первую очередь/блоб/таблицу, а при добавлении во вторую — нет.

2. Можно использовать не только BlobInput и BlobOutput атрибуты, но и механизм, схожий с routing в mvc/webAPI.
<spoiler title="В данном случае мы получаем название blob, и относительно этого уже можем строить какую-то логику.">
<img src="http://habrastorage.org/getpro/habr/post_images/b2f/ee4/403/b2fee4403ce78cc10091f63108b1b58e.jpg"/>
</spoiler>

3. Не только Stream или строка. 
<spoiler title="SDK позволяет десериализовать из входного потока более сложный объект, чем просто stream.">
<img src="http://habrastorage.org/getpro/habr/post_images/1b6/543/7fb/1b65437fba5f073fb84e12281a91285e.jpg"/>
</spoiler> 

<h4>Дополнительные ссылки</h4>
<ul>
	<li>Примеры кода с <a href="http://aspnet.codeplex.com/SourceControl/latest#Samples/AzureWebJobs/">codeplex  </a></li>
	<li><a href="http://curah.microsoft.com/52143/using-the-webjobs-feature-of-Windows-azure-web-sites">Собранние </a>интересных ссылок  </li>
	<li> <a href="http://www.hanselman.com/blog/IntroducingWindowsAzureWebJobs.aspx">Блог </a>Хансельмана </li>
	<li>Анонс на <a href="http://blogs.msdn.com/b/webdev/archive/2014/03/27/announcing-0-2-0-alpha2-preview-of-Windows-azure-webjobs-sdk.aspx">msdn </a></li>
	<li>How to на <a href="http://www.asp.NET/aspnet/overview/developing-apps-with-Windows-azure/getting-started-with-Windows-azure-webjobs">ASP.NET  </a></li>
	<li><a href="http://habrahabr.ru/post/212765/">как хранятся webjob физически. </a></li>
	<li><a href="http://visualstudiogallery.msdn.microsoft.com/f4824551-2660-4afa-aba1-1fcc1673c3d0">Расширение к студии</a>, добавляющее кнопку “сделать из консольника webjob”.</li>
	<li><a href="http://www.bradygaster.com/post/rebuilding-the-sitemonitr-using-Windows-azure-webjobs">человек сделал систему мониторинга сайта на webjob</a>. Хотя я бы ни за что так делать не стал, но как пример кода глянуть стоит.</li>
</ul>

Ссылка на примеры описанные выше на <a href="https://github.com/SychevIgor/blog_webjob">github</a>. Строки подключения к Storage не действительные, они оставлены как образец, чтобы понять как они выглядят.

P.S. Для тех, кто читает Хансельмана или блог  команды asp.net . Я, по сути, повторил то, что сделали они, но добавил, чем это решение отличается от того, что было ранее.

Если Вы хотите помочь улучшить статью- предлогайте ваши правки через <a href="https://github.com/SychevIgor/blog/tree/master/Azure/WebJob">github</a>

