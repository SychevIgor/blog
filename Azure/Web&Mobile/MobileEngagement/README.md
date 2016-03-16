Добрый день! В октябре 2015 года был запущен в коммерческую эксплуатацию сервис <a href="https://azure.microsoft.com/ru-ru/services/mobile-engagement/">Azure Mobile Engagement</a>. В чем его предназначение и какие проблемы он решает?

Мы написали мобильное приложение, опубликовали его, пользователь его скачал, и больше мы о своём детище ничего не знаем. Что он делает, когда и как использует? Мы можем написать сами сервис по сбору аналитики с приложения (время/деньги) или использовать уже готовый сервис. Аналитика - это хорошо, но, имея знания, нужно уметь их использовать, нужно иметь канал связи с пользователем. Можно написать свою систему нотификаций (время на имплементацию-> деньги).

<a href="https://azure.microsoft.com/en-us/documentation/services/mobile-engagement/">Azure Mobile Engagement </a>комбинирует в себе эти 2 функции: сбор данных о поведении пользователя и сегментация пользователей и канал обратной связи с ним, причем для 3 популярных платформ (ios, android, windows).

Самое классное - яркое объяснение в виде 1.5-минутного видео:

<iframe src="https://channel9.msdn.com/Blogs/Windows-Azure/Azure-Mobile-Engagement-Overview/player" width="640" height="360" allowFullScreen frameBorder="0"></iframe>
<cut text="Узнать больше подробностей можно под катом..." />
<ul>
	<li>“Бизнес-Пример”: мы написали игру, но пользователь со временем стал в нее реже играть… a значит, скоро может вообще уйти… и точно не будет покупать ништяки для своего персонажа. Для любой игры нужна постоянная вовлеченность пользователя. Mobile Engagement позволяет выделить сегмент игроков, готовых уйти, и вы можете начислить этому игроку какую-нибудь плюшку (премиумный танк, к примеру, как ему начислить - это уже имплементация на стороне вашего приложения) и отправить нотификацию, в которой поздравить игрока с этой плюшкой. Возможно, пользователь вновь загорится игрой. </li>
	<li>Или более простой пример: игрок дошел до предпоследнего уровня игры. Не сложно представить, что скоро он пройдет игру и с большой вероятностью перестанет играть. Вы можете предложить ему прислать нотификацию, что “только для вас, лучшая цена на продолжение культовой саги”.</li>
</ul>
С вопросом «зачем нужен этот сервис?» мы закончили. Переходим к имплементации.

Для использования этого сервиса нужно совмещать 2 роли: разработчика и аналитика. 
Введем несколько <a href="https://azure.microsoft.com/en-us/documentation/articles/mobile-engagement-concepts/">концепций</a>: 

<ul>
	<li><b>User</b>- тут ничего интересно.</li>
	<li><b>Session</b>- набор активностей от входа в приложение до его закрытия.</li>
	<li><b>Activity</b>- некоторой действие, совершенное за время сессии.</li>
	<li><b>Event</b>- тип activity, у которого не было длительности (нажатие на кнопку).</li>
	<li><b>Job</b>- тип активности, у которой есть начальный и конечный момент времени (http call).</li>
</ul>
И к Job, и к Event можно добавить кастомные данные.

<h3>Разработчику</h3>
Предлагаю начать с того, что нужно знать разработчику, т.к. это быстрее и проще.

<spoiler title="Создать новый сервис на портале (manage.windowsazure.com) ">

<img align="center" width="650" src="https://habrastorage.org/files/a04/3bf/5f1/a043bf5f15c44c6891d06fb1971cb755.png"/>
<img align="center" src="https://habrastorage.org/files/6c3/a5f/8a9/6c3a5f8a9f924b50afcceab33677d1cd.png"/>
<img align="center" width="650" src="https://habrastorage.org/files/eda/bfa/f12/edabfaf1254e4467b8e31c0b0568e32e.png"/></spoiler>
<spoiler title="Хоть приложение и создается на classic портале, оно поддерживает ARM модель управления ">

<img align="center" width="650" src="https://habrastorage.org/files/467/490/0da/4674900da48f45c995f3c010f2efdfca.png"/></spoiler>
А далее все зависит операционной системы/языка, под которую мы будем писать, в котором мы будем использовать ME. Готовые примеры интеграции можно взять с <a href="https://github.com/Azure/azure-mobile-engagement-samples">GitHub</a>.

Как и многие сервисы Azure, он не просто поддерживает IOS и Android, но и эти sdk были сделаны едва ли не раньше, чем под Windows.

<ul>
	<li><a href="https://azure.microsoft.com/en-us/documentation/articles/mobile-engagement-ios-get-started/">ObjectiveC</a></li>
	<li><a href="https://azure.microsoft.com/en-us/documentation/articles/mobile-engagement-ios-swift-get-started/">Swift</a></li>
	<li><a href="https://azure.microsoft.com/en-us/documentation/articles/mobile-engagement-android-get-started/">Java</a></li>
</ul>
Для Windows платформы есть 2 мануала: для Silverlight приложений и для universal apps (8.1).

<ul>
	<li><a href="https://azure.microsoft.com/en-us/documentation/articles/mobile-engagement-windows-store-dotnet-get-started/">Universal 8.1</a></li>
	<li><a href="https://azure.microsoft.com/en-us/documentation/articles/mobile-engagement-windows-phone-get-started/">Silverlight</a></li>
	<li>На данный момент Windows 10 Universal инструкции нет, но это поддерживается. Просто берем документацию от <a href="https://azure.microsoft.com/en-us/documentation/articles/mobile-engagement-windows-store-dotnet-get-started/">8.1</a>  </li>
	<li>Для Xamarin уже <a href="https://feedback.azure.com/forums/285737-mobile-engagement/suggestions/10029978-xamarin-c-sdk-to-work-with-azure-mobile-engagem">начали </a>писать sdk  </li>
</ul>
Сама SDK делится на 2 части: стандартная (сбор данных) и расширенная (отправка нотификаций). 
Приведенный ниже код для расширенной версии (т.к. базовая в нем тоже подключена).

<spoiler title="В App.xaml.cs добавим инициализацию." >
<img align="center" width="650" src="https://habrastorage.org/files/3b0/018/1a2/3b00181a22b2400eb9bee70428c463c5.png"/></spoiler>
<spoiler title="На каждой странице, где мы хотим включить в нашу аналитику, нужно заменить базовый класс.">
<img align="center" width="650" src="https://habrastorage.org/files/d8f/d64/577/d8fd645775c646f0b9db5e86d7beba2e.png"/></spoiler>
Если Вас такой вариант наследования не устраивает, то можно <a href="https://azure.microsoft.com/en-us/documentation/articles/mobile-engagement-windows-store-use-engagement-api/">самим </a>имплементировать функционал, который в базовых классах реализован. 

<spoiler title="Пример реализации">

<img align="center" width="650" src="https://habrastorage.org/files/b05/0d5/91f/b050d591fea946868d50bae900013dc4.png"/></spoiler>
<spoiler title="Ну, и нужно добавить конфигурацию. Для этого нужно добавить xml файл.">

<img align="center" width="650" src="https://habrastorage.org/files/30c/b5f/2c4/30cb5f2c44c94b0e9095a7a4a4289120.png"/></spoiler>
<b>На этом базовые шаги по настройке окончены. </b>

<spoiler title="Чтобы убедиться, что данные отправляются, предлагаю запустить Visual Studio с network profile и посмотреть, куда идут запросы."><img align="center" width="650" src="https://habrastorage.org/files/33a/b12/9dd/33ab129dd5e0490b9f8578f922293031.png"/>
<img align="center" width="800" src="https://habrastorage.org/files/e00/963/221/e00963221da846d3b76d3cf4c21e8721.png"/></spoiler>
Важная настройка - как часто отправлять эти логи на сервер? По умолчанию, это происходит в real time режиме, но можно <a href="https://azure.microsoft.com/en-us/documentation/articles/mobile-engagement-windows-store-integrate-engagement/">установить</a> пакетную отправку. 

<spoiler title="Пример">

<img align="center" src="https://habrastorage.org/files/a74/5e2/2b9/a745e22b9b3347b99d21cffec9ef6577.png"/></spoiler>
Перед тем, как переходить к аналитике, остается еще 1 важный вопрос: а как, собственно, нотификации-то доставлять, не голубиной же почтой? Для того, чтобы отправлять нотификации, используется Azure Notification Hub, но это для нас скрыто за Mobile Engagement.

<img align="center" src="https://habrastorage.org/files/a48/01d/547/a4801d5477cf4101828c03012cd2e4e9.png"/>
Как и для любых нотификаций, нам нужно будет зарезервировать имя приложения в windows store (или любом другом магазине), скопировать оттуда ApplicationID и userSecret и вставить их в Mobile Engagement.

<img align="center" width="650" src="https://habrastorage.org/files/fa2/7b2/14b/fa27b214ba3644e19a485d79991971ce.png"/>
<h3>Аналитика</h3>
Прежде чем делать “Welcome Campaign” (“Hello World” в мире мобильной аналитики), хорошо бы, как минимум, посмотреть на аналитику, собираемую для вас. 

<img align="center" width="650" src="https://habrastorage.org/files/4ba/e72/bde/4bae72bde5a6402e861536d90f4493ab.png"/>
Статистика по количеству пользователей и сессий, уверен, понятна всем. Давайте начнем с UserPath

<img align="center" width="650" src="https://habrastorage.org/files/5de/5ce/e97/5de5cee976764dbe8c1699db4dd6dc5f.png"/>
Это граф переходов между вашими страницами. Какие выводы можно из него сделать, которые нельзя сделать, посмотрев код и потыкав в приложение самому? Тут собраны те переходы, которые пользователи действительно использовали, а не все возможные. Статистика агрегирована по всем пользователям, и можно указать дополнительный фильтр для разных версий приложения.

Куда более интересна статистика по количеству активностей (открытия страниц).

<img align="center" width="650" src="https://habrastorage.org/files/e1e/71c/ccb/e1e71cccbd0c4580a48243618f7f58f7.png"/>
Также интересно посмотреть последние события 

<img align="center" width="650" src="https://habrastorage.org/files/9a0/d09/ae6/9a0d09ae644d430693ff354734d1ce71.png"/>
С собираемыми данными более-менее разобрались, давайте теперь перейдем к сегментации и нотификации пользователей.

<h5><b>Engage/Reach</b></h5>
Прежде чем начинать спамить пользователей, было бы хорошо подумать <a href="https://azure.microsoft.com/en-us/documentation/articles/mobile-engagement-define-your-mobile-engagement-strategy/">над стратегией</a>, над вашими kpi и т.п., чтобы не вызвать у пользователей лютую ненависть. 

Затем уже можно идти на портал и <a href="https://azure.microsoft.com/en-us/documentation/articles/mobile-engagement-user-interface-segments/">выбрать из всех пользователей вашего приложения сегменты </a>пользователей по одному вам известному способу.

Создаем новый сегмент:

<img align="center" width="650" src="https://habrastorage.org/files/26e/2e1/ace/26e2e1ace755457aa57f64c84aaf57bf.png"/>
И затем, шаг за шагом, выбираем критерии отбора пользователей. Этих критериев может быть много, но начнем с самого очевидного и общего - с пользовательских сессий. 

<img align="center" src="https://habrastorage.org/files/2c1/483/339/2c14833393b9408cba69bd32b65d4052.png"/>
<spoiler title="Выбираем сессии за последние несколько дней.">

<img align="center" src="https://habrastorage.org/files/9fc/843/f8d/9fc843f8dc8842a0b5d40124e4e589a1.png"/></spoiler>
<spoiler title="У которых было хотя бы 2 разных операции (не просто открыл-закрыл случайно…а что-то сделал.)">

<img align="center" src="https://habrastorage.org/files/edb/d66/58c/edbd6658ca414dcb9af6834d94963b87.png"/></spoiler>
<spoiler title="И длительность сессии более n секунд (опять же фильтруем случайные открытия).">

<img align="center" src="https://habrastorage.org/files/173/987/4d4/1739874d47194d82be19a41c69f307c8.png"/></spoiler>
<spoiler title="Сохраняем">

<img align="center" src="https://habrastorage.org/files/bba/22d/e2d/bba22de2d53741deb761f525c4604c2c.png"/></spoiler>
Мы создали наш первый сегмент. К сожалению, не все процессы в Mobile Engagement проходят в real time и нам придется подождать, прежде чем мы узнаем, сколько пользователей попадают под наши условия. А ждать придется до 24 часов. Согласен, что не самый интерактивный способ поэтому предлагаю проголосовать за эту <a href="https://feedback.azure.com/forums/285737-mobile-engagement/suggestions/12868080-caculate-aggregates-statistics-every-6h-or-less">идею</a> на user voice 

<b>После того, как мы посмотрели на сегменты, можно уже и рассылкой заниматься.</b>

<h3>Reach/Engage</h3>
<spoiler title="Давайте теперь создавать маркетинговую компанию на основе нотификаций:">

<img align="center" width="650" src="https://habrastorage.org/files/2ea/49c/c26/2ea49cc2622644dd990ead579f13292e.png"/></spoiler>
<spoiler title="Создаем компанию, указываем текст нотификации и выбираем кому будем отправлять:">

<img align="center" width="650" src="https://habrastorage.org/files/6ec/474/4cd/6ec4744cd81a42128b96daf5da656fc7.png"/></spoiler>
Тут мы выбрали, что мы только сделаем нотификацию с текстом Hello World.
Затем мы выбираем кому мы отправляем. Если же мы нажмем кнопку simulate, мы узнаем сколько юзеров попало под эту выборку

<img align="center" width="650" src="https://habrastorage.org/files/470/53d/a57/47053da57e7d4076952cedb409e093e3.png"/>
<spoiler title="Чтобы не спамить всех бесконечно, можно указать время действия компании.">

<img align="center" width="650" src="https://habrastorage.org/files/5ee/346/d4d/5ee346d4d47943398d9f6c6e19337945.png"/></spoiler>
Как только компания создана и запущена, можно посмотреть, сколько нотификаций было доставлено, сколько просмотрено и т.п.

<img align="center" width="650" src="https://habrastorage.org/files/9ef/f17/7a0/9eff177a04504414940641195a950ec7.png"/>
Какие еще способы взаимодействия с пользователем у Вас есть?

<ul>
	<li>Вы можете показать ему опросник…</li>
	<li>Вы можете со стороны сервера отправить на клиент данные (push data)
<img width="650" align="center" src="https://habrastorage.org/files/867/c9e/585/867c9e5853d947a981bf56df7f2a6dcd.png"/>
</li></ul>
<h3>Цены</h3>
Как и любой сервис, mobile engagement имеет <a href="https://azure.microsoft.com/en-us/pricing/details/mobile-engagement/">цену </a>

<img align="center" width="650" src="https://habrastorage.org/files/fe3/8d2/fe1/fe38d2fe17da4d3ea79f3728063f2e59.png"/>
Оплата по активным пользователям в месяц. Активный пользователь - пользователь открывавший ваше приложение хотя бы раз за месяц.

<h3>Summary</h3>
Используя Azure Mobile Engagement, вы можете собирать данные о ваших пользователях и отправлять им нотификации в рамках ваших маркетинговых компаний. Сервис может быть использован во всех популярных мобильных платформах. Этим вы оптимизируете “счастье пользователя”, ну, и толщину слоя масла на вашем бутерброде.