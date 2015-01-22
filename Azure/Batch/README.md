<img src="http://habrastorage.org/files/7b4/3d7/4c7/7b43d74c7306424fb942889dcff35a54.png" alt="image"/>
Пару недель назад Microsoft анонсировало для Azure новый сервис <a href="http://azure.microsoft.com/en-us/services/batch/">Azure Batch</a> .
Как всегда в описании любого облачного сервиса куча слов про <b>"large-scale parallel and high performance computing"</b>.
Читая описания проекта в первый раз, сразу возникнет вопрос- а что он делает такого, что не делает уже существующие проекты, ведь можно загрузить бинарник на исполнение уже давно. 

<b>Azure Batch- это windows кластер по запросу, для выполнения операций над большим числом одинаковых, независимых задач.</b>

<habracut text="Чем же Azure Batch отличается от всех остальных схожих сервисов Azure?" />
<h6><b>WebJob </b></h6>
От WebJob этот проект отличается многим:
<ul>
	<li>Во первых WebJob исполняется на тех же инстансах, что и основное приложение. Т.е. это паразитная нагрузка к ним. Batch же использует выделенные машины.Т.к. WebJob исполняется как паразитная нагрузка, он отнимает ресурсы вашего веб приложения. В Batch можно использовать совершенно другие по размерам инстансы чем для основного сайта.</li>
	<li>У WebJob масштаб уровня машины, на которую он был задеплоен. Т.е. перепарсить логи, которые сама же машина сгенерировала. У Batch нет задача перелопатить файлы сгенерированные самим хостом, он обрабатывает данные созданные где угодно в любом количестве.
</li>
<li>Batch- это кластер, а webjob одна машинка.</li>
</ul>
<h6><b>Service Role</b></h6>
Второй кандидат на сравнение- Service Role. Service Role может выполнять любую работу, которыю вы напишите. 
<ol>
	<li>Batch работает по вашему заказу, а ServiceRole постоянно. В этом отличие.</li>
	<li>Чтобы балансировать нагрузку между Service Role придется изобретать велосипед, в Batch вам предоставляют Api и контракт, которые сокращает полет фантазии для велосипедостроения.</li>
</ol>
<h6><b>Виртуальные машины</b></h6>
Третий кандидат на сравнение Виртуальные машины:
Виртуальные машины вы получаете по одной, в случаи Batch вы получаете сразу кластер и управляется кластером, а не одной виртуальной машиной. Т.е. вы копируете ПО 1 раз, а потом только пользуетесь. (Правда есть особенность, виртуальную машину вы можете выбрать из готовых images, либо смонтировать уже свою, а тут ваш выбор ограничен 3 версиями windows.)
В случаи с виртуальными машинами, как и с Service Role любой планировщик вам придется писать самим и городить велописед. 

<h6><b>HDInside(Hadoop)</b></h6>
Далее возникает желание сравнить Batch и HDInside(Hadoop). 
<spoiler title="Некоторых можно просто перечисления связаных с hadoop вещей может напугать">
<img src="http://habrastorage.org/files/a25/f6d/6e0/a25f6d6e0bb74c5387ae280c7b91223b.png" alt="image"/>
<img src="http://habrastorage.org/files/98c/83f/ce0/98c83fce01fc4560b05c442cc6aca2a6.png" alt="image"/>
</spoiler>
Лично мое мнение, что Batch сильно проще, чем Hadoop. В нем нет ни HDFS, Hive, Solar ни кучи других технологий-сервисов.
Простой, чистый windows cluster (набор числодробилок), с минимальным распределением нагрузки и то если потребуется. Простота и каркас для написания планировщика- это единственное, что вообще отличает Batch от ранее созданных сервисов.
Один из авторов на хабре уже писал про Batch в <a href="http://habrahabr.ru/post/242403/">статье </a>и и ему было жаль, что нет dataflow и т.п. Мое мнение- не надо усложнять, чем проще тем лучше и тем ниже порог входа. 

<b>Batch - это промежуточное решение между hdinside(hadoop) и виртуальными машин. Над просто виртуалньными машинами абстракция в виде задач и пула виртуальных машин, но не на столько сложно как в hadoop. </b>
Мое личное мнение, что этот сервис надо было делать еще года 3-4 назад, в самом начале Azure, когда все было на порядок проще, а необходимость была и тогда уже.

<h6><b>Сценарии использования</b></h6>
Сами Microsoft заявляют следующий набор сценариев использования:
<ul>
	<li>Financial risk modeling</li>
	<li>Image rendering and image processing</li>
	<li>Media encoding and transcoding</li>
	<li>Genetic sequence analysis</li>
	<li>Software testing</li>
</ul>
Лично у меня, когда я вижу такой список возник вопрос- те же самые задачи уже ранее были представлены как use case к другим сервисам.
Тестирование- это к visual studio online, видео- это media services. По этому зачем реально вам нужен такой кластер- это исключительно на ваше усмотрение.

<h4><b>Основные концепции:</b></h4>
<ul>
	<li><b>Virtual Machine Pool </b>- набор виртуальных машин с одинаковыми харрактеристиками. Вы не сами инсталируете каждую машину и не конфигурируете, это за вас делает Azure. На данный момент доствпны только Windows образы для виртуальных машин, но есть feature request на linux образы.</li>
	<li><b>Task Virtual Machine</b> - виртуальная машина, входящаяя в пул выделенная для выполнения задач.</li>
	<li><b>Work Item</b>- шаблон операции. Пример- запустить .exe файл на исполнения. По сути это логический контейнер.</li>
	<li><b>Job </b>- экземпляр Work Item запланированный к исполнению. Создается вместе с WorkItem</li>
	<li><b>Task </b>- куски Job, которые выполняются на виртуальной машине.</li>
</ul>

<h6><b>Последовательность шагов выполнения:</b></h6>
<img src="http://habrastorage.org/files/edc/fd5/c0e/edcfd5c0e13e44e09be4c45dc745a861.png" alt="image"/>
<ul>
	<li>Загрузить пакет с бинарными файалами, которые будут выполнять задачу.</li>
	<li>Загрузить файлы с задачами. Они загружаются в Azure Storage Account.</li>
	<li>Создать пулл виртуальных машин.</li>
	<li>Создать Work Item. Job будет создан автоматически.</li>
	<li>Добавить Task к Job.</li>
	<li>Запустить приложение исполнять Task.</li>
	<li>Дождаться окончания работы приложения.</li>
	<li>Выгрузить результирующий файл результатов.</li>
</ul>
<img src="http://habrastorage.org/files/895/b85/2bd/895b852bd5d6472faea242a572ccca2d.png" alt="image"/>

<h6><b>Свой Map Reduce без блэкджека.</b></h6>
Среди примеров работы сервера можно найти вот такой <a href="https://code.msdn.microsoft.com/Azure-Batch-Apps-Samples-dd781172/sourcecode?fileId=128208&pathId=1607913124">пример</a>: 
Лично мне он напоминает такой map-reduce. 
<spoiler title="Создается класс, который умеет разделять весь поток задач на части."><img src="http://habrastorage.org/files/392/a81/539/392a81539aea446790b0d8fa8ab29fb6.png" alt="image"/>
</spoiler>
<spoiler title="а затем уже виртуальные машины получают эти части и выполняют работу."><img src="http://habrastorage.org/files/77f/a82/6b0/77fa826b0ff647cc96ab2ef21695f5fa.png" alt="image"/>
</spoiler>

<h6><b>Rest Api</b></h6>
Как и у всех сервис azure, у Batch есть Rest для управления задач/пулами. <a href="http://msdn.microsoft.com/en-us/library/azure/dn820177.aspx">Документация </a>доступна: 

В Nuget сразу же появились 2 пакета для работы с batch из .net <a href="http://www.nuget.org/packages/Azure.Batch/">первый </a>и <a href="http://www.nuget.org/packages/Microsoft.Azure.Management.Batch/1.1.5-preview">второй</a>.


Обертки для уже существующих приложений, чтобы они могли запускаться в azure batch так-же доступны в nuget <a href="http://www.nuget.org/packages/Microsoft.Azure.Batch.Apps/">тут </a>и <a href="http://www.nuget.org/packages/Microsoft.Azure.Batch.Apps.Cloud/">тут</a>.

<h6><b>Цены:</b></h6>
<a href="http://azure.microsoft.com/en-us/pricing/details/batch/">Цены </a>указаны за час, замер факта использования по минутам, а цены в списке представлены в зависимости от типа запрашиваемого инстанса виртуальной машины.  На сам сервис на время preview действует 50% скидка.
Особенность в том, что эта цена без учета стоимости ресурсов виртуальных машин, на которых это будет работать. И реально надо еще добавить <a href="http://azure.microsoft.com/en-us/pricing/details/cloud-services/">цену виртуальных машин</a>.
 . Суммарно стоимости batch примерно равна использованию базового <a href="http://azure.microsoft.com/en-us/pricing/details/hdinsight">HDInside</a>. 
Так, что по деньгам выигрыша нет в использования batch вместо hdinside или просто набора виртуалок.

<h6><b>Ссылки:</b></h6>
<ul>
<li><a href="http://azure.microsoft.com/en-us/services/batch/">Azure Batch стартовая</a> </li>
<li><a href="http://azure.microsoft.com/en-us/documentation/articles/batch-technical-overview/">Azure Batch техническая информация</a> </li>
	<li><a href="https://social.msdn.microsoft.com/forums/azure/en-US/home?forum=azurebatch">Forum</a></li>
	<li><a href="https://code.msdn.microsoft.com/site/search?f[0].Type=Topic&f[0].Value=Azure%20Batch&f[0].Text=Azure%20Batch">Примеры кода </a></li>
</ul>

Текст статьи доступе на <a href="https://github.com/SychevIgor/blog/tree/master/Azure/Batch">github</a>/
