Это продолжение серии статей, первую из которых я опубликовал вчера <a href="http://habrahabr.ru/blogs/open_source/100379/">тут</a>. В ней я продолжу рассказ о библиотеках структур данных и алгоритмов, которые были найдены и изучены мной на codeplex и googlecode. Третья статья серии <a href="http://habrahabr.ru/blogs/algorithm/101820/">тут</a>.
В первой части говорилось о 
<ul>
<li><a href="http://numerical.codeplex.com/">Numerical Methods on C#</a></li>
<li><a href="http://silverlightnumeric.codeplex.com/">Numerical Methods on Silverlight</a></li>
<li><a href="http://npack.codeplex.com/">Npack</a></li>
<li><a href="http://smartmathlibrary.codeplex.com/">SmartMathLibrary</a></li>
<li><a href="http://dynaprecision.codeplex.com/">DynaPrecision</a></li>
</ul>
Так же в первой части я высказал свое мнение по поводу некоторых минусов проектов, которые я нашел.
Во второй же будет говориться о 
<ul>
<li><a href="http://mathnetnumerics.codeplex.com/">Math.NET Numerics </a></li>
<li><a href="http://code.google.com/p/ngenerics/">NGenerics</a></li>
<li><a href="http://alglib.codeplex.com/">Alglib</a></li>
</ul>
И совсем кратко упомянуто будет о <ul>
<li>
<a href="http://dotrandom.svn.sourceforge.net/viewvc/dotrandom/">DotRandom</a>
</li>
<li>
<a  href="http://freemath.cvs.sourceforge.net/viewvc/freemath/FreeMath/">FreeMath</a>
</li>
<li>
<a href="http://yacascs.svn.sourceforge.net/viewvc/yacascs/">Yacascs</a> 
</li>	
</ul>
Так же закончу свои мысли поводу opensorce библиотеках, и плавно перейду к 3 части, где уже совсем не opensorce, а закрытые решения.
<habracut/>

<h4>Math.NET Numerics </h4>
Как говорится на главной странице проекта: "проект является объединением двух других проектов <a href="http://dnanalytics.codeplex.com/">dnAnalyticsa> и <a href="http://www.mathdotnet.com/Iridium.aspx" >Math.NET Iridium</a>
В итоговой версии библиотеки входит следующий функционал:
Обертки над библиотеками <a href="http://software.intel.com/en-us/intel-mkl/">Intel Math Kernel Library</a>(в нее входят наверное все мат функции которые я только знаю: BLAS, LAPACK, ScaLAPACK, Sparse Solvers, Fast Fourier Transforms, Vector Math и тп. Про нее нам рассказывали, что существует десяток команд, которые специализируются на какой либо одной части и соревнуются с этой библиотекой в производительности и оптимизации под архитектуру.), обертка над <a href="http://math-atlas.sourceforge.net/">Atlas</a>(Есть множество реализаций этой библиотеки.  (Automatically Tuned Linear Algebra Software) - библиотека, позволяющая автоматически генерировать и оптимизировать численное программное обеспечение для процессоров с многоуровневой организацией памяти и конвейерными функциональными устройствами. Базируется на BLAS(с)). Это одна из самых интересных частей библиотеки, да и вообще всех других библиотек. Рекламировать MKL не буду- это вотчина Intel, но кратко скажу, что многие люди, занимающиеся параллельными вычислениями на ВМК  ННГУ ее используют, так же про нее любит рассказывать ребята из Санкт-Петербурга.  Это, что касается нативного кода.
Основной часть библиотеки, исходный код которой я видел составляет именно Управляемый код на C# и F#.
В проекте присутствуют традиционные уже функции связанные с Численным интегрированием, Интерполяцией, генераторы случайных чисел различные, Статистика, Линейная алгебра, появилась тригонометрия (все возможные эллиптические функции и прочее с ними связанное). Свои наборы сортировок и тп. Есть даже полный набор констант из математики и ядерной физики, значения логарифмов некоторых
В общем стандартный "джентльменский" набор математиков.
Этот проект хорошо покрыт тестами, даже более чем прилично.
Есть очень даже не плохая документация на веб сайте проекта:
<img src="http://s59.radikal.ru/i165/1008/85/69574349ab3b.jpg" alt="image"/>
<img src="http://s61.radikal.ru/i171/1008/c9/022664696b31.jpg" alt="image"/>

Проект живой, происходит активное обсуждение на форуме на <a href="http://mathnetnumerics.codeplex.com/Thread/List.aspx">Codeplex</a>
Единственное, что мне не нравится, что есть очень много функций с пустыми заглушками. Но с учетом, что я даже не представляю себе, что должны делать эти функции (не хватает  опыта и мат подготовки что бы понять), то для меня это не особо важно. Желаю успеха этому хорошему проекту.

<h4>NGenerics</h4>
Этот проект не похож на все остальные. Не похож тем, что он сконцентрирован на структурах данных и операциях над ними, в то время как остальные проекты связаны именно с операциями. Как указано на главное странице проекта основная его задача: реализовать те структуры данных, которые отсутствуют в .net, но крайне важны и полезны при разработке.
В состав проекта входят только управляемый код, никаких оберток над нативными библиотеками.
Началась писаться эта библиотека, еще до появления .Net 4.0, во времена .Net 3.0- 3.5.
Библиотека предоставляет множество структур данных таких, как:
Графы, Матрицы, разряженные матрицы, разложение матриц на компоненты. Векторы 2d 3d, Деревья красно-черные, бинарные, сбалансированные. Очереди с приоритетами, циклические очереди. Такие структуры как Bag и Heap, PascalSet

Кроме самих структур данных, существует множество операций над этими данными. Поиск по деревьям, умножение матриц, алгоритмы на графах. Что-то есть по параллельной и асинхронной обработки. Сортировок целых 8 штук. Некоторые даже считают, что реализовывать все 8 не имеет смысла, хватило бы и меньшего числа.

Что приятно удивляет в этой библиотеке:
Хорошее покрытие тестами.
Хорошо структурирована. Наверное лучше всех из тех что я видел, хотя интерфейсы я бы все таки выделил в отдельные папки, что бы не засоряли вид.
К основным структурам данных сгенерированны диаграммы, на который даже без документации понятно, что там и зачем

<img src="http://i066.radikal.ru/1008/7f/4619efbe9515.jpg" alt="image"/>
Эта библиотека мне очень понравилась, при первой же возможности использую ее в свою целях.
<h4>Alglib</h4>
"Alglib- коллекция алгоритмов для решения проблем в области численного анализа и обработки данных. " Эта библиотека очень своеобразная.  Основная причина в том, что она многоязыковая т.е. существуют реализации всех алгоритмов включаемых в нее на 
С++, C#, VB. Писали ее русско говорящие разработчики, причем очень давно.
Библиотека содержит код по следующим направлениям:
<ul>
	<li>Решение обыкновенных дифференциальных уравнений</li>
	<li>Линейные уравнения</li>
	<li>Операции с матрицами и векторами</li>
	<li>Нахождение собственных значений и векторов</li>
	<li>Разреженные матрицы: итеративные алгоритмы</li>
	<li>Численное интегрирование</li>
	<li>Интерполяция, аппроксимация и численное дифференцирование</li>
	<li>Одномерная и многомерная оптимизация</li>
	<li>БПФ, свертка, корреляция</li>
	<li>Статистика: общие алгоритмы</li>
	<li>Проверка гипотез</li>
	<li>Классификация, регрессия, кластеризация, работа с данными</li>
</ul>
Кода много- это хорошо. Но навигация по коду просто адская головная боль для меня. Название 90% файлов ну совершенно не говорящие мне ничего. Скорее всего, я просто не достаточно много занимался компьютерной математикой, сплошные аббревиатуры мне не понятны. Если FFT я еще понимаю, что это быстрое преобразование Фурье, то что такое PSIF хоть убейте не понимаю,  не заглянув в код. Документация есть на сайте и в коде. Она достаточна полная, что бы в код по 100 раз лазить не пришлось. Код документирован, в каждой функции есть довольно серьезное описание, что она делает. На пример

  /*************************************************************************
        Matrix norm estimation

        The algorithm estimates the 1-norm of square matrix A  on  the  assumption
        that the multiplication of matrix  A  by  the  vector  is  available  (the
        iterative method is used). It is recommended to use this algorithm  if  it
        is hard  to  calculate  matrix  elements  explicitly  (for  example,  when
        estimating the inverse matrix norm).

        The algorithm uses back communication for multiplying the  vector  by  the
        matrix.  If  KASE=0  after  returning from a subroutine, its execution was
        completed successfully, otherwise it is required to multiply the  returned
        vector by matrix A and call the subroutine again.

        The DemoIterativeEstimateNorm subroutine shows a simple example.

        Parameters:
            N       -   size of matrix A.
            V       -   vector.   It is initialized by the subroutine on the first
                        call. It is then passed into it on repeated calls.
            X       -   if KASE<>0, it contains the vector to be replaced by:
                            A * X,      if KASE=1
                            A^T * X,    if KASE=2
                        Array whose index ranges within [1..N].
            ISGN    -   vector. It is initialized by the subroutine on  the  first
                        call. It is then passed into it on repeated calls.
            EST     -   if KASE=0, it contains the lower boundary of the matrix
                        norm estimate.
            KASE    -   on the first call, it should be equal to 0. After the last
                        return, it is equal to 0 (EST contains the  matrix  norm),
                        on intermediate returns it can be equal to 1 or 2 depending
                        on the operation to be performed on vector X.

          -- LAPACK auxiliary routine (version 3.0) --
             Univ. of Tennessee, Univ. of California Berkeley, NAG Ltd.,
             Courant Institute, Argonne National Lab, and Rice University
             February 29, 1992
        *************************************************************************/

Из минусов - Нет как таковых проектных файлов. Есть только Голые исходники. Файлы с расширением *.cs. Из рекомендации по использованию – “просто добавьте файлы библиотеки в ваш проект.” Честно говоря не хотелось бы код из под gpl включать в свой проект, лицензионные соглашения все таки надо соблюдать, не смотря на то, что мы в России. Уж лучше сделать отдельный солюшен, который бы динамически линковался=> а почему это не сделали авторы библиотеки - не понятно. Понятно, что можно без труда просто выдрать самому нужные файлы и их вызывать, но честно говоря хотелось бы именно библиотеку, а не набор файлов.

По части самого кода остаются еще большие непонятности. Судя по виду кода на C#, он был получен методом прямой конвертации синтаксических конструкций с С++ со всеми вытакающими приятностями.
Повсюду параметры передаются по ссылке. Именование переменных совсем не говорящее.

<blockquote><code><font size="2" face="Courier New" color="black"><ol><li> <font color="#0000ff">else</font></li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color="#008000">//</font></li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color="#008000">// General case: no multicollinearity</font></li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color="#008000">//</font></li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tm = <font color="#0000ff">new</font> <font color="#0000ff">double</font>[nvars-1+1, nvars-1+1];</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;a = <font color="#0000ff">new</font> <font color="#0000ff">double</font>[nvars-1+1, nvars-1+1];</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blas.matrixmatrixmultiply(<font color="#0000ff">ref</font> sw, 0, nvars-1, 0, nvars-1, <font color="#0000ff">false</font>, <font color="#0000ff">ref</font> z, 0, nvars-1, 0, nvars-1, <font color="#0000ff">false</font>, 1.0, <font color="#0000ff">ref</font> tm, 0, nvars-1, 0, nvars-1, 0.0, <font color="#0000ff">ref</font> work);</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blas.matrixmatrixmultiply(<font color="#0000ff">ref</font> z, 0, nvars-1, 0, nvars-1, <font color="#0000ff">true</font>, <font color="#0000ff">ref</font> tm, 0, nvars-1, 0, nvars-1, <font color="#0000ff">false</font>, 1.0, <font color="#0000ff">ref</font> a, 0, nvars-1, 0, nvars-1, 0.0, <font color="#0000ff">ref</font> work);</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color="#0000ff">for</font>(i=0; i&#60;=nvars-1; i++)</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color="#0000ff">for</font>(j=0; j&#60;=nvars-1; j++)</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;a[i,j] = a[i,j]/<font color="#2B91AF">Math</font>.Sqrt(d[i]*d[j]);</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color="#0000ff">if</font>( !evd.smatrixevd(a, nvars, 1, <font color="#0000ff">true</font>, <font color="#0000ff">ref</font> d2, <font color="#0000ff">ref</font> z2) )</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;info = -4;</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color="#0000ff">return</font>;</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color="#0000ff">for</font>(k=0; k&#60;=nvars-1; k++)</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color="#0000ff">for</font>(i=0; i&#60;=nvars-1; i++)</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tf[i] = z2[i,k]/<font color="#2B91AF">Math</font>.Sqrt(d[i]);</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color="#0000ff">for</font>(i=0; i&#60;=nvars-1; i++)</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;v = 0.0;</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color="#0000ff">for</font>(i_=0; i_&#60;=nvars-1;i_++)</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;v += z[i,i_]*tf[i_];</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;w[i,k] = v;</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</li></font></ol><font size="1" color="gray">* This source code was highlighted with <a href="http://virtser.net/blog/post/source-code-highlighter.aspx"><font size="1" color="gray">Source Code Highlighter</font></a>.</font></code></blockquote>

СОВСЕМ, СОВСЕМ КОРОТКО
<h4>DotRandom</h4>
Как видно из названия - библиотека для генерации и получения случайных чисел.
Я не знаю, что по ней можно написать, кроме того, что она - документирована, легковесна. 
Но по-моему любая уважающая себя библиотеке и меть страничку wiki. Запросом в пару известных поисковиков dotrandom я не смог найти официальной страницы. В общем если на нее случайно не наткнуться на sourceforge- то можно подумать, что такого проекта и не существует.

<h4>Yacascs</h4>
Это порт с Java,C++,Lisp довольно известной в узких кругах библиотеки<a href="http://yacas.sourceforge.net/homepage.html"> yacas</a>. Честно говоря смутно понимаю, как ее и зачем использовать, но для полноты представления решил процитировать  официальный сайт:
"Yacas (Yet Another Computer Algebra System, Еще Одна Система Компьютерной Алгебры) - это маленькая и очень гибкая система компьютерной алгебры общего назначения и язык программирования. Язык имеет знакомый Си-подобный инфиксно-операторный синтаксис. Дистрибутив содержит небольшую библиотеку математических функций, но ее настоящая мощь в языке, на котором вы можете легко писать ваши собственные алгоритмы символьных манипуляций. Ядро поддерживает арифметику с произвольной точностью (для более быстрых вычислений оно может быть по выбору слинковано с библиотекой математики с произвольной точностью GNU libgmp) и способно выполнять символьные манипуляции над различными математическими объектами, следуя определенным пользователем правилам."<a href="http://www.uic.unn.ru/~zoav1/writings/yacas-intro.html">(c)</a>

<h4>Freemath</h4>
А это библиотека меня вообще поразила. Во-первых, у нее такое название, что по нему поисковики находят что угодно,  кроме нее. (Они бы еще Porno.Net назвали ее, что бы найти было проще.)
Есть только ссылка на sourceforge <a href="http://sourceforge.net/projects/freemath/">эта</a>. Что за проект, что умеет, для чего делался - не понятно. Документации нет. Тестов нет. NotImplementedExeption по всюду. 
Изучил  исходный код и совершенно не понял, какой функционал вкладывали в эту библиотеку. В общем: библиотека как бы есть, и как бы нет.

<b><h4>МЫСЛИ ПОСЛЕ ОКОНЧАНИЯ ИЗУЧЕНИЯ</h4></b>
Не люблю писать выводы- тк они должны следовать из постановки задачи и содержания статьи, а у меня далеко не все получилось вынести в текст статьи, что я хотел. А главное видеть код, который видел я своими глазами. 

1- с opensource дело обстоит довольно туго. Многие проекты не комитились давно. Некоторые правда просто были доведены до готовности, а не брошены.
2- очень многие проекты - это порты с Java. Это ни хорошо и ни плохо. Если есть, что то качественное - не надо придумывать велосипед. В прошлой статье, мне указали, что есть много мат библиотек на python, и я даже честно пообещал посмотреть и изучить, но ни одна из перечисленных мною библиотек, не является портом с python, наверное потому, что конвертация из java на много проще в виду схожести, а из python куда сложнее (частности нет привычного цикла for(;;) если лишь по сути foreach)
3- если авторы хотят, что бы их проект использовали другие разработчики, то почему:
Нельзя написать нормальные тесты?
Нельзя почитать нотации общепринятые?
Нельзя написать страничку документации или на худой конец хоть страничку wiki, что бы хоть знать что за проект и какие его цели?
Нельзя написать парочки обзорных статей на каких-нибудь ресурсах популярных, которые индексируют поисковики?
Без всего этого, как использовать ваш код!? Какая прибыть от алмазов, которые спрятаны на глубине 10000 километров или в другой галактике, если достичь мы можем максимум 12км!

Я не хочу сказать, что НЕ opensource безгрешен. Смотря на некоторые проекты, которые писал и я, и которые писались там, где я работаю, я тоже не вижу часто ни тестов, ни  документации. Но там, хотя бы внутренняя разработка и этого ни кто не видит, и пользоваться не будет. Но если ты выкладываешь исходные коды в  открытый доступ, то хотя бы о страничке проекта, можно позаботиться и минимальных тестах, которые бы внушили доверия другие девелоперов к твоему проекту. И ведь это - Научные наработки. В которых, ценится качество как нигде в других местах. Ни кто не станет доверять свою научную репутацию чужому коду, пусть и открытому но ничерта не понятному и не документированному.

3 часть будет выложена на следующий день, что бы не перегружать Уважаемого читателя информацией.