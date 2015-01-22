В Visual Studio UML Explorer реализована возможность запуска Generate Code, после этого будет сгенерирован C# код на основе UML описания. Нам захотелось сгенерировать java код, а не C#. 
C# и java достаточно близкие языки, чтобы не писать трансформацию uml-> java самому. (Среди того, что может быть сгенерировано из UML этих различий и того меньше.) Мы взяли готовые C# шаблоны и модифицировали их.
<habracut>
<h4>Способы генерации</h4>
Было в принципе 3 способа генерации:
<ul>
	<li><b>Сгенерировать код через WriteLine чисто в C#</b>, но это как-то некрасиво, ибо конкатенация.</li>
	<li>Второй вариант - это <b>написать на t4, и написать свою кнопку</b>, по которой произойдет генерация. Проблема в том, что t4 пришлось бы писать самим полностью, т.к. код готового шаблона завязан на определенные библиотеки, и как это правильно вызвать, чтобы не вылетало ошибок -  я так и не понял. </li>
	<li><b>Изменить t4 шаблон</b> для кодогенерации уже<b> существующей кнопкой</b> в visual studio.</li>
</ul>
В итоге мы остановились на последнем варианте, т.к. это наименее ресурсно затратный способ.

Поиск <a href="http://msdn.microsoft.com/en-us/library/ff657795(v=vs.110).aspx ">показал</a>, что изменить t4 шаблон при геренации не сложно. Нужно при первом нажатии generate code выставить пути к шаблонам.

<h4>Cписок модификаций  template</h4>
<ul>
	<li>Переименовали файла с CSharp* на Java, чтобы было очевидно.</li>
	<li>Убрали unsafe, partial, internal, protected-internal ключевые слова. Для этого аккуратно удалили все методы, которые содержат эти слова.</li>
	<li>Затем убрали подключаемые по умолчанию namespace типа system.linq - это бесполезно.</li>
	<li>Заменили sealed на final. </li>
	<li>Поправили расстановку границы namespace. Т.к. в C# - namespace {}, а в java - package.</li>
	<li>Изменили шаблон наследования с двоеточия на extends</li>
	<li>Убрали модификатор override  и заменили атрибутами.</li>
	<li>Заменили auto properties на тройку get_x,set_x,_x.</li>
</ul>
Для базовых вещей - этого должно хватить.

<h4>Распространение t4 шаблона</h4>
Теперь вопрос - как распространять наши t4 шаблоны, чтобы их можно было не только локально запускать, но и на любой другой машине не занимаясь копированием файлов руками.
Решение одно - создать расширение visual studio и вместе с ним ставить эти шаблоны.
Я долго искал информацию по теме "как правильно установить t4 шаблоны", но ничего лучшего не нашел, как просто скопировать эти шаблоны в assembly, а саму сборку использовать как MEF расширение к студии.
<a href="http://visualstudiomagazine.com/Articles/2009/05/01/Visual-Studios-T4-Code-Generation.aspx?Page=1">Вот </a>примерно к тем же выводам пришел человек, на несколько лет раньше меня.

<h4>Итог</h4>
<ul>
	<li><spoiler title="У нас есть t4 шаблоны для кодогенерации"><img src="http://habrastorage.org/getpro/habr/post_images/6df/180/9da/6df1809da38a411703c89393ce7bf276.jpg"/></spoiler></li>
	<li><spoiler title="Есть расширение Visual Studio для дистрибуции шаблонов. "><img src="http://habrastorage.org/getpro/habr/post_images/c50/5f5/e17/c505f5e1775273b3957084e5592daeae.jpg"/></spoiler></li>
	<li><spoiler title="Нажимаем на кнопку generate code"><img src="http://habrastorage.org/getpro/habr/post_images/716/18b/f29/71618bf292085fd25ba841bcd06e5eb3.jpg"/>
</spoiler></li>
	<li><spoiler title="Подставляем шаблоны по которым генерировать код"><img src="http://habrastorage.org/getpro/habr/post_images/a25/dae/061/a25dae061bd8e3897da1d87f86b42e32.jpg"/></spoiler></li>
	<li><spoiler title="и получаем из UML модели java интерфейсы."><img src="http://habrastorage.org/getpro/habr/post_images/99d/472/cd4/99d472cd47e66bcb6ca9695f6521809e.jpg"/>
</spoiler></li>
</ul>

Приятного прочтения.
Кому было интересно, есть еще несколько дней назад написанная статья про <a href="http://habrahabr.ru/post/211949/">Генерация XSD из UML</a>
Пример на <a href="https://github.com/SychevIgor/blog/tree/master/VisualStudioUML/javacodegeneration">github</a>
