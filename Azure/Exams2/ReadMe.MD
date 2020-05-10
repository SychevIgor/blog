За последние 3 месяца, Microsoft анонсировал много изменений в сертификации и экзаменах. <a href="https://habr.com/ru/post/490598/">Часть из них описаны в этой статье</a>. 

В этой статье фокус выставлен не на совершенно новые экзамены, а на обновленные версии ранее существовавших: <b>AZ-104</b> для администраторов, <b>AZ-204</b> для разработчиков, <b>AZ-303 и AZ-304</b> для архитекторов.

В январе 2020 года (прошло чуть менее 1.5 лет от изначального анонса role-based экзаменов на Ignite2018, 1 год и 1 месяц после появления az-203 и az-103), Microsoft <a href="https://www.microsoft.com/en-us/learning/community-blog-post.aspx?BlogId=8&Id=375281">анонсировал изменения в экзаменах</a> для разработчиков, администраторов, архитекторов и ai инженеров (последнее не так важно, как первые 3). 

Часть экзаменов уже доступна (az-204/az-104) в бета, а экзамены по архитектуре в доступе появятся позже. Старые (текущие) экзамены можно будет сдать до конца авгста 2020 года (сроки сдвигались из-за Covid-19)

Кажется, что Microsoft вынесла уроки с прошлого анонса, когда “бомбило” и “подгорало” очень сильно. В частности, после ввода новых экзаменов, новые сертификаты не вводятся: как были administrator/developer/architect, так и остались. В общем, умножения на ноль не произошло и для внешнего наблюдателя как бы ничего не изменилось, т.к. и раньше видны были сертификаты, а не экзамены. 

В этой статье я расскажу, что же изменилось в экзаменах.
<cut/>
Сообщество редко радуется изменению экзаменов, т.к. каждый раз это умножает на ноль их предыдущие экзамены (даже если это не совсем так, то сообщество все равно воспринимает это так). Но тут, “не все так однозначно”.  

<spoiler title="Почему вообще понадобились новые экзамены? ">
На этот вопрос Microsoft в своем блоге ответила, что у них не было четкого понимания, какие реально роли существуют, и поэтому она не до конца правильно распределила контент по сертификатам. Это был официальный ответ компании. 

Но этот ответ подходит для тех, кто плохо помнит первичную реакцию на новые экзамены. Я тоже из их числа, но у меня остались записи в блоге. Еще когда экзамены только появились, уже тогда я был недоволен наличием в курсе по разработке разделов по azure batch, azure mobile apps и т.п. И я такой был не один. На мой субъективный взгляд, экзамены составлялись (или, по крайней мере, финальные правки делались) людьми, достаточно далекими от реальной разработки, которые исходили из своего теоретического опыта.
</spoiler>
Давайте перейдем к разбору изменений в экзаменах.

<h2>AZ-203/AZ-204</h2>
Анализ изменений сделан на основании официального <a href="https://query.prod.cms.rt.microsoft.com/cms/api/am/binary/RE3VEHC">skill measurements </a>. С одной стороны, в az-204, относительно az-203, изменений очень мало. С другой стороны, az-203 – это уже вторая версия, т.к. он пришел на смену az-200beta/az-201beta и уж со второй попытки, сделать нормально было сильно проще.

В AZ-204 из крупного были убраны: Azure Search, Azure Batch, Azure API/Mobile apps, Azure Storage Tables, Azure SQL Azure. Из опыта проведения курсов в 2019 году, к включению этих сервисов (кроме SQL) в экзамен было очень много претензий, т.к. опытные разработчики, писавшие на Azure несколько лет в разных проектах, эти сервисы никогда не видели. Конечно, это субъективно, но на большой выборке, становится уже репрезентативно.

<ul>
	<li>Если Azure Search (из личного опыта) – это дорогой, не очень популярный сервис, то Azure Batch вообще azure developers не нужен, т.к. он всё-таки ближе к Data Практике. 

<spoiler title="">
<img src="https://habrastorage.org/webt/ri/uj/9p/riuj9pno2seq7gwubwhrzgnp294.png" />
<img src="https://habrastorage.org/webt/vb/uy/mu/vbuymu9ybfezr5kdxmtv0otpzug.png" />
</spoiler></li>
	<li>API Apps отдельно рассматривать не было смысла, т.к. деление на API и Web – искусственно. А Mobile Apps имеют мало имеют, когда битва за Mobile Platform проиграна пару лет назад. 

<spoiler title=""><img src="https://habrastorage.org/webt/9q/eh/xj/9qehxjsa_l6tsdof06zs5rw1rwu.png" /></spoiler></li>
	<li>Azure Storage Tables убрали, т.к. ну не самый популярный это сервис. После того как Microsoft перестал писать туда свои метрики, а в CosmosDB появились Premium Tables, где все поля проиндексированы и поиск перестал быть кошмаром, наличие вопросов по azure storage tables вызывали не понимание. 

<spoiler title="">
<img src="https://habrastorage.org/webt/xf/fk/nw/xffknwz6ehwutg0zkljekljxmgk.png" /></spoiler></li>
<li>Microsoft убрала еще и SQL Azure. Лично я не понимаю логику этого действия (полное удаление), т.к. CosmosDB, к примеру, оставлен. Согласен, что есть отдельные экзамены по SQL Azure, что нынешний экзамен не отображал специфику SQL Azure Development относительно разработки on-prem. Но все равно: даже azure pass based developers должны знать реляционные базы в каком-то виде. Можно было просто секцию переработать, а не удалять целиком. Лично для меня это единственная секция, из-за которой экзамен потерял что-то. Остальные правки только в плюс пойдут (готовиться проще, актуальность выше).
</li>
<li>Довольно заметно почистили Security часть, убрав оттуда много не Azure специфичных вещей. Например, Role Base и Claim Base аваторизацию. Вопросы были составлены про asp.net core реализацию, но и сам asp.net core меняется, и есть те, кто и без него пишут. Заодно удалили еще и авторизацию на формах, токенах – это вообще не связано с Azure ну никак. С таким же успехом, можно было базовые вопросы по C# в курсе спросить.  

<spoiler title=""><img src="https://habrastorage.org/webt/cl/c0/80/clc080qcu9zfuudx6mnk9ofxiim.png" /></spoiler></li>
<li>Единственное, что мне не нравится - добавление App Configuration, т.к. этот сервис еще в Beta, но это уже мелочи.</li>
<li>Убрали разработку на Visual Studio для Azure Functions (можно писать и без нее, для .net core например), убрали Function на Python (единственный вопрос по python в экзамене, где требуется C# опыт). Немного увеличили раздел по контейнерам.</li>
<li>Разные мелочи – типа “а зачем разработчику знать про disk encryption”, предлагаю сильно не обсуждать.</li>
</ul>
Давайте перейдем к AZ-104 для administrators

<h2>AZ-103/AZ-104</h2>
В отличии от Az-204, где удаляли целыми секциями, а перегруппировки было достаточно мало, в Az-104 – сплошная перегруппировка.

Вместо раздела про <b>управление подписками</b>, теперь у нас гордое Governance т.е. подписки, ресурсные группы + немного про identity management.

<spoiler title="">
<img src="https://habrastorage.org/webt/bp/lf/jl/bplfjlr41qjtnrzmrwhnoc9xoj8.png" /></spoiler>
<b>Раздел про Storage содержит следующие изменения:</b>

<ul>
	<li>Из storage убрали backup(логично, т.к. это не storage) и переместили в отдельную секцию backup and monitoring </li>
	<li>Убрали databox, что тоже нормально, т.к. мало кто с ним работает на практике, а что про него спросить на экзамене решительно не понятно. </li>
	<li>Убрали CDN, т.к. это тоже не storage. </li>
	<li>Убрали activity logs, т.к. это тоже не storage specific вещь, переместили в отдельную секцию backup and monitoring</li>
</ul>
<spoiler title=""><img src="https://habrastorage.org/webt/hy/-q/3_/hy-q3_eufmosfrcokxfyqf5lbu8.png" /></spoiler>
Секция Virtual Machines трансформировалась в секцию по Compute и теперь содержит не только Virtual Machines, но еще и Managed Kubernetes Cluster, Containers Instances и Web Apps 

<spoiler title=""><img src="https://habrastorage.org/webt/zx/yf/ip/zxyfipeiyzal8y5-od1nmnv8gz0.png" /></spoiler>
При этом DSC тоже убрали, хотя может и замаскировали под custom script extensions в итоге. DSC, конечно, интересная технология, но тривиальная, а в мире, где Linux сильно больше, не на столько интересна (на мой личный взгляд).

Секция Networking была сильнее всего дополнена. В ней появились явным образом Azure Application Gateway, Azure Bastion, Azure WAN.

<spoiler title=""> <img src="https://habrastorage.org/webt/yy/ck/v5/yyckv5tibmkjntu3v4prdjwkfoe.png" />
<img src="https://habrastorage.org/webt/nz/y1/zt/nzy1ztfczymfhlhg6tnchpnfuui.png" />
<img src="https://habrastorage.org/webt/ip/2p/e2/ip2pe2eg7djm5emgbu8nyfcrita.png" />
</spoiler>
Появилась отдельная секция по мониторингу, которая была раньше частью “Azure Resource Utilization”, что, честно говоря, не соответствует сути.

<spoiler title=""><img src="https://habrastorage.org/webt/h8/ed/fx/h8edfx7tku3l4v7itwohh4zcw8k.png" />
</spoiler>
<b>Identity/Azure Active Directory</b>

Очень сильно, похудела и трансформировалась секция про Azure Active Directory. Я скорее поддерживаю это решение, т.к. ну не каждый день мы MFA настраиваем (обычно разовая операция, на весь тенант? и то не все используют azure MFA). Синхронизацию через ad connect тоже хорошо, что убрали, т.к. это хоть и многие клиенты используют, но обычно ее 1 раз настраивают и больше не трогают (99% админов ни разу ее не видели, хотя и админят azure круглыми сутками)

<b>Итого, на мой субъективный взгляд, требования к знаниям практически не изменились, но структура контента стала логичнее.</b>

Переходим к самому большому изменению – экзамены для архитекторов.

<h2>AZ-300&AZ301->AZ-303/AZ-304</h2>
Для сдачи сертификата по архитектуре нужно было сдать 2 экзамена Design&Implementation. В этом смысле ничего не изменилось: как было 2 экзамена, так и осталось. Но вот структура экзаменов была очень сильно пересмотрена. На мой взгляд, набор знаний и опыта, по сути, не изменился, но структура экзаменов изменилась радикально. Выводы сделаны на основе новых skill measures <a href="https://query.prod.cms.rt.microsoft.com/cms/api/am/binary/RE3VzwB">1</a> и <a href="https://query.prod.cms.rt.microsoft.com/cms/api/am/binary/RE3VEHD">2</a>

Были убраны части, которые, конечно, хорошо знать настоящим архитекторам, но они не Azure специфичные или их тяжело проверить напрямую. Например, был такой раздел: “сбор требований” в az-301.

<spoiler title=""><img src="https://habrastorage.org/webt/el/r8/zf/elr8zfub8rqakyq4g9arhhhy7v8.png" /></spoiler>
На экзамене, с помощью сценариев “case study”, можно понять умеет ли архитектор вычленять важные требования или нет. Но для реального сбора требований нужно делать whiteboarding sessions, опросники, хакатоны и воркшопы. В тестах этого не сделать.

Еще из 301 экзамена “выпилили” раздел по созданию ролей, персон и т.п. Исходя из своего опыта работы в роли Solution Architect, я могу сказать, что такие вещи - работа для Бизнес Аналитика, и только когда таковых в проекте нет, можно и самостоятельно это сделать. И Azure тут вообще ни при чем. 

<spoiler title=""><img src="https://habrastorage.org/webt/g5/ht/bl/g5htbljilcoyvd2xwnxxxyhcjhs.png" /></spoiler>
Была убрана часть, которая требовала от архитектора уметь писать код на SQL. Штука полезная, но есть разные диалекты и вообще причем тут архитектура?! Архитектор может играть роль Tech Lead проекта, но и в этом случае вопросы по базовому sql синтаксису - это не проблема архитектора. А вот High Availability архитектор должен знать, даже если он не очень большой специалист по Data. 

<spoiler title=""><img src="https://habrastorage.org/webt/xx/zc/s3/xxzcs39civcytcbnfjmjkqxaok0.png" /></spoiler>
Были убраны достаточно абстрактные слова про Security из серии SSL/TLS и заменены на конкретные сервисы типа Azure Key Vault и Azure AD Managed Identity. 

<spoiler title=""><img src="https://habrastorage.org/webt/qt/zc/rj/qtzcrjy-tryfsmmdjkxbyc5z2iy.png" /></spoiler>
Приятно, что секцию по миграции все-таки описали в Az-303 экзамене, а то до обновления было уж слишком лаконично.

<spoiler title=""><img src="https://habrastorage.org/webt/wx/uk/ff/wxukfflbt5g0h11xvrawfx-d2ni.png" /></spoiler>
<spoiler title="Зато в 304 ее только переформулировали "><img src="https://habrastorage.org/webt/av/da/gv/avdagvqb6_fpdaee1kr55pplnge.png" /></spoiler>
Раздел networking стал более azure features/services специфичным. По сути, нам уточнили что нужно знать. Раньше было очень абстрактно: network security, а что в него входит - не понятно.

<spoiler title=""><img src="https://habrastorage.org/webt/i1/lr/tr/i1lrtrkpyycquh7lye5yxkyvxli.png" /></spoiler>
Design Data management, Design Storage strategy, Data Protection, Archiving strategy (было вынесено из Business continuity) были сведены к выбору правильных баз и storage account. По-моему, это скорее переупаковка, чем изменение контента. Многие пункты можно было сократить, и так и было сделано.

<spoiler title=""><img src="https://habrastorage.org/webt/kv/gf/xf/kvgfxfcd6-r9hg-fpu2yi3uaqx8.png" /></spoiler>
Раздел Design and Document Dataflow стал Design Data Integration, а также были напрямую перечислены сервисы. Приятно, что были убраны непроверяемые вопросы типа ”создание data flow диаграмм”. Очередной раз мне кажется, что описание к az-301 писали про абстрактного архитектора, а в 304 - решили написать только то, что можно проверить и что специфично именно для azure.

<spoiler title=""><img src="https://habrastorage.org/webt/c7/px/6u/c7px6uua0vudhrgm6hg_ut7yrya.png" /></spoiler>
Зато раздел по авторизации, (глядя на список тем) изменился полностью. Раньше это был абстрактный “блабла”. В новом варианте - спрашивают конкретные сервисы и фичи Azure AD and Azure. Хотя, часть из новых вопросов- он еще и в governance мог бы войти.

<spoiler title=""><img src="https://habrastorage.org/webt/j7/pa/cl/j7paclkw3i0xougvoel_9-boucc.png" /></spoiler>
Секция Compute, по сути, не изменилась, разве что про AKS добавили пункт, но он уже ранее был в других разделах, поэтому можно сказать, что ничего не поменялось.

<spoiler title=""><img src="https://habrastorage.org/webt/qw/ue/mc/qwuemckeemk236e1wpc1zurnqoo.png" /></spoiler>
Раздел API Integration был переведен в секцию Design an Application Architecture. В эту же секцию попали event/messages, которые были удалены из Az-300 (а в итоге осели в az-304).

Туда же, в Design an Application Architecture, переехала секция Design Deployments. 

<spoiler title=""><img src="https://habrastorage.org/webt/z_/mg/zm/z_mgzmamawtj_oswlpc2yase3es.png" /></spoiler>
High Availability вроде бы не изменился, просто часть вопросов уехала в Business continuity.

<spoiler title=""><img src="https://habrastorage.org/webt/t5/et/vl/t5etvlnuisawo0rufgly1n5n1yk.png" /></spoiler>
Раздел Disaster Recovery впитал в себя еще и часть по backup. Стало более логично. 

<spoiler title=""><img src="https://habrastorage.org/webt/ik/tj/vm/iktjvmz-6hiu1puvfowuw_hdqwm.png" /></spoiler>
<b>Итак, можно с уверенностью сказать, что в Az-303/AZ-304 секции подверглись очень большой перегруппировке и рефакторингу. Но сумма проверяемых знаний, на мой взгляд, не изменилась. Тем, кто готовился к прошлым экзаменам, не должно составить проблемы сдать новый. </b>

<b>Если посмотреть на все 4 экзамена, то налицо заметные улучшения в структуре экзаменов (или, по крайней мере, в структуре skill measurements). Однако, если вы создали курсы подготовки, то вам придется их переснять и переструктурировать. </b>