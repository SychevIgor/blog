На мероприятии в сентябре 2018 было <a href="https://www.microsoft.com/en-us/learning/community-blog-post.aspx?BlogId=8&Id=375159">анонсировано</a>, что появились новые экзамены серии AZ-***, а серия 70-53* ушли в небытие. 

Описание уже было <a href="https://habr.com/post/426351/">тут</a> и в моей <a href="https://habr.com/ru/post/435166/">более ранней статье</a>. Но с тех пор многое изменилось.

<img src="https://habrastorage.org/webt/9s/h3/c9/9sh3c97knqctfkun-hc8s7e3uyo.jpeg" />

В этой <a href="https://habr.com/post/435602/">статье</a>, будет список ресурсов для подготовки к сдаче по Azure Dev/Infra/Architecture.
<cut />

<h3>Что принципиально изменилось?</h3>
<ul>
	<li>Полная замена существующих экзаменов на новые- это конечно существенное изменение, но это меня не впечатлило.</li>
<li>Для архитектуров есть 2 экзамена вместо одного- это вообще мало что меняет, т.к. для получения сертификата архитектора - все равно оба сдать надо. Просто стало экзаменов больше.</li>
<li>Появился экзамен по <a href="https://www.microsoft.com/en-us/learning/exam-az-400.aspx">Azure DevOps</a> (ex VSTS, ex VSO) и <a href="https://www.microsoft.com/en-us/learning/exam-az-500.aspx">Azure Security Technologies</a></li>
	<li>Самым большим нововведением стало <b>добавление практической части (во многие, но не во все. На пример в az-203,az-301 не добавили), где Вам дают доступ на реальный портал Azure, дают настоящую подписку, учетную запись из под которой работать и несколько заданий, который надо выполнить.</b> Это прямо супер т.к. экзамены начали проверять и практические навыки человека. Весной 2020 года практическую часть из экзаменов убрали в связи с нехваткой мощностей.
<ul>
	<li>Из личного опыта сдачи, если у Вас есть опыт работы с Azure, то лабораторная часть делает сдачу проще, а не тяжелее т.к. Вы можете не помнишь сходу правильный ответ на вопрос, но в практической части, взглянув на настройку среды в Azure, Вы его найдете. </li>
</ul></li></ul>
<h2>Azure для чайников, или AZ-900</h2>
<a href="https://www.microsoft.com/en-us/learning/exam-AZ-900.aspx">AZ-900</a> был анонсирован сильно позже остальных, но я считаю, что это первое, что нужно было сделать. В AZ-900 собраны все базовые вопросы по Azure без привязки к техническим ролям (разработчик/архитектор/itpro). Примеры: что такое CAPEX/OPEX, public/private/hybrid cloud, как работает биллинг, кому принадлежат данные, в 2 словах надо уметь объяснить пару десятков базовых сервисов, в чем разница между публичными data centers и data centers Azure в Германии/Китае/US GOV и т.п. И на выходе даже получить сертификат базовый можно.

<img src="https://habrastorage.org/webt/e-/wa/8q/e-wa8qi3kwyqlhjab0d6ddxzt5o.png" />
 
Наконец-то появился экзамен для людей, которым еще рано сдавать что-то серьезное или вообще не нужно, но при этом нужна справка<s> о вменяемости</s>, что они знакомы с темой. На мой скромный взгляд, <b>этот экзамен надо сдавать всем менеджерам и продавцам, которые учувствуют в проектах связанными с Azure</b>. Это такой способ убедиться, что люди понимают, чем они занимаются. <b>Техническим ролям тоже не грешно такой сдать</b> в самом начале своего пути к сертификациям, т.к. экзамен покрывает вопросы по нескольким десяткам базовых сервисов (что это и зачем), а заодно даёт общие обзоры платформы, которые обычно упускаются из виду.  
 
Уже после того, как Вы осилите экзамен, можно думать, стоит ли дальше "сдаваться" или нет, т.к. каждый экзамен требует серьезных трудозатрат на подготовку.

<h2><a href="https://www.microsoft.com/en-us/learning/exam-AZ-103.aspx">Az-103</a> Инфраструктура (itpro/или по-модному devops)</h2>
AZ-103 спрашивают  о том как и что можно делать в Azure (создать машину, доступ к ресурсам, подпискам, ресурсным группам, работать с объектами azure active directory, с сетями и т.п.). Правда убрали несколько тем по: "Azure AD Identity Protection and Enterprise State Roaming; configure self-service password reset; implement conditional access policies; manage multiple directories; perform an access review", "Implement Azure load balancer", "Monitor and troubleshoot virtual networking", "Integrate on premises network with Azure virtual network", "Managed role based access control (RBAC)", "Implement multi-factor authentication (MFA)" и немного расширили раздел "Implement and manage hybrid identities"

<h2><a href="https://www.microsoft.com/en-us/learning/exam-az-203.aspx">AZ-203</a> Разработка</h2>
В AZ-203 экзамене спрашивают про <b>Web Apps</b>, <b>SQL Database</b>, <b>Functions</b>, <b>AKS</b>, <b>CosmosDB</b>, <b>Logic Apps</b>, <b>Event Grid</b>, <b>API Management</b> и т.п. <b>Я считаю, что это правильный набор сервисов, отражающий текущее состояние Azure.</b> 

<spoiler title="В AZ-203 хватает проблем">
<ol>
<li><b>Почему Batch Services попал в экзамен? Неужели без числодробилки прожить нельзя</b> (WebJobs/Functions хватит, если не нужно Compute Intensive операции делать). </li>
<li>Зачем у разработчиков спрашивать про шифрование дисков виртуальных машин через azure key vault (configure Azure Disk Encryption for VMs)? Это инфраструктурный вопрос, ну и частично безопасности. Но к разработке, это имеет крайне слабое отношение.
</li>
<li>Разделы по API Apps тоже достаточно спорные. Зачем спрашивать про Swagger/OpenAPI в экзамене по Azure, мне не понятно. Это полезная вещь и без Azure. Вопросы про Swagger/OpenAPI я бы перенес в раздел Logic App, что без потери бы закрыло тему и было бы, на мой взгляд, более логичным.
</li>
	<li>Зачем нужны <b>Mobile Apps от Microsoft в 2019 году</b> мне также не понятно. Microsoft проиграла борьбу за свою мобильную платформу, а когда у тебя нет своей мобильной платформы, то и сервисы для ее поддержки не востребованы. Но они включены в core экзамен. 

<ul>
	<li>Мне очень нравится инструкция по настройке Notification Hub для Android, которая звучит так: «перед созданием Notification Hub для Android, создайте Firebase (который умеет отправлять нотификации на Android/IOS бесплатно)».</li>
<li>Зачем спрашивать про Mobile Apps и не спрашивать про Visual Studio Mobile Center?</li>
</ul></li>	
	<li><a href="https://www.microsoft.com/en-us/learning/exam-az-203.aspx#syllabus-4">Claim Based/Role based авторизация</a> - это вопрос про Asp.Net Core и выбивается из общего ряда т.к. в том-же Node, это реализовано по другому, но код знать надо (Microsoft в последние годы старается делать свои сервисы кроссплатформенным) и не связанная с Azure напрямую.</li>
<li>Зачем, в разделе по мониторингу спрашивать про Load Testing (который базируется на Azure DevOps Load Testing), если о<a href="https://devblogs.microsoft.com/devops/cloud-based-load-testing-service-eol/">н признан устаревшим и будет выведен из эксплуатации в 2020 году уже</a>.</li>
<li> Зачем нужен Azure Storage Queue в 2019 тоже не понятно.
Возьмем простой кейс:
В Azure Service Bus- за 1 миллион сообщений, каждое по 256кб надо заплатить 5 центов (east us). 
1млн*4кб/1024(до мегабайтов)/1024(до гигобайтов)/2 операции(одно сообщение вставить и одно получить- это 2 операции)
Это 2GB за 0.05$. Сообщение может быть до 256kb, что сделает либо дешевле, либо за теже деньги больший объем.

Стоимость 2 GB в Storage Queue - 0.09$.
По этому, возникает вопрос, а в 2019 году- какой сценарий использования Azure storage queue? Если они дороже, более серьезного решения?!
</li>
</ol>
</spoiler>
 <b>То, что есть сейчас - это сильно лучше/свежее, чем то, что было в 70-532 экзамене с 2015 по 2018 год</b> <s>(И если бы не подстава тех, кто сдавал AZ-200/201/202, то все бы было очень даже неплохо.)</s>

<h2>Архитектура</h2>
Таких экзаменов 2, за сдачу обоих выдается сертификат Solution Architect-ора. По-моему, сдавать один без другого - это довольно странная затея, т.к. это<b> 2 точки зрения на одно и тоже.</b>

<ul>
	<li>В случае с <a href="https://www.microsoft.com/en-us/learning/exam-AZ-300.aspx">az-300 Microsoft Azure Architect Technologies</a> мы идем от конкретных сервисов (azure active directory, azure storage, virtual machines)</li>
	<li>А в случае с <a href="https://www.microsoft.com/en-us/learning/exam-AZ-301.aspx">az-301 Microsoft Azure Architect Design</a> мы идем от ключевых логических блоков (авторизация, хранилище, compute).</li>
</ul>
Я бы не сказал, что между ними есть зеркальное соответствие типа один к одному. Например, в 301 под словом compute в соответствующем разделе может подразумеваться и azure batch, и aks, и vmss. При этом в 300 будет четкое разделение на 3 разных части (parallel processing, containers, vms).

Не вижу смысла преводить здесь список сервисов, которые нужно знать т.к. нужно знать не только сервисы, но и как они между собой связаны и когда что использовать. А еще потому, что список очень длинный, и полной версии нет даже на страничках с описанием экзамнов т.к. Архитектор должен знать предмет, широко (а разработчик- глубоко).

Еще раз повторюсь: рекомендую <b>сдавать оба экзамена и готовиться к ним параллельно</b>.

<h2>DevOps в Azure на сервисах Azure</h2>
<a href="https://www.microsoft.com/en-us/learning/exam-az-400.aspx">AZ-400 Microsoft Azure DevOps Solutions</a> ориентирован на очень широкий круг вопросов. Экзамен требует с одной стороны понимать процессы и методологии (работы с work item, планирование и т.п.), а с другой - знать как управлять зависимостями проектов, как собирать код, публиковать, как пользоваться внешними утилитами для анализа кода, как получать feedback от пользователя через тулы и т.п. 

<spoiler title="Личное мнение">
Лично я бы сделал экзамен похожим на AZ-30* (разбил на 2 части: процессы&практика/ремесленная часть работы devops) т.к. это как разница между scrum master и devops инженеров. Но авторам виднее. 
</spoiler>
Чтобы получить Сертификат <a href="https://www.microsoft.com/en-us/learning/azure-devops.aspx">Azure DevOps Engineer Expert</a>, нужно предварительно получить сертификат либо по <a href="https://www.microsoft.com/en-us/learning/azure-developer.aspx">разработке</a>, либо по <a href="https://www.microsoft.com/en-us/learning/azure-administrator.aspx">администрированию</a>. 

<ul>
	<li>Если Вы хотите сертификацию именно по Azure/Cloud, то для вас все хорошо. Я бы рекомендовал сначала сдать AZ-203, т.к. в нем вы получите обзор некоторых Azure сервисов, а уже в AZ-400 целый раздел про Azure Kubernetes Services, Azure Container Registry, ARM, Azure CLI в разрезе публикации.</li>
	<li>Ну а если Вы хотите с<b>дать экзамен, но публиковать не в Azure</b>, то <b>все равно с Azure ознакомиться придется</b>. Выбора у Вас всё равно нет, т.к. 31 декабря 2018 года, Microsoft <a href="https://www.microsoft.com/en-us/learning/retired-certification-exams.aspx">вывела из сдачи все 3 экзамена по TFS</a> и теперь либо Cloud версия, либо ничего. <img src="https://habrastorage.org/webt/e7/n3/9n/e7n39naibo7kmv9vawbyommo-t8.png" /></li>
</ul>

<h2>Azure Security Engineer</h2>
<a href="https://www.microsoft.com/en-us/learning/exam-AZ-500.aspx">Az-500</a> - это экзамен, который вышел в апреле 2019 года и он следует в русле, что Microsoft делает сертификации и экзамены, которые соотвествуют ролям, которые могут быть в Cloud.

В него, перекочевали часть вопросов из az-102 связанных с Azure Active Directory Security таких как just in time access и т.п. С другой стороны, появились вещи связанные с ежедневной работой с AAD на пример: управление пользователями, создания OAuth приложений, трансфер подписок на другого владельца. И кроме того, настройка сбора security logs (нажатие галочки enable на многих разных сервросв) в Azure Monitor/Log Analytics. 
 <spoiler title="Личное мнение">
Т.к. я еще не ходил сдавать этот экзамен и материалов для подготовки еще нет, то к экзамену очень много вопросов. 
<ul>
	<li>По списку вопросов, человек должен знать какие логи в каких сервисах включить. Сервисов много, и не понятно- на каком уровне надо знать сами сервисы, чтобы понимать какие ошибки и риски безопасности могут туда попасть. Просто нажать на кнопку- это не проблема, а вот понять- от чего она защиает и понять данные, которые она выдаст- это совсем другой уровень скила.</li>
<li>К AZ-400 (DevOps) было много притензий, что ижненер должен знать много, внешних для Azure сессий. В Az-500 тоже самое будет. На пример: "implement vulnerability management for containers". В Azure, должно подразумеваться интеграция ACR с Aqua. Но Aqua - это не Azure продукт, это внешний сервис. Т.е. экзамен, уже по внешним продуктам.</li>
</ul>
</spoiler>

<h2>Экзамены по Data Platform</h2>
<ul>
	<li><a href="https://www.microsoft.com/en-us/learning/exam-AI-100.aspx">Designing and Implementing an Azure AI Solution AI-100</a></li>
	<li><a href="https://www.microsoft.com/en-us/learning/exam-DP-100.aspx">Designing and Implementing a Data Science Solution on Azure DP-100</a></li>
	<li><a href="https://www.microsoft.com/en-us/learning/exam-DP-200.aspx">Implementing an Azure Data Solution DP-200</a></li>
	<li><a href="https://www.microsoft.com/en-us/learning/exam-DP-201.aspx">Designing an Azure Data Solution DP-201</a></li>
</ul>
Как человек, сдавший все эти экзамены и получивший сертификаты, могу сказать следующее:
<ul>
	<li>DP-100 Data Science Solutions - экзамен на знания Azure ML сервиса. Нужно хорошо понимать python, базовые библиотеки на нем и Azure ML SDK. Немного стоит знать, сам Azure на уровне виртуальных машин.</li>
	<li>DP-200/DP-201 - это про хранении и обработку данных именно в Azure (Azure Data Solution). Куда входят как вопросы общего характера, так и специфичные для SQL Azure, CosmosDB, SQL DWH и т.п.</li>
	<li>AI-100 -экзамен на знание Azure Cognitive Services и их возморжностей, Microsoft Bot Framework, LUIS, QnA Maker и т.п. Знание C# поможет, но экзамен не фокусируется на языке совершенно.</li>
</ul>