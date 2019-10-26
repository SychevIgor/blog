В <a href="https://habr.com/post/435166/">прошлой статье</a> я рассказал про новые экзамены по Azure (Серия AZ: AZ-103,AZ-203,AZ-300/AZ-301,AZ-400,AZ-900. Серия DP:DP-100,DP-200,DP-201. Серия AI: AI-100). Теперь можно обсудить подготовку к экзаменам.

В статье я расскажу про 
<ul>
	<li><a href="https://docs.microsoft.com/en-us/learn/">Microsoft Learning</a></li>
	<li><a href="https://www.pluralsight.com">Pluralsight (RoleIQ и Paths)</a></li>
	<li><a href="https://oxa.microsoft.com">OpenEDX</a></li>
	<li><a href="https://docs.microsoft.com/en-us/azure/architecture/">Azure Architecture Center</a></li>
        <li>Рекомендованный мною путь изучения-сдачи экзаменов-сертификации</li>
        <li><b>И некоторые другие ресурсы.</b></li>
</ul>
<cut />
<spoiler title="Предположения:">
<ol>
	<li>В статье я не буду касаться вопросов типа <b>«А зачем вообще сдавать?»</b></li>
	<li>В статье будет <b>мое личное мнение</b> про подготовку к экзамену, оно может отличаться от вашего мнения или, тем более, мнения Microsoft.</li>
	<li>В статье будут освещены<b> только англоязычные ресурсы</b></li>	
	<li><b>Минимальный уровень знаний по Azure у вас есть</b>, т.к. сертифицироваться, не имея опыта - это очень плохая идея. Сертификат – это все-таки подтверждение квалификации </li>
  </ol>
</spoiler>
<h2><a href="https://docs.microsoft.com/en-us/learn/">Microsoft Learning</a></h2>
Первым ресурсом, на который нужно обратить свое внимание, будет <a href="https://docs.microsoft.com/en-us/learn/">Microsoft Learning</a>.<b>Это основной, рекомендованный Microsoft ресурс для изучения Azure.</b> Этот ресурс, который можно использовать для изучения Azure с нуля, при этом выбрав свою роль (разработчик, архитектор, админ, специалист по Data или AI<s>(в понимании Microsoft конечно)</s>). 
Тут много относительно небольших кусочков, которые можно изучать по 30-60 минут в день в течение 1-3 месяцев, охватив при этом очень широкий пласт материала. 

<img src="https://habrastorage.org/webt/sb/8q/zr/sb8qzr45v01dxqxqum73j-hu2ao.png" />

Одним из самых важных моментов является то, что там много небольших лабораторных работ, которые помогают наработать мышечную память. На пример- возьмем все <a href="https://docs.microsoft.com/en-us/learn/browse/?roles=developer&products=azure">разделы по Azure, которые могут быть интересны для разработчиков</a>.

Безусловно, про 1-3 месяца – это совсем с нуля. Если вы уже последние пару лет работаете с Azure, то этот ресурс стоит очень быстро просмотреть, найти пробелы в своих знаниях и перейти к подготовке к сдаче экзамена.

<h2><a href="https://www.pluralsight.com/product/role-iq">Pluralsight RoleIQ</a></h2>
Для начала, можно бесплатно пройти тестирование на знание Azure по 3 (из 8) направлениям: <a href="https://www.pluralsight.com/role-iq/microsoft-azure-solution-architect">архитектура</a>, <a href="https://www.pluralsight.com/role-iq/microsoft-azure-developer">разработка</a>, <a href="https://www.pluralsight.com/role-iq/microsoft-azure-administrator">инфраструктура</a>, <a href="https://www.pluralsight.com/role-iq/microsoft-azure-ai-engineer">AI инженер</a>, <a href="https://www.pluralsight.com/role-iq/microsoft-azure-data-engineer">Data инженер</a>, <a href="https://www.pluralsight.com/role-iq/microsoft-azure-devops-engineer">DevOps инженер</a>, <a href="https://www.pluralsight.com/role-iq/microsoft-azure-security-engineer">Security инженер</a>, <a href="https://www.pluralsight.com/role-iq/microsoft-azure-data-scientist">Data scientist</a>  и на выходе получить некоторую оценку 0-300 своих знаний. Каждая роль состоит из нескольких тестирований 6-9, что позволяет комплексно посмотреть на свои знания. (Нужно создать учетную запись, карту привязывать не нужно, free trial начинать тоже не обязательно. Тесты доступны и без этого). Пример по архитектуре 

<img src="https://habrastorage.org/webt/dq/0o/c3/dq0oc3ubkk7ppqnelwjf6-xb9nq.png" />

На мой взгляд, это хороший <b>качественные </b>тесты (<b>есть качественный, а есть количественные метод, который даст значение</b>), чтобы оценить свои знания. 

На каждый вопрос дается <b>ограничение по времени</b>, в зависимости от длины текста вопроса + всех вариантов ответов. Но если вы хотите хакнуть систему, то будет тяжело, т.к. времени дается не много. 

При всем этом <b>оценка нелинейная</b>, т.е. сдал 17 из 20 вопросов - получишь 255 из 300. Зависит это от сложности заданий и в какой момент ты ошибся. Лично мне такая система немного не понятна (получается, если ты ошибся в начале - это плохо, а если ближе к концу - менее страшно), но <b>качественный результат дает.</b>

<img src="https://habrastorage.org/webt/gz/eo/8n/gzeo8nexhvycw9swo1yhqe0ce8m.png" />

<s>Кстати, можно потешить свое самолюбие, т.к. в конце каждого теста дают не только оценку, но и процент людей, который сдал лучше тебя. Приятно бывает видеть, что лучше тебя сдало 1-3%.</s>
 
Я вижу этот тест, как способ разделить массу желающих обучаться на несколько групп по их исходным навыкам. 
После прохождения теста Вам порекомендуют курсы, которые закрывают пробелы в знаниях, но эти курсы уже за деньги.

<h2><b><a href="https://oxa.microsoft.com/">OpenEDX</a></b></h2>
<spoiler title="Есть много похожих ресурсов с одинаковым контентом. Потому, что">
Microsoft распространяет этот контент через своих Education partners, а те, в свою очередь, делают из контента продукт. По этому, контент можно найти на десятке разных порталов. Но мне в EPAM его не дали, т.к. мы не Education Partner.
</spoiler>
<b>Тут есть курсы для каждого раздела, перечисленного в описании экзамена. Это такая выжимка, brain dump, который надо обязательно знать для сдачи экзаменов. </b>

Вы записываетесь на курс (enroll), читаете контент, делаете небольшие тестовые задания самостоятельно и в конце сдаете небольшой тест. Я не готов гарантировать, что, выучив текст всех модулей, Вы сдадите экзамен, но если Вы уже знаете Azure, то этот ресурс очень помогает сократить время подготовки. Кроме того, на OpenEdx генерируется "сертификат". Выглядит сертификат солидно, с подписью самого-самого, правда непонятно насколько эти сертификаты имеют ценность.<img src="https://habrastorage.org/webt/pa/mu/tz/pamutz3cxprw-vhuxslcnn87ri8.png" />

На мой субъективный взгляд, курсы с OpenEDX максимально близки к тому, что спрашивают в экзаменах серии AZ и при этому бесплатные. 

Приведу здесь список курсов для подготовки к экзаменам. (Чтобы попасть на openedx версию, просто замените в URL “cloudsociety.learning” на “openedx” или наоборот).
<b>У тренингов выходят обновления, по этому рекомендую ссылки перепроверять самостоятельно перед началом обучения т.к. на момент первой публикации актуальной версией была 2018_T3, а на момент редактирования уже 2019_T2</b>

<ul>
	<li><a href="https://oxa.microsoft.com/courses/course-v1:Microsoft+AZ-103.1+2019_T2/course/">AZ-103 (Microsoft Azure Administrator)</a></li>
	<li><a href="https://oxa.microsoft.com/courses/course-v1:Microsoft+AZ-500.0+2019_T2/about">AZ-500 (Microsoft Azure Security Technologies)</a></li>
	<li><a href="https://oxa.microsoft.com/courses/course-v1:Microsoft+AZ-900+2019_T2/about">AZ-900 (Microsoft Azure Fundamentals)</a></li>
	<li><a href="https://oxa.microsoft.com/courses/course-v1:Microsoft+DP-200.1+2019_T1/about">DP-200 (Implementing an Azure Data Solution)</a></li>
</ul>
<spoiler title="AZ-203">
<ul>
	<li><a href="https://oxa.microsoft.com/courses/course-v1:Microsoft+AZ-203.1+2019_T2/course/">Develop Azure Infrastructure as a Service compute solutions</a></li>
	<li><a href="https://oxa.microsoft.com/courses/course-v1:Microsoft+AZ-203.2+2019_T2/course/">Develop Azure Platform as a Service compute solutions</a></li>
	<li><a href="https://oxa.microsoft.com/courses/course-v1:Microsoft+AZ-203.3+2019_T2/course/">Develop for Azure storage</a></li>
	<li><a href="https://oxa.microsoft.com/courses/course-v1:Microsoft+AZ-203.4+2019_T2/course/">Implement Azure Security</a></li>
	<li><a href="https://oxa.microsoft.com/courses/course-v1:Microsoft+AZ-203.5+2019_T2/course/">Monitor, troubleshoot, and optimize Azure solutions</a></li>
	<li><a href="https://oxa.microsoft.com/courses/course-v1:Microsoft+AZ-203.6+2019_T2/course/">Connect to and consume Azure, and third-party, services</a></li>
</ul>
</spoiler>
<spoiler title="AZ-300">
<ol>
	<li><a href="https://oxa.microsoft.com/courses/course-v1:Microsoft+AZ-300.1+2019_T2/info">Deploying and Configuring Infrastructure</a>  </li>
	<li><a href="https://oxa.microsoft.com/courses/course-v1:Microsoft+AZ-300.2+2019_T2/info">Implementing Workloads and Security</a>  </li>
	<li><a href="https://oxa.microsoft.com/courses/course-v1:Microsoft+AZ-300.3+2019_T2/info">Understanding Cloud Architect Technology Solutions</a> </li>
	<li><a href="https://oxa.microsoft.com/courses/course-v1:Microsoft+AZ-300.4+2019_T2/info">Creating and Deploying Apps</a>  </li>
	<li><a href="https://oxa.microsoft.com/courses/course-v1:Microsoft+AZ-300.6+2019_T2/info">Developing for the Cloud</a></li>
</ol>
</spoiler>
<spoiler title="AZ-301">
<ol>
	<li><a href="https://oxa.microsoft.com/courses/course-v1:Microsoft+AZ-301.1+2019_T2/info">Designing for Identity and Security</a>  </li>
	<li><a href="https://oxa.microsoft.com/courses/course-v1:Microsoft+AZ-301.2+2019_T2/info">Designing a Data Platform Solution</a>  </li>
	<li><a href="https://oxa.microsoft.com/courses/course-v1:Microsoft+AZ-301.3+2019_T2/info">Designing for Deployment, Migration, and Integration</a>  </li>
	<li><a href="https://oxa.microsoft.com/courses/course-v1:Microsoft+AZ-301.4+2019_T2/info">Designing an Infrastructure Strategy </a></li>
</ol>
</spoiler>
<spoiler title="AZ-400">
<ol>
	<li><a href="https://oxa.microsoft.com/courses/course-v1:Microsoft+AZ-400.1+2019_T1/about">Implementing DevOps Development Processes</a></li>
	<li><a href="https://oxa.microsoft.com/courses/course-v1:Microsoft+AZ-400.2+2019_T1/about">Implementing Continuous Integration</a></li>
	<li><a href="https://oxa.microsoft.com/courses/course-v1:Microsoft+AZ-400.3+2019_T1/about">Implementing Continuous Delivery</a></li>
	<li><a href="https://oxa.microsoft.com/courses/course-v1:Microsoft+AZ-400.4+2019_T1/about">Implementing Dependency Management</a></li>
	<li><a href="https://oxa.microsoft.com/courses/course-v1:Microsoft+AZ-400.5+2019_T1/about">Implementing Application Infrastructure</a></li>
	<li><a href="https://oxa.microsoft.com/courses/course-v1:Microsoft+AZ-400.6+2019_T1/about">Implementing Continuous Feedback</a></li>
	<li><a href="https://oxa.microsoft.com/courses/course-v1:Microsoft+AZ-400.7+2019_T1/about">Designing a DevOps Strategy</a></li>
</ol>
</spoiler>

<spoiler title="Хотя есть и минусы у OpenEdx, оснвной из которых - практических работ с azure portal там нет ">
На openedx курсов не видно в поиске - на них можно попасть только по прямым ссылкам. Но это лучше, чем у EDX т.к. на EDX- даже тест бесплатно пройти нельзя. На edx нужно заплатить 99$ за каждый.<img src="https://habrastorage.org/webt/u8/tn/qr/u8tnqrvj21sjjoay0c_ocfip1m8.png" />
А прогресс по курсу буквально через месяц будет удален, если курс не оплачен, даже если курс длится 3 месяца. 
</spoiler>

<h2><a href="https://github.com/MicrosoftLearning">MicrosoftLearning лабы на github</a></h2>
К официальным курсам для Microsoft Certified Trainers прилагается серия лабораторных работ на github. Их можно использовать и без самого курса.
<ul>
<li><a href="https://github.com/MicrosoftLearning/AZ-103-MicrosoftAzureAdministrator">AZ-103</a></li>
<li><a href="https://github.com/MicrosoftLearning/AZ-203-DevelopingSolutionsforMicrosoftAzure">AZ-203</a></li>	
	<li><a href="https://github.com/MicrosoftLearning/AZ-300-MicrosoftAzureArchitectTechnologies">AZ-300</a></li>
	<li><a href="https://github.com/MicrosoftLearning/AZ-301-MicrosoftAzureArchitectDesign">AZ-301</a></li>	
	<li><a href="https://github.com/MicrosoftLearning/AI-100-Design-Implement-Azure-AISol">AI-100</a></li>
	<li><a href="https://github.com/MicrosoftLearning/DP-100-Designing-and-Implementing-a-Data-Science-Solutio">DP-100</a></li>
	<li><a href="https://github.com/MicrosoftLearning/DP-200-Implementing-an-Azure-Data-Solution">DP-200</a></li>
	<li><a href="https://github.com/MicrosoftLearning/DP-201-Designing-an-Azure-Data-Solution">DP-201</a></li>
</ul>

<h2>Pluralsight курсы</h2>
В 2019 появились пути (path) по подготовке непосредственно к экзаменам серии AZ/DP.
Path- это набор курсов, выстроенных в последовательность.
Часть курсов появились раньше, чем сами экзамены- но к счастью, некоторые базовые вещи в Azure давно не меняются.
<ul>
	<li><a href="https://www.pluralsight.com/paths/microsoft-azure-administrator-az-103">AZ-103</a></li>
	<li><a href="https://www.pluralsight.com/paths/developing-solutions-for-microsoft-azure-az-203">AZ-203</a></li>
	<li><a href="https://www.pluralsight.com/paths/microsoft-azure-architect-technologies-az-300">AZ-300</a></li>
	<li><a href="https://www.pluralsight.com/paths/microsoft-azure-architect-design-az-301">AZ-301</a></li>
<li><a href="https://app.pluralsight.com/paths/certificate/azure-data-solution-dp-201">DP-201</a></li>
</ul>

<h2>Linuxacademy курсы</h2>
Курсы на этом ресурсе появились позже, чем на остальных, но тоже можно их рассмотреть
<ul>
	<li><a href="https://linuxacademy.com/course/exam-az-103-microsoft-azure-administrator/">AZ-103 infra</a></li>
	<li><a href="https://linuxacademy.com/course/microsoft-certified-azure-developer-exam-203-prep/">AZ-203 dev</a></li>
	<li><a href="https://linuxacademy.com/course/az-300-exam-preparation-microsoft-azure-architect-technologies/">az-300 arch implementation</a></li>
	<li><a href="https://linuxacademy.com/course/microsoft-azure-architect-design-exam-az-301/">az-301 arch design </a></li>
        <li><a href="https://linuxacademy.com/course/az-500-microsoft-azure-security-technologies/">az-500 decurity</a></li>
        <li><a href="https://linuxacademy.com/course/microsoft-azure-fundamentals-az-900-exam-prep/">AZ-900</a></li>
        <li><a href="https://linuxacademy.com/course/implementing-an-azure-data-solution-dp-200/">DP-200</a></li>
</ul>

<h2><a href="https://github.com/Microsoft/MCW">Microsoft Cloud Workshop Project</a></h2>
Microsoft опубликовала на github серию Cloud Workshops, в которых можно взять HandOnLabs и по ним сделать предложенные практические упражнения. Т.к. все экзамены, серии AZ, заявлены как Experience based, то практический опыт- безценен.
<spoiler title="AZ-203/AZ-300/Az-301">
<ul>
	<li><a href="https://github.com/Microsoft/MCW-Serverless-Architecture">Serverless-Architecture</a></li>
	<li><a href="https://github.com/Microsoft/MCW-Big-Compute">Big-Compute</a></li>
	<li><a href="https://github.com/Microsoft/MCW-Lift-and-shift-Azure-Resource-Manager">Lift-and-shift-Azure-Resource-Manager</a></li>
	<li><a href="https://github.com/Microsoft/MCW-App-modernization">App-modernization</a></li>
	<li><a href="https://github.com/Microsoft/MCW-Containers-and-DevOps">Containers-and-DevOps</a></li>
	<li><a href="https://github.com/Microsoft/MCW-Continuous-delivery-in-Azure-DevOps">Continuous-delivery-in-Azure-DevOps</a></li>
	<li><a href="https://github.com/Microsoft/MCW-Securing-PaaS">Securing-PaaS</a></li>
</ul>
</spoiler>
<spoiler title="AI-100/DP-100/DP-200/DP-201">
<ul>
	<li><a href="https://github.com/microsoft/MCW-Big-data-and-visualization">Big data and visualization</a></li>
	<li><a href="https://github.com/microsoft/MCW-Cognitive-services-and-deep-learning">Cognitive services and deep learning</a></li>
	<li><a href="https://github.com/microsoft/MCW-Intelligent-analytics">Intelligent analytics</a></li>
	<li><a href="https://github.com/microsoft/MCW-Migrate-EDW-to-Azure-SQL-Data-Warehouse">Migrate EDW to Azure SQL Data Warehouse</a></li>
</ul>
</spoiler>
И еще много других полезных лабораторных работ. 
Я не предлагаю перемолотить все практические работы, особенно если учесть, что они отвязаны от самих экзаменов серии AZ/AI/DP. Но эти Handsonlabs дадут Вам практический опыт. А уже будите ли Вы использовать этот контент или нет - Ваша воля.

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

<h4><a href="https://iotschool.microsoft.com/en-us/iot/learning-paths">Azure IoT school</a></h4>
Для Архитектурного экзамена, можно попробовать сделать практические задания из Azure IoT School. Разработчика на экзамене это не спрашивают, но архитекторов спрашивают.

<h4>Linkedin Learning</h4>
Linkedin - это бывший Lynda. Тут доступно не так много курсов по подготовке непосредственно к экзаменам, хотя есть много курсов к экзаменам не привязанных.
<ul>
	<li><a href="https://www.linkedin.com/learning/exam-prep-microsoft-azure-fundamentals-az-900/azure-certification-for-advancement">AZ-900</a></li>
<li><a href="https://www.linkedin.com/learning/exam-tips-microsoft-azure-administrator-az-103/azure-certification-for-advancement">AZ-103</a></li>
</ul>

<h2>Рекомендованный мною путь изучения-сдачи экзаменов-сертификации</h2>
Если Вы <b>менеджер проекта</b>, где используется Azure, я бы рекомендовал следующий набор ресурсов и шагов по изучению:
<ol>
       <li>OpenEdx - AZ-900 подготовительные материалы</li>
	<li>Скорее всего, Вам придется еще много чего погуглить.</li>
	<li>Экзамен AZ-900 (экзамен, подтверждающий, что вы знаете все ключевые понятия по Azure)</li>
</ol>

Если Вы <b>ITPro</b>
<ol>
	<li>OpenEdx - Общий обзор базовых сервисов. Лабораторные работы можно не сдавать, но почитать контент будет правильным</li>
	<li>OpenEdx- AZ-103 подготовительные материалы</li>
	<li>На RoleIQ Pluralsight -> RoleIQ -> Microsoft Azure Administrator (попроходить тесты, чтобы убедиться в своих навыках)</li>
	<li>Экзамен AZ-900 (экзамен, подтверждающий, что вы знаете все ключевые понятия по Azure)</li>
	<li>Экзамен AZ-103</i></li>
</ol>
Если Вы <b>разработчик </b>(и знаете .net/C#)
<ol>
	<li>Курсы на OpenEdx - Общий обзор базовых сервисов нужен разработчикам, т.к. не все проекты можно на чистом PAAS сделать, а разбираться в базовых инфраструктурных сервисах все равно нужно, потому что те же AKS базируются, в конце концов, на VMs, подключенных к Vnets с Load Balanced, Public IP, Network Security Groups и т.п.</li>
	<li>OpenEdx - AZ-203 подготовительные материалы</li>
	<li>На RoleIQ Pluralsight -> RoleIQ -> RoleIQ Pluralsight -> RoleIQ -> Microsoft Azure Developer (тесты попроходить, чтобы в своих навыках убедиться)</li>
	<li><i>AZ-900 Не обязателен, но полезен (экзамен, подтверждающий, что вы знаете все ключевые понятия по Azure.</i>)</li>
	<li>Экзамен AZ-203</li>
</ol>
Если Вы C#/.Net не знаете, Вам будет тяжелее сдать, но возможно, т.к. все C-like языки очень похожи, и посмотреть на API можно и не зная C#.
 
Если вы <b>Architect </b>(Solution или любого другого типа). Этот путь будет самым долгим, но "Царских путей к геометрии нет".
<ol>
	<li>OpenEdx - Общий обзор базовых сервисов. Лабораторные работы можно не сдавать, но почитать контент будет правильным</li>
	<li>OpenEdx - AZ-300/AZ-301 подготовительные материалы
<ul><li><i>OpenEdx - AZ-103 подготовительные материалы (Не обязательные, но очень полезные, т.к. можно на те же сервисы глянуть под другим углом)</i></li>
	<li><i>OpenEdx - AZ-203 подготовительные материалы (Не обязательные, но очень полезные, т.к. можно на те же сервисы глянуть под другим углом)</i></li>
</ul></li>
	<li>Очень рекомендую сдать экзамен AZ-900. (Экзамен, подтверждающий, что вы знаете все ключевые понятия по Azure. Для Архитекторов это такой Checkpoint, в котором можно убедиться, что Вы идете верным путем)</li>
	<li>На RoleIQ Pluralsight -> RoleIQ -> RoleIQ Pluralsight -> RoleIQ -> RoleIQ Pluralsight -> RoleIQ -> Microsoft Azure Solution Architect (тесты пройти, чтобы в своих навыках убедиться)

<ul>
<li><i>RoleIQ Pluralsight -> RoleIQ -> RoleIQ Pluralsight -> RoleIQ -> Microsoft Azure Developer (Опционально, но дополнительная практика не повредит)</i></li>
<li><i>RoleIQ Pluralsight -> RoleIQ -> Microsoft Azure Administrator (Опционально, но дополнительная практика не повредит)</i></li></ul></li>
	<li>Изучить материал на Azure Architecture Center </li>
	<li>Экзамен AZ-300/301 в обязательном порядке, т.к. сдавать один без другого смысла особого нет.</li>
</ol>
