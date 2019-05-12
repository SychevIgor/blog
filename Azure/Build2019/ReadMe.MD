Буквально на прошлой неделе прошла самая большая конференция Microsoft для разработчиков <a href="https://www.microsoft.com/en-us/build">Build2019</a>. Поехав туда, я преследовал 2 цели.
<ul>
	<li>Первая цель - понять, куда идет Microsoft с точки зрения разработки и какие технологии и подходы продвигает. </li>
	<li>Вторая цель - понять состояние сообщества вокруг Microsoft. Build - публичная конференция - куда лучше дает об этом представление, чем внутренние конференции Microsoft для своих сотрудников. На публичном мероприятии можно делать выводы даже по количеству людей, пришедших на сессию.</li>
</ul>

Для себя я выделил несколько ключевых тем, по которым хочу поделиться мыслями:
<ul>
	<li>.Net Framework Roadmap</li>
	<li>Kubernetes</li>
	<li>ServerLess</li>
	<li>Edge Computing</li>
	<li>Big Data, Machine Learning, Artificial Intelligence </li>
	<li>Windows Presentation Platform </li>
</ul>
<cut />

<h2>.Net Framework Roadmap</h2>
На Build2019 был доклад <a href="https://mybuild.techcommunity.microsoft.com/sessions/77031">.NET Platform Overview and Roadmap</a>. Очень рекомендую посмотреть-прочитать <a href="https://devblogs.microsoft.com/dotnet/introducing-net-5/">Introducing .NET 5</a>, <a href="https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8">C# 8</a> и отдельный доклад по C# 8 - <a href="https://mybuild.techcommunity.microsoft.com/sessions/77032">The Future of C#</a>

<img src="https://devblogs.microsoft.com/dotnet/wp-content/uploads/sites/10/2019/05/dotnet_schedule.png" alt="image"/>

<ul>
	<li>Мои наблюдения с момента анонса .net core 3.0 в следующем: создание .net core/.net standards было очень правильными, но в .net, как и в других платформах, накоплено очень много кода, который нельзя вот так взять и перенести. А значит надо привнести плюшки .net core/standard в старые проекты с минимальной модификацией. <a href="https://github.com/dotnet/winforms">WinForms</a>/<a href="https://github.com/dotnet/wpf">WPF</a> вынесли в opensource, следующий релиз будет уже с .net standard под капотом, и можно будет забыть про старую структуру csproj файлов и получить еще много других бонусов. Вещи безусловно правильные, но вызваны они в том числе тем, что legacy надо тоже поддерживать.</li>
	<li>Хорошо, что для мобильных платформ перестали вспоминать UWP, и остался только Xamarin для C# разработчиков. </li>
	<li>На стенде команды .Net Core я задал вопрос- а какие большие изменения Вы планируете делать в .Net 6-7-8? И будет ли у Вас повод увеличить major версию продукта каждый год? Больше всего мне понравилась часть ответа, которую я перевел-понял как "ну это же vision, а как оно будет дальше- посмотрим. "</li>
<li>По поводу C# 8 у меня остались похожие мысли, как и о всех релизах после async/await, который действительно изменил стиль программирования на C#. А все остальное, было конечно прикольно и добавляли синтаксического сахар, но выглядело достаточно блекло фоне Async/Await. Зато код, становится все менее похож на классический C#. Чтобы вы сказали на такой код, году так в 2012-ом<img src="https://habrastorage.org/webt/cn/sq/fm/cnsqfms0pskaohybsvblrogzt94.png" /></li>
</ul>

А вот, что мне не понравилось на этой сессии, так это настойчивые попытки еще раз подчеркнуть всем .net/C# разработчикам необходимость знать, понимать и на ежедневной основе <b>использовать Machine Learning, Cognitive Services</b> и т.п. 
Безусловно, толковый разработчик должен такие вещи понимать, изучать, по возможности практиковать. Но в 99% случаев, в проекте это не требуется и столь настойчивое евангелизирование, откровенно говоря, начинает надоедать.
Если честно, то я не очень верю в будущее проектов типа Spark.Net, о котором рассказывали в этой сессии. Опыт напоминает, что похожие попытки писать Wrappers на C# или полностю портировать data проект на C# за последние лет 10 заканчивались обычно ни чем т.к. и сообщество меньше и язык сменить не так сложно.

<h2>Service Fabric vs Kubernetes</h2>
3 года в Microsoft и уже почти полгода в EPAM я не могу дать нормального технического объяснения зачем нужен Service Fabric (и вы, при этом, не работаете в Microsoft), если есть Kubernetes. 
<ul>
	<li>Долгое время "толмачи от маркетинга" рассказывали, что это равные платформы, но это не так (гуглится элементарно).</li>
<li>Затем были разговоры, что SF более зрелый для Windows development, а Kubernetes для Linux.</li>
	<li>Ну и заодно, мол, на SF ваши разработчики смогут использовать свои навыки работы в Windows Environment, а в K8s надо изучить Linux и переучиваться. Согласен, legacy код и необходимость переучивать-переучиваться – это серьезный аргумент, а с другой стороны - SF была достаточно сложной, и на мой взгляд ничуть не легче чем K8s. Ну а Linux с одной стороны изучать и знать надо в любом случае. Даже закостенелому “виндузятнику”(коим и я являюсь). А с другой - Kubernetes достаточно сильно от этого абстрагирует.</li>
</ul>
На Build2019 я для себя поставил крест на SF, т.к. по нему был <a href="https://mybuild.techcommunity.microsoft.com/sessions/77069">1 доклад (хотя в названии и было про Mission Critical ***)</a>. 
А по Kubernetes штук 20-30 во всех разрезах (<a href="https://mybuild.techcommunity.microsoft.com/sessions/77059">Fundamentals of Kubernetes on Microsoft Azure and the road ahead (планы развития)</a> и <a href="https://mybuild.techcommunity.microsoft.com/sessions/77799">Serverless Kubernetes, KEDA (event based auto-scaling), and Azure Functions(запуск Azure Functions на Kubernetes)</a>, разработка, облака, devops <a href="https://mybuild.techcommunity.microsoft.com/sessions/77569">YAML CI/CD and Kubernetes Deployments</a> <a href="https://mybuild.techcommunity.microsoft.com/sessions/77060"> тут</a> и <a href="https://mybuild.techcommunity.microsoft.com/sessions/77045">From Zero to DevOps Superhero: The Container Edition(хотя, если вы уже используете AKS и Azure DevOps, то вряд ли что-то новое услышите)</a> а еще <a href="https://mybuild.techcommunity.microsoft.com/sessions/77598">Developer collaboration prototypes for AKS with Dev Spaces</a>. <a href="https://mybuild.techcommunity.microsoft.com/sessions/77061">Enterprise security in the era of containers and Kubernetes</a>). 
На мой взгляд, Microsoft сдались и приняли реальность - SF сообщество, по сути, не адаптировало, с чем я нас с Вами и поздравляю. А вот Kubernetes стал по факту стандартом. 

<h2>ServerLess всем и каждому. </h2>
По-прежнему очень много говорится про ServerLess вычисления. Но если раньше под этот соус заворачивали только Azure Functions и Logic Apps, то сейчас зацепило даже Azure SQL Database ServerLess (когда увидел анонс, очень удивился т.к. уж что-что, а ServerLess SQL – это звучит интересно). 
С другой стороны - Serverless можно запустить не только в Azure, но и локально в контейнере. Таким образом, Serverless становится более понятным и менее волшебным (инженеры обычно не любят волшебство, т. к. не понимают, как оно работает… а если не работает, то, как волшебство починить).

<h3><a href="https://docs.microsoft.com/en-us/azure/sql-database/sql-database-serverless">SQL ServerLess</a></h3>
Суть <a href="https://docs.microsoft.com/en-us/azure/sql-database/sql-database-serverless">SQL Serverless</a> в том, что Вы можете указать нижнюю и верхнюю границу потребляемых ресурсов и платить будете обязательно по нижней границе и плюс то, что потребите между нижней и верхней границей. Мелкую фичу, что можно ставить SQL на паузу (и не платить за compute ресурсы), если база не используется (на 6 часов можно ставить на паузу сейчас), я бы пока не рассматривал, т.к. чтобы пару часов вообще ни одного запроса к базе не было - это очень странная ситуация, ведь есть же хотя бы мониторинг, да и старт у базы (как обещали) будет за 30-60 секунд, что тоже важно.
<img src="https://docs.microsoft.com/en-us/azure/sql-database/media/sql-database-serverless/serverless-billing.png" alt="image"/>

<h2>Edge Computing по подписке или Cloud не только в Microsoft Data Center</h2>
<ul>
	<li>Когда-то давно, в 2008-2010 годах, Microsoft говорил примерно так: «вот вам наши magic Cloud Service, перепишите ваши приложения под них (Web/Worker Role) и будет у Вас счастье». Счастья не получилось, т.к. Legacy все портило. </li>
	<li><s>Потом появились виртуальные машины, но сейчас это не важно.</s></li>
	<li>Затем, когда стало понятно, что даже теперь мало кто может полностью переехать в Cloud, надо все-таки делать Hybrid решения. В начале, под этим подразумевались VPN до Azure. Затем появился Azure Stack (программно-аппаратный комплекс, который по API похож на Azure и можно было на нем держать Production нагрузку, если регулятор не разрешает публиковаться в Public Cloud, а dev/test с анонимизированными данными держать в Public Cloud)</li>
	<li>Потом стали модными и популярными всякие IoT решения (для Microsoft и других больших игроков… а телеметрию-то давно писали). Поначалу в сценарии Connected Factory (Завод/ сборочная линия), предлагали использовать решения из Azure Cloud, но индустрия-таки объяснила, что Latency между их заводом может быть сильно больше допустимого и останавливать сборочную линию из-за “моргнувшего” интернета – это не жизнеспособное решение. </li>
	<li>В итоге, сначала появился Azure IoT Edge, который хоть и скачивался из Azure, но работал и обрабатывал данные на вашем железе (нужен был Docker совместимый хост, который хоть иногда в интернет подключался), но на нем поначалу был совсем скромный набор возможностей.</li>
	<li>Потом, когда IoT Edge показал себя полезным (для потребителей и для финансов Microsoft), стали как грибы появляться сервисы, которые раньше считались Cloud Only. Например, <a href="https://azure.microsoft.com/en-us/blog/a-deep-dive-into-what-s-new-with-azure-cognitive-services/">Cognitive Services</a> пришли на Edge. Визуальный контроль качества продукции на сборочной линии или транспортере делать из локального docker container сильно проще, чем собирать latency до Azure Data Center.</li>
	<li>А вот на Build2019 многие из этих сервисов <a href="https://azure.microsoft.com/en-us/blog/a-deep-dive-into-what-s-new-with-azure-cognitive-services/">вышли в общий доступ или появилась в качестве preview</a> (мне больше всего из preview нравится Speech Services для синтезации речи. Его очень сильно не хватало на устройствах без постоянного интернета), а заодно был анонсирован <a href="https://azure.microsoft.com/en-us/services/sql-database-edge/">SQL Server он Edge</a>. Нет, SQL 2017 уже давно запускался на Linux в Docker, но требовал 3.5 GB памяти. Эта версия оптимизирована в том числе по памяти, для Edge устройств (на них памяти обычно мало).</li>
	<li>Кроме того, начали показывать Hardware на базе Azure Sphere для Secured IoT решений.</li>
	<li>Показали <a href="https://docs.microsoft.com/en-us/azure/databox-online/data-box-edge-overview">Azure Edge compute</a> оборудование, что уже совсем не оставляет сомнений, что тема под пристальным контролем.
<spoiler title="Правда ящик, для миграции данных в Azure мне понравился больше т.к. выглядит по солиднее.">
<img src="https://habrastorage.org/webt/u4/wn/re/u4wnrerxvtzgqkbjzithscu6x_0.jpeg" />
</spoiler></li>
</ul>

<h3>Big Data, Machine Learning, Artificial Intelligence </h3>
Я не самый большой специалист в этих областях, но и писать про них буду с позиции бывшего разработчика (хотя бывших разработчиков не бывает).

Очень часто встречал “интересную” позицию некоторых заказчиков, что IaaS надо делать в Aws, PaaS в Azure и Data в GCP. Нельзя не согласиться, что исторически каждый из провайдеров специализировался на чем-то, но сейчас, если смотреть по-крупному, во многих сервисах паритет достигнут (разница в нюансах, конечно, осталась). Интеграция решений между разными Cloud провайдерами – это, конечно, интересная работа и золотая жила, но как правило, крайне неэффективная для самого заказчика (за исходящий трафик всегда надо платить, а есть же еще latency и complexity/сложность решения).

Наверное, самым перспективным направлением для Microsoft/Azure на ближайшее время с точки зрения новых денег является работа с данными – “привет” Spark/Hadoop/Kafka, Data lakes и еще много интересных сервисов,а заодно с горячи темами (кто-же не любит на хайпе делать продажи) типа Artificial intelligence (Опять нам показывают Кортану, опять нам показывают умные автомобили). Количество анонсов, а главное кейсов (иногда синтетических, а иногда даже показывают счастливого клиента) по использованию Big Data сервисов в Azure на конференции просто зашкаливало. Большинство этих технологий open source, они все community driven и существуют во всех 3 больших провайдеров. Пару лет назад такого активного подхода к Data сервисам я, признаться, не припомню.

<h3><a href="https://mybuild.techcommunity.microsoft.com/sessions/77008">Windows Presentation Platform</a></h3> 
Одна из сессий, которую я бы хотел отметить - это сессия про Windows Presentation Platform (WPP). Если быть честным, я по невнимательности считал, что это про Windows Presentation Foundations (WPF), но зато приятно удивился, что тема была шире, ожидаемой.
Когда-то в далеком 2009 году, когда WPF только появился, была популярна тема: хостинг WinForms controls в WPF приложениях или наоборот - пытаться вставить WPF controls в WinForms. Это все было от того, что взять и махом переписать огромные куски приложения на новый framework было часто невозможно. В первых релизах такие особенности не рекламировали, но когда стало очевидно, что обратную совместимость надо тянуть, то начали очень активно пиарить.
Так вот, в 2019 году обсуждается как хостить Unified Windows Controls в WPF (UWP islands), и как развязать UI components и операционную систему (т. е. поставлять controls/compiler/runtime в качестве nuget packages и не ждать Windows Update. Идея отличная, но делать надо было еще в самой первой версии UWP, т. к. к тому времени команда Entity Framework вынесла EF из состава .net Framework, чтобы перестать зависеть от Windows Updates.)
Для сессии был отведен большой зал, но свободных мест в зале хватало (Разработку под Windows уже лет 10 хоронят), но дело не в этом. Молодых лиц в зале было крайне мало (сравниваю с сессией по Asp.Net Core или тем более Machine Learning). Это лишь мои субъективные наблюдения, я не занимаюсь похоронами разработки под Windows.

<h2>Microsoft Ecosystem для разработчиков</h2>
Работая полевым инженером в Microsoft, я официально поддерживал только то, что сделал сам Microsoft. От такого подхода атрофируются знания всего остального. Сейчас, когда я ушел из Microsoft и стал Solution Architect, стало жизненно важно заполнить этот пробел. А на Build была целая выставка решений партнеров для разработки и разработчиков, где можно было подойти к любому стенду и позадавать вопросы, попросить демку. Я сэкономил недели, посещая эти стенды. 
<ul>
	<li>По-прежнему можно использовать SonarQube для управления техническим долгом (качество кода, а не архитектура конечно-же)</li>
	<li>Есть специализированные решения по DevOps на Kubertenes, которые сильно проще использовать, чем Azure DevOps</li>
	<li>Есть интересные решения типа Aqua(aquasec)/Snyk, по аудиту содержимого docker images и уже запущенных контейнеров.</li>
	<li>Есть интересные решения по мониторингу-трассировке распределенных приложений, у которых есть преимущества перед банальным ELK или Azure Monitor (Application Insights + Log Analytics) типа Signalfx</li>
	<li>Я уже молчу про R# и среду разработки на .net от Jetbrains (Про R# я помнил, но не использовал, т.к. код писал мало и соответственно про среду разработки особо не слышал).</li>
	<li>Было полно всяких решений на базе AI/ML/Data и т.п., но я к ним особо не ходил, т.к. не имею практического опыта в промышленных Big Data решениях и не смогу оценить преимущества.</li>
</ul>
<img src="https://habrastorage.org/webt/nd/5z/1a/nd5z1aq7ip3xb7poe4_cz8ibxbc.jpeg" />

<h3>Анонсы</h3>
Если честно, то лично меня анонсы (<a href="https://news.microsoft.com/2019/05/06/microsoft-introduces-new-cloud-experiences-and-developer-tools-for-all-creators-at-microsoft-build/">тут</a> и <a href="https://blogs.microsoft.com/blog/2019/05/06/10-cool-things-to-check-out-at-microsoft-build-2019/">тут</a>) этого года не впечатлили, и я особо их не запомнил. На квантовых компьютерах хорошо хайпиться, но не заметно, что это технология сегодняшнего дня. А больше ничего толком и не запомнилось. 
<ul>
	<li><s>Ну не о эксперементальной версии Edge(браузер от Microsoft) с движком Chromium же писать и <a href="https://github.com/microsoftedge/msedgeexplainers">доступности его исходных кодов</a>! (о нем <a href="https://blogs.windows.com/windowsexperience/2018/12/06/microsoft-edge-making-the-web-better-through-more-open-source-collaboration/">было известно сильно до Build2019</a>)</s></li>
	<li><a href="https://cloudblogs.microsoft.com/opensource/2019/05/06/announcing-keda-kubernetes-event-driven-autoscaling-containers/">Kubernetes Event–driven Autoscaling (KEDA)</a> вроде не плох, но как-то wow эффекта у меня не вызвало. Хотя идея замечательная.</li>
</ul>

<h2>Послесловие</h2>
<ul>
	<li>Если честно, то я ожидал большего количества представителей не itшных индустрий, т.к. Microsoft давно заявляет, что стремится именно помочь бизнесу с проектами, а не itшникам. Да, конечно, были доклады с участием <a href="https://mybuild.techcommunity.microsoft.com/sessions/77137">Airbus</a>, <a href="https://mybuild.techcommunity.microsoft.com/sessions/77563">BMW</a>… но я ожидал большего количества.</li>
	<li>Я не большой специалист по office365, поэтому решил даже не пробовать рассматривать эту тему.</li>
	<li><b>Все вышесказанное - это мое личное мнение, сделанное на базе моих наблюдений и моего предыдущего опыта. На объективность не претендую. Обсудить можно любой тезис.</b></li>
</ul>