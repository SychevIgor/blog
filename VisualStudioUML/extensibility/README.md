Для .net разработчиков не секрет что существует Visual Studio, а в ней есть Architecture Modeling. С помощью этого инструмента отлично получается создавать диаграммы, визуализировать мысли, можно даже код сгенерировать. <b>Для нас было важно связать то, что было "намоделировано" с реальным миром и данными.</b> Как вы понимаете, модель в вакууме разработчикам не очень интересна.
 
Мы решили немного <b>расширить описание модели</b>, чтобы иметь возможность из неё <b>сгенерировать артефакт</b>ы, которые можно использовать вне Modeling Project. В нашем случае это были <b>XSD схемы</b>, которые описывают модели (контракты методов API). Можно было и WSDL генерировать, можно Java/C# классы, но мы остановились на xsd.

Чтобы лучше понять, как это делать, на мой взгляд, лучше всего изучить, как происходит код генерация на C#. А Уже затем сделать по образу и подобию. Вооружившись поисковиком на ваш вкус, можно найти статьи на эту тему, однако я попробую пересказать просто-кратко-как сам понял.
<habracut/>

<h4>Visual Studio SDK</h4>
Чтобы писать расширения для uml нужно 2 компонента:
<ul>
<li>Microsoft Visual Studio * SDK  . <a href="http://www.microsoft.com/en-us/download/details.aspx?id=30668 ">Microsoft Visual Studio 2012 SDK </a> </li>
<li>Microsoft Visual Studio *  Visualization & Modeling SDK. <a href="https://www.microsoft.com/en-us/download/details.aspx?id=30680 ">Microsoft Visual Studio 2012 Visualization & Modeling SDK</a> </li>
</ul>

<h4>Visual Studio UML "API"</h4>
Все типы диаграмм, которые можно строить в Visual Studio, предоставляют свои объекты через унифицированные интерфейсы.
Набор их таков:
<ul>
<li>Microsoft.VisualStudio.Uml.Classes.<b>IClass</b></li>
<li>Microsoft.VisualStudio.Uml.Classes.<b>IDependency</b></li>
<li>Microsoft.VisualStudio.Uml.Classes.<b>IEnumeration</b></li>
<li>Microsoft.VisualStudio.Uml.Classes.<b>IInterface</b></li>
<li>Microsoft.VisualStudio.Uml.Classes.<b>IOperation</b></li>
<li>Microsoft.VisualStudio.Uml.Classes.<b>IPackage</b></li>
<li>Microsoft.VisualStudio.Uml.Classes.<b>IPackageImport</b></li>
<li>Microsoft.VisualStudio.Uml.Classes.<b>IProperty</b></li>
</ul>

Я думаю, что из их названий примерно понятно что это. Для диаграммы классов этот список map'ится прям один в один, а, например, для диаграммы компонентов сам  компонент будет представлен как IClass, его интерфейсы - как IProperties и т.д. Смысл в том, что интерфейсы единообразны для разных типов моделей. Это хорошо, т.к. можно одинаково работать с разными типами диаграмм, но нас будут интересовать диаграммы классов.

<h4>Profile</h4>
Существует C#-profile, частный случай profile. В нем описано в виде xml, какие объекты какими метаданными на диаграмме могут быть описаны/расширены.  
Пример: в UML модели Visual Studio существует диаграмма классов, в ней есть классы: их можно получить через интерфейс Microsoft.VisualStudio.Uml.Classes.IClass. В C# этому интерфейсу можно сопоставить и class, и struct. На uml диаграмме мы можем выбрать (указав C#-profile) будем ли мы считать UML_Class эквивалентным C# class или C# struct. 
Сам C#-profile можно найти в папке  <b>C:\Program Files (x86)\Microsoft Visual Studio 11.0\Common7\IDE\Extensions\Microsoft\Architecture Tools\UmlProfiles </b>
На него лучше посмотреть своими глазами - он не такой уж большой (строк 400).

Profile состоит из 3 секций: 
<ul>
<li><b>Stereotypes</b>. Простым языком, это то метаописание, которое можно закрепить за элементом UML модели. Например, class или атрибут класса.</li>
<li><b>Metaclasses </b>- это то, какому интерфейсу из Microsoft.VisualStudio.Uml.Classes.* соответсвует  стереотип. К примеру, C# struct/class соответсвуеют IClass, а IPackage соотвествует namespace в C#. </li>
<li><b>propertyTypes </b>- какими типами представлено (строки, булевские значение и тп.)</li>
</ul>

<h4>Как работает генератор C# кода из UML.</h4>
На UML диаграмме рисуются создаются (ибо мы архитекторы, а не просто быдлокодеры) модели. Во всей диаграмме допускается использование определенного набора profiles, в частности C# profile. Затем у модели можно выбрать, какой stereotype из profile использовать. Потом можно задать к stereotype его свойства: например, у C# видимость класса (public/protected/private etc). 
Разметку закончили. 

К Visual Studio написано расширение (extension), которое добавляет кнопку "Generate Code".
Мы можем  написать свои обработчики кнопок:
<ul>
<li><a href="http://msdn.microsoft.com/en-us/library/ee329481.aspx ">Как написать кнопку в menu uml diagram </a></li>
<li><a href="http://msdn.microsoft.com/en-us/library/ee329484.aspx ">Как написать расширение visual studio</a> </li>
</ul>

Жмем кнопку, вызывается прикладной код расширения и он уже генерирует код. 
Внутри происходит следующее:
<ul>
<li>Из папки берутся C# t4 template <b>C:\Program Files (x86)\Microsoft Visual Studio 11.0\Common7\IDE\Extensions\Microsoft\Architecture Tools\Extensibility\Templates\Text</b></li>
<li> На основе них генерируется код. Сам C# template, в целом, имеет понятную и тривиальную структуру: отрендерить все поля класса, все методы, атрибуты каждого метода. В общем, совсем не rocket science. Можно почитать этот код и суть вы уливите быстро. Сам шаблон - это C# код процентов на 80%, на оставшиеся 20% - тексты шаблонов. </li>
</ul>

<h4>Генерация XSD из схемы.</h4>
Что нам нужно чтобы схожим образом сгенерировать xsd схемы.
<ul>
<li>Создать Xsd.profile.<spoiler title="Пример XSD.profile"> <img src="http://habrastorage.org/getpro/habr/post_images/d01/7a3/17d/d017a317d42d92659304b11b6b57ab41.jpg"/></spoiler>
<a href="http://msdn.microsoft.com/en-us/library/dd465143.aspx">Пример создания profile</a>, <a href="http://msdn.microsoft.com/en-us/library/dd465156.aspx">Кастомизация profile</a>, <a href="http://msdn.microsoft.com/en-us/library/dd465146.aspx">Описание содержимого profile</a> </li>
<li><spoiler title="Создать vsix расширение к Visual Studio."> <img src="http://habrastorage.org/getpro/habr/post_images/542/cd7/c26/542cd7c26f7868397e723af17c1054b9.jpg"/></spoiler>
</li>
<li>В Visual studio в UML модели привязать profile к диаграмме</li>
<li><spoiler title="Классам сопоставить stereotypes из profile."><img src="http://habrastorage.org/getpro/habr/post_images/694/0cc/cca/6940cccca1f3c4afaa33c9b95d9ba007.jpg"/></spoiler>
</li>
<li>Создать расширение Visual Studio, которое  отобразит кнопку “compile xsd schema” <img src="http://habrastorage.org/getpro/habr/post_images/cb8/eed/07d/cb8eed07dd10957098fccffe49c49ab6.jpg"/>
Здесь нужно чуть по подробнее остановиться, тк есть не всем известные атрибуты.
<b>Export</b>- этот атрибут из MEF(Management Extensibility Framework). Он используется Visual Studio- как механизм загрузки и использования расширений. До версии vs2012 это MEF1. Не повторяйте мою ошибку с попыткой использовать последнюю версию- MEF2 ибо не заработает.VS видят на классе атрибут Export регистрирует класс в себе.

Атрибут <b>ClassDesignerExtension</b>- этот атрибут один из комплекта атрибутов, по которым Visual Studio определяет на каких типах диаграмм это расширение можно использовать. Другие варианты ComponentDesignerExtension и тп. Этих атрибутов можно поставить и больше, но мне было достаточно одного.

<b>Import </b>на свойстве DiagramContext - Он говорит Visual Studio что это свойство нужно инициализировать из MEF контейнера. Есть Dependency Injection через конструктор, а это  DI через свойства.

Остальной код- тривиален: получить все элементы IClass, сгруппировать их по IPackage.Name и далее для каждого пакета- вывести в файл. 
</li>
<li>Установить это расширение. </li>
<li><spoiler title="Написать обработчик, который по нажатии на кнопку сгенерирует xsd схемы. Нажать на кнопку Compile XSD (Название не принципиально)"><img src="http://habrastorage.org/getpro/habr/post_images/12a/a86/aa1/12aa86aa1843bc4205fc0f0f6acf8b0d.jpg"/></spoiler>(Можно на t4 это сделать, но самый простой прототип проще получить конкатенацией строк, хотя t4, безусловно, правильнее.)</li>
<li><spoiler title="В итоге должно получиться примерно так:"><img src="http://habrastorage.org/getpro/habr/post_images/59f/974/69b/59f97469b9fc771b2244f33ff58abf64.jpg"/>
<img src="http://habrastorage.org/getpro/habr/post_images/7c1/ecd/26b/7c1ecd26b85d01304b7c5956a88bc558.jpg"/></spoiler></li>
</li>
</ul>

P.S. У меня не было задачи сделать полную генерацию XSD схему- задача была показать как это делается в принципе.
Пример на <a href="https://github.com/SychevIgor/blog/tree/master/VisualStudioUML/extensibility">github</a>
