В <a href="https://habr.com/post/435166/">прошлой статье</a> я рассказал про новые экзамены по Azure (Серия AZ: az-103,az-203,az-30*). Теперь можно обсудить подготовку к экзаменам.

В статье я расскажу про 

<ul>
	<li><a href="https://docs.microsoft.com/en-us/learn/">Microsoft Learning</a></li>
	<li><a href="https://openedx.microsoft.com">OpenEDX</a>/<a href="https://cloudsociety.fastlane.live/courses">CloudSociety.learning</a></li>
	<li><a href="https://docs.microsoft.com/en-us/azure/architecture/">Azure Architecture Center</a></li>
	<li><a href="https://www.pluralsight.com">Pluralsight (RoleIQ и курсы)</a></li>
<li>Рекомендованный мною путь изучения-сдачи экзаменов-сертификации</li>
</ul>
<b>И некоторые другие ресурсы.</b>
<cut />
<spoiler title="Предположения:">
<ol>
	<li>В статье я не буду касаться вопросов типа <b>«А зачем вообще сдавать?»</b> </li>
	<li>В статье будет <b>мое личное мнение</b> про подготовку к экзамену, оно может отличаться от вашего мнения или, тем более, мнения Microsoft.</li>
	<li>В статье будут освещены<b> только англоязычные ресурсы</b>
<ul>
	<li>во-первых, русскоязычных просто нет. Личные блоги не дадут вам нужной картины.</li>
	<li>во-вторых, только англоязычные ресурсы являются источником правды (source of truth). В общении с поддержкой бесполезно ссылаться на русскоязычную версию, даже если кто-то из сотрудников Microsoft типа Cloud Solution Architect прислал ссылку на русскоязычную статью. </li>
	<li>в-третьих, в теории сдавать экзамен на русском можно, но что-то мне подсказывает, что эти версии сильно сложнее для понимания.</li>
</ul> </li>	
	<li><b>Минимальный уровень знаний по Azure у вас есть</b>, т.к. сертифицироваться, не имея опыта - это очень плохая идея. Сертификат – это все-таки подтверждение квалификации.</li>
	<li>Подготовка к экзаменам по<b> Data&AI</b> в статье <b>затронута не будет</b>, т.к. экзамены все равно скоро изменятся, а готовиться к “войнам прошлого” – так себе идея.</li>
	<li>Подготовку к экзамену <b>Az-400</b> (DevOps), я также <b>не затрону</b>, т.к. не сдавал и не готовился. Да и без этого экзамена контента будет достаточно.</li>
</ol>
</spoiler>
<h2><a href="https://docs.microsoft.com/en-us/learn/">Microsoft Learning</a></h2>
Первым ресурсом, на который нужно обратить свое внимание, будет <a href="https://docs.microsoft.com/en-us/learn/">Microsoft Learning</a>. Этот ресурс, который можно использовать для изучения Azure с нуля, при этом выбрав свою роль (разработчик, архитектор, админ). 
 
Тут много относительно небольших кусочков, которые можно изучать по 30-60 минут в день в течение 1-3 месяцев, охватив при этом очень широкий пласт материала. 

<img src="https://habrastorage.org/webt/f1/oa/fj/f1oafj1q1dy8e6e4kcb07qg3c1e.png" />

Безусловно, про 1-3 месяца – это совсем с нуля. Если вы уже последние пару лет работаете с Azure, то этот ресурс стоит очень быстро просмотреть, найти пробелы в своих знаниях и перейти к подготовке к сдаче экзамена.

<h2><b><a href="https://openedx.microsoft.com/">OpenEDX</a>/<a href="https://cloudsociety.fastlane.live/courses">CloudSociety.learning</a></b></h2>
<b>Тут есть курсы для каждого раздела, перечисленного в описании экзамена. Это такая выжимка, brain dump, который надо обязательно знать для сдачи экзаменов. </b>

<img src="https://habrastorage.org/webt/yb/g2/3c/ybg23cfqb_aqqsr3hfdtvobp8ve.png" />

Вы записываетесь на курс (enroll), читаете контент, делаете небольшие тестовые задания самостоятельно и в конце сдаете небольшой тест. Я не готов гарантировать, что, выучив текст всех модулей, Вы сдадите экзамен, но если Вы уже знаете Azure, то этот ресурс очень помогает сократить время подготовки.

На мой субъективный взгляд, курсы с OpenEDX/CloudSociety максимально близки к тому, что спрашивают в экзаменах серии AZ и при этому бесплатные. 

Приведу здесь список курсов для подготовки к экзаменам. (Чтобы попасть на openedx версию, просто замените в URL “cloudsociety.learning” на “openedx” или наоборот).
<b>У тренингов выходят обновления, по этому рекомендую ссылки перепроверять самостоятельно перед началом обучения т.к. на момент первой публикации актуальной версией была 2018_T3, а на момент редактирования уже 2019_T1</b>
<spoiler title="AZ-103 (отдельных курсов по az-103 я не нашел, но можно переиспользовать az-100/az-101)">
<ol>
	<li><a href="https://openedx.microsoft.com/courses/course-v1:Microsoft+AZ-100.1+2019_T1/info">Manage Subscriptions and Resources</a>  </li>
	<li><a href="https://openedx.microsoft.com/courses/course-v1:Microsoft+AZ-100.2+2019_T1/info">Implementing and Managing Storage</a>  </li>
	<li><a href="https://openedx.microsoft.com/courses/course-v1:Microsoft+AZ-100.3+2019_T1/info">Deploying and Managing Virtual Machines</a>  </li>
	<li><a href="https://openedx.microsoft.com/courses/course-v1:Microsoft+AZ-100.4+2019_T1/info">Configuring and Managing Virtual Networks</a>  </li>
	<li><a href="https://openedx.microsoft.com/courses/course-v1:Microsoft+AZ-100.5+2019_T1/info">Managing Identities</a>  </li>
</ol>
<ol>
	<li><a href="https://openedx.microsoft.com/courses/course-v1:Microsoft+AZ-101.3+2019_T1/info">Implement Advanced Virtual Networking</a></li>
	<li><a href="https://openedx.microsoft.com/courses/course-v1:Microsoft+AZ-101.4+2019_T1/info">Securing Identities</a></li>
</ol>
</spoiler>
<spoiler title="AZ-203 (отдельных курсов по az-203 я не нашел, но можно переиспользовать az-200/az-201)">
<ul>
	<li><a href="https://cloudsociety.learning.microsoft.com/courses/course-v1:Microsoft+AZ-200.1+2018_T3/info">Select the appropriate Azure technology development solution</a></li>
	<li><a href="https://cloudsociety.learning.microsoft.com/courses/course-v1:Microsoft+AZ-200.2+2018_T3/info">Develop for Azure storage</a></li>
	<li><a href="https://cloudsociety.learning.microsoft.com/courses/course-v1:Microsoft+AZ-200.3+2018_T3/info">Develop Azure Platform as a Service solutions</a></li>
	<li><a href="https://cloudsociety.learning.microsoft.com/courses/course-v1:Microsoft+AZ-200.4+2018_T3/info">Implement security in Azure development solutions</a></li>
	<li><a href="https://cloudsociety.learning.microsoft.com/courses/course-v1:Microsoft+AZ-201.1+2018_T3/info">Develop for an Azure cloud model</a>   (частично)</li>
	<li><a href="https://cloudsociety.learning.microsoft.com/courses/course-v1:Microsoft+AZ-201.2+2018_T3/info">Implement Azure development integration solutions</a></li>
</ul>
</spoiler>
<spoiler title="AZ-300">
<ol>
	<li><a href="https://openedx.microsoft.com/courses/course-v1:Microsoft+AZ-300.1+2019_T1/info">Deploying and Configuring Infrastructure</a>  </li>
	<li><a href="https://openedx.microsoft.com/courses/course-v1:Microsoft+AZ-300.2+2019_T1/info">Implementing Workloads and Security</a>  </li>
	<li><a href="https://openedx.microsoft.com/courses/course-v1:Microsoft+AZ-300.3+2019_T1/info">Understanding Cloud Architect Technology Solutions</a> </li>
	<li><a href="https://openedx.microsoft.com/courses/course-v1:Microsoft+AZ-300.4+2019_T1/info">Creating and Deploying Apps</a>  </li>
	<li><a href="https://openedx.microsoft.com/courses/course-v1:Microsoft+AZ-300.5+2019_T1/info">Implementing Authentication and Secure Data</a>  </li>
	<li><a href="https://openedx.microsoft.com/courses/course-v1:Microsoft+AZ-300.6+2019_T1/info">Developing for the Cloud</a></li>
</ol>
</spoiler>
<spoiler title="AZ-301">
<ol>
	<li><a href="https://openedx.microsoft.com/courses/course-v1:Microsoft+AZ-301.1+2019_T1/info">Designing for Identity and Security</a>  </li>
	<li><a href="https://openedx.microsoft.com/courses/course-v1:Microsoft+AZ-301.2+2019_T1/info">Designing a Data Platform Solution</a>  </li>
	<li><a href="https://openedx.microsoft.com/courses/course-v1:Microsoft+AZ-301.3+2019_T1/info">Designing for Deployment, Migration, and Integration</a>  </li>
	<li><a href="https://openedx.microsoft.com/courses/course-v1:Microsoft+AZ-301.4+2019_T1/info">Designing an Infrastructure Strategy </a></li>
</ol>
</spoiler>
<spoiler title="Зачем Microsoft 2 площадки на одном движке мне решительно не понятно">
Ведь почти все курсы на 2 ресурсах одновременно. И контент одинаковый, и вопросы-ответы и даже порядок следования вопросов. Найдите отличия! 

<img src="https://habrastorage.org/webt/dz/m7/0b/dzm70b8tzs2oywh1t-aoz-1ivk4.png" />

Я ожидал, судя по тому, что <a href="https://blogs.msdn.microsoft.com/wriju/2018/12/20/free-trainings-for-azure-certifications-az/">статья</a> про CloudSociety Learning появилась 20 декабря, то, предположительно, развивать будут CloudSociety, а не openedx. Но сейчас  в январе 2019 почему-то ссылки на cloud society на домене microsoft.com стали перенаправляться на внешний домен. При этом в Microsoft, <b>менеджер, отвественный за обучение partners</b>, мне не смог ответить, а сам <b>дает ссылки на OpenEDX</b>.

<ul>
	<li>Я нашел у openedx всего один плюс: Microsoft генерирует сертификаты о прохождении курсов бесплатно. На edx нужно заплатить 99$ за каждый, а на CloudSociety вообще сертификатов нет (по состоянию на 5 января). <img src="https://habrastorage.org/webt/pa/mu/tz/pamutz3cxprw-vhuxslcnn87ri8.png" />Выглядит сертификат солидно, с подписью самого-самого, правда непонятно насколько эти сертификаты имеют ценность.</li>
	<li>Хотя есть и минус: на openedx курсов не видно в поиске - на них можно попасть только по прямым ссылкам. Возможно, это означает, что этот ресурс уже не целевой, но тогда возникает вопрос: «а зачем нужно было заводить новый ресурс на том же движке, заливать туда контент и рекламировать его в блоге?» Если кто-то знает ответ, то поделитесь этой тайной.</li>
</ul> 
</spoiler>
Но есть и некоторые недостатки у OpenEDX/CloudSociety:
<ul>
	<li>Нет настоящих лабораторных работ (ссылка на инструкцию в официальной документации - это несерьезно).</li>
	<li>Половина разделов - видео с channel9/youtube, и бывает, что интерфейс уже немного поменялся, а в случае с некоторыми разделами по AAD - даже портал уже поменялся.</li>
</ul>
<h2><a href="https://www.edx.org/">EDX</a></h2>
<b><a href="https://www.edx.org/">EDX</a></b>- всем известная платформа: на ней очень много различных курсов от ведущих университетов. Там собраны, в том числе, и курсы от <a href="https://www.edx.org/course?search_query=azure">Microsoft по Azure</a> 
Чем глобально отличается <b>EDX </b>от Cloud Society понятно - это <b>внешняя относительно Microsoft площадка</b>, и присутствие на ней для Microsoft обязательно, т.к. это и демонстрация флага (много других хороших курсов, и мы должны быть там), и “торговля на красных линиях” (может кто-то будет, проходя мимо, и наши курсы изучать, даже если не очень-то и хотелось). 

<spoiler title="Но с этой площадкой в декабре 2018 году наступила проблема, которая поделила EDX на ноль, лично для меня">
Все практические тесты стали платными, т.е. за 99$. 

<img src="https://habrastorage.org/webt/u8/tn/qr/u8tnqrvj21sjjoay0c_ocfip1m8.png" />

А прогресс по курсу буквально через месяц будет удален, если курс не оплачен, даже если курс длится 3 месяца. 

<img src="https://habrastorage.org/webt/tm/c1/bw/tmc1bwd_hclbalkxsk7japhybpi.png" />

Я понимаю, что <a href="https://blog.edx.org/updates-platform-achieving-long-term-sustainability?track=blog">компании нужны деньги</a>, но без тестов подготовка к Azure экзаменам имеет мало смысла, а с ними – это минимум в пару тысяч долларов влетит. И если верить <a href="https://blog.edx.org/updates-platform-achieving-long-term-sustainability?track=blog">анонсированному еще весной 2018 подходу</a>, вряд ли тесты сделают снова бесплатными. Я, естественно, блог EDX не читаю, поэтому об изменениях я узнал сначала через вот такое сообщение на портале, которое меня сильно удивило.  

Стало как-то неприятно, но зато понятно, почему Microsoft нужен собственный ресурс. На мой взгляд, <b>Microsoft не может полагаться в столь важном процессе, как обучение, на добрую волю внешней компании</b>, на которую они никак не влияют. Поэтому нужен собственный ресурс, который, если что, ее заменит и которому не нужно будет зарабатывать деньги. Но это лишь мое мнение.
</spoiler>
<h2><b><a href="https://academy.microsoft.com/en-us/professional-program/">Microsoft Professional Program</a></b></h2>
Есть такая программа <a href="https://academy.microsoft.com/en-us/professional-program/">MPP </a>(которая приходит на смену Microsoft Virtual Academy и многим другим ресурсам для обучения), в рамках которой вы можете пройти трек, в который входят несколько курсов 9-12 на edx, и получить один общий сертификат, что этот трек вы окончили (сдали зачеты, лабы и т.п.)

<spoiler title="Все курсы из MPP хостятся на платформе EDX, в связи с чем в 2019 году появилась проблема: ">
Пройти тесты к курсам можно только за деньги, без них на MPP сайте курс не будет отмечен как завершенный. В итоге, общий сертификат MPP можно получить, только заплатив за каждый курс по 99$. Я надеюсь, что Microsoft сможет перенести информацию о прохождении по курсам с EDX на свою платформу Cloud Society без потери прогресса, иначе это дискредитирует MPP программу. 
</spoiler>
В контексте сдачи экзаменов по Azure для нас интересен трек <a href="https://academy.microsoft.com/en-us/professional-program/tracks/cloud-administration/">Cloud Administration track</a> в первую очередь, т.к. в него входят следующие курсы:

<ul>
	<li>Microsoft Professional Orientation: Cloud Administration</li>
	<li>Microsoft Azure Virtual Machines</li>
	<li>Microsoft Azure Virtual Networks</li>
	<li>Microsoft Azure Identity</li>
	<li>Microsoft Azure Storage</li>
	<li>Microsoft Azure App Service</li>
	<li>Databases in Azure</li>
	<li>Azure Security and Compliance</li>
	<li>Automating Azure Workloads</li>
	<li>Migrating Workloads to Azure</li>
</ul>
<b>Эти же курсы можно найти и на Cloud Society. </b>Курсы из этой программы не соотносятся с экзаменами по Azure, потому что они сильно проще, но можно начать изучать Azure и готовиться к экзамену AZ-103 именно с нее. 

<b>Кроме тестов есть еще и лабораторные работы в реальном облаке. Настоятельно рекомендую их сделать, т.к. в экзаменах серии AZ тоже есть лабораторные работы, в которых нужно что-то опубликовать, что-то починить в реальном облаке. Практический опыт бесценен при сдаче az-103</b>.

Я бы использовал эту программу как минимальный допуск к работе с Azure в компании. Осилил - получи доступ, не осилил - извините, но нужны дополнительные испытания. Курс несложный, я бы даже сказал, подойдет для студентов второго курса (которые уже научились сами материал изучать, как в старшей школе, а не как в средней - преподаватель все темы расскажет, главное - прилежно посещать).

<b><a href="https://academy.microsoft.com/en-us/professional-program/tracks/internet-of-things/">Azure IoT</a> я бы очень рекомендовал, как трек для подготовки к архитектурному экзамену.</b> Хоть этот трек слабее, чем курсы по Big Data, но в нем все равно есть 4 курса, которые стоит посмотреть:
<ul>
	<li>Getting Started with the Internet of Things (IoT)</li>
	<li>IoT Data Analytics and Storage</li>
	<li>IoT Architecture Design and Business Planning</li>
	<li>Business Intelligence for IoT Solutions</li>
	<li>Они покрывают как Azure Iot Reference Architecture, пример - RFP (request for proposal) для IoT решения, так и обзоры сервисов типа PowerBi, Time Series, Hot/Cold storage, Event/IoT hubs. </li>
</ul>
Можно еще по изучать треки <a href="https://academy.microsoft.com/en-us/professional-program/tracks/devops/">DevOps </a>, <a href="https://academy.microsoft.com/en-us/professional-program/tracks/big-data/">Big Data</a>, но это уже вне заявленной темы.

<h2><a href="https://app.pluralsight.com/roleiq">Pluralsight RoleIQ</a></h2>
Можно бесплатно пройти тестирование на знание Azure по 3 направлениям: архитектура, разработка, инфраструктура и на выходе получить некоторую оценку 0-300 своих знаний. Каждая роль состоит из нескольких тестирований 6-9, что позволяет комплексно посмотреть на свои знания. (Нужно создать учетную запись, карту привязывать не нужно, free trial начинать тоже не обязательно. Тесты доступны и без этого). Пример по архитектуре 

<img src="https://habrastorage.org/webt/dq/0o/c3/dq0oc3ubkk7ppqnelwjf6-xb9nq.png" />

На мой взгляд, это хороший <b>качественные </b>тесты (<b>есть качественный, а есть количественные метод, который даст значение</b>), чтобы оценить свои знания. 

<spoiler title="Численные оценки для меня мало что значили, т.к. с формулировкой многих вопросов я был не согласен, как и с ответами. ">

<ul>
	<li>Самыми простыми примерами можно считать вопросы типа: "На каком blade вы можете найти данные метрик" и дальше 4 варианта выбора. С учетом того, что портал быстро меняется, и названия вкладок я лично не запоминаю, этот вопрос с точки зрения тестирования не корректен.</li>
	<li>Или задание: "выберите правильный метод, чтобы удалить сообщение из очереди". Здравый смысл меня в нем подвел, т.к. я выбрал <b>queue.Dequeue</b> вместо правильного <b>queue.DequeueMessage</b>. На мой взгляд, такие вопросы очень странные, ведь это всегда подскажет Auto-complete в любой IDE. </li>
	<li>Ну или вопрос: "Назовите наиболее используемые состояния подключения к ресурсу, в паттерне <a href="https://docs.microsoft.com/en-us/azure/architecture/patterns/circuit-breaker">circuit-breaker</a> в популярной имплементации". Как бы сказать: "часто используемые и популярные имплементации" - это прям «точный» вопрос. Осталось померить популярность и частоту использования состояний.</li>
</ul>
</spoiler>
На каждый вопрос дается <b>ограничение по времени</b>, в зависимости от длины текста вопроса + всех вариантов ответов. Но если вы хотите хакнуть систему, то будет тяжело, т.к. времени дается не много. 

При всем этом <b>оценка нелинейная</b>, т.е. сдал 17 из 20 вопросов - получишь 255 из 300. Зависит это от сложности заданий и в какой момент ты ошибся. Лично мне такая система немного не понятна (получается, если ты ошибся в начале - это плохо, а если ближе к концу - менее страшно), но <b>качественный результат дает.</b>

<img src="https://habrastorage.org/webt/gz/eo/8n/gzeo8nexhvycw9swo1yhqe0ce8m.png" />

<s>Кстати, можно потешить свое самолюбие, т.к. в конце каждого теста дают не только оценку, но и процент людей, который сдал лучше тебя. Приятно бывает видеть, что лучше тебя сдало 1-3%.</s>
 
Я вижу этот тест, как способ разделить массу желающих обучаться на несколько групп по их исходным навыкам. 

<ul>
	<li>Если человек сдал в среднем на 200-250, то ему делать нечего на обучении. </li>
	<li>Если на 100 - ему явно в группу начинающих.</li>
</ul>
После прохождения теста Вам порекомендуют курсы, которые закрывают пробелы в знаниях, но эти курсы уже за деньги.

<h2>Pluralsight курсы</h2>
В 2019 появились пути (path) по подготовке непосредственно к экзаменам серии AZ.
<ul>
	<li>AZ-103 комбинируем из <a href="https://www.pluralsight.com/paths/microsoft-azure-infrastructure-and deployment-az-100">az-100</a> и <a href="https://www.pluralsight.com/paths/microsoft-azure-integration-and-security-az-101">az-101</a></li>
	<li><a href="https://www.pluralsight.com/paths/developing-solutions-for-microsoft-azure-az-203">az-203</a></li>
	<li><a href="https://www.pluralsight.com/paths/microsoft-azure-architect-technologies-az-300">az-300</a></li>
	<li><a href="https://www.pluralsight.com/paths/microsoft-azure-architect-design-az-301">az-301</a></li>
</ul>
В чем path отличается от курса по подготовке? Судя по датам (часть курсов сделаны в августе, еще до анонса новых экзаменов)<b>, контент был изначально сделан не под эти экзамены, а лишь после объявления новых испытаний из курсов были сформированы пути, покрывающие темы из экзамена. </b>

К сожалению, ничего не могу сказать про релевантность этих курсов самим экзаменам. Они вышли недавно, объем контента там огромный, а у меня еще и подписки платной сейчас нет. 

Но еще раз повторюсь: выглядит очень близко к тому, что описано на страницах с экзаменами.

<h2>Linuxacademyкурсы</h2>
Курсы на этом ресурсе появились позже, чем на остальных, но тоже можно их рассмотреть
<ul>
	<li><a href="https://linuxacademy.com/azure/training/course/name/microsoft-azure-infrastructure-and-deployment-exam-az-100">az-100 admins</a>(сам az-100 уже устарел, но этот курс покрывает большую нового экзамена az-103)</li>
	<li><a href="https://linuxacademy.com/azure/training/course/name/microsoft-certified-azure-developer-exam-203-prep">az-203 dev</a></li>
	<li><a href="https://linuxacademy.com/azure/training/course/name/az-300-exam-preparation-microsoft-azure-architect-technologies">az-300 arch</a></li>
</ul>

<h2>Курсы для Microsoft Partners</h2>
Microsoft для своих Partners делает study groups. Это серия видео курсов, по часу на модуль (для az-203 их 6 штук), и набор ссылок к ним. Можно саму зарегистрироваться и посмотреть, если вы знаете свой MCP ID и MS Partner ID (MPID)
<ul>
<li><a href="https://msuspartner.eventbuilder.com/?landingpageid=3RUCnG">AZ-203</a></li>
<li><a href="https://msuspartner.eventbuilder.com/?landingpageid=KDP2WO">AZ-101</a></li>
</ul>
<s>Наверное есть еще, но я не искал для других курсов.</s>

К ним же прилагается серия лабораторных работ на github
<ul>
<li>По Az-103 лабораторных в марте 2019 еще не было, но можно взять <a href="https://github.com/MicrosoftLearning/AZ-100-MicrosoftAzureInfrastructureDeployment">AZ-100</a>, <a href="https://github.com/MicrosoftLearning/AZ-101-MicrosoftAzureIntegrationandSecurity">AZ-101</a></li>
	<li><a href="https://github.com/MicrosoftLearning/AZ-300-MicrosoftAzureArchitectTechnologies">AZ-300</a></li>
	<li><a href="https://github.com/MicrosoftLearning/AZ-301-MicrosoftAzureArchitectDesign">AZ-301</a></li>	
</ul>
И еще одна серия от менеджера из Microsoft, который отвечает за обучение партнеров
<ul>
	<li><a href="https://github.com/JazzyWagdaddy/AzureStudyGroups-AZ-101">AZ-101</a></li>
	<li><a href="https://github.com/JazzyWagdaddy/AzureStudyGroups-AZ-203">AZ-203</a></li>
	<li><a href="https://github.com/JazzyWagdaddy/AzureStudyGroups-AZ-301">AZ-301</a></li></ul>

<h2><a href="https://github.com/Microsoft/MCW">Microsoft Cloud Workshop Project</a></h2>
Microsoft опубликовала на github серию Cloud Workshops, в которых можно взять HandOnLabs и по ним сделать предложенные практические упражнения. Т.к. все экзамены, серии AZ, заявлены как Experience based, то практический опыт- безценен.
<ul>
	<li><a href="https://github.com/Microsoft/MCW-Serverless-Architecture">Serverless-Architecture</a></li>
	<li><a href="https://github.com/Microsoft/MCW-Big-Compute">Big-Compute</a></li>
	<li><a href="https://github.com/Microsoft/MCW-Lift-and-shift-Azure-Resource-Manager">Lift-and-shift-Azure-Resource-Manager</a></li>
	<li><a href="https://github.com/Microsoft/MCW-App-modernization">App-modernization</a></li>
	<li><a href="https://github.com/Microsoft/MCW-Containers-and-DevOps">Containers-and-DevOps</a></li>
	<li><a href="https://github.com/Microsoft/MCW-Continuous-delivery-in-Azure-DevOps">Continuous-delivery-in-Azure-DevOps</a></li>
	<li><a href="https://github.com/Microsoft/MCW-Securing-PaaS">Securing-PaaS</a></li>
</ul>
И еще много других полезных лабораторных работ. 
Я не предлагаю перемолотить все практические работы, особенно если учесть, что они отвязаны от самих экзаменов серии AZ. Но эти Handsonlabs дадут Вам практический опыт. А уже будите ли Вы использовать этот контент или нет - Ваша воля.

<h2><a href="https://docs.microsoft.com/en-us/azure/architecture/">Azure Architecture Center</a></h2>
Хороший ресурс, созданный командой <a href="https://github.com/mspnp">Patterns and Practices</a>, который при очень большом желании можно осилить за день (прочесть все статьи). 
Есть еще нишевые примеры, такие как <a href="https://docs.microsoft.com/en-us/gaming/azure/reference-architectures/general-guidelines">Architecture for Gaming</a>.
<ul>
	<li>Можно разобраться с <b>паттернами</b>, которые выделила pnp команд (не скажу, что ракетные технологии, но так и в GangOf4 тоже не про космос пишут). Например, <a href="https://docs.microsoft.com/en-us/azure/architecture/patterns/competing-consumers">competing-consumers</a>. Эти паттерны встречаются в курсах AZ-300, и, возможно, встречаются в экзаменах.</li>
	<li>Почитать <b>Checklists </b>по разным направлениям. Например, <b>Resiliency/Scalability</b> checklist (тоже не квантовая хромодинамика, но чеклисты и не для этого создаются, а чтобы не пропустить чего случайно)</li>
	<li>Можно посмотреть простенькие <b><a href="https://docs.microsoft.com/en-us/azure/architecture/reference-architectures/data/stream-processing-stream-analytics">reference architecture</a></b><img src="https://habrastorage.org/webt/bi/xe/gc/bixegc3wbzv1clksxql4wgigynm.png" /></li>
	<li>Ну и много чего еще интересного.</li>
</ul>
Этот ресурс будет <b>полезно почитать</b> не только тем, кто собирается быть облачным <b>архитектором</b>, но и <b>разработчикам</b>, т.к. это им эти шаблоны реализовывать, а заодно и <b>itpro </b>некоторые вещи будут интересными, как например, <a href="https://docs.microsoft.com/en-us/azure/architecture/cloud-adoption/business-strategy/cloud-migration-business-case#dispelling-cloud-migration-myths">мифы про миграцию в Cloud</a>.

<h2><a href="https://docs.microsoft.com/en-us/azure/">Официальная документация</a></h2>
Это <b>отличное место для изучения</b>, т.к. только оно является официальным источником правды.

Можно часами и даже целыми днями читать, смотреть, даже пытаться повторить то, что показано в документации. Я вижу 3 проблемы:

<ol>
	<li>Отсутствие лабораторных работ. Это огромный минус, т.к. у многих людей «мышечная» память лучше, чем визуальная.</li>
	<li>Местами устаревшая документация (или, по крайней мере, скриншоты). Документация огромна. К примеру, когда я последний раз проверял, в ней было 9000 картинок, на которые совсем не было ссылок в документации. Правда, тех, на которые были ссылки, было тысяч 50, но многие нуждались в обновлении. С текстом -тоже самое.</li>
	<li>Иногда в документации просто нет ответов на нужные вопросы и единственный способ найти решение - сделать, попробовав все варианты.</li>
</ol>
Но все эти 3 проблемы, все равно не перевешивают факта, что <b>документация - главный источник теоретических знаний</b>.

<h2><a href="https://channel9.msdn.com/">Channel9</a></h2>
<b>Channel9 - это не ресурс для изучения Azure.</b> В лучшем случае, это место, где можно получить нотификацию о существовании новой фичи, но детали только на практике и в документации. Поэтому лично я качаю видео выборочно перед командировкой, чтобы посмотреть в самолете. Благо, за месяц их обычно штук 5-6 по 10 минут появляется.

<h2><a href="https://azure.microsoft.com/en-us/blog/">Azure Blog</a></h2>
Этот ресурс лучше и детальнее чем Channel9, но близок к нему по своей сути и подходит для получения нотификаций о новых фичах. Иногда там есть технические детали, которые потом невозможно отыскать даже в документации (что у меня вызывает недоумение), но найти такие моменты - это как поиск иголок в стоге сена. Поэтому, я вычеркнул для себя этот источник.

<h2><a href="https://github.com/azure-samples/">Github repositories</a></h2>
Есть очень много samples на github. <a href="https://github.com/azure-samples/">Например</a>, тут примеры неплохие, их очень много наделали для всех сервисов, и они обычно достаточно хорошо покрывают потребности разработчиков/архитекторов. Я бы не назвал github ресурсом для подготовки к экзаменам, т.к. там нет ничего специфичного для экзаменов серии AZ. Но как место, где можно посмотреть примеры кода по заявленным темам экзамена- вполне.

Одна беда: поддержка этих примеров почти нулевая. Я открывал issues/pull requests и считал везением, если за месяц был хотя бы ответ. Новые фичи через issue ни разу не добавляли. А вот pull request в некоторых случаях принимали, но не всегда. При этом, я был не каким-то no name user, а сотрудником компании, но это вообще никак не влияло.

<h2><b><a href="https://customers.microsoft.com/en-us/search">Azure User stories</a></b> </h2>
Microsoft любит публиковать маркетинговые материалы. Из них можно узнать некоторые примеры, как клиенты используют Azure. Это не сильно поможет при сдаче экзамена, но, по крайней мере, вы сможете сформировать картину мира. Начать можно с этой ссылки 

Также есть и несколько более <a href="https://microsoft.github.io/techcasestudies">техническая информация</a>, где постятся интересные примеры с хакатонов. Мне этот ресурс очень понравился, т.к. там обычно есть и визуальная картинка, как это выглядит с точки зрения архитектуры (что с чем связано) и объяснение зачем. Вот пара примеров таких кейсов:

<ul>
	<li>У человека была <a href="https://microsoft.github.io/techcasestudies/iot/2017/03/09/plasmd.html">травма в опорно-двигательном аппарате</a>. Восстанавливаться долго, а мест в специализированных центрах мало. Идея - давайте выписывать быстрее, чтобы больше людей оборачивалось, а человеку домой поставим <a href="https://customers.microsoft.com/en-us/story/inail">Kinect </a>подключенный к интернету. Если человек двигается - хорошо, врач может глянуть как часто и правильно ли. Если наоборот не пользуется - принять меры. 

<img src="https://habrastorage.org/webt/gq/ma/3b/gqma3bspnlfbh1inlhakrdhk96a.jpeg" /></li>
	<li>Или дорожные рабочие/механики/слесари у которых руки заняты, но можно голосом <a href="https://microsoft.github.io/techcasestudies/bot%20framework/2017/06/19/Powel.html">спросить бота</a> “когда и кто ремонтировал этот участок дороги” или «есть ли деталь на складе». Если телефон на каске закреплен, то можно сказать: «сделай фотку», чтобы руками по локоть в гудроне не лезть, а зафиксировать результат ремонта и приложить к отчету.</li>
	<li>Ну и на худой конец, какая-нибудь <a href="https://microsoft.github.io/techcasestudies/iot/2017/03/30/PeakUp.html">connected ферма</a></li>
</ul>
Очень интересно понаблюдать, чем люди занимаются, какие идеи генерируют.

<h4>Lynda</h4>
На этом ресурсе в марте 2019 появился курс по <a href="https://www.lynda.com/Azure-tutorials/Exam-Prep-Microsoft-Azure-Infrastructure-Deployment-AZ-100/5005068-2.html">AZ-100</a>, а уже через пару недель экзамен был отмечен, как - "устаревает с мая 2019". Но по архитектуре или разработке ничего специализированного не было.

<h2>Рекомендованный мною путь изучения-сдачи экзаменов-сертификации</h2>
Если Вы <b>менеджер проекта</b>, где используется Azure, я бы рекомендовал следующий набор ресурсов и шагов по изучению:
<ol>
	<li>Microsoft Professional Program -> Cloud Administration track (Общий обзор базовых сервисов. Лабораторные работы можно не сдавать, но контент почитать- будет правильным).</li>
	<li>Безусловно, Вам придется еще много чего погуглить, т.к. специализированного контента для AZ-900 на момент написания статьи инет.</li>
	<li>Экзамен AZ-900 (экзамен, подтверждающий, что вы знаете все ключевые понятия по Azure)</li>
</ol>

Если Вы <b>ITPro</b>
<ol>
	<li>OpenEdx/Курсы на Cloud Society входящие в Microsoft Professional Program -> Cloud Administration track (Общий обзор базовых сервисов. Лабораторные работы можно не сдавать, но почитать контент будет правильным)</li>
	<li>OpenEdx/Cloud Society - AZ-100/AZ-101 подготовительные материалы</li>
	<li>На RoleIQ Pluralsight -> RoleIQ -> Microsoft Azure Administrator (попроходить тесты, чтобы убедиться в своих навыках)</li>
	<li>Экзамен AZ-900 (экзамен, подтверждающий, что вы знаете все ключевые понятия по Azure)</li>
	<li>Экзамен AZ-103</i></li>
</ol>
Если Вы <b>разработчик </b>(и знаете .net/C#)

<ol>
	<li>Курсы на OpenEdx/Cloud Society, входящие в Microsoft Professional Program -> Cloud Administration track (Общий обзор базовых сервисов нужен разработчикам, т.к. не все проекты можно на чистом PAAS сделать, а разбираться в базовых инфраструктурных сервисах все равно нужно, потому что те же AKS базируются, в конце концов, на VMs, подключенных к Vnets с Load Balanced, Public IP, Network Security Groups и т.п.)</li>
	<li>OpenEdx/Cloud Society  - AZ-200/AZ-201 подготовительные материалы</li>
	<li>На RoleIQ Pluralsight -> RoleIQ -> RoleIQ Pluralsight -> RoleIQ -> Microsoft Azure Developer (тесты попроходить, чтобы в своих навыках убедиться)</li>
	<li><i>AZ-900 Не обязателен, но полезен (экзамен, подтверждающий, что вы знаете все ключевые понятия по Azure.</i>)</li>
	<li>Экзамен AZ-203 </li>
</ol>
Если Вы C#/.Net не знаете, Вам будет тяжелее сдать, но возможно, т.к. все C-like языки очень похожи, и посмотреть на API можно и не зная C#.
 
Если вы <b>Architect </b>(Solution или любого другого типа). Этот путь будет самым долгим, но "Царских путей к геометрии нет".
<ol>
	<li>Курсы на Cloud Society входящие в Microsoft Professional Program -> Cloud Administration track (Общий обзор базовых сервисов. Лабораторные работы можно не сдавать, но контент почитать будет правильным)</li>э
<li>Курсы на OpenEdx/Cloud Society входящие в Microsoft Professional Program -> IoT track</li>
	<li>OpenEdx/Cloud Society - AZ-300/AZ-301 подготовительные материалы
<ul><li><i>OpenEdx/Cloud Society - AZ-100/AZ-101 подготовительные материалы (Не обязательные, но очень полезные, т.к. можно на те же сервисы глянуть под другим углом)</i></li>
	<li><i>OpenEdx/Cloud Society - AZ-200/AZ-201 подготовительные материалы (Не обязательные, но очень полезные, т.к. можно на те же сервисы глянуть под другим углом)</i></li>
</ul></li>
	<li>Очень рекомендую сдать экзамен AZ-900. (Экзамен, подтверждающий, что вы знаете все ключевые понятия по Azure. Для Архитекторов это такой Checkpoint, в котором можно убедиться, что Вы идете верным путем)</li>
	<li>На RoleIQ Pluralsight -> RoleIQ -> RoleIQ Pluralsight -> RoleIQ -> RoleIQ Pluralsight -> RoleIQ -> Microsoft Azure Solution Architect (тесты пройти, чтобы в своих навыках убедиться)

<ul>
<li><i>RoleIQ Pluralsight -> RoleIQ -> RoleIQ Pluralsight -> RoleIQ -> Microsoft Azure Developer (Опционально, но дополнительная практика не повредит)</i></li>
<li><i>RoleIQ Pluralsight -> RoleIQ -> Microsoft Azure Administrator (Опционально, но дополнительная практика не повредит)</i></li></ul></li>
	<li>Изучить материал на Azure Architecture Center </li>
	<li>Экзамен AZ-300/301 в обязательном порядке, т.к. сдавать один без другого смысла особого нет.</li>
</ol>
