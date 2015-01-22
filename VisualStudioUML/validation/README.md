В компании существует множество сервисов, которые объединены в общий Service Layer. Написаны они на разных технологиях и платформах, но все эти сервисы изначально должны проектироваться архитекторами, которые предварительно придумывают API, а затем проверяют соответствие их проекта и реализованной архитектуры. 

Очевидно, что качество (понятность, единообразие, предсказуемость поведения и т.п.) зависит от опыта архитектора. Чем опытнее человек, тем больше у него обязанностей. Определив на бумаге (wiki) набор формальных правил для API, можно избавить проект (и самого архитектора) от части проблем, неточностей и неконсистентности.

Если API спроектирован в Visual Studio с помощью UML Сlass diagram, то можно добавить написанные на бумаге правила к валидации архитектуры в UML проекте.
<habracut>
<h4>Формулировка правил человеческим языком</h4>
Что первое приходит в голову  при фразе "правила проектирования API"? Лично мне –  не создавать классы всемогуторы (God Object), в которых сотни методов. 
<b>Правило 1</b>: не более N метод на класс. N выбрать под себя.
Второе: мне вспоминается Win API, где сотни параметров, большинство из которых в примерах, да и в коде null/0. 
<b>Правило 2</b>: не более M параметров у метода. M выбрать под себя.
Очепятки и копипаст
<b>Правило 3</b>: явно запрещаем повторение имен operations и attributes в рамках класса. 
<b>Правило 4</b>: не менее 2 символов на имя параметра, и не более 30.  Причина - меньше 2 не понятно что за параметр (У Google конечно есть q= в поиске, но это слабый аргумент), больше 30 – это уже перебор (мое субъективное мнение).
<b>Правило 5</b>: каждый метод  API должен возвращать значение, т.е. никаких void быть не должно. Коды возврата, состояние, созданный объект - как угодно, но "выстрелил и забыл" всё-таки не наш метод.
<b>Правило 6</b>: в классе с моделью API не должно быть никаких private/protected методов. Мы ведь не реализацией еще занимаемся, а архитектурой! Нам не надо так глубоко залезать, иначе за деревьями можно не увидеть леса. Детализировать можно бесконечно, но цель не в этом.

Правила для REST:
<b>Правило 7:</b> в имени метода должно быть имя глагола get/post/delete/put. (Можно спорить, говорить, что роутинг можно настроить или что это не важно. Однако, это вариант, который можно использовать.)
<b>Правило 8:</b> не использовать в именах методов запрещенный список глаголов. Иначе из REST у нас получится remote procedure call over http. 
Пример: предположим, что создан метод StartExecutionProcess. По названию заметно, что оно в концепцию REST как-то не очень укладывается.
В общем, такие правила можно придумывать бесконечно, можно обсуждать, спорить, бить в лицевую часть морды и так далее, поэтому остановимся на уже написанном списке. Переходим к реализации.

<h4>Visual Studio SDK</h4>
Чтобы писать расширения для uml нужно 2 компонента:
<ul>
<li>Microsoft Visual Studio * SDK  . <a href="http://www.microsoft.com/en-us/download/details.aspx?id=30668 ">Microsoft Visual Studio 2012 SDK </a> </li>
<li>Microsoft Visual Studio *  Visualization & Modeling SDK. <a href="https://www.microsoft.com/en-us/download/details.aspx?id=30680 ">Microsoft Visual Studio 2012 Visualization & Modeling SDK</a> </li>
</ul>

<h4>Информация для ознакомления</h4>
Информацию по нижеперечисленным ссылкам лучше прочесть, т.к. это описание объектов, из которых мы будем получать данные:
<ul>
	<li><a href="http://msdn.microsoft.com/en-us/library/dd323860.aspx">Properties of Types in UML Class Diagrams</a>  информация о типах</li>
	<li><a href="http://msdn.microsoft.com/en-us/library/dd323861.aspx">Properties of Attributes in UML Class Diagrams </a> информация о полях</li>
	<li><a href="http://msdn.microsoft.com/en-us/library/dd323859.aspx ">Properties of Operations in UML Class Diagrams </a> информация о методах</li>
	<li><a href="http://msdn.microsoft.com/en-us/library/ee329482.aspx">How to: Define Validation Constraints for UML Models</a>  как мы будем писать расширение.</li>
</ul>
Опциональные ссылки:
<ul>
	<li>Developing Models for Software Design http://msdn.microsoft.com/en-us/library/dd409436.aspx </li>
	<li>UML Class Diagrams: Reference http://msdn.microsoft.com/en-us/library/dd409437.aspx </li>
	<li>UML Class Diagrams: Guidelines http://msdn.microsoft.com/en-us/library/dd409416.aspx </li>
</ul>

<h4>План реализации</h4>
Шаги по реализации:
<ul>
	<li>Создаем проект расширения </li>
	<li>Создаем проект с кодом валидации</li>
	<li>Создаем проект, на котором будем тестировать валидацию</li>
</ul>

Начнем с конца.
<spoiler title="Создадим простой проект с набором  явных нарушений."><img src="http://habrastorage.org/getpro/habr/post_images/1cd/da4/252/1cdda4252d223ab61363d7fe887164ac.jpg"/></spoiler>
Класс с повторяющимися именами атрибутов, класс  с большим количеством методов. Класс с методом, у которого слишком много параметров, методы-классы с пробелами в именах.

<spoiler title="Создаем проект расширения для Visual Studio"><img src="http://habrastorage.org/getpro/habr/post_images/63d/234/130/63d234130a98ffb300f00f0125623df9.jpg"/></spoiler>
Прочесть можно либо в <a href="http://habrahabr.ru/post/211949/">прошлой статье</a>, либо по ссылке http://msdn.microsoft.com/en-us/library/ee329482.aspx в разделе Defining a Validation Extension
Должно получиться: 

<h4>Разбираем код валидации:</h4>

<spoiler title="Начнем с сигнатуры метода и его описания:"><img src="http://habrastorage.org/getpro/habr/post_images/6a4/165/c91/6a4165c91f61e6030f013672e14b1f33.jpg"/></spoiler>

Export-атрибут фактически определяет, что этот метод будет использоваться для валидации. Visual Studio по нему понимает, что параметры для метода, нужно получить из DI контейнера MEF.
ValidationMethod - это атрибут, который говорит, что этот метод используется для валидации и также дает информацию на какие действия он будет активирован потом (перечисляя Enum). 
<spoiler title="Тело метода:"><img src="http://habrastorage.org/getpro/habr/post_images/195/54a/b9d/19554ab9d7e9a4c3afaa0d4b40a1ac7e.jpg"/></spoiler>
Код написания простых правил тривиален. Получили список методов и проверили, что методов больше чем MaxMethodParametersInMethod (который равен 5).

<spoiler title="Проверка, что в методе API нет каких-либо методов логики, которые не видны."><img src="http://habrastorage.org/getpro/habr/post_images/24d/7a7/f86/24d7a7f8634ccdd6c07ef548bec3f091.jpg"/></spoiler>

Я думаю, что код объяснять излишне.

<h4>Что должно получится на выходе:</h4>
<spoiler title="Вариант 1"><img src="http://habrastorage.org/getpro/habr/post_images/5e2/dae/8e7/5e2dae8e7f140cf657b3b05917a6beb7.jpg"/></spoiler>
<spoiler title="Вариант 2 (Чуть сложнее)"><img src="http://habrastorage.org/getpro/habr/post_images/16f/6d8/ebb/16f6d8ebb9b6b02c27779957e937aa23.jpg"/></spoiler>

Все наши проверки отработали, и мы их видим: Warning, Errors. Правила писать конечно надо под конкретный проект, но уж сейчас Архитектор-Аналитик который будет писать совсем уж ерунду получит по рукам автоматически при попытке сохранить модель.


<h4>Текстовый формат модели</h4>
Кроме валидации модели, нам так же захотелось получить текстовый формат модели. 
Для этого пришлось в лоб обойти все классы модели, интерфейсы, методы и вывести в текстовый файл. <spoiler title="Это был самый простой способ."><img src="http://habrastorage.org/getpro/habr/post_images/608/27f/51c/60827f51c1ea84e2186b36301669235d.jpg"/></spoiler> 
 <spoiler title="Выбираем все компоненты"><img src="http://habrastorage.org/getpro/habr/post_images/07d/f5e/7fd/07df5e7fd3b9d8e4ab3fc2cd96725294.jpg"/></spoiler>
и  далее идем по всем методам интерфейса распечатывая их входные параметры и выходное значение. 
Единственной особенностью кода является необходимость проверить, какие из параметров находятся в одной коллекции объектов - parameters.

<spoiler title="И на выходе текстовый вывод"><img src="http://habrastorage.org/getpro/habr/post_images/6fd/e98/00a/6fde9800a1bc3f23914717635cc7a08a.jpg"/></spoiler>

Пример на <a href="https://github.com/SychevIgor/blog/tree/master/VisualStudioUML/validation">github </a>
