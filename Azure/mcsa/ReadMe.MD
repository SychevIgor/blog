За 3 прошедших месяца Microsoft сделала 3 крупных анонса:

<ol>
	<li>MCSA, MCSD, MCSE с 2021 года вместе со всеми предыдущими экзаменами, кроме новых Role-based, <a href="https://www.microsoft.com/en-us/learning/community-blog-post.aspx?BlogId=8&Id=375282">прекращают своё существование</a>.</li>
	<li> Почти все предыдущие Azure Role-based экзамены устареют. Об этом можно почитать в <a href="https://habr.com/ru/post/489372/">отдельной статье с разбором</a></li>
	<li> Появится несколько новых экзаменов и соответственно сертификатов к ним:
<ul>
	<li><a href="https://docs.microsoft.com/en-us/learn/certifications/exams/dp-300">Exam DP-300: Administering Relational Databases on Microsoft Azure (beta)</a>/<a href="https://docs.microsoft.com/en-us/learn/certifications/azure-database-administrator-associate">Microsoft Certified: Azure Database Administrator Associate </a></li>
	<li><a href="https://docs.microsoft.com/en-us/learn/certifications/exams/da-100">Exam DA-100: Analyzing Data with Microsoft Power BI (beta)</a>/<a href="https://docs.microsoft.com/en-us/learn/certifications/data-analyst-associate">Microsoft Certified: Data Analyst Associate</a> </li>
	<li><a href="https://docs.microsoft.com/en-us/learn/certifications/exams/az-120">Exam AZ-120: Planning and Administering Microsoft Azure for SAP Workloads</a>/<a href="https://docs.microsoft.com/en-us/learn/certifications/azure-for-sap-workloads-specialty">Microsoft Certified: Azure for SAP Workloads Specialty</a> </li>
	<li><a href="https://docs.microsoft.com/en-us/learn/certifications/exams/az-220">Exam AZ-220: Microsoft Azure IoT Developer</a>/ <a href="https://docs.microsoft.com/en-us/learn/certifications/azure-iot-developer-specialty">Microsoft Certified: Azure IoT Developer Specialty</a></li></ul></li></ol>
Обо всем по порядку.
<cut/>
<h2>MCSA/MCSA/MCSE – все. Совсем все.</h2>
Уверен, что устаревание MCSA/MCSA/MCSE вызвало куда большую реакцию, чем все остальные анонсы. Если бы просто новых экзаменов по SQL 2019 или Windows Server 2019 не было – это еще не так страшно. Но фактически, Microsoft все сертификаты и экзамены не по Azure/Dynamics365/Office365 умножаются на ноль. Нам, конечно, подсластили пилюлю, заверив, что в транскрипте ваших экзаменов факт сдачи никуда не исчезнет, но это вообще не меняет сути. 
 
<img src="https://habrastorage.org/webt/ff/hf/si/ffhfsid228cdr0f6vfa7he-skmm.png" />

<spoiler title="Список экзаменов, которые будут отмечены как устаревшие, слишком велик">
<img src="https://habrastorage.org/webt/r9/w5/8d/r9w58dxioursh0wlqkb9fxrdv-c.png" />
</spoiler>
<spoiler title="У меня есть личное мнение, которое можно прочитать, открыв этот скрытый текст.">
Я не считаю это изменение плохим или хорошим. Это данность, которую я не в силах изменить, а значит нужно к ней приспосабливаться.

Что делать, если вы/ваша компания/ваш клиент/ваша страна не хочет в Azure? Ответ очевиден, но пусть каждый ответит себе сам. 
Было много комментариев, что сейчас навыки C# или по веб разработке на платформе Microsoft - не будет возможности оценить. Это правда, но не думаю, что MSFT это интересно. Мир очень сильно изменился, и то, что вы умеете писать на C# - уже не важно, главное- что ваше приложение хостится в Azure и вы за это платите.

Но я не удивлен. На мой взгляд, это логичный шаг со стороны Microsoft (я не говорю, что правильный), т.к. год от года агитация “переходите в Azure” только росла. В течение моих 4 лет работы в Microsoft этот тренд было очень хорошо видно. Если бы действующие сотрудники Microsoft могли рассказать, как это происходит внутри Microsoft в последние 1.5 года, уверен, было бы интересно послушать. Для себя я сделал такие выводы (у вас может быть другое мнение).

<ul>
	<li>Если вы не хотите в Azure – это не проблема Microsoft,  т.к. они обычная коммерческая компания, которая хочет заработать деньги своим акционерам. Если вы ей в этом не помогаете, то и рассчитывать ни на что не стоит.</li>
	<li>Если ваша страна/компания не хочет в Microsoft Cloud, то у меня хорошая новость: старые ламповые хостеры никуда не денутся. А есть же еще локальный облачные провайдеры.</li>
	<li>Если вы Microsoft Certified Trainer и теперь в России, вам читать, по сути, нечего: тут Microsoft всегда может сказать, что вы “как бизнесмен”, сами несете свои риски и “как бизнесмен”, должны адаптироваться под тренды.</li>
</ul>
</spoiler>
<h3><b>Azure SAP</b></h3>
Тут все сложно, потому что не Microsoft технология совмещена с Azure т.е. экзамен одновременно по Azure инфраструктуре/SAP компонентам и сервисов(для мониторинга, для эстимации) и архитектуре. 

<h3><b>Azure IoT</b></h3>
Экзамен совмещает в себе навыки разработчика IoT на C#, Администратора/Интегратора IoT решения(Device Provisioning очень много спрашивают), пользователя Azure SaaS сервисов для IoT и архитектора. Понятно, что IoT все глубже входит в нашу жизнь, и экзамен нужен тем, кто хочет свои навыки верифицировать. Лично я не уверен, что количество IoT разработчиков будет большим, но экзамен явно требовался, чтобы закрыть соответствующую нишу.

<h3><b>Power-BI</b></h3>
Тут все просто: как работать с Power BI. Лично мне не нравится название сертификата, который дается за этот экзамен “Microsoft Certified: Data Analyst Associate”. Есть много других замечательных инструментов для анализа данных, PowerBI – слишком узко, для такого наименования.

<h3><b>Azure SQL Administrator</b></h3>
Тут все слова важны - ни одного нельзя выкинуть. Это не разработка, а разворачивание, оптимизация, производительность, отказоустойчивость и т.п. Локальный SQL Server рассматривается только как часть Hybrid (про private вообще ни слова нет в skill measurements).

Т.к. код экзамена DA-300, то следуя конвенции именования, я не удивлюсь увидем еще DP-301 про разработку. Но это все - спекуляции. 

Подводя итоги, могу сказать, что Microsoft идет семимильными шагами, и, если вам по пути, мир становится все интереснее. Если данный маршрут Вас не устраивает, не огорчайтесь, есть еще много других путей с другими вендорами и производителями софта и оборудования.